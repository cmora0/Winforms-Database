USE [BWUsers]
GO
/****** Object:  StoredProcedure [dbo].[ValidateUser]    Script Date: 8/17/2024 12:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ValidateUser]
	@Username NVARCHAR(50),
	@Password NVARCHAR(50)
AS
BEGIN
	SELECT COUNT(*)
	FROM Users
	WHERE Username = @Username AND Password = @Password
END;
GO
