
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BPEvent_Orig')
BEGIN

	CREATE TABLE [dbo].[BPEvent_Orig](
		[CompanyID] [int] NOT NULL,
		[EventID] [uniqueidentifier] NOT NULL,
		[Name] [nvarchar](64) NOT NULL,
		[Description] [nvarchar](256) NULL,
		[ScreenID] [char](8) NOT NULL,
		[ViewName] [nvarchar](256) NULL,
		[ActionName] [nvarchar](64) NULL,
		[Active] [bit] NOT NULL,
		[Type] [tinyint] NOT NULL,
		[RowProcessingType] [tinyint] NOT NULL,
		[FilterID] [uniqueidentifier] NULL,
		[GroupingField] [nvarchar](256) NULL,
		[GroupingTable] [nvarchar](256) NULL,
		[IsGroupByNew] [bit] NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
	 CONSTRAINT [BPEvent_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
			[EventID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BPEvent_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM BPEvent_Orig)
	BEGIN
		INSERT INTO BPEvent_Orig (
			[CompanyID]
			,[EventID]
			,[Name]
			,[Description]
			,[ScreenID]
			,[ViewName]
			,[ActionName]
			,[Active]
			,[Type]
			,[RowProcessingType]
			,[FilterID]
			,[GroupingField]
			,[GroupingTable]
			,[IsGroupByNew]
			,[NoteID]
			,[CompanyMask]
		)
		SELECT [CompanyID]
			,[EventID]
			,[Name]
			,[Description]
			,[ScreenID]
			,[ViewName]
			,[ActionName]
			,[Active]
			,[Type]
			,[RowProcessingType]
			,[FilterID]
			,[GroupingField]
			,[GroupingTable]
			,[IsGroupByNew]
			,[NoteID]
			,[CompanyMask]
		  FROM [dbo].[BPEvent]

	END

END

GO