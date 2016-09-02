USE [Auradies]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_NewsFeedComment_NewsFeedMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[NewsFeedComment]'))
ALTER TABLE [dbo].[NewsFeedComment] DROP CONSTRAINT [FK_NewsFeedComment_NewsFeedMaster]
GO

USE [Auradies]
GO

/****** Object:  Table [dbo].[NewsFeedComment]    Script Date: 09/02/2016 18:36:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NewsFeedComment]') AND type in (N'U'))
DROP TABLE [dbo].[NewsFeedComment]
GO

USE [Auradies]
GO

/****** Object:  Table [dbo].[NewsFeedComment]    Script Date: 09/02/2016 18:36:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NewsFeedComment](
	[ID] [int]  IDENTITY(1,1) NOT NULL,
	[NewsFeedID] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserImageID] [nvarchar](max) NULL,
	[Comment] [nvarchar](150) NOT NULL,
	[CommentDateTime] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_NewsFeedComment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[NewsFeedComment]  WITH CHECK ADD  CONSTRAINT [FK_NewsFeedComment_NewsFeedMaster] FOREIGN KEY([NewsFeedID])
REFERENCES [dbo].[NewsFeedMaster] ([ID])
GO

ALTER TABLE [dbo].[NewsFeedComment] CHECK CONSTRAINT [FK_NewsFeedComment_NewsFeedMaster]
GO


