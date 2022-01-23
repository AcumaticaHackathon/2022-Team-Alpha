
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'CSAttributeGroup_Orig')
BEGIN

	CREATE TABLE [dbo].[CSAttributeGroup_Orig](
		[CompanyID] [int] NOT NULL,
		[AttributeID] [nvarchar](10) NOT NULL,
		[EntityClassID] [nvarchar](30) NOT NULL,
		[EntityType] [nvarchar](100) NOT NULL,
		[SortOrder] [smallint] NULL,
		[tstamp] [timestamp] NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[DefaultValue] [nvarchar](255) NULL,
		[Required] [bit] NOT NULL,
		[IsActive] [bit] NOT NULL,
		[AttributeCategory] [char](1) NOT NULL,
	 CONSTRAINT [CSAttributeGroup_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[AttributeID] ASC,
		[EntityClassID] ASC,
		[EntityType] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'CSAttributeGroup_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM CSAttributeGroup_Orig)
	BEGIN
		INSERT INTO CSAttributeGroup_Orig (
			[CompanyID]
			,[AttributeID]
			,[EntityClassID]
			,[EntityType]
			,[SortOrder]
			,[CreatedByID]
			,[CreatedByScreenID]
			,[CreatedDateTime]
			,[LastModifiedByID]
			,[LastModifiedByScreenID]
			,[LastModifiedDateTime]
			,[DefaultValue]
			,[Required]
			,[IsActive]
			,[AttributeCategory]
		)
		SELECT [CompanyID]
			,[AttributeID]
			,[EntityClassID]
			,[EntityType]
			,[SortOrder]
			,[CreatedByID]
			,[CreatedByScreenID]
			,[CreatedDateTime]
			,[LastModifiedByID]
			,[LastModifiedByScreenID]
			,[LastModifiedDateTime]
			,[DefaultValue]
			,[Required]
			,[IsActive]
			,[AttributeCategory]
		  FROM [dbo].[CSAttributeGroup]

	END

END

GO