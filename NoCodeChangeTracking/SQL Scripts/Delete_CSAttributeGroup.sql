
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER TRIGGER Delete_CSAttributeGroup
   ON CSAttributeGroup
   AFTER DELETE
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
	WHERE [Name] = 'CSAttributeGroup'

	-- Initialize and fill key table for looping trigger rows

	DECLARE @loopKeys TABLE (
		CompanyID int,
		AttributeID nvarchar(10),
		EntityClassID nvarchar(30),
		EntityType nvarchar(100)
	)

	INSERT INTO @loopKeys (CompanyID, AttributeID, EntityClassID, EntityType)
	SELECT CompanyID, AttributeID, EntityClassID, EntityType FROM deleted

	DECLARE 
		@companyID int,
		@attributeID nvarchar(10),
		@entityClassID nvarchar(30),
		@entityType nvarchar(100),
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
			@entityClassID = EntityClassID,
			@entityType = EntityType
		FROM @loopKeys

		-- Build JSON key of current row
		SELECT @jsonKey = (
			SELECT CompanyID, AttributeID, EntityClassID, EntityType
			FROM @loopKeys
			WHERE CompanyID = @companyID
				AND AttributeID = @attributeID
				AND EntityClassID = @entityClassID
				AND EntityType = @entityType
			FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
		)

		-- Build JSON object for current row
		SELECT @jsonObject = (
			SELECT * 
			FROM deleted
			WHERE CompanyID = @companyID
				AND AttributeID = @attributeID
				AND EntityClassID = @entityClassID
				AND EntityType = @entityType
			FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
		)

		-- Look for object in change tables
		SELECT @changeObjectID = ChangeObjectID
		FROM AKChangeObject 
		WHERE CompanyID = @companyID
			AND ChangeObjectTypeID = @changeObjectTypeID
			AND CAST(JSON_VALUE(KeyValues, '$.CompanyID') AS int) = @companyID
			AND CAST(JSON_VALUE(KeyValues, '$.AttributeID') AS nvarchar(10)) = @attributeID
			AND CAST(JSON_VALUE(KeyValues, '$.EntityClassID') AS nvarchar(30)) = @entityClassID
			AND CAST(JSON_VALUE(KeyValues, '$.EntityType') AS nvarchar(100)) = @entityType

		-- Insert object into change tracking
		EXEC AKTrackChange @jsonObject, @jsonKey, @companyID, @changeObjectTypeID, @changeObjectSubTypeID, @changeObjectID, 'D'

		-- Remove key of current row to continue looping
		DELETE FROM @loopKeys
		WHERE CompanyID = @companyID
			AND AttributeID = @attributeID
			AND EntityClassID = @entityClassID
			AND EntityType = @entityType

	END

END

GO
