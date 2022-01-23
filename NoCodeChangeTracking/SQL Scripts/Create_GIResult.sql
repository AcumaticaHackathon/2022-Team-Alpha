
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GIResult_Orig')
BEGIN

	CREATE TABLE [dbo].[GIResult_Orig](
		[CompanyID] [int] NOT NULL,
		[DesignID] [uniqueidentifier] NOT NULL,
		[LineNbr] [int] NOT NULL,
		[SortOrder] [int] NULL,
		[IsActive] [bit] NOT NULL,
		[ObjectName] [nvarchar](255) NOT NULL,
		[Field] [nvarchar](max) NOT NULL,
		[SchemaField] [nvarchar](255) NULL,
		[Caption] [nvarchar](128) NULL,
		[StyleFormula] [nvarchar](max) NULL,
		[Width] [int] NULL,
		[IsVisible] [bit] NOT NULL,
		[DefaultNav] [bit] NOT NULL,
		[AggregateFunction] [nvarchar](32) NULL,
		[TotalAggregateFunction] [nvarchar](32) NULL,
		[NavigationNbr] [int] NULL,
		[QuickFilter] [bit] NOT NULL,
		[FastFilter] [bit] NOT NULL,
		[RowID] [uniqueidentifier] NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
	 CONSTRAINT [GIResult_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DesignID] ASC,
		[LineNbr] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GIResult_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM GIResult_Orig)
	BEGIN
		INSERT INTO GIResult_Orig (
			[CompanyID]
           ,[DesignID]
           ,[LineNbr]
           ,[SortOrder]
           ,[IsActive]
           ,[ObjectName]
           ,[Field]
           ,[SchemaField]
           ,[Caption]
           ,[StyleFormula]
           ,[Width]
           ,[IsVisible]
           ,[DefaultNav]
           ,[AggregateFunction]
           ,[TotalAggregateFunction]
           ,[NavigationNbr]
           ,[QuickFilter]
           ,[FastFilter]
           ,[RowID]
           ,[CreatedByID]
           ,[CreatedDateTime]
           ,[CreatedByScreenID]
           ,[LastModifiedByID]
           ,[LastModifiedDateTime]
           ,[LastModifiedByScreenID]
           ,[NoteID]
           ,[CompanyMask]
		)
		SELECT [CompanyID]
           ,[DesignID]
           ,[LineNbr]
           ,[SortOrder]
           ,[IsActive]
           ,[ObjectName]
           ,[Field]
           ,[SchemaField]
           ,[Caption]
           ,[StyleFormula]
           ,[Width]
           ,[IsVisible]
           ,[DefaultNav]
           ,[AggregateFunction]
           ,[TotalAggregateFunction]
           ,[NavigationNbr]
           ,[QuickFilter]
           ,[FastFilter]
           ,[RowID]
           ,[CreatedByID]
           ,[CreatedDateTime]
           ,[CreatedByScreenID]
           ,[LastModifiedByID]
           ,[LastModifiedDateTime]
           ,[LastModifiedByScreenID]
           ,[NoteID]
           ,[CompanyMask]
		  FROM [dbo].[GIResult]

	END

END

GO