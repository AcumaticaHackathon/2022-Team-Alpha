
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GIOn_Orig')
BEGIN

	CREATE TABLE [dbo].[GIOn_Orig](
		[CompanyID] [int] NOT NULL,
		[DesignID] [uniqueidentifier] NOT NULL,
		[RelationNbr] [int] NOT NULL,
		[LineNbr] [int] NOT NULL,
		[OpenBrackets] [char](9) NULL,
		[ParentField] [nvarchar](max) NOT NULL,
		[Condition] [char](2) NOT NULL,
		[ChildField] [nvarchar](max) NULL,
		[CloseBrackets] [char](9) NULL,
		[Operation] [char](1) NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
	 CONSTRAINT [GIOn_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DesignID] ASC,
		[RelationNbr] ASC,
		[LineNbr] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GIOn_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM GIOn_Orig)
	BEGIN
		INSERT INTO GIOn_Orig (
			[CompanyID]
           ,[DesignID]
           ,[RelationNbr]
           ,[LineNbr]
           ,[OpenBrackets]
           ,[ParentField]
           ,[Condition]
           ,[ChildField]
           ,[CloseBrackets]
           ,[Operation]
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
           ,[RelationNbr]
           ,[LineNbr]
           ,[OpenBrackets]
           ,[ParentField]
           ,[Condition]
           ,[ChildField]
           ,[CloseBrackets]
           ,[Operation]
           ,[CreatedByID]
           ,[CreatedDateTime]
           ,[CreatedByScreenID]
           ,[LastModifiedByID]
           ,[LastModifiedDateTime]
           ,[LastModifiedByScreenID]
           ,[NoteID]
           ,[CompanyMask]
		  FROM [dbo].[GIOn]

	END

END

GO