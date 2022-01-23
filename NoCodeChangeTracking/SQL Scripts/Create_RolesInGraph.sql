
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'RolesInGraph_Orig')
BEGIN

	CREATE TABLE [dbo].[RolesInGraph_Orig](
		[CompanyID] [int] NOT NULL,
		[ScreenID] [varchar](8) NOT NULL,
		[Rolename] [nvarchar](64) NOT NULL,
		[ApplicationName] [varchar](32) NOT NULL,
		[Accessrights] [smallint] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[RecordSourceID] [smallint] NULL,
	 CONSTRAINT [RolesInGraph_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[ScreenID] ASC,
		[Rolename] ASC,
		[ApplicationName] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'RolesInGraph_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM RolesInGraph_Orig)
	BEGIN
		INSERT INTO RolesInGraph_Orig (
			[CompanyID]
           ,[ScreenID]
           ,[Rolename]
           ,[ApplicationName]
           ,[Accessrights]
           ,[CompanyMask]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
           ,[RecordSourceID]
		)
		SELECT [CompanyID]
           ,[ScreenID]
           ,[Rolename]
           ,[ApplicationName]
           ,[Accessrights]
           ,[CompanyMask]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
           ,[RecordSourceID]
		  FROM [dbo].[RolesInGraph]

	END

END

GO