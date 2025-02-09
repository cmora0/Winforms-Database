USE [BWUsers]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 8/17/2024 12:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateUser]
	@Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @PhoneNumber NVARCHAR(15),
    @EmailAddress NVARCHAR(50)
AS
BEGIN
    UPDATE Users
    SET Username = @Username,
        Password = @Password,
        FirstName = @FirstName,
        LastName = @LastName,
        PhoneNumber = @PhoneNumber,
        EmailAddress = @EmailAddress
    WHERE Username = @Username;
END;
GO
