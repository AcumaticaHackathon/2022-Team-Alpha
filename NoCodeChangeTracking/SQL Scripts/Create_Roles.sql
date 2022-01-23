
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Roles_Orig')
BEGIN

	CREATE TABLE [dbo].[Roles_Orig](
		[CompanyID] [int] NOT NULL,
		[Rolename] [nvarchar](64) NOT NULL,
		[ApplicationName] [varchar](32) NOT NULL,
		[Descr] [nvarchar](255) NULL,
		[Guest] [bit] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
	 CONSTRAINT [Roles_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[Rolename] ASC,
		[ApplicationName] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Roles_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM Roles_Orig)
	BEGIN
		INSERT INTO Roles_Orig (
			[CompanyID]
           ,[Rolename]
           ,[ApplicationName]
           ,[Descr]
           ,[Guest]
           ,[CompanyMask]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
		)
		SELECT [CompanyID]
           ,[Rolename]
           ,[ApplicationName]
           ,[Descr]
           ,[Guest]
           ,[CompanyMask]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
		  FROM [dbo].[Roles]

	END

END

GO