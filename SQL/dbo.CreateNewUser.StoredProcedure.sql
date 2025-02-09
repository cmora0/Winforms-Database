USE [BWUsers]
GO
/****** Object:  StoredProcedure [dbo].[CreateNewUser]    Script Date: 8/17/2024 12:27:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[CreateNewUser]
	@Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @PhoneNumber NVARCHAR(15),
    @EmailAddress NVARCHAR(50)
AS
BEGIN
    INSERT INTO Users (Username, Password, FirstName, LastName, PhoneNumber, EmailAddress)
    VALUES (@Username, @Password, @FirstName, @LastName, @PhoneNumber, @EmailAddress);
END;
GO
