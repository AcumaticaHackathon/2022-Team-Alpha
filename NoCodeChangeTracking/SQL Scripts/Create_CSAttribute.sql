
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'CSAttribute_Orig')
BEGIN

	CREATE TABLE [dbo].[CSAttribute_Orig](
		[CompanyID] [int] NOT NULL,
		[AttributeID] [nvarchar](10) NOT NULL,
		[Description] [nvarchar](60) NOT NULL,
		[ControlType] [int] NOT NULL,
		[EntryMask] [varchar](60) NULL,
		[RegExp] [nvarchar](255) NULL,
		[List] [nvarchar](max) NULL,
		[IsInternal] [bit] NULL,
		[ContainsPersonalData] [bit] NOT NULL,
		[tstamp] [timestamp] NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
		[ObjectName] [nvarchar](512) NULL,
		[FieldName] [nvarchar](512) NULL,
	 CONSTRAINT [CSAttribute_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[AttributeID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'CSAttribute_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM CSAttribute_Orig)
	BEGIN
		INSERT INTO CSAttribute_Orig (
			  [CompanyID]
			  ,[AttributeID]
			  ,[Description]
			  ,[ControlType]
			  ,[EntryMask]
			  ,[RegExp]
			  ,[List]
			  ,[IsInternal]
			  ,[ContainsPersonalData]
			  ,[CreatedByID]
			  ,[CreatedByScreenID]
			  ,[CreatedDateTime]
			  ,[LastModifiedByID]
			  ,[LastModifiedByScreenID]
			  ,[LastModifiedDateTime]
			  ,[NoteID]
			  ,[ObjectName]
			  ,[FieldName]
		)
		SELECT [CompanyID]
			  ,[AttributeID]
			  ,[Description]
			  ,[ControlType]
			  ,[EntryMask]
			  ,[RegExp]
			  ,[List]
			  ,[IsInternal]
			  ,[ContainsPersonalData]
			  ,[CreatedByID]
			  ,[CreatedByScreenID]
			  ,[CreatedDateTime]
			  ,[LastModifiedByID]
			  ,[LastModifiedByScreenID]
			  ,[LastModifiedDateTime]
			  ,[NoteID]
			  ,[ObjectName]
			  ,[FieldName]
		  FROM [dbo].[CSAttribute]

	END

END

GO