
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BPEventTriggerCondition_Orig')
BEGIN

	CREATE TABLE [dbo].[BPEventTriggerCondition_Orig](
		[CompanyID] [int] NOT NULL,
		[EventID] [uniqueidentifier] NOT NULL,
		[OrderNbr] [smallint] NOT NULL,
		[TableName] [varchar](256) NULL,
		[Operation] [tinyint] NOT NULL,
		[Active] [bit] NOT NULL,
		[OpenBrackets] [int] NOT NULL,
		[FieldName] [varchar](256) NULL,
		[Condition] [tinyint] NULL,
		[Value] [nvarchar](256) NULL,
		[Value2] [nvarchar](256) NULL,
		[CloseBrackets] [int] NOT NULL,
		[Operator] [int] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
		[DataType] [int] NULL,
	 CONSTRAINT [BPEventTriggerCondition_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[EventID] ASC,
		[OrderNbr] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BPEventTriggerCondition_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM BPEventTriggerCondition_Orig)
	BEGIN
		INSERT INTO BPEventTriggerCondition_Orig (
			[CompanyID]
           ,[EventID]
           ,[OrderNbr]
           ,[TableName]
           ,[Operation]
           ,[Active]
           ,[OpenBrackets]
           ,[FieldName]
           ,[Condition]
           ,[Value]
           ,[Value2]
           ,[CloseBrackets]
           ,[Operator]
           ,[CompanyMask]
           ,[DataType]
		)
		SELECT [CompanyID]
           ,[EventID]
           ,[OrderNbr]
           ,[TableName]
           ,[Operation]
           ,[Active]
           ,[OpenBrackets]
           ,[FieldName]
           ,[Condition]
           ,[Value]
           ,[Value2]
           ,[CloseBrackets]
           ,[Operator]
           ,[CompanyMask]
           ,[DataType]
		  FROM [dbo].[BPEventTriggerCondition]

	END

END

GO