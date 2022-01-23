
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BPEventSubscriber_Orig')
BEGIN

	CREATE TABLE [dbo].[BPEventSubscriber_Orig](
		[CompanyID] [int] NOT NULL,
		[EventID] [uniqueidentifier] NOT NULL,
		[HandlerID] [uniqueidentifier] NOT NULL,
		[Active] [bit] NOT NULL,
		[OrderNbr] [smallint] NOT NULL,
		[Type] [nchar](4) NOT NULL,
		[StopOnError] [bit] NOT NULL,
		[IsProcessSingleLine] [bit] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
	 CONSTRAINT [BPEventSubscriber_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[EventID] ASC,
		[HandlerID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BPEventSubscriber_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM BPEventSubscriber_Orig)
	BEGIN
		INSERT INTO BPEventSubscriber_Orig (
			[CompanyID]
           ,[EventID]
           ,[HandlerID]
           ,[Active]
           ,[OrderNbr]
           ,[Type]
           ,[StopOnError]
           ,[IsProcessSingleLine]
           ,[CompanyMask]
		)
		SELECT [CompanyID]
           ,[EventID]
           ,[HandlerID]
           ,[Active]
           ,[OrderNbr]
           ,[Type]
           ,[StopOnError]
           ,[IsProcessSingleLine]
           ,[CompanyMask]
		  FROM [dbo].[BPEventSubscriber]

	END

END

GO