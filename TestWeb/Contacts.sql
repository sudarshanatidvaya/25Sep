USE [Auradies]
GO

/****** Object:  Table [dbo].[Contact]    Script Date: 09/02/2016 18:34:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contact]') AND type in (N'U'))
DROP TABLE [dbo].[Contact]
GO

USE [Auradies]
GO

/****** Object:  Table [dbo].[Contact]    Script Date: 09/02/2016 18:34:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Designation] [nvarchar](50) NULL,
	[ContactNumber] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NULL,
	[MailID] [nvarchar](max) NULL,
	[OfficeAddress] [nvarchar](max) NULL,
	[ImageID] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO