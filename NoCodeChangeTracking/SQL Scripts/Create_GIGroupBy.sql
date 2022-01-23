
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GIGroupBy_Orig')
BEGIN

	CREATE TABLE [dbo].[GIGroupBy_Orig](
		[CompanyID] [int] NOT NULL,
	    [DesignID] [uniqueidentifier] NOT NULL,
	    [LineNbr] [int] NOT NULL,
	    [IsActive] [bit] NOT NULL,
	    [DataFieldName] [nvarchar](max) NOT NULL,
	    [CreatedByID] [uniqueidentifier] NOT NULL,
	    [CreatedDateTime] [datetime] NOT NULL,
	    [CreatedByScreenID] [char](8) NOT NULL,
	    [LastModifiedByID] [uniqueidentifier] NOT NULL,
	    [LastModifiedDateTime] [datetime] NOT NULL,
	    [LastModifiedByScreenID] [char](8) NOT NULL,
	    [NoteID] [uniqueidentifier] NOT NULL,
	    [CompanyMask] [varbinary](32) NOT NULL,
	 CONSTRAINT [GIGroupBy_Orig_PK] PRIMARY KEY CLUSTERED 
	(
	    [CompanyID] ASC,
	    [DesignID] ASC,
	    [LineNbr] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GIGroupBy_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM GIGroupBy_Orig)
	BEGIN
		INSERT INTO GIGroupBy_Orig (
			[CompanyID]
           ,[DesignID]
           ,[LineNbr]
           ,[IsActive]
           ,[DataFieldName]
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
           ,[IsActive]
           ,[DataFieldName]
           ,[CreatedByID]
           ,[CreatedDateTime]
           ,[CreatedByScreenID]
           ,[LastModifiedByID]
           ,[LastModifiedDateTime]
           ,[LastModifiedByScreenID]
           ,[NoteID]
           ,[CompanyMask]
		  FROM [dbo].[GIGroupBy]

	END

END

GO