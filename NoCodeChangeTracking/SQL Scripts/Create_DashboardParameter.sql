
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'DashboardParameter_Orig')
BEGIN

	CREATE TABLE [dbo].[DashboardParameter_Orig](
		[CompanyID] [int] NOT NULL,
		[DashboardID] [int] NOT NULL,
		[LineNbr] [int] NOT NULL,
		[Name] [varchar](256) NOT NULL,
		[IsActive] [bit] NOT NULL,
		[Required] [bit] NOT NULL,
		[ObjectName] [nvarchar](512) NOT NULL,
		[FieldName] [nvarchar](512) NOT NULL,
		[DisplayName] [nvarchar](512) NULL,
		[IsExpression] [bit] NOT NULL,
		[DefaultValue] [nvarchar](512) NULL,
		[Size] [varchar](3) NULL,
		[LabelSize] [varchar](3) NULL,
		[ColSpan] [int] NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
	 CONSTRAINT [DashboardParameter_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DashboardID] ASC,
		[LineNbr] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'DashboardParameter_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM DashboardParameter_Orig)
	BEGIN
		INSERT INTO DashboardParameter_Orig (
			[CompanyID]
           ,[DashboardID]
           ,[LineNbr]
           ,[Name]
           ,[IsActive]
           ,[Required]
           ,[ObjectName]
           ,[FieldName]
           ,[DisplayName]
           ,[IsExpression]
           ,[DefaultValue]
           ,[Size]
           ,[LabelSize]
           ,[ColSpan]
           ,[NoteID]
           ,[CompanyMask]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
		)
		SELECT [CompanyID]
           ,[DashboardID]
           ,[LineNbr]
           ,[Name]
           ,[IsActive]
           ,[Required]
           ,[ObjectName]
           ,[FieldName]
           ,[DisplayName]
           ,[IsExpression]
           ,[DefaultValue]
           ,[Size]
           ,[LabelSize]
           ,[ColSpan]
           ,[NoteID]
           ,[CompanyMask]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
		  FROM [dbo].[DashboardParameter]

	END

END

GO