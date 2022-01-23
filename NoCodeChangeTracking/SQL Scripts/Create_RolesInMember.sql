
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'RolesInMember_Orig')
BEGIN

	CREATE TABLE [dbo].[RolesInMember_Orig](
		[CompanyID] [int] NOT NULL,
		[ScreenID] [varchar](8) NOT NULL,
		[Cachetype] [varchar](255) NOT NULL,
		[Membername] [varchar](255) NOT NULL,
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
	 CONSTRAINT [RolesInMember_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[ScreenID] ASC,
		[Cachetype] ASC,
		[Membername] ASC,
		[Rolename] ASC,
		[ApplicationName] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'RolesInMember_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM RolesInMember_Orig)
	BEGIN
		INSERT INTO RolesInMember_Orig (
			[CompanyID]
           ,[ScreenID]
           ,[Cachetype]
           ,[Membername]
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
		)
		SELECT [CompanyID]
           ,[ScreenID]
           ,[Cachetype]
           ,[Membername]
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
		  FROM [dbo].[RolesInMember]

	END

END

GO