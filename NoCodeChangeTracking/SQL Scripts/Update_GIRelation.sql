
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER TRIGGER Update_GIRelation
   ON GIRelation
   AFTER UPDATE
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
	WHERE [Name] = 'GI'

	SELECT @changeObjectSubTypeID = ChangeObjectSubTypeID
	FROM AKChangeObjectSubType
	WHERE [Name] = 'GIRelation'

	-- Initialize and fill key table for looping trigger rows

	DECLARE @loopKeys TABLE (
		CompanyID int,
		DesignID uniqueidentifier,
		LineNbr int
	)

	INSERT INTO @loopKeys (CompanyID, DesignID, LineNbr)
	SELECT CompanyID, DesignID, LineNbr FROM inserted

	DECLARE 
		@companyID int,
		@designID uniqueidentifier,
		@lineNbr int,
		@changeObjectID bigint,
		@jsonKey nvarchar(1000),
		@jsonObject nvarchar(max)

	-- Loop through trigger rows
	WHILE (EXISTS(SELECT 1 FROM @loopKeys))
	BEGIN
		-- Grab keys of a row
		SELECT TOP 1 
			@companyID = CompanyID,
			@designID = DesignID,
			@lineNbr = LineNbr
		FROM @loopKeys

		-- Build JSON key of current row
		SELECT @jsonKey = (
			SELECT CompanyID, DesignID, LineNbr
			FROM @loopKeys
			WHERE CompanyID = @companyID
				AND DesignID = @designID
				AND LineNbr = @lineNbr
			FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
		)

		-- Build JSON object for current row
		SELECT @jsonObject = (
			SELECT * 
			FROM inserted
			WHERE CompanyID = @companyID
				AND DesignID = @designID
				AND LineNbr = @lineNbr
			FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
		)

		-- Look for object in change tables
		SELECT @changeObjectID = ChangeObjectID
		FROM AKChangeObject 
		WHERE CompanyID = @companyID
			AND ChangeObjectTypeID = @changeObjectTypeID
			AND CAST(JSON_VALUE(KeyValues, '$.CompanyID') AS int) = @companyID
			AND CAST(JSON_VALUE(KeyValues, '$.DesignID') AS uniqueidentifier) = @designID
			AND CAST(JSON_VALUE(KeyValues, '$.LineNbr') AS int) = @lineNbr

		-- Insert object into change tracking
		EXEC AKTrackChange @jsonObject, @jsonKey, @companyID, @changeObjectTypeID, @changeObjectSubTypeID, @changeObjectID, 'U'

		-- Remove key of current row to continue looping
		DELETE FROM @loopKeys
		WHERE CompanyID = @companyID
			AND DesignID = @designID
			AND LineNbr = @lineNbr

	END

END

GO
