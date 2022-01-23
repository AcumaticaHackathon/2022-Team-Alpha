
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeVersion')
BEGIN
	CREATE TABLE [dbo].[AKChangeVersion](
		[CompanyID] [int] NOT NULL,
		[ChangeVersionID] [bigint] IDENTITY(1,1) NOT NULL,
		[ChangeObjectID] [bigint] NOT NULL,
		[LastVersion] [bigint] NOT NULL,
		CreatedDateTime datetime NOT NULL,
		LastModifiedDateTime datetime NOT NULL,
		ActionType char(1) NOT NULL,
	 CONSTRAINT [PK_AKChangeVersion] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[ChangeVersionID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

GO


-- Create foreign keys

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeVersion')
BEGIN
	IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys 
					WHERE object_id = OBJECT_ID(N'FK_AKChangeVersion_AKChangeObject')
					AND parent_object_id = OBJECT_ID(N'dbo.AKChangeVersion'))
	BEGIN
		ALTER TABLE [dbo].[AKChangeVersion]  WITH CHECK ADD  CONSTRAINT [FK_AKChangeVersion_AKChangeObject] FOREIGN KEY([CompanyID], [ChangeObjectID])
		REFERENCES [dbo].[AKChangeObject] ([CompanyID], [ChangeObjectID])

		ALTER TABLE [dbo].[AKChangeVersion] CHECK CONSTRAINT [FK_AKChangeVersion_AKChangeObject]
	END
END

GO


-- Create indexes

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeVersion')
BEGIN
	IF NOT EXISTS (SELECT 1 FROM sys.indexes 
					WHERE name='AK_AKChangeVersion_ChangeObjectID' AND object_id = OBJECT_ID('dbo.AKChangeVersion'))
	BEGIN
		CREATE UNIQUE NONCLUSTERED INDEX [AK_AKChangeVersion_ChangeObjectID] ON [dbo].[AKChangeVersion]
		(
			[CompanyID] ASC,
			[ChangeObjectID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	END
END

GO

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeVersion')
BEGIN
	IF NOT EXISTS (SELECT 1 FROM sys.indexes 
					WHERE name='AK_AKChangeVersion_ChangeVersionID' AND object_id = OBJECT_ID('dbo.AKChangeVersion'))
	BEGIN
		CREATE UNIQUE NONCLUSTERED INDEX [AK_AKChangeVersion_ChangeVersionID] ON [dbo].[AKChangeVersion]
		(
			[ChangeVersionID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	END
END

GO

