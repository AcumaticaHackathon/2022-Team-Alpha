
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeObjectSubType')
BEGIN
	CREATE TABLE [dbo].[AKChangeObjectSubType](
		[ChangeObjectSubTypeID] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
		[Description] [nvarchar](255) NOT NULL,
	 CONSTRAINT [PK_AKChangeObjectSubType] PRIMARY KEY CLUSTERED 
	(
		[ChangeObjectSubTypeID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

GO


-- Insert default data
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeObjectSubType')
BEGIN

	IF NOT EXISTS (SELECT 1 FROM AKChangeObjectSubType)
	BEGIN
		INSERT INTO [dbo].[AKChangeObjectSubType]
				   ([Name]
				   ,[Description])
		SELECT 'CSAttribute', 'Attribute Entity'
		UNION SELECT 'CSAttributeDetail', 'Attribute Detail Entity'
		UNION SELECT 'CSAttributeGroup', 'Attribute Group Entity'
		UNION SELECT 'CSScreenAttribute', 'Screen Attribute Entity'
		UNION SELECT 'Dashboard', 'Dashboard Entity'
		UNION SELECT 'Widget', 'Dashboard Widget Entity'
		UNION SELECT 'Dashboard Parameter', 'Dashboard Parameter Entity'
		UNION SELECT 'UserReport', 'Report Entity'
		UNION SELECT 'Sitemap', 'Sitemap Entity'
		UNION SELECT 'WebHook', 'WebHook Entity'
		UNION SELECT 'BPEvent', 'BPEvent Entity'
		UNION SELECT 'BPEventSchedule', 'BPEventSchedule Entity'
		UNION SELECT 'BPEventTriggerCondition', 'BPEventTriggerCondition Entity'
		UNION SELECT 'BPEventSubscriber', 'BPEventSubscriber Entity'
		UNION SELECT 'BPInquiryParameter', 'BPInquiryParameter Entity'
		UNION SELECT 'Roles', 'Roles Entity'
		UNION SELECT 'RolesInGraph', 'RolesInGraph Entity'
		UNION SELECT 'RolesInMember', 'RolesInMember Entity'
		UNION SELECT 'RolesInCache', 'RolesInCache Entity'
		UNION SELECT 'SYMapping', 'SYMapping Entity'
		UNION SELECT 'SYMappingCondition', 'SYMappingCondition Entity'
		UNION SELECT 'SYImportCondition', 'SYImportCondition Entity'
		UNION SELECT 'SYMappingField', 'SYMappingField Entity'
		UNION SELECT 'GIDesign', 'GIDesign Entity'
		UNION SELECT 'GIFilter', 'GIFilter Entity'
		UNION SELECT 'GIGroupBy', 'GIGroupBy Entity'
		UNION SELECT 'GIMassAction', 'GIMassAction Entity'
		UNION SELECT 'GIMassUpdateField', 'GIMassUpdateField Entity'
		UNION SELECT 'GINavigationScreen', 'GINavigationScreen Entity'
		UNION SELECT 'GINavigationParameter', 'GINavigationParameter Entity'
		UNION SELECT 'GINavigationCondition', 'GINavigationCondition Entity'
		UNION SELECT 'GIOn', 'GIOn Entity'
		UNION SELECT 'GIRecordDefault', 'GIRecordDefault Entity'
		UNION SELECT 'GIRelation', 'GIRelation Entity'
		UNION SELECT 'GIResult', 'GIResult Entity'
		UNION SELECT 'GISort', 'GISort Entity'
		UNION SELECT 'GITable', 'GITable Entity'
		UNION SELECT 'GIWhere', 'GIWhere Entity'
	END
END

GO


-- Create indexes

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AKChangeObjectSubType')
BEGIN
	IF NOT EXISTS (SELECT 1 FROM sys.indexes 
					WHERE name='AK_AKChangeObjectSubType_Name' AND object_id = OBJECT_ID('dbo.AKChangeObjectSubType'))
	BEGIN
		CREATE UNIQUE NONCLUSTERED INDEX [AK_AKChangeObjectSubType_Name] ON [dbo].[AKChangeObjectSubType]
		(
			[Name] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	END
END

GO
