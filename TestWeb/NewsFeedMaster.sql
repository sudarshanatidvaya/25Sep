USE [Auradies]
GO

/****** Object:  Table [dbo].[NewsFeedMaster]    Script Date: 09/02/2016 18:34:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NewsFeedMaster]') AND type in (N'U'))
DROP TABLE [dbo].[NewsFeedMaster]
GO

USE [Auradies]
GO

/****** Object:  Table [dbo].[NewsFeedMaster]    Script Date: 09/02/2016 18:34:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NewsFeedMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserImageID] [nvarchar](50) NULL,
	[StatusMessage] [nvarchar](200) NOT NULL,
	[StatusImageID] [nvarchar](max) NULL,
	[StatusLink] [nvarchar](max) NULL,
	[StatusDateTime] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_NewsFeedMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


