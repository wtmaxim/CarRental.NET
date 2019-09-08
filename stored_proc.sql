CREATE PROCEDURE usp_Adress_List
AS

BEGIN
	SELECT id, Street_Number, Locality, Postal_Code, Country, Administrative_Area, [Route], [Name]
	FROM [Address]
END
GO
CREATE PROCEDURE usp_Booking_Get_Id
	@id INT
AS
BEGIN
	SELECT Id, id_Request_Booking, is_Personal_Car_Used, Licence_Plate
	FROM Booking
	WHERE id = @id
END
GO
CREATE PROCEDURE usp_Booking_List_LicencePlate
	@licencePlate VARCHAR(25)
AS
BEGIN
	SELECT Id, id_Request_Booking, is_Personal_Car_Used, Licence_Plate
	FROM Booking
	WHERE Licence_Plate = @licencePlate
END
GO

CREATE PROCEDURE usp_Car_Get
	@licence_Plate VARCHAR(25)
AS
BEGIN
	SELECT is_Available, Mileage, Licence_Plate, Energy_Value, is_Active, Id_Company, Id_User, id_Car_Model
	FROM Car
	WHERE Licence_Plate = @licence_Plate
END
GO
CREATE PROCEDURE usp_Car_Insert
	@is_Available TINYINT,
	@mileage INT,
	@licencePlate VARCHAR(25),
	@energy_value INT,
	@is_Active TINYINT,
	@id_Company INT,
	@id_User INT,
	@id_Car_Model INT
AS
BEGIN

	INSERT INTO Car VALUES (@is_Available, @mileage, @licencePlate, @energy_value, @is_Active, @id_Company, @id_User, @id_Car_Model)

END
GO
CREATE PROCEDURE usp_Car_List
AS
BEGIN
	SELECT is_Available, Mileage, Licence_Plate, Energy_Value, is_Active, Id_Company, Id_User, id_Car_Model
	FROM Car
END
GO
CREATE PROCEDURE usp_CarMake_Get_Id
	@id INT
AS
BEGIN
	SELECT id, Make
	FROM CarMake
	WHERE id = @id
END
GO
CREATE PROCEDURE usp_CarMake_List
AS
BEGIN
	SELECT id, Make
	FROM CarMake
END
GO
CREATE PROCEDURE usp_CarModel_Get_id
	@id INT
AS
BEGIN
	SELECT id, Model, Places, Energy, id_Car_Make
	FROM CarModel
	WHERE id = @id
END
GO
CREATE PROCEDURE usp_CarModel_List_idMake
	@idMake INT
AS
BEGIN
	SELECT id, Model, Places, Energy, id_Car_Make
	FROM CarModel
	WHERE id_Car_Make = @idMake
END
GO
CREATE PROCEDURE usp_Event_List
	@licencePlate VARCHAR(25)
AS
BEGIN
	SELECT Id, Libelle, Start_Date, End_Date, Licence_Plate
	FROM Event
	WHERE Licence_Plate = @licencePlate
END
GO
CREATE PROCEDURE usp_StopOver_List_idBooking
	@idBooking INT
AS
BEGIN
	SELECT Id, Departure_Date, Arrival_Date, Id_Booking, Id_Stop_Over_Type
	FROM StopOver
	WHERE Id_Booking = @idBooking
END
GO
CREATE PROCEDURE usp_StopOverAddress_Get_idStopOver
	@idStopOver INT
AS
BEGIN
	SELECT is_Departure, id_Address, Id_Stop_Over
	FROM StopOverAddress
	WHERE Id_Stop_Over = @idStopOver
END
GO
CREATE PROCEDURE usp_StopOverType_Get_id
	@id INT
AS
BEGIN
	SELECT id, Libelle
	FROM StopOverType
	WHERE Id = @id
END

GO
CREATE PROCEDURE usp_CarModel_List_idMake
	@idMake INT
AS
BEGIN
	SELECT id, Model, Places, Energy, id_Car_Make
	FROM CarModel
	WHERE id_Car_Make = @idMake
END

GO
CREATE PROCEDURE usp_Event_List
	@licencePlate VARCHAR(25)
AS
BEGIN
	SELECT Id, Libelle, Start_Date, End_Date, Licence_Plate
	FROM Event
	WHERE Licence_Plate = @licencePlate
END

GO
CREATE PROCEDURE usp_PasswordResetToken_DELETE_BY_ID	
	@Id int
AS
BEGIN
	Delete from PasswordResetToken
	Where Id=@Id
END

GO
CREATE PROCEDURE usp_PasswordResetToken_get @token varchar(255)
AS
BEGIN
	SELECT * 
	FROM PasswordResetToken
	Where token = @token
END

GO
CREATE PROCEDURE usp_PasswordResetToken_Insert
@token varchar (255),
@expiry_date datetime,
@user_Id int
AS
BEGIN
	INSERT INTO PasswordResetToken(expiry_date,token,user_id)
	Values(@expiry_date,@token,@user_Id)
END

GO
CREATE PROCEDURE usp_User_GET @id int
AS
BEGIN
Select * from [User]
Where Id = @id
END

GO
CREATE PROCEDURE usp_User_GET_By_EMail @email Varchar(255)
AS
BEGIN
Select * from [User]
Where Email = @email
END

GO
CREATE PROCEDURE usp_User_Get_By_Email_And_Password
@Email Varchar(255),
@Password Varchar(255)

AS
BEGIN
Select * 
from [User]
Where Email = @Email
AND [Password] = @Password
END

GO
CREATE PROCEDURE usp_User_List
AS
BEGIN
Select * 
FROM [User]
END

GO
CREATE PROCEDURE usp_User_Update_Password
@password varchar(255),
@email varchar(255)
AS
BEGIN
UPDATE [User]
SET  Password = @password
Where Email = @email
END

-- Utilisateur - ajout idRole
ALTER TABLE [User] ADD Id_Role INT NOT NULL DEFAULT 0;
ALTER TABLE [User] ADD CONSTRAINT fk_Id_Role FOREIGN KEY (Id_Role) REFERENCES [Role](Id);
GO

-- Liste des utilisteurs
CREATE PROCEDURE usp_User_List
AS
BEGIN
	SELECT Id, Firstname, Lastname, Email, [Password], is_Active, 
		Job, Note, Phone_Number, is_Address_Private, Id_Company, Id_Role
	FROM [User]
	WHERE is_Active = 1
END
GO

-- Recherche d'un utilisateur
CREATE PROCEDURE usp_User_Get_Fistname_Lastname_Email
	@searchValue varchar
AS
BEGIN
	SELECT Id, Firstname, Lastname, Email, [Password], is_Active, 
		Job, Note, Phone_Number, is_Address_Private, Id_Company, Id_Role
	FROM [User]
	WHERE 
		(
			Firstname LIKE CONCAT('%', @searchValue,'%') OR
			Lastname LIKE CONCAT('%', @searchValue,'%') OR
			Email LIKE CONCAT('%', @searchValue,'%')
		)
		AND is_Active = 1
END
GO
