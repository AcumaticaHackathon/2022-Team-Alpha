
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BPInquiryParameter_Orig')
BEGIN

	CREATE TABLE [dbo].[BPInquiryParameter_Orig](
		[CompanyID] [int] NOT NULL,
		[EventID] [uniqueidentifier] NOT NULL,
		[Name] [nvarchar](64) NOT NULL,
		[FieldType] [int] NOT NULL,
		[Value] [nvarchar](256) NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
	 CONSTRAINT [BPInquiryParameter_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[EventID] ASC,
		[Name] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BPInquiryParameter_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM BPInquiryParameter_Orig)
	BEGIN
		INSERT INTO BPInquiryParameter_Orig (
			[CompanyID]
           ,[EventID]
           ,[Name]
           ,[FieldType]
           ,[Value]
           ,[CompanyMask]
		)
		SELECT [CompanyID]
           ,[EventID]
           ,[Name]
           ,[FieldType]
           ,[Value]
           ,[CompanyMask]
		  FROM [dbo].[BPInquiryParameter]

	END

END

GO