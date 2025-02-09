USE [BWUsers]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/17/2024 12:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[EmailAddress] [nvarchar](50) NULL
) ON [PRIMARY]
GO
