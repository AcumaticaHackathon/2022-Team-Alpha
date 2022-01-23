
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GIFilter_Orig')
BEGIN

	CREATE TABLE [dbo].[GIFilter_Orig](
		[CompanyID] [int] NOT NULL,
	    [DesignID] [uniqueidentifier] NOT NULL,
	    [LineNbr] [int] NOT NULL,
	    [IsActive] [bit] NOT NULL,
	    [Name] [nvarchar](255) NOT NULL,
	    [FieldName] [nvarchar](512) NOT NULL,
	    [DataType] [varchar](50) NOT NULL,
	    [DisplayName] [nvarchar](512) NULL,
	    [AvailableValues] [nvarchar](1024) NULL,
	    [IsExpression] [bit] NOT NULL,
	    [DefaultValue] [nvarchar](max) NULL,
	    [ColSpan] [int] NOT NULL,
	    [Required] [bit] NOT NULL,
	    [Hidden] [bit] NULL,
	    [Size] [varchar](3) NULL,
	    [LabelSize] [varchar](3) NULL,
	    [CreatedByID] [uniqueidentifier] NOT NULL,
	    [CreatedDateTime] [datetime] NOT NULL,
	    [CreatedByScreenID] [char](8) NOT NULL,
	    [LastModifiedByID] [uniqueidentifier] NOT NULL,
	    [LastModifiedDateTime] [datetime] NOT NULL,
	    [LastModifiedByScreenID] [char](8) NOT NULL,
	    [NoteID] [uniqueidentifier] NOT NULL,
	    [CompanyMask] [varbinary](32) NOT NULL,
	 CONSTRAINT [GIFilter_Orig_PK] PRIMARY KEY CLUSTERED 
	(
	    [CompanyID] ASC,
	    [DesignID] ASC,
	    [LineNbr] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GIFilter_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM GIFilter_Orig)
	BEGIN
		INSERT INTO GIFilter_Orig (
			[CompanyID]
           ,[DesignID]
           ,[LineNbr]
           ,[IsActive]
           ,[Name]
           ,[FieldName]
           ,[DataType]
           ,[DisplayName]
           ,[AvailableValues]
           ,[IsExpression]
           ,[DefaultValue]
           ,[ColSpan]
           ,[Required]
           ,[Hidden]
           ,[Size]
           ,[LabelSize]
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
           ,[Name]
           ,[FieldName]
           ,[DataType]
           ,[DisplayName]
           ,[AvailableValues]
           ,[IsExpression]
           ,[DefaultValue]
           ,[ColSpan]
           ,[Required]
           ,[Hidden]
           ,[Size]
           ,[LabelSize]
           ,[CreatedByID]
           ,[CreatedDateTime]
           ,[CreatedByScreenID]
           ,[LastModifiedByID]
           ,[LastModifiedDateTime]
           ,[LastModifiedByScreenID]
           ,[NoteID]
           ,[CompanyMask]
		  FROM [dbo].[GIFilter]

	END

END

GO