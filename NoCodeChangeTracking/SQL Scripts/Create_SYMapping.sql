
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SYMapping_Orig')
BEGIN

	CREATE TABLE [dbo].[SYMapping_Orig](
		[CompanyID] [int] NOT NULL,
		[MappingID] [uniqueidentifier] NOT NULL,
		[InverseMappingID] [uniqueidentifier] NULL,
		[Name] [nvarchar](128) NOT NULL,
		[IsActive] [bit] NOT NULL,
		[ScreenID] [char](8) NOT NULL,
		[MappingType] [char](1) NOT NULL,
		[GraphName] [varchar](128) NOT NULL,
		[ViewName] [varchar](128) NOT NULL,
		[GridViewName] [varchar](128) NULL,
		[ProviderID] [uniqueidentifier] NOT NULL,
		[ProviderObject] [nvarchar](128) NOT NULL,
		[SyncType] [char](1) NOT NULL,
		[Status] [char](1) NOT NULL,
		[FieldCntr] [smallint] NOT NULL,
		[FieldOrderCntr] [smallint] NOT NULL,
		[ImportConditionCntr] [smallint] NOT NULL,
		[ConditionCntr] [smallint] NOT NULL,
		[DataCntr] [int] NOT NULL,
		[NbrRecords] [int] NOT NULL,
		[PreparedOn] [datetime] NULL,
		[CompletedOn] [datetime] NULL,
		[ImportTimeStamp] [nvarchar](4000) NULL,
		[ExportTimeStamp] [datetime] NULL,
		[ExportTimeStampUtc] [datetime] NULL,
		[FormatLocale] [varchar](6) NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[tstamp] [timestamp] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
		[SitemapID] [uniqueidentifier] NULL,
		[IsSimpleMapping] [bit] NULL,
		[DiscardResult] [bit] NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
		[IsExportOnlyMappingFields] [bit] NOT NULL,
		[RepeatingData] [tinyint] NOT NULL,
		[ProcessInParallel] [bit] NOT NULL,
		[BreakOnError] [bit] NOT NULL,
		[BreakOnTarget] [bit] NOT NULL,
		[SkipHeaders] [bit] NOT NULL,
	 CONSTRAINT [SYMapping_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[MappingID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SYMapping_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM SYMapping_Orig)
	BEGIN
		INSERT INTO SYMapping_Orig (
			[CompanyID]
           ,[MappingID]
           ,[InverseMappingID]
           ,[Name]
           ,[IsActive]
           ,[ScreenID]
           ,[MappingType]
           ,[GraphName]
           ,[ViewName]
           ,[GridViewName]
           ,[ProviderID]
           ,[ProviderObject]
           ,[SyncType]
           ,[Status]
           ,[FieldCntr]
           ,[FieldOrderCntr]
           ,[ImportConditionCntr]
           ,[ConditionCntr]
           ,[DataCntr]
           ,[NbrRecords]
           ,[PreparedOn]
           ,[CompletedOn]
           ,[ImportTimeStamp]
           ,[ExportTimeStamp]
           ,[ExportTimeStampUtc]
           ,[FormatLocale]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
           ,[CompanyMask]
           ,[SitemapID]
           ,[IsSimpleMapping]
           ,[DiscardResult]
           ,[NoteID]
           ,[IsExportOnlyMappingFields]
           ,[RepeatingData]
           ,[ProcessInParallel]
           ,[BreakOnError]
           ,[BreakOnTarget]
           ,[SkipHeaders]
		)
		SELECT [CompanyID]
           ,[MappingID]
           ,[InverseMappingID]
           ,[Name]
           ,[IsActive]
           ,[ScreenID]
           ,[MappingType]
           ,[GraphName]
           ,[ViewName]
           ,[GridViewName]
           ,[ProviderID]
           ,[ProviderObject]
           ,[SyncType]
           ,[Status]
           ,[FieldCntr]
           ,[FieldOrderCntr]
           ,[ImportConditionCntr]
           ,[ConditionCntr]
           ,[DataCntr]
           ,[NbrRecords]
           ,[PreparedOn]
           ,[CompletedOn]
           ,[ImportTimeStamp]
           ,[ExportTimeStamp]
           ,[ExportTimeStampUtc]
           ,[FormatLocale]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
           ,[CompanyMask]
           ,[SitemapID]
           ,[IsSimpleMapping]
           ,[DiscardResult]
           ,[NoteID]
           ,[IsExportOnlyMappingFields]
           ,[RepeatingData]
           ,[ProcessInParallel]
           ,[BreakOnError]
           ,[BreakOnTarget]
           ,[SkipHeaders]
		  FROM [dbo].[SYMapping]

	END

END

GO