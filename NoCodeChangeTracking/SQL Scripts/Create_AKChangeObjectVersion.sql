
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeObjectVersion')
BEGIN
	CREATE TABLE [dbo].[AKChangeObjectVersion](
		[CompanyID] [int] NOT NULL,
		[ChangeObjectVersionID] [bigint] IDENTITY(1,1) NOT NULL,
		[ChangeObjectID] [bigint] NOT NULL,
		[Version] [bigint] NOT NULL,
		[ChangeObject] [nvarchar](max) NOT NULL,
		CreatedDateTime datetime NOT NULL,
		LastModifiedDateTime datetime NOT NULL,
	 CONSTRAINT [PK_AKChangeObjectVersion] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[ChangeObjectVersionID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

GO


-- Create foreign keys

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeObjectVersion')
BEGIN
	IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys 
					WHERE object_id = OBJECT_ID(N'FK_AKChangeObjectVersion_AKChangeObject')
					AND parent_object_id = OBJECT_ID(N'dbo.AKChangeObjectVersion'))
	BEGIN
		ALTER TABLE [dbo].[AKChangeObjectVersion]  WITH CHECK ADD  CONSTRAINT [FK_AKChangeObjectVersion_AKChangeObject] FOREIGN KEY([CompanyID], [ChangeObjectID])
		REFERENCES [dbo].[AKChangeObject] ([CompanyID], [ChangeObjectID])

		ALTER TABLE [dbo].[AKChangeObjectVersion] CHECK CONSTRAINT [FK_AKChangeObjectVersion_AKChangeObject]
	END
END

GO


-- Create indexes

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeObjectVersion')
BEGIN
	IF NOT EXISTS (SELECT 1 FROM sys.indexes 
					WHERE name='AK_AKChangeObjectVersion_ChangeObjectVersionID' AND object_id = OBJECT_ID('dbo.AKChangeObjectVersion'))
	BEGIN
		CREATE UNIQUE NONCLUSTERED INDEX [AK_AKChangeObjectVersion_ChangeObjectVersionID] ON [dbo].[AKChangeObjectVersion]
		(
			[ChangeObjectVersionID] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	END
END

GO
