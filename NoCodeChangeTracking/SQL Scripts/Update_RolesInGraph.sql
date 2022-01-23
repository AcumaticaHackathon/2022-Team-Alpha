
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER TRIGGER Update_RolesInGraph
   ON RolesInGraph
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
	WHERE [Name] = 'Role'

	SELECT @changeObjectSubTypeID = ChangeObjectSubTypeID
	FROM AKChangeObjectSubType
	WHERE [Name] = 'RolesInGraph'

	-- Initialize and fill key table for looping trigger rows

	DECLARE @loopKeys TABLE (
		CompanyID int,
		RoleName nvarchar(64),
		ApplicationName varchar(32),
		ScreenID varchar(8)
	)

	INSERT INTO @loopKeys (CompanyID, RoleName, ApplicationName, ScreenID)
	SELECT CompanyID, RoleName, ApplicationName, ScreenID FROM inserted

	DECLARE 
		@companyID int,
		@roleName nvarchar(64),
		@applicationName varchar(32),
		@screenID varchar(8),
		@changeObjectID bigint,
		@jsonKey nvarchar(1000),
		@jsonObject nvarchar(max)

	-- Loop through trigger rows
	WHILE (EXISTS(SELECT 1 FROM @loopKeys))
	BEGIN
		-- Grab keys of a row
		SELECT TOP 1 
			@companyID = CompanyID,
			@roleName = RoleName,
			@applicationName = ApplicationName,
			@screenID = ScreenID
		FROM @loopKeys

		-- Build JSON key of current row
		SELECT @jsonKey = (
			SELECT CompanyID, RoleName, ApplicationName, ScreenID
			FROM @loopKeys
			WHERE CompanyID = @companyID
				AND RoleName = @roleName
				AND ApplicationName = @applicationName
				AND ScreenID = @screenID
			FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
		)

		-- Build JSON object for current row
		SELECT @jsonObject = (
			SELECT * 
			FROM inserted
			WHERE CompanyID = @companyID
				AND RoleName = @roleName
				AND ApplicationName = @applicationName
				AND ScreenID = @screenID
			FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
		)

		-- Look for object in change tables
		SELECT @changeObjectID = ChangeObjectID
		FROM AKChangeObject 
		WHERE CompanyID = @companyID
			AND ChangeObjectTypeID = @changeObjectTypeID
			AND CAST(JSON_VALUE(KeyValues, '$.CompanyID') AS int) = @companyID
			AND CAST(JSON_VALUE(KeyValues, '$.RoleName') AS nvarchar(64)) = @roleName
			AND CAST(JSON_VALUE(KeyValues, '$.ApplicationName') AS varchar(32)) = @applicationName
			AND CAST(JSON_VALUE(KeyValues, '$.ScreenID') AS varchar(8)) = @screenID

		-- Insert object into change tracking
		EXEC AKTrackChange @jsonObject, @jsonKey, @companyID, @changeObjectTypeID, @changeObjectSubTypeID, @changeObjectID, 'U'

		-- Remove key of current row to continue looping
		DELETE FROM @loopKeys
		WHERE CompanyID = @companyID
			AND RoleName = @roleName
			AND ApplicationName = @applicationName
			AND ScreenID = @screenID

	END

END

GO
