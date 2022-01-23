
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Sitemap_Orig')
BEGIN

	CREATE TABLE [dbo].[Sitemap_Orig](
		[CompanyID] [int] NOT NULL,
		[Position] [float] NULL,
		[Title] [nvarchar](255) NULL,
		[Description] [varchar](512) NULL,
		[Url] [varchar](512) NULL,
		[ScreenID] [varchar](8) NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
		[NodeID] [uniqueidentifier] NOT NULL,
		[ParentID] [uniqueidentifier] NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[RecordSourceID] [smallint] NULL,
	 CONSTRAINT [SiteMap_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[NodeID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Sitemap_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM Sitemap_Orig)
	BEGIN
		INSERT INTO Sitemap_Orig (
				[CompanyID]
			   ,[Position]
			   ,[Title]
			   ,[Description]
			   ,[Url]
			   ,[ScreenID]
			   ,[CompanyMask]
			   ,[NodeID]
			   ,[ParentID]
			   ,[CreatedByID]
			   ,[CreatedByScreenID]
			   ,[CreatedDateTime]
			   ,[LastModifiedByID]
			   ,[LastModifiedByScreenID]
			   ,[LastModifiedDateTime]
			   ,[RecordSourceID]
		)
		SELECT [CompanyID]
			   ,[Position]
			   ,[Title]
			   ,[Description]
			   ,[Url]
			   ,[ScreenID]
			   ,[CompanyMask]
			   ,[NodeID]
			   ,[ParentID]
			   ,[CreatedByID]
			   ,[CreatedByScreenID]
			   ,[CreatedDateTime]
			   ,[LastModifiedByID]
			   ,[LastModifiedByScreenID]
			   ,[LastModifiedDateTime]
			   ,[RecordSourceID]
		  FROM [dbo].[Sitemap]

	END

END

GO