CREATE TABLE Action
(
  Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Libelle VARCHAR(255),
  CONSTRAINT AK_LibelleAction UNIQUE(Libelle)
);

CREATE TABLE ActionRole
(
  Id_Role INT NOT NULL,
  Id_Action INT NOT NULL,
  PRIMARY KEY (Id_Role, Id_Action),
  FOREIGN KEY (Id_Role) REFERENCES Role(Id),
  FOREIGN KEY (Id_Action) REFERENCES Action(Id)
);

CREATE TABLE Address
(
  id INT NOT NULL IDENTITY(1,1),
  Street_Number VARCHAR(7),
  Locality VARCHAR(50) NOT NULL,
  Postal_Code VARCHAR(5) NOT NULL,
  Country VARCHAR(50) NOT NULL,
  Administrative_Area VARCHAR(50),
  Route VARCHAR(255) NOT NULL,
  Name VARCHAR(255),
  PRIMARY KEY (id)
);

CREATE TABLE Booking
(
  Id INT NOT NULL IDENTITY(1,1),
  is_Personal_Car_Used TINYINT NOT NULL,
  Licence_Plate VARCHAR(25) NOT NULL,
  id_Request_Booking INT NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (Licence_Plate) REFERENCES Car(Licence_Plate),
  FOREIGN KEY (id_Request_Booking) REFERENCES RequestBooking(id)
);

CREATE TABLE Car
(
  is_Available TINYINT NOT NULL,
  Mileage INT NOT NULL,
  Licence_Plate VARCHAR(25) NOT NULL,
  Energy_Value INT NOT NULL,
  is_Active TINYINT NOT NULL,
  Id_Company INT NOT NULL,
  Id_User INT NOT NULL,
  id_Car_Model INT NOT NULL,
  PRIMARY KEY (Licence_Plate),
  FOREIGN KEY (Id_Company) REFERENCES Company(Id),
  FOREIGN KEY (Id_User) REFERENCES [User](Id),
  FOREIGN KEY (id_Car_Model) REFERENCES CarModel(id)
);

CREATE TABLE CarModel
(
  id INT NOT NULL IDENTITY(1,1),
  Model VARCHAR(255) NOT NULL,
  Places INT,
  Energy VARCHAR(15),
  id_Car_Make INT NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (id_Car_Make) REFERENCES CarMake(id),
  CONSTRAINT AK_ModelCarModel UNIQUE(Model)
);

CREATE TABLE CarMake
(
  id INT NOT NULL IDENTITY(1,1),
  Make VARCHAR(50) NOT NULL,
  PRIMARY KEY (id),
  CONSTRAINT AK_MakeCarMake UNIQUE(Make)
);

CREATE TABLE CarReport
(
  id INT NOT NULL IDENTITY(1,1),
  Information TEXT,
  Libelle varchar(255) NOT NULL,
  Id_Booking INT NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (Id_Booking) REFERENCES Booking(Id)
);

CREATE TABLE CategoryCost
(
  Id INT NOT NULL IDENTITY(1,1),
  Libelle VARCHAR(255) NOT NULL,
  PRIMARY KEY (Id),
  CONSTRAINT AK_LibelleCategoryCost UNIQUE(Libelle)
);

CREATE TABLE Company
(
  Id INT NOT NULL IDENTITY(1,1),
  Name VARCHAR(255) NOT NULL,
  id_Address INT NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (id_Address) REFERENCES Address(id),
  CONSTRAINT AK_NameCompany UNIQUE(Name)
);

CREATE TABLE Cost
(
  Libelle VARCHAR(255) NOT NULL,
  Price INT NOT NULL,
  Id INT NOT NULL IDENTITY(1,1),
  Id_Booking INT NOT NULL,
  Id_Category_Cost INT NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (Id_Booking) REFERENCES Booking(Id),
  FOREIGN KEY (Id_Category_Cost) REFERENCES CategoryCost(Id)
);

CREATE TABLE Event
(
  Id INT NOT NULL IDENTITY(1,1),
  Libelle VARCHAR(255) NOT NULL,
  Start_Date DATE NOT NULL,
  End_Date DATE NOT NULL,
  Licence_Plate VARCHAR(25) NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (Licence_Plate) REFERENCES Car(Licence_Plate)
);

CREATE TABLE [Notification]
(
  Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  IdUser INT NOT NULL,
  IsRead TINYINT NOT NULL,
  CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
  IsForAdmin TINYINT NOT NULL,
  IsForNewRequest TINYINT  NOT NULL DEFAULT 0,
  IdBooking INT NOT NULL,
  FOREIGN KEY (IdUser) REFERENCES [User](Id),
  FOREIGN KEY (IdBooking) REFERENCES [Booking](Id),
);

CREATE TABLE PasswordResetToken (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [expiry_date] DATETIME      NULL,
    [token]       VARCHAR (255) NULL,
    [user_id]     INT           NOT NULL,
    CONSTRAINT [PK_ID] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PasswordResetToken_UserID] FOREIGN KEY (user_id) REFERENCES [User] (Id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE RequestBooking
(
  id INT NOT NULL IDENTITY(1,1),
  is_Personal_Car_Available TINYINT NOT NULL,
  Date DATE NOT NULL,
  Reason VARCHAR(255) NOT NULL,
  Id_Status INT NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (Id_Status) REFERENCES Status(Id)
);

CREATE TABLE Role
(
  Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Libelle VARCHAR(255) NOT NULL,
  CONSTRAINT AK_LibelleRole UNIQUE(Libelle)  
);

CREATE TABLE Status
(
  Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Libelle VARCHAR(255) NOT NULL,
  CONSTRAINT AK_LibelleStatus UNIQUE(Libelle)
);

CREATE TABLE StopOver
(
  Id INT NOT NULL IDENTITY(1,1),
  Departure_Date DATE NOT NULL,
  Arrival_Date DATE NOT NULL,
  Id_Booking INT NOT NULL,
  Id_Stop_Over_Type INT NOT NULL,
  PRIMARY KEY (Id),
  FOREIGN KEY (Id_Booking) REFERENCES Booking(Id),
  FOREIGN KEY (Id_Stop_Over_Type) REFERENCES StopOverType(Id)
);

CREATE TABLE StopOverAddress
(
  is_Departure TINYINT NOT NULL,
  Id_Stop_Over INT NOT NULL,
  id_Address INT NOT NULL,
  PRIMARY KEY (is_Departure, Id_Stop_Over, id_Address),
  FOREIGN KEY (Id_Stop_Over) REFERENCES StopOver(Id),
  FOREIGN KEY (id_Address) REFERENCES Address(id)
);

CREATE TABLE StopOverType
(
  Id INT NOT NULL IDENTITY(1,1),
  Libelle VARCHAR(255) NOT NULL,
  PRIMARY KEY (Id),
  CONSTRAINT AK_LibelleStopOverType UNIQUE(Libelle)
);

CREATE TABLE [User]
(
  Id INT NOT NULL IDENTITY(1,1),
  Firstname VARCHAR(255) NOT NULL,
  Lastname VARCHAR(255) NOT NULL,
  Email VARCHAR(255) NOT NULL,
  Password VARCHAR(255) NOT NULL,
  is_Active TINYINT NOT NULL,
  Job VARCHAR(255) NOT NULL,
  Note TEXT,
  Phone_Number VARCHAR(13),
  is_Address_Private TINYINT NOT NULL,
  Id_Company INT, 
  PRIMARY KEY (Id),  
  FOREIGN KEY (Id_Company) REFERENCES Company(Id),  
  CONSTRAINT AK_EmailUser UNIQUE(Email)
);

CREATE TABLE user_role(
id_user int not null,
id_role int not null,
primary key(id_user,id_role),
foreign key (id_user) references [User](id),
foreign key (id_role) references role(id)
);

Create Table user_address(
id_user int not null,
id_address int not null,
address_Name varchar(50),
primary key(id_user, id_address),
foreign key (id_user) references [User](id),
foreign key (id_address) references address(id)
);

CREATE TABLE UserBooking
(
  is_Driver TINYINT NOT NULL,
  is_Going TINYINT NOT NULL,
  Id_Booking INT NOT NULL,
  Id_User INT NOT NULL,
  PRIMARY KEY (Id_Booking, Id_User),
  FOREIGN KEY (Id_Booking) REFERENCES Booking(Id),
  FOREIGN KEY (Id_User) REFERENCES [User](Id)
);