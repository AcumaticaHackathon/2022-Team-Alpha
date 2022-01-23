
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Widget_Orig')
BEGIN

	CREATE TABLE [dbo].[Widget_Orig](
		[CompanyID] [int] NOT NULL,
		[DashboardID] [int] NOT NULL,
		[WidgetID] [int] NOT NULL,
		[CompanyWidgetID] [int] NOT NULL,
		[OwnerName] [nvarchar](64) NULL,
		[Caption] [nvarchar](255) NULL,
		[Column] [int] NOT NULL,
		[Row] [int] NOT NULL,
		[Workspace] [int] NOT NULL,
		[Width] [int] NOT NULL,
		[Height] [int] NOT NULL,
		[Type] [nvarchar](max) NOT NULL,
		[Settings] [nvarchar](max) NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
	 CONSTRAINT [WidgetContainer_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DashboardID] ASC,
		[WidgetID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Widget_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM Widget_Orig)
	BEGIN
		INSERT INTO Widget_Orig (
				[CompanyID]
			   ,[DashboardID]
			   ,[WidgetID]
			   ,[CompanyWidgetID]
			   ,[OwnerName]
			   ,[Caption]
			   ,[Column]
			   ,[Row]
			   ,[Workspace]
			   ,[Width]
			   ,[Height]
			   ,[Type]
			   ,[Settings]
			   ,[CompanyMask]
			   ,[CreatedByID]
			   ,[CreatedByScreenID]
			   ,[CreatedDateTime]
			   ,[LastModifiedByID]
			   ,[LastModifiedByScreenID]
			   ,[LastModifiedDateTime]
			   ,[NoteID]
		)
		SELECT [CompanyID]
			   ,[DashboardID]
			   ,[WidgetID]
			   ,[CompanyWidgetID]
			   ,[OwnerName]
			   ,[Caption]
			   ,[Column]
			   ,[Row]
			   ,[Workspace]
			   ,[Width]
			   ,[Height]
			   ,[Type]
			   ,[Settings]
			   ,[CompanyMask]
			   ,[CreatedByID]
			   ,[CreatedByScreenID]
			   ,[CreatedDateTime]
			   ,[LastModifiedByID]
			   ,[LastModifiedByScreenID]
			   ,[LastModifiedDateTime]
			   ,[NoteID]
		  FROM [dbo].[Widget]

	END

END

GO