
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'CSAttributeDetail_Orig')
BEGIN

	CREATE TABLE [dbo].[CSAttributeDetail_Orig](
		[CompanyID] [int] NOT NULL,
		[AttributeID] [nvarchar](10) NOT NULL,
		[ValueID] [nvarchar](10) NOT NULL,
		[Description] [nvarchar](60) NULL,
		[SortOrder] [smallint] NULL,
		[Disabled] [bit] NOT NULL,
		[tstamp] [timestamp] NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
	 CONSTRAINT [CSAttributeDetail_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[AttributeID] ASC,
		[ValueID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'CSAttributeDetail_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM CSAttributeDetail_Orig)
	BEGIN
		INSERT INTO CSAttributeDetail_Orig (
			[CompanyID]
			,[AttributeID]
			,[ValueID]
			,[Description]
			,[SortOrder]
			,[Disabled]
			,[CreatedByID]
			,[CreatedByScreenID]
			,[CreatedDateTime]
			,[LastModifiedByID]
			,[LastModifiedByScreenID]
			,[LastModifiedDateTime]
			,[NoteID]
		)
		SELECT 
			[CompanyID]
			,[AttributeID]
			,[ValueID]
			,[Description]
			,[SortOrder]
			,[Disabled]
			,[CreatedByID]
			,[CreatedByScreenID]
			,[CreatedDateTime]
			,[LastModifiedByID]
			,[LastModifiedByScreenID]
			,[LastModifiedDateTime]
			,[NoteID]
		  FROM [dbo].[CSAttributeDetail]

	END

END

GO