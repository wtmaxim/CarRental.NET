GO
create procedure [dbo].[usp_Action_List_By_User]
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
/****** Object:  StoredProcedure [dbo].[usp_Address_GetAddress]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Address_GetAddress]
	@IdBooking INT
AS
BEGIN

	SELECT address.Administrative_Area, address.Country, address.id, address.Locality, address.Name, address.Postal_Code, address.Route, address.Street_Number
	FROM StopOverAddress stopOverAddress
	INNER JOIN [Address] address ON stopOverAddress.id_Address = address.id
	INNER JOIN StopOver stopOver ON stopOver.Id = stopOverAddress.Id_Stop_Over
	INNER JOIN Booking booking ON stopOver.Id_Booking = booking.Id
	WHERE booking.Id = @IdBooking
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Adress_List]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Adress_List]
AS

BEGIN
	SELECT id, Street_Number, Locality, Postal_Code, Country, Administrative_Area, [Route], [Name]
	FROM [Address]
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Booking_Get_Id]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Booking_Get_Id]
	@id INT
AS
BEGIN
	SELECT Id, id_Request_Booking, is_Personal_Car_Used, Licence_Plate
	FROM Booking
	WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Booking_Get_idRequestBooking]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Booking_Get_idRequestBooking]
	@idRequestBooking INT
AS
BEGIN
	SELECT Id, id_Request_Booking, is_Personal_Car_Used, Licence_Plate
	FROM Booking
	WHERE id_Request_Booking = @idRequestBooking
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Booking_Insert]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Booking_Insert]
	@isPersonalCarUsed TINYINT,
	@idRequestBooking INT,
	@licencePlate VARCHAR(25)
AS
BEGIN
	INSERT INTO Booking (is_Personal_Car_Used, id_Request_Booking, Licence_Plate) VALUES (@isPersonalCarUsed, @idRequestBooking, @licencePlate)

	SELECT id, is_Personal_Car_Used, id_Request_Booking, Licence_Plate FROM Booking WHERE id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Booking_List_LicencePlate]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Booking_List_LicencePlate]
	@licencePlate VARCHAR(25)
AS
BEGIN
	SELECT Id, id_Request_Booking, is_Personal_Car_Used, Licence_Plate
	FROM Booking
	WHERE Licence_Plate = @licencePlate
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Car_Get]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Car_Get]
	@licence_Plate VARCHAR(25)
AS
BEGIN
	SELECT is_Available, Mileage, Licence_Plate, Energy_Value, is_Active, Id_Company, Id_User, id_Car_Model
	FROM Car
	WHERE Licence_Plate = @licence_Plate
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Car_Insert]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Car_Insert]
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
/****** Object:  StoredProcedure [dbo].[usp_Car_List]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Car_List]
AS
BEGIN
	SELECT is_Available, Mileage, Licence_Plate, Energy_Value, is_Active, Id_Company, Id_User, id_Car_Model
	FROM Car
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Car_List_Search]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Car_List_Search]
	@searchWord VARCHAR(MAX)
AS
BEGIN
	SELECT is_Available, Mileage, Licence_Plate, Energy_Value, is_Active, Id_Company, Id_User, id_Car_Model
	FROM Car
	WHERE Licence_Plate like '%'+@searchWord+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CarMake_Get_Id]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_CarMake_Get_Id]
	@id INT
AS
BEGIN
	SELECT id, Make
	FROM CarMake
	WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CarMake_List]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CarMake_List]
AS
BEGIN
	SELECT id, Make
	FROM CarMake
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CarModel_Get_id]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CarModel_Get_id]
	@id INT
AS
BEGIN
	SELECT id, Model, Places, Energy, id_Car_Make
	FROM CarModel
	WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CarModel_List_idMake]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CarModel_List_idMake]
	@idMake INT
AS
BEGIN
	SELECT id, Model, Places, Energy, id_Car_Make
	FROM CarModel
	WHERE id_Car_Make = @idMake
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Company_List]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Company - List
CREATE PROCEDURE [dbo].[usp_Company_List]
AS
BEGIN
	SELECT *
	FROM Company
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Event_List]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Event_List]
	@licencePlate VARCHAR(25)
AS
BEGIN
	SELECT Id, Libelle, Start_Date, End_Date, Licence_Plate
	FROM Event
	WHERE Licence_Plate = @licencePlate
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Notification_Insert]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Ajout d'une notification
CREATE PROCEDURE [dbo].[usp_Notification_Insert]
	@IdUser int,
	@IsRead tinyint,
	@IsForAdmin tinyint,
	@IsForNewRequest tinyint,
	@IdBooking int
AS
BEGIN
	INSERT INTO [Notification] (IdUser, IsRead, IsForAdmin, IsForNewRequest, IdBooking) 
	VALUES (@IdUser, @IsRead, @IsForAdmin, @IsForNewRequest, @IdBooking)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Notification_List]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Notification - List
CREATE PROCEDURE [dbo].[usp_Notification_List]
AS
BEGIN
select * from [Notification]
order by CreationDateTimestamp desc
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PasswordResetToken_DELETE_BY_ID]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_PasswordResetToken_DELETE_BY_ID]	
	@Id int
AS
BEGIN
	Delete from PasswordResetToken
	Where Id=@Id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_PasswordResetToken_get]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PasswordResetToken_get] @token varchar(255)
AS
BEGIN
	SELECT * 
	FROM PasswordResetToken
	Where token = @token
END

GO
/****** Object:  StoredProcedure [dbo].[usp_PasswordResetToken_Insert]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PasswordResetToken_Insert]
@token varchar (255),
@expiry_date datetime,
@user_Id int
AS
BEGIN
	INSERT INTO PasswordResetToken(expiry_date,token,user_id)
	Values(@expiry_date,@token,@user_Id)
END

GO
/****** Object:  StoredProcedure [dbo].[usp_RequestBooking_Get]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_RequestBooking_Get]
	@Id INT
AS
BEGIN
	SELECT r.Id, r.Id_Status, r.Date, r.is_Personal_Car_Available ,r.Reason, r.CreateBy
	FROM RequestBooking r
	WHERE r.id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_RequestBooking_Get_IdBooking]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_RequestBooking_Get_IdBooking]
	@IdBooking INT
AS
BEGIN
	SELECT r.Id, r.Id_Status, r.Date, r.is_Personal_Car_Available ,r.Reason, r.CreateBy
	FROM RequestBooking r
	INNER JOIN Booking b ON r.id = b.id_Request_Booking
	WHERE b.id_Request_Booking = @IdBooking
END
GO
/****** Object:  StoredProcedure [dbo].[usp_RequestBooking_Insert]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_RequestBooking_Insert]
	@isPersonalCarAvailable TINYINT,
	@Reason VARCHAR(255),
	@idStatut INT,
	@createBy INT
AS

BEGIN
	INSERT INTO RequestBooking (is_Personal_Car_Available, Date, Reason, Id_Status, CreateBy)
	VALUES (@isPersonalCarAvailable, GETDATE(), @Reason, @idStatut, @createBy)

	SELECT id, is_Personal_Car_Available, Date, Reason, Id_Status, CreateBy FROM RequestBooking WHERE id = @@Identity;
END

GO
/****** Object:  StoredProcedure [dbo].[usp_RequestBooking_List]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_RequestBooking_List]
AS
BEGIN
	SELECT id, is_Personal_Car_Available, Date, Reason, Id_Status, CreateBy
	FROM RequestBooking
END
GO
/****** Object:  StoredProcedure [dbo].[usp_RequestBooking_List_IdUser]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_RequestBooking_List_IdUser]
	@IdUser INT
AS
BEGIN
	SELECT id, is_Personal_Car_Available, Date, Reason, Id_Status, CreateBy
	FROM RequestBooking
	WHERE @IdUser = CreateBy
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Role_GET]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[usp_Role_GET_List_Users_BY_Libelle]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[usp_Role_List]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Liste des roles
CREATE PROCEDURE [dbo].[usp_Role_List]
AS
BEGIN
select * from [Role] r
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Status_Get]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Status_Get]
	@Id INT
AS
BEGIN
	SELECT Id, Libelle
	FROM [Status]
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_StopOver_Get_idBooking]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_StopOver_Get_idBooking]
	@idBooking INT
AS
BEGIN
	SELECT Id, Departure_Date, Arrival_Date, Id_Booking, Id_Stop_Over_Type
	FROM StopOver
	WHERE Id_Booking = @idBooking
END
GO
/****** Object:  StoredProcedure [dbo].[usp_StopOver_Insert]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_StopOver_Insert]
	@ArrivalDate DATE,
	@DepartureDate DATE,
	@IdBooking INT,
	@IdStopOverType INT
AS
BEGIN
	INSERT INTO StopOver (Arrival_Date, Departure_Date, Id_Booking, Id_Stop_Over_Type)
	VALUES (@ArrivalDate, @DepartureDate, @IdBooking, @IdStopOverType)

	SELECT Id, Departure_Date, Arrival_Date, Id_Booking, Id_Stop_Over_Type FROM StopOver WHERE Id = @@Identity;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_StopOver_List_idBooking]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_StopOver_List_idBooking]
	@idBooking INT
AS
BEGIN
	SELECT Id, Departure_Date, Arrival_Date, Id_Booking, Id_Stop_Over_Type
	FROM StopOver
	WHERE Id_Booking = @idBooking
END
GO
/****** Object:  StoredProcedure [dbo].[usp_StopOverAddress_Get_idStopOver]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_StopOverAddress_Get_idStopOver]
	@idStopOver INT
AS
BEGIN
	SELECT is_Departure, id_Address, Id_Stop_Over
	FROM StopOverAddress
	WHERE Id_Stop_Over = @idStopOver
END
GO
/****** Object:  StoredProcedure [dbo].[usp_StopOverAddress_Insert]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_StopOverAddress_Insert]
	@idAddress INT,
	@idStopOver INT,
	@isDeparture TINYINT
AS
BEGIN
	INSERT INTO StopOverAddress (id_Address, Id_Stop_Over, is_Departure)
	VALUES (@idAddress, @idStopOver, @isDeparture)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_StopOverType_Get_id]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_StopOverType_Get_id]
	@id INT
AS
BEGIN
	SELECT id, Libelle
	FROM StopOverType
	WHERE Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_User_GET]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_User_GET] @id int
AS
BEGIN
Select * from [User]
Where Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_User_GET_By_EMail]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_User_GET_By_EMail] @email Varchar(255)
AS
BEGIN
Select * from [User]
Where Email = @email
END

GO
/****** Object:  StoredProcedure [dbo].[usp_User_Get_By_Email_And_Password]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_User_Get_By_Email_And_Password]
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
/****** Object:  StoredProcedure [dbo].[usp_User_Get_Fistname_Lastname_Email]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Recherche d'un utilisateur
CREATE PROCEDURE [dbo].[usp_User_Get_Fistname_Lastname_Email]
	@searchValue varchar(255)
AS
BEGIN
	SELECT Id, Firstname, Lastname, Email, [Password], is_Active, Job, Note, Phone_Number, is_Address_Private, Id_Company
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
/****** Object:  StoredProcedure [dbo].[usp_User_GET_List_Roles]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[usp_User_GetDriver]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_User_GetDriver]
	@IdBooking INT,
	@isGoing TINYINT
AS
BEGIN
	
	SELECT Id, Firstname, Lastname, Email, Password, is_Active, Job, Note, Phone_Number, is_Address_Private, Id_Company
	FROM [User] u
	INNER JOIN UserBooking ub ON ub.Id_User = u.Id
	WHERE ub.Id_Booking = @IdBooking AND ub.is_Driver = 1 AND ub.is_Going = @isGoing
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Insert]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Ajout d'un utilisateur
CREATE PROCEDURE [dbo].[usp_User_Insert]
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
/****** Object:  StoredProcedure [dbo].[usp_User_Insert_Or_Update]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Ajout ou Insert d'un utilisateur
CREATE PROCEDURE [dbo].[usp_User_Insert_Or_Update]
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
/****** Object:  StoredProcedure [dbo].[usp_User_List]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_User_List]
AS
BEGIN
Select * 
FROM [User]
END

GO
/****** Object:  StoredProcedure [dbo].[usp_User_List_Active]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Liste des utilisteurs actifs
CREATE PROCEDURE [dbo].[usp_User_List_Active]
AS
BEGIN
	SELECT *
	FROM [User]
	WHERE is_Active = 1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_List_All]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_User_List_All]
AS
BEGIN
Select * 
FROM [User]
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_List_Unactive]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Liste des utilisteurs non actifs
CREATE PROCEDURE [dbo].[usp_User_List_Unactive]
AS
BEGIN
	SELECT *
	FROM [User]
	WHERE is_Active = 0
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_ListDrivers]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_User_ListDrivers]
	@IdBooking INT
AS
BEGIN
	
	SELECT Id, Firstname, Lastname, Email, Password, is_Active, Job, Note, Phone_Number, is_Address_Private, Id_Company
	FROM [User] u
	INNER JOIN UserBooking ub ON ub.Id_User = u.Id
	WHERE ub.Id_Booking = @IdBooking AND ub.is_Driver = 1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_ListPassagers]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_User_ListPassagers]
	@IdBooking INT
AS
BEGIN
	
	SELECT Id, Firstname, Lastname, Email, Password, is_Active, Job, Note, Phone_Number, is_Address_Private, Id_Company
	FROM [User] u
	INNER JOIN UserBooking ub ON ub.Id_User = u.Id
	WHERE ub.Id_Booking = @IdBooking AND ub.is_Driver = 0
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Update_Password]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_User_Update_Password]
@password varchar(255),
@email varchar(255)
AS
BEGIN
UPDATE [User]
SET  Password = @password
Where Email = @email
END

GO
/****** Object:  StoredProcedure [dbo].[usp_UserBooking_Insert]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_UserBooking_Insert]
	@isDriver TINYINT,
	@isGoing TINYINT,
	@idBooking INT,
	@idUser INT
AS

BEGIN
	INSERT INTO UserBooking(is_Driver, is_Going, Id_Booking, Id_User)
	VALUES (@isDriver, @isGoing, @idBooking, @idUser)
END

GO
/****** Object:  StoredProcedure [dbo].[usp_UserBooking_ListPassagers_IdBooking]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UserBooking_ListPassagers_IdBooking]
	@IdBooking INT
AS
BEGIN
	SELECT is_Driver, is_Going, Id_Booking, Id_User
	FROM UserBooking
	WHERE is_Driver = 0 AND Id_Booking = @IdBooking
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UserRole_GET_USER_IN_ROLE]    Script Date: 06/10/2019 14:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
