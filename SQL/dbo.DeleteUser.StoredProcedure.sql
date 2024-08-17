USE [BWUsers]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 8/17/2024 12:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[DeleteUser]
	@Username NVARCHAR(50)
AS
BEGIN
	DELETE FROM Users WHERE Username = @Username;
END;	
GO
