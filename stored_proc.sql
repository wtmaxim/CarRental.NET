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

CREATE PROCEDURE usp_User_List_All
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
GO

-- Liste des utilisteurs actifs
CREATE PROCEDURE usp_User_List_Active
AS
BEGIN
	SELECT *
	FROM [User]
	WHERE is_Active = 1
END
GO

-- Liste des utilisteurs non actifs
CREATE PROCEDURE usp_User_List_Unactive
AS
BEGIN
	SELECT *
	FROM [User]
	WHERE is_Active = 0
END
GO

-- Recherche d'un utilisateur
CREATE PROCEDURE usp_User_Get_Fistname_Lastname_Email
	@searchValue varchar(255)
AS
BEGIN
	SELECT Id, Firstname, Lastname, Email, [Password], is_Active, 
		Job, Note, Phone_Number, is_Address_Private, Id_Company
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

-- Ajout d'un utilisateur
CREATE PROCEDURE usp_User_Insert
	@firstname varchar(255),
	@lastname varchar(255),
	@email varchar(255),
	@password varchar(255),
	@isActive tinyint,
	@job varchar(255),
	@note text,
	@phoneNumber varchar(13),
	@isAddressPrivate tinyint,
	@idCompany int
AS
BEGIN
	INSERT INTO [User]
	VALUES (
		@firstname, @lastname, @email, @password, @isActive, @job, 
		@note, @phoneNumber, @isAddressPrivate, @idCompany
		)
END
GO

-- Ajout ou Insert d'un utilisateur
CREATE PROCEDURE usp_User_Insert_Or_Update
(
    @firstname varchar(255),
	@lastname varchar(255),
	@email varchar(255),
	@password varchar(255),
	@isActive tinyint,
	@job varchar(255),
	@note text,
	@phoneNumber varchar(13),
	@isAddressPrivate tinyint,
	@idCompany int
)
AS
BEGIN
    IF EXISTS (
		SELECT Id, Firstname, Lastname, Email, [Password], is_Active, 
			Job, Note, Phone_Number, is_Address_Private, Id_Company
		FROM [User]
        WHERE Email=@email
    )
    BEGIN
        UPDATE [User]
		SET
			Firstname = @firstname, 
			Lastname = @lastname, 
			Email = @email,
			is_Active = @isActive,
			Job = @job, 
			Note = @note, 
			Phone_Number = @phoneNumber, 
			is_Address_Private = @isAddressPrivate, 
			Id_Company = @idCompany
		WHERE Email=@email
    END
ELSE
    BEGIN
        INSERT INTO [User]
		VALUES (
			@firstname, @lastname, @email, @password, @isActive, @job, 
			@note, @phoneNumber, @isAddressPrivate, @idCompany
			)
    END

END
GO

-- Archivage d'un utilisateur
CREATE PROCEDURE usp_User_Archive
	@id INT
AS
BEGIN
	UPDATE [User]
	SET is_Active = 0
	WHERE id = @id
END
GO

-- De-archivage d'un utilisateur
CREATE PROCEDURE usp_User_Unarchive
	@id INT
AS
BEGIN
	UPDATE [User]
	SET is_Active = 1
	WHERE id = @id
END
GO
-- Ajout d'un role à un utilisateur à partir à l'aide de leurs id
CREATE PROCEDURE [dbo].[usp_UserRole_INSERT]
	@userID int,
	@RoleID int
AS
BEGIN
Insert into user_role (id_role, id_user) values (@RoleId, @userID)
END
GO

-- Vérifie que l'utilisateur en paramètre possède le role souhaité à partir de l'email de l'utilsateur et du nom du role
CREATE PROCEDURE [dbo].[usp_UserRole_GET_USER_IN_ROLE]
	@email varchar(255),
	@roleName varchar(255)
AS
BEGIN
	Select u.Id,u.Email,u.Firstname,u.Lastname,u.Id_Company,u.is_Active,u.is_Address_Private,U.Job,u.Note,u.[Password],u.Phone_Number
FROM [Role] r,[user_role] ur,[User] u
Where u.Id=ur.id_user
and r.Id=ur.id_role
and r.Libelle=@roleName
and u.Email=@email
END
GO

-- Récupère les roles d'un utilisateur à partir de son email
CREATE PROCEDURE [dbo].[usp_User_GET_List_Roles]
 @email varchar(255)
AS
BEGIN
Select r.Id, r.Libelle
from [Role] r, [user_role] ur, [User] u
WHERE u.Email=@email
and u.Id= ur.id_user
and ur.id_role=r.Id
END
GO

-- Récupère un role selon son nom
CREATE PROCEDURE [dbo].[usp_Role_GET]
@roleName varchar(255)
AS
BEGIN
select * from [Role] r
where r.Libelle= @roleName
END
GO

-- Récupère la liste des utilisateurs possédant un role selon le libelle
CREATE PROCEDURE [dbo].[usp_Role_GET_List_Users_BY_Libelle]
@roleName varchar(255)
AS 
BEGIN
Select u.Id,u.Email,u.Firstname,u.Id_Company,u.is_Active,u.is_Address_Private,U.Job,u.Lastname,u.Note,u.[Password],u.Phone_Number
FROM [Role] r,[user_role] ur,[User] u
Where u.Id=ur.id_user
and r.Id=ur.id_role
and r.Libelle=@roleName
END
GO
-- Ajoute un role
CREATE PROCEDURE [dbo].[usp_Role_Insert]
	@libelle varchar(255)	
AS
BEGIN
Insert INTO [Role] (Libelle) VALUES (@libelle)
END
GO

-- Liste des roles
CREATE PROCEDURE [dbo].[usp_Role_List]
AS
BEGIN
select * from [Role] r
END
GO

-- Récupère la liste des action auquel un utilisateur à accès à partir de son email
create procedure dbo.usp_Action_List_By_User
@email varchar(255)
as
BEGIN
select distinct a.Id,a.Libelle
from [Action] a,[ActionRole] ar ,[Role] r,[User] u , [user_role] ur
where u.Id =ur.id_user
and ur.id_role=r.Id
and r.Id= ar.Id_Role
and ar.Id_Action=a.Id
and u.Email = @email
END
GO

-- Récupère un role selon id
Create procedure usp_Role_Get_By_ID
@Id int
AS
BEGIN
Select * from [Role]
Where Id=@Id
END
GO

-- Company - List
CREATE PROCEDURE usp_Company_List
AS
BEGIN
	SELECT *
	FROM Company
END

