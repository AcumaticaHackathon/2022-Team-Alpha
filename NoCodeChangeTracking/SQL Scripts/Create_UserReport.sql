
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'UserReport_Orig')
BEGIN

	CREATE TABLE [dbo].[UserReport_Orig](
		[CompanyID] [int] NOT NULL,
		[ReportFileName] [nvarchar](50) NOT NULL,
		[Version] [int] NOT NULL,
		[Description] [nvarchar](50) NULL,
		[DateCreated] [datetime] NULL,
		[IsActive] [bit] NOT NULL,
		[Xml] [nvarchar](max) NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
	 CONSTRAINT [PK_UserReport_Orig] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[ReportFileName] ASC,
		[Version] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'UserReport_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM UserReport_Orig)
	BEGIN
		INSERT INTO UserReport_Orig (
			  [CompanyID]
			  ,[ReportFileName]
			  ,[Version]
			  ,[Description]
			  ,[DateCreated]
			  ,[IsActive]
			  ,[Xml]
			  ,[CreatedByID]
			  ,[CreatedByScreenID]
			  ,[CreatedDateTime]
			  ,[LastModifiedByID]
			  ,[LastModifiedByScreenID]
			  ,[LastModifiedDateTime]
		)
		SELECT [CompanyID]
			  ,[ReportFileName]
			  ,[Version]
			  ,[Description]
			  ,[DateCreated]
			  ,[IsActive]
			  ,[Xml]
			  ,[CreatedByID]
			  ,[CreatedByScreenID]
			  ,[CreatedDateTime]
			  ,[LastModifiedByID]
			  ,[LastModifiedByScreenID]
			  ,[LastModifiedDateTime]
		  FROM [dbo].[UserReport]

	END

END

GO