
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Dashboard_Orig')
BEGIN

	CREATE TABLE [dbo].[Dashboard_Orig](
		[CompanyID] [int] NOT NULL,
		[DashboardID] [int] NOT NULL,
		[CompanyDashboardID] [int] NOT NULL,
		[Name] [nvarchar](255) NOT NULL,
		[DefaultOwnerRole] [nvarchar](64) NOT NULL,
		[ScreenID] [varchar](8) NULL,
		[AllowCopy] [bit] NOT NULL,
		[Workspace1Size] [int] NOT NULL,
		[Workspace2Size] [int] NOT NULL,
		[IsPortal] [bit] NOT NULL,
		[ExposeViaMobile] [bit] NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
	 CONSTRAINT [Dashboard_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DashboardID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Dashboard_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM Dashboard_Orig)
	BEGIN
		INSERT INTO Dashboard_Orig (
				[CompanyID]
			  ,[DashboardID]
			  ,[CompanyDashboardID]
			  ,[Name]
			  ,[DefaultOwnerRole]
			  ,[ScreenID]
			  ,[AllowCopy]
			  ,[Workspace1Size]
			  ,[Workspace2Size]
			  ,[IsPortal]
			  ,[ExposeViaMobile]
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
			  ,[CompanyDashboardID]
			  ,[Name]
			  ,[DefaultOwnerRole]
			  ,[ScreenID]
			  ,[AllowCopy]
			  ,[Workspace1Size]
			  ,[Workspace2Size]
			  ,[IsPortal]
			  ,[ExposeViaMobile]
			  ,[NoteID]
			  ,[CompanyMask]
			  ,[CreatedByID]
			  ,[CreatedByScreenID]
			  ,[CreatedDateTime]
			  ,[LastModifiedByID]
			  ,[LastModifiedByScreenID]
			  ,[LastModifiedDateTime]
		  FROM [dbo].[Dashboard]

	END

END

GO