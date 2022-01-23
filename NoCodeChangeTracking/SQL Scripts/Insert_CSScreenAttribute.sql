
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER TRIGGER Insert_CSScreenAttribute
   ON CSScreenAttribute
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE 
		@changeObjectTypeID int,
		@changeObjectSubTypeID int

	-- Look for type IDs

	SELECT @changeObjectTypeID = ChangeObjectTypeID 
	FROM AKChangeObjectType 
	WHERE [Name] = 'Attribute'

	SELECT @changeObjectSubTypeID = ChangeObjectSubTypeID
	FROM AKChangeObjectSubType
	WHERE [Name] = 'CSScreenAttribute'

	-- Initialize and fill key table for looping trigger rows

	DECLARE @loopKeys TABLE (
		CompanyID int,
		AttributeID nvarchar(10),
		ScreenID varchar(8),
		TypeValue nvarchar(60)
	)

	INSERT INTO @loopKeys (CompanyID, AttributeID, ScreenID, TypeValue)
	SELECT CompanyID, AttributeID, ScreenID, TypeValue FROM inserted

	DECLARE 
		@companyID int,
		@attributeID nvarchar(10),
		@screenID varchar(8),
		@typeValue nvarchar(60),
		@changeObjectID bigint,
		@jsonKey nvarchar(1000),
		@jsonObject nvarchar(max)

	-- Loop through trigger rows
	WHILE (EXISTS(SELECT 1 FROM @loopKeys))
	BEGIN
		-- Grab keys of a row
		SELECT TOP 1 
			@companyID = CompanyID,
			@attributeID = AttributeID,
			@screenID = ScreenID,
			@typeValue = TypeValue
		FROM @loopKeys

		-- Build JSON key of current row
		SELECT @jsonKey = (
			SELECT CompanyID, AttributeID, ScreenID, TypeValue
			FROM @loopKeys
			WHERE CompanyID = @companyID
				AND AttributeID = @attributeID
				AND ScreenID = @screenID
				AND TypeValue = @typeValue
			FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
		)

		-- Build JSON object for current row
		SELECT @jsonObject = (
			SELECT * 
			FROM inserted
			WHERE CompanyID = @companyID
				AND AttributeID = @attributeID
				AND ScreenID = @screenID
				AND TypeValue = @typeValue
			FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
		)

		-- Look for object in change tables
		SELECT @changeObjectID = ChangeObjectID
		FROM AKChangeObject 
		WHERE CompanyID = @companyID
			AND ChangeObjectTypeID = @changeObjectTypeID
			AND CAST(JSON_VALUE(KeyValues, '$.CompanyID') AS int) = @companyID
			AND CAST(JSON_VALUE(KeyValues, '$.AttributeID') AS nvarchar(10)) = @attributeID
			AND CAST(JSON_VALUE(KeyValues, '$.ScreenID') AS varchar(8)) = @screenID
			AND CAST(JSON_VALUE(KeyValues, '$.TypeValue') AS nvarchar(60)) = @typeValue

		-- Insert object into change tracking
		EXEC AKTrackChange @jsonObject, @jsonKey, @companyID, @changeObjectTypeID, @changeObjectSubTypeID, @changeObjectID, 'I'

		-- Remove key of current row to continue looping
		DELETE FROM @loopKeys
		WHERE CompanyID = @companyID
			AND AttributeID = @attributeID
			AND ScreenID = @screenID
			AND TypeValue = @typeValue

	END

END

GO
