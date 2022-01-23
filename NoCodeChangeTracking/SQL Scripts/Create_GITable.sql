
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GITable_Orig')
BEGIN

	CREATE TABLE [dbo].[GITable_Orig](
		[CompanyID] [int] NOT NULL,
		[DesignID] [uniqueidentifier] NOT NULL,
		[Alias] [nvarchar](255) NOT NULL,
		[Name] [varchar](255) NOT NULL,
		[Number] [int] NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
	 CONSTRAINT [GITable_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DesignID] ASC,
		[Alias] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GITable_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM GITable_Orig)
	BEGIN
		INSERT INTO GITable_Orig (
			[CompanyID]
           ,[DesignID]
           ,[Alias]
           ,[Name]
           ,[Number]
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
           ,[Alias]
           ,[Name]
           ,[Number]
           ,[CreatedByID]
           ,[CreatedDateTime]
           ,[CreatedByScreenID]
           ,[LastModifiedByID]
           ,[LastModifiedDateTime]
           ,[LastModifiedByScreenID]
           ,[NoteID]
           ,[CompanyMask]
		  FROM [dbo].[GITable]

	END

END

GO