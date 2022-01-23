
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'WebHook_Orig')
BEGIN

	CREATE TABLE [dbo].[WebHook_Orig](
		[CompanyID] [int] NOT NULL,
		[WebHookID] [uniqueidentifier] NOT NULL,
		[Name] [nvarchar](128) NOT NULL,
		[Handler] [varchar](128) NOT NULL,
		[IsActive] [bit] NOT NULL,
		[IsSystem] [bit] NOT NULL,
		[RequestLogLevel] [tinyint] NOT NULL,
		[RequestRetainCount] [smallint] NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[tstamp] [timestamp] NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
	 CONSTRAINT [WebHook_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[WebHookID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'WebHook_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM WebHook_Orig)
	BEGIN
		INSERT INTO WebHook_Orig (
			[CompanyID]
           ,[WebHookID]
           ,[Name]
           ,[Handler]
           ,[IsActive]
           ,[IsSystem]
           ,[RequestLogLevel]
           ,[RequestRetainCount]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
           ,[NoteID]
           ,[CompanyMask]
		)
		SELECT [CompanyID]
           ,[WebHookID]
           ,[Name]
           ,[Handler]
           ,[IsActive]
           ,[IsSystem]
           ,[RequestLogLevel]
           ,[RequestRetainCount]
           ,[CreatedByID]
           ,[CreatedByScreenID]
           ,[CreatedDateTime]
           ,[LastModifiedByID]
           ,[LastModifiedByScreenID]
           ,[LastModifiedDateTime]
           ,[NoteID]
           ,[CompanyMask]
		  FROM [dbo].[WebHook]

	END

END

GO