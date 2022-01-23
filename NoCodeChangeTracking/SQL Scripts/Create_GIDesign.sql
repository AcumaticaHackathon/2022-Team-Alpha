
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GIDesign_Orig')
BEGIN

	CREATE TABLE [dbo].[GIDesign_Orig](
		[CompanyID] [int] NOT NULL,
		[DesignID] [uniqueidentifier] NOT NULL,
		[Name] [nvarchar](255) NOT NULL,
		[FilterCaption] [nvarchar](255) NULL,
		[ResultsCaption] [nvarchar](255) NULL,
		[SelectTop] [int] NULL,
		[FilterColCount] [int] NULL,
		[PageSize] [int] NULL,
		[ExportTop] [int] NULL,
		[PrimaryScreenIDNew] [varchar](8) NULL,
		[NewRecordCreationEnabled] [bit] NOT NULL,
		[MassDeleteEnabled] [bit] NOT NULL,
		[AutoConfirmDelete] [bit] NOT NULL,
		[MassRecordsUpdateEnabled] [bit] NOT NULL,
		[MassActionsOnRecordsEnabled] [bit] NOT NULL,
		[ExposeViaOData] [bit] NOT NULL,
		[ExposeViaMobile] [bit] NOT NULL,
		[RowStyleFormula] [nvarchar](max) NULL,
		[ShowDeletedRecords] [bit] NOT NULL,
		[NotesAndFilesTable] [nvarchar](255) NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
	 CONSTRAINT [GIDesign_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[DesignID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GIDesign_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM GIDesign_Orig)
	BEGIN
		INSERT INTO GIDesign_Orig (
			[CompanyID]
           ,[DesignID]
           ,[Name]
           ,[FilterCaption]
           ,[ResultsCaption]
           ,[SelectTop]
           ,[FilterColCount]
           ,[PageSize]
           ,[ExportTop]
           ,[PrimaryScreenIDNew]
           ,[NewRecordCreationEnabled]
           ,[MassDeleteEnabled]
           ,[AutoConfirmDelete]
           ,[MassRecordsUpdateEnabled]
           ,[MassActionsOnRecordsEnabled]
           ,[ExposeViaOData]
           ,[ExposeViaMobile]
           ,[RowStyleFormula]
           ,[ShowDeletedRecords]
           ,[NotesAndFilesTable]
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
           ,[Name]
           ,[FilterCaption]
           ,[ResultsCaption]
           ,[SelectTop]
           ,[FilterColCount]
           ,[PageSize]
           ,[ExportTop]
           ,[PrimaryScreenIDNew]
           ,[NewRecordCreationEnabled]
           ,[MassDeleteEnabled]
           ,[AutoConfirmDelete]
           ,[MassRecordsUpdateEnabled]
           ,[MassActionsOnRecordsEnabled]
           ,[ExposeViaOData]
           ,[ExposeViaMobile]
           ,[RowStyleFormula]
           ,[ShowDeletedRecords]
           ,[NotesAndFilesTable]
           ,[CreatedByID]
           ,[CreatedDateTime]
           ,[CreatedByScreenID]
           ,[LastModifiedByID]
           ,[LastModifiedDateTime]
           ,[LastModifiedByScreenID]
           ,[NoteID]
           ,[CompanyMask]
		  FROM [dbo].[GIDesign]

	END

END

GO