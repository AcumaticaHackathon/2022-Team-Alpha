
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeObjectType')
BEGIN

	CREATE TABLE [dbo].[AKChangeObjectType](
		[ChangeObjectTypeID] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
		[Description] [nvarchar](255) NOT NULL,
	 CONSTRAINT [PK_AKChangeObjectType] PRIMARY KEY CLUSTERED 
	(
		[ChangeObjectTypeID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

GO


-- Insert default data
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeObjectType')
BEGIN

	IF NOT EXISTS (SELECT 1 FROM AKChangeObjectType)
	BEGIN
		INSERT INTO [dbo].[AKChangeObjectType]
				   ([Name]
				   ,[Description])
		SELECT 'Attribute', 'Generic logical attribute'
		UNION SELECT 'Report', 'Report engine reports'
		UNION SELECT 'Dashboard', 'Dashboards'
		UNION SELECT 'Sitemap', 'Sitemap'
		UNION SELECT 'WebHook', 'WebHook'
		UNION SELECT 'BusinessEvent', 'Business events'
		UNION SELECT 'Role', 'Business Roles'
		UNION SELECT 'Scenario', 'Import/Export scenarios'
		UNION SELECT 'GI', 'Generic inquiries'
	END
END

GO


-- Create indexes

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeObjectType')
BEGIN
	IF NOT EXISTS (SELECT 1 FROM sys.indexes 
					WHERE name='AK_AKChangeObjectType_Name' AND object_id = OBJECT_ID('dbo.AKChangeObjectType'))
	BEGIN
		CREATE UNIQUE NONCLUSTERED INDEX [AK_AKChangeObjectType_Name] ON [dbo].[AKChangeObjectType]
		(
			[Name] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	END
END

GO
