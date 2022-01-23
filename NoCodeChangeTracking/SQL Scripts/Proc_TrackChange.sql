SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE AKTrackChange
	@jsonObject nvarchar(MAX), 
	@jsonKey nvarchar(max), 
	@companyID int, 
	@changeObjectTypeID int, 
	@changeObjectSubTypeID int, 
	@changeObjectID bigint, 
	@actionType char(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE 
		@modifyDate datetime

	SELECT @modifyDate = GETDATE()

	-- If object doesn't exist yet, add it
	IF @changeObjectID IS NULL
	BEGIN
		INSERT INTO AKChangeObject (CompanyID, KeyValues, ChangeObjectTypeID, ChangeObjectSubTypeID, CreatedDateTime, LastModifiedDateTime)
		VALUES (@companyID, @jsonKey, @changeObjectTypeID, @changeObjectSubTypeID, @modifyDate, @modifyDate)
		
		SELECT @changeObjectID = @@IDENTITY
	END

	DECLARE 
		@lastVersion bigint,
		@nextVersion bigint

	BEGIN TRANSACTION

		-- Look for the last version of the object, locking the version until update
		SELECT @lastVersion = LastVersion
		FROM AKChangeVersion
		WITH (ROWLOCK)
		WHERE CompanyID = @companyID
			AND ChangeObjectID = @changeObjectID

		IF @lastVersion IS NULL
		BEGIN
			SELECT @lastVersion = 0

			INSERT INTO AKChangeVersion (CompanyID, ChangeObjectID, LastVersion, CreatedDateTime, LastModifiedDateTime)
			VALUES (@companyID, @changeObjectID, @lastVersion, @modifyDate, @modifyDate)
		END

		SELECT @nextVersion = @lastVersion + 1

		-- Create new version of object
		INSERT INTO AKChangeObjectVersion (CompanyID, ChangeObjectID, [Version], [ChangeObject], CreatedDateTime, LastModifiedDateTime, ActionType)
		VALUES (@companyID, @changeObjectID, @nextVersion, @jsonObject, @modifyDate, @modifyDate, @actionType)

		UPDATE AKChangeVersion SET
			LastVersion = @nextVersion,
			LastModifiedDateTime = @modifyDate
		WHERE CompanyID = @companyID
			AND ChangeObjectID = @changeObjectID

	-- Release row lock
	COMMIT TRANSACTION
END

GO
