
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SYMappingField_Orig')
BEGIN

	CREATE TABLE [dbo].[SYMappingField_Orig](
		[CompanyID] [int] NOT NULL,
		[MappingID] [uniqueidentifier] NOT NULL,
		[LineNbr] [smallint] NOT NULL,
		[OrderNumber] [int] NULL,
		[IsActive] [bit] NOT NULL,
		[IsVisible] [bit] NOT NULL,
		[ParentLineNbr] [smallint] NULL,
		[ObjectName] [varchar](128) NOT NULL,
		[FieldName] [nvarchar](4000) NOT NULL,
		[Value] [nvarchar](4000) NULL,
		[NeedCommit] [bit] NOT NULL,
		[IgnoreError] [bit] NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[tstamp] [timestamp] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
	 CONSTRAINT [SYMappingField_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[MappingID] ASC,
		[LineNbr] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SYMappingField_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM SYMappingField_Orig)
	BEGIN
		INSERT INTO SYMappingField_Orig (
			[CompanyID]
           ,[MappingID]
           ,[LineNbr]
           ,[OrderNumber]
           ,[IsActive]
           ,[IsVisible]
           ,[ParentLineNbr]
           ,[ObjectName]
           ,[FieldName]
           ,[Value]
           ,[NeedCommit]
           ,[IgnoreError]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
           ,[CompanyMask]
           ,[NoteID]
		)
		SELECT [CompanyID]
           ,[MappingID]
           ,[LineNbr]
           ,[OrderNumber]
           ,[IsActive]
           ,[IsVisible]
           ,[ParentLineNbr]
           ,[ObjectName]
           ,[FieldName]
           ,[Value]
           ,[NeedCommit]
           ,[IgnoreError]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
           ,[CompanyMask]
           ,[NoteID]
		  FROM [dbo].[SYMappingField]

	END

END

GO