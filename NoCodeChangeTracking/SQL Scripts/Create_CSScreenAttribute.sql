
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'CSScreenAttribute_Orig')
BEGIN

	CREATE TABLE [dbo].[CSScreenAttribute_Orig](
		[CompanyID] [int] NOT NULL,
		[AttributeID] [nvarchar](10) NOT NULL,
		[ScreenID] [varchar](8) NOT NULL,
		[TypeValue] [nvarchar](60) NOT NULL,
		[Hidden] [bit] NOT NULL,
		[Required] [bit] NOT NULL,
		[Column] [smallint] NULL,
		[Row] [smallint] NULL,
		[tstamp] [timestamp] NOT NULL,
		[CreatedByID] [uniqueidentifier] NOT NULL,
		[CreatedByScreenID] [char](8) NOT NULL,
		[CreatedDateTime] [datetime] NOT NULL,
		[LastModifiedByID] [uniqueidentifier] NOT NULL,
		[LastModifiedByScreenID] [char](8) NOT NULL,
		[LastModifiedDateTime] [datetime] NOT NULL,
		[NoteID] [uniqueidentifier] NOT NULL,
		[DefaultValue] [nvarchar](255) NULL,
	 CONSTRAINT [CSScreenAttribute_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[ScreenID] ASC,
		[AttributeID] ASC,
		[TypeValue] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'CSScreenAttribute_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM CSScreenAttribute_Orig)
	BEGIN
		INSERT INTO CSScreenAttribute_Orig (
			[CompanyID]
			  ,[AttributeID]
			  ,[ScreenID]
			  ,[TypeValue]
			  ,[Hidden]
			  ,[Required]
			  ,[Column]
			  ,[Row]
			  ,[CreatedByID]
			  ,[CreatedByScreenID]
			  ,[CreatedDateTime]
			  ,[LastModifiedByID]
			  ,[LastModifiedByScreenID]
			  ,[LastModifiedDateTime]
			  ,[NoteID]
			  ,[DefaultValue]
		)
		SELECT [CompanyID]
			  ,[AttributeID]
			  ,[ScreenID]
			  ,[TypeValue]
			  ,[Hidden]
			  ,[Required]
			  ,[Column]
			  ,[Row]
			  ,[CreatedByID]
			  ,[CreatedByScreenID]
			  ,[CreatedDateTime]
			  ,[LastModifiedByID]
			  ,[LastModifiedByScreenID]
			  ,[LastModifiedDateTime]
			  ,[NoteID]
			  ,[DefaultValue]
		  FROM [dbo].[CSScreenAttribute]
	END

END

GO