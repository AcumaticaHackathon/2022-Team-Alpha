
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SYMappingCondition_Orig')
BEGIN

	CREATE TABLE [dbo].[SYMappingCondition_Orig](
		[CompanyID] [int] NOT NULL,
		[MappingID] [uniqueidentifier] NOT NULL,
		[LineNbr] [smallint] NOT NULL,
		[IsActive] [bit] NOT NULL,
		[OpenBrackets] [int] NOT NULL,
		[ObjectName] [nvarchar](128) NULL,
		[FieldName] [nvarchar](128) NOT NULL,
		[Condition] [int] NOT NULL,
		[IsRelative] [bit] NOT NULL,
		[Value] [nvarchar](128) NULL,
		[Value2] [nvarchar](128) NULL,
		[CloseBrackets] [int] NOT NULL,
		[Operator] [int] NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[tstamp] [timestamp] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
	 CONSTRAINT [SYMappingCondition_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[MappingID] ASC,
		[LineNbr] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SYMappingCondition_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM SYMappingCondition_Orig)
	BEGIN
		INSERT INTO SYMappingCondition_Orig (
			[CompanyID]
           ,[MappingID]
           ,[LineNbr]
           ,[IsActive]
           ,[OpenBrackets]
           ,[ObjectName]
           ,[FieldName]
           ,[Condition]
           ,[IsRelative]
           ,[Value]
           ,[Value2]
           ,[CloseBrackets]
           ,[Operator]
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
           ,[IsActive]
           ,[OpenBrackets]
           ,[ObjectName]
           ,[FieldName]
           ,[Condition]
           ,[IsRelative]
           ,[Value]
           ,[Value2]
           ,[CloseBrackets]
           ,[Operator]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
           ,[CompanyMask]
           ,[NoteID]
		  FROM [dbo].[SYMappingCondition]

	END

END

GO