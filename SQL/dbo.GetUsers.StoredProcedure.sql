USE [BWUsers]
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 8/17/2024 12:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetUsers]
AS
SELECT * FROM Users
GO
