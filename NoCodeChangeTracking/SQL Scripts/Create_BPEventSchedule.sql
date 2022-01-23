
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Create table
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BPEventSchedule_Orig')
BEGIN

	CREATE TABLE [dbo].[BPEventSchedule_Orig](
		[CompanyID] [int] NOT NULL,
		[EventID] [uniqueidentifier] NOT NULL,
		[ScheduleID] [int] NOT NULL,
		[Active] [bit] NOT NULL,
		[CompanyMask] [varbinary](32) NOT NULL,
	 CONSTRAINT [BPEventSchedule_Orig_PK] PRIMARY KEY CLUSTERED 
	(
		[CompanyID] ASC,
		[EventID] ASC,
		[ScheduleID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END

GO

-- Copy data for beginning snapshot
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BPEventSchedule_Orig')
BEGIN
	
	IF NOT EXISTS (SELECT 1 FROM BPEventSchedule_Orig)
	BEGIN
		INSERT INTO BPEventSchedule_Orig (
		   [CompanyID]
           ,[EventID]
           ,[ScheduleID]
           ,[Active]
           ,[CompanyMask]
		)
		SELECT [CompanyID]
           ,[EventID]
           ,[ScheduleID]
           ,[Active]
           ,[CompanyMask]
		FROM [dbo].[BPEventSchedule]

	END

END

GO