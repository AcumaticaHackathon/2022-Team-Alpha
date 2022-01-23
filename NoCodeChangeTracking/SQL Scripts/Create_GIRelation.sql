
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GIRelation_Orig')
BEGIN

	CREATE TABLE [dbo].[GIRelation_Orig](
		[CompanyID] [int] NOT NULL,
	    [DesignID] [uniqueidentifier] NOT NULL,
	    [LineNbr] [int] NOT NULL,
	    [ParentTable] [nvarchar](255) NOT NULL,
	    [ChildTable] [nvarchar](255) NOT NULL,
	    [IsActive] [bit] NOT NULL,
	    [JoinType] [char](1) NOT NULL,
	    [CreatedByID] [uniqueidentifier] NOT NULL,
	    [CreatedDateTime] [datetime] NOT NULL,
	    [CreatedByScreenID] [char](8) NOT NULL,
	    [LastModifiedByID] [uniqueidentifier] NOT NULL,
	    [LastModifiedDateTime] [datetime] NOT NULL,
	    [LastModifiedByScreenID] [char](8) NOT NULL,
	    [NoteID] [uniqueidentifier] NOT NULL,
	    [CompanyMask] [varbinary](32) NOT NULL,
	 CONSTRAINT [GIRelation_Orig_PK] PRIMARY KEY CLUSTERED 
	(
	    [CompanyID] ASC,
	    [DesignID] ASC,
	    [LineNbr] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GIRelation_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM GIRelation_Orig)
	BEGIN
		INSERT INTO GIRelation_Orig (
			[CompanyID]
           ,[DesignID]
           ,[LineNbr]
           ,[ParentTable]
           ,[ChildTable]
           ,[IsActive]
           ,[JoinType]
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
           ,[ParentTable]
           ,[ChildTable]
           ,[IsActive]
           ,[JoinType]
           ,[CreatedByID]
           ,[CreatedDateTime]
           ,[CreatedByScreenID]
           ,[LastModifiedByID]
           ,[LastModifiedDateTime]
           ,[LastModifiedByScreenID]
           ,[NoteID]
           ,[CompanyMask]
		  FROM [dbo].[GIRelation]

	END

END

GO