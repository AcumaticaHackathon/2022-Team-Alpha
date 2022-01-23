
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeObject')
BEGIN
	CREATE TABLE [dbo].[AKChangeObject](
		[CompanyID] [int] NOT NULL,
		[ChangeObjectID] [bigint] IDENTITY(1,1) NOT NULL,
		[KeyValues] [nvarchar](1000) NOT NULL,
		[ChangeObjectTypeID] [int] NOT NULL,
		[ChangeObjectSubTypeID] [int] NULL,
		CreatedDateTime datetime NOT NULL,
		LastModifiedDateTime datetime NOT NULL,
	 CONSTRAINT [PK_AKChangeObject] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[ChangeObjectID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

GO


-- Create foreign keys

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeObject')
BEGIN
	IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys 
					WHERE object_id = OBJECT_ID(N'FK_AKChangeObject_AKChangeObjectSubType')
					AND parent_object_id = OBJECT_ID(N'dbo.AKChangeObject'))
	BEGIN
		ALTER TABLE [dbo].[AKChangeObject]  WITH CHECK ADD  CONSTRAINT [FK_AKChangeObject_AKChangeObjectSubType] FOREIGN KEY([ChangeObjectSubTypeID])
		REFERENCES [dbo].[AKChangeObjectSubType] ([ChangeObjectSubTypeID])

		ALTER TABLE [dbo].[AKChangeObject] CHECK CONSTRAINT [FK_AKChangeObject_AKChangeObjectSubType]
	END
END

GO

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeObject')
BEGIN
	IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys 
					WHERE object_id = OBJECT_ID(N'FK_AKChangeObject_AKChangeObjectType')
					AND parent_object_id = OBJECT_ID(N'dbo.AKChangeObject'))
	BEGIN
		ALTER TABLE [dbo].[AKChangeObject]  WITH CHECK ADD  CONSTRAINT [FK_AKChangeObject_AKChangeObjectType] FOREIGN KEY([ChangeObjectTypeID])
		REFERENCES [dbo].[AKChangeObjectType] ([ChangeObjectTypeID])

		ALTER TABLE [dbo].[AKChangeObject] CHECK CONSTRAINT [FK_AKChangeObject_AKChangeObjectType]
	END
END

GO


-- Create indexes

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeObject')
BEGIN
	IF NOT EXISTS (SELECT 1 FROM sys.indexes 
					WHERE name='AK_AKChangeObject_ChangeObjectID' AND object_id = OBJECT_ID('dbo.AKChangeObject'))
	BEGIN
		CREATE UNIQUE NONCLUSTERED INDEX [AK_AKChangeObject_ChangeObjectID] ON [dbo].[AKChangeObject]
		(
			[ChangeObjectID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	END
END

GO