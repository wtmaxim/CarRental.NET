
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/21/2019 19:36:25
-- Generated from EDMX file: D:\Users\will\Documents\CarRental.NET\CarRental.DAL\CarRentalModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CarRental];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__ActionRol__Id_Ac__2D27B809]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionRole] DROP CONSTRAINT [FK__ActionRol__Id_Ac__2D27B809];
GO
IF OBJECT_ID(N'[dbo].[FK__ActionRol__Id_Ro__2C3393D0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionRole] DROP CONSTRAINT [FK__ActionRol__Id_Ro__2C3393D0];
GO
IF OBJECT_ID(N'[dbo].[FK__Booking__id_Requ__5629CD9C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [FK__Booking__id_Requ__5629CD9C];
GO
IF OBJECT_ID(N'[dbo].[FK__Booking__Licence__5535A963]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Booking] DROP CONSTRAINT [FK__Booking__Licence__5535A963];
GO
IF OBJECT_ID(N'[dbo].[FK__Car__id_Car_Mode__52593CB8]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Car] DROP CONSTRAINT [FK__Car__id_Car_Mode__52593CB8];
GO
IF OBJECT_ID(N'[dbo].[FK__Car__Id_Company__5070F446]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Car] DROP CONSTRAINT [FK__Car__Id_Company__5070F446];
GO
IF OBJECT_ID(N'[dbo].[FK__Car__Id_User__5165187F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Car] DROP CONSTRAINT [FK__Car__Id_User__5165187F];
GO
IF OBJECT_ID(N'[dbo].[FK__CarModel__id_Car__3E52440B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarModel] DROP CONSTRAINT [FK__CarModel__id_Car__3E52440B];
GO
IF OBJECT_ID(N'[dbo].[FK__CarReport__Id_Bo__6B24EA82]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CarReport] DROP CONSTRAINT [FK__CarReport__Id_Bo__6B24EA82];
GO
IF OBJECT_ID(N'[dbo].[FK__Company__id_Addr__4222D4EF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Company] DROP CONSTRAINT [FK__Company__id_Addr__4222D4EF];
GO
IF OBJECT_ID(N'[dbo].[FK__Cost__Id_Booking__5CD6CB2B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cost] DROP CONSTRAINT [FK__Cost__Id_Booking__5CD6CB2B];
GO
IF OBJECT_ID(N'[dbo].[FK__Cost__Id_Categor__5DCAEF64]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cost] DROP CONSTRAINT [FK__Cost__Id_Categor__5DCAEF64];
GO
IF OBJECT_ID(N'[dbo].[FK__Event__Licence_P__60A75C0F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Event] DROP CONSTRAINT [FK__Event__Licence_P__60A75C0F];
GO
IF OBJECT_ID(N'[dbo].[FK__RequestBo__Id_St__34C8D9D1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequestBooking] DROP CONSTRAINT [FK__RequestBo__Id_St__34C8D9D1];
GO
IF OBJECT_ID(N'[dbo].[FK__StopOver__Id_Boo__6383C8BA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StopOver] DROP CONSTRAINT [FK__StopOver__Id_Boo__6383C8BA];
GO
IF OBJECT_ID(N'[dbo].[FK__StopOver__Id_Sto__6477ECF3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StopOver] DROP CONSTRAINT [FK__StopOver__Id_Sto__6477ECF3];
GO
IF OBJECT_ID(N'[dbo].[FK__StopOverA__id_Ad__68487DD7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StopOverAddress] DROP CONSTRAINT [FK__StopOverA__id_Ad__68487DD7];
GO
IF OBJECT_ID(N'[dbo].[FK__StopOverA__Id_St__6754599E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StopOverAddress] DROP CONSTRAINT [FK__StopOverA__Id_St__6754599E];
GO
IF OBJECT_ID(N'[dbo].[FK__User__Id_Company__45F365D3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK__User__Id_Company__45F365D3];
GO
IF OBJECT_ID(N'[dbo].[FK__user_addr__id_ad__4D94879B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[user_address] DROP CONSTRAINT [FK__user_addr__id_ad__4D94879B];
GO
IF OBJECT_ID(N'[dbo].[FK__user_addr__id_us__4CA06362]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[user_address] DROP CONSTRAINT [FK__user_addr__id_us__4CA06362];
GO
IF OBJECT_ID(N'[dbo].[FK__user_role__id_ro__49C3F6B7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[user_role] DROP CONSTRAINT [FK__user_role__id_ro__49C3F6B7];
GO
IF OBJECT_ID(N'[dbo].[FK__user_role__id_us__48CFD27E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[user_role] DROP CONSTRAINT [FK__user_role__id_us__48CFD27E];
GO
IF OBJECT_ID(N'[dbo].[FK__UserBooki__Id_Bo__59063A47]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserBooking] DROP CONSTRAINT [FK__UserBooki__Id_Bo__59063A47];
GO
IF OBJECT_ID(N'[dbo].[FK__UserBooki__Id_Us__59FA5E80]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserBooking] DROP CONSTRAINT [FK__UserBooki__Id_Us__59FA5E80];
GO
IF OBJECT_ID(N'[dbo].[FK_PasswordResetToken_UserID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PasswordResetToken] DROP CONSTRAINT [FK_PasswordResetToken_UserID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Action]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Action];
GO
IF OBJECT_ID(N'[dbo].[ActionRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionRole];
GO
IF OBJECT_ID(N'[dbo].[Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Address];
GO
IF OBJECT_ID(N'[dbo].[Booking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Booking];
GO
IF OBJECT_ID(N'[dbo].[Car]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Car];
GO
IF OBJECT_ID(N'[dbo].[CarMake]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarMake];
GO
IF OBJECT_ID(N'[dbo].[CarModel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarModel];
GO
IF OBJECT_ID(N'[dbo].[CarReport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarReport];
GO
IF OBJECT_ID(N'[dbo].[CategoryCost]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoryCost];
GO
IF OBJECT_ID(N'[dbo].[Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company];
GO
IF OBJECT_ID(N'[dbo].[Cost]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cost];
GO
IF OBJECT_ID(N'[dbo].[Event]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Event];
GO
IF OBJECT_ID(N'[dbo].[PasswordResetToken]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PasswordResetToken];
GO
IF OBJECT_ID(N'[dbo].[RequestBooking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RequestBooking];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[StopOver]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StopOver];
GO
IF OBJECT_ID(N'[dbo].[StopOverAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StopOverAddress];
GO
IF OBJECT_ID(N'[dbo].[StopOverType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StopOverType];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[user_address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user_address];
GO
IF OBJECT_ID(N'[dbo].[user_role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user_role];
GO
IF OBJECT_ID(N'[dbo].[UserBooking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserBooking];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Action'
CREATE TABLE [dbo].[Action] (
    [Libelle] varchar(255)  NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Address'
CREATE TABLE [dbo].[Address] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Street_Number] varchar(7)  NULL,
    [Locality] varchar(50)  NOT NULL,
    [Postal_Code] varchar(5)  NOT NULL,
    [Country] varchar(50)  NOT NULL,
    [Administrative_Area] varchar(50)  NULL,
    [Route] varchar(255)  NOT NULL,
    [Name] varchar(255)  NULL
);
GO

-- Creating table 'Booking'
CREATE TABLE [dbo].[Booking] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [is_Personal_Car_Used] tinyint  NOT NULL,
    [Licence_Plate] varchar(25)  NOT NULL,
    [id_Request_Booking] int  NOT NULL
);
GO

-- Creating table 'Car'
CREATE TABLE [dbo].[Car] (
    [is_Available] tinyint  NOT NULL,
    [Mileage] int  NOT NULL,
    [Licence_Plate] varchar(25)  NOT NULL,
    [Energy_Value] int  NOT NULL,
    [is_Active] tinyint  NOT NULL,
    [Id_Company] int  NOT NULL,
    [Id_User] int  NOT NULL,
    [id_Car_Model] int  NOT NULL
);
GO

-- Creating table 'CarMake'
CREATE TABLE [dbo].[CarMake] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Make] varchar(50)  NOT NULL
);
GO

-- Creating table 'CarModel'
CREATE TABLE [dbo].[CarModel] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Model] varchar(255)  NOT NULL,
    [Places] int  NULL,
    [Energy] varchar(15)  NULL,
    [id_Car_Make] int  NOT NULL
);
GO

-- Creating table 'CarReport'
CREATE TABLE [dbo].[CarReport] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Information] varchar(max)  NULL,
    [Libelle] varchar(255)  NOT NULL,
    [Id_Booking] int  NOT NULL
);
GO

-- Creating table 'CategoryCost'
CREATE TABLE [dbo].[CategoryCost] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] varchar(255)  NOT NULL
);
GO

-- Creating table 'Company'
CREATE TABLE [dbo].[Company] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [id_Address] int  NOT NULL
);
GO

-- Creating table 'Cost'
CREATE TABLE [dbo].[Cost] (
    [Libelle] varchar(255)  NOT NULL,
    [Price] int  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL,
    [Id_Booking] int  NOT NULL,
    [Id_Category_Cost] int  NOT NULL
);
GO

-- Creating table 'Event'
CREATE TABLE [dbo].[Event] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] int  NOT NULL,
    [Start_Date] datetime  NOT NULL,
    [End_Date] datetime  NOT NULL,
    [Licence_Plate] varchar(25)  NOT NULL
);
GO

-- Creating table 'RequestBooking'
CREATE TABLE [dbo].[RequestBooking] (
    [id] int IDENTITY(1,1) NOT NULL,
    [is_Personal_Car_Available] tinyint  NOT NULL,
    [Date] datetime  NOT NULL,
    [Reason] varchar(255)  NOT NULL,
    [Id_Status] int  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] varchar(255)  NOT NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] varchar(255)  NOT NULL
);
GO

-- Creating table 'StopOver'
CREATE TABLE [dbo].[StopOver] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Departure_Date] datetime  NOT NULL,
    [Arrival_Date] datetime  NOT NULL,
    [Id_Booking] int  NOT NULL,
    [Id_Stop_Over_Type] int  NOT NULL
);
GO

-- Creating table 'StopOverAddress'
CREATE TABLE [dbo].[StopOverAddress] (
    [is_Departure] tinyint  NOT NULL,
    [Id_Stop_Over] int  NOT NULL,
    [id_Address] int  NOT NULL
);
GO

-- Creating table 'StopOverType'
CREATE TABLE [dbo].[StopOverType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] varchar(255)  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Firstname] varchar(255)  NOT NULL,
    [Lastname] varchar(255)  NOT NULL,
    [Email] varchar(255)  NOT NULL,
    [Password] varchar(255)  NOT NULL,
    [is_Active] tinyint  NOT NULL,
    [Job] varchar(255)  NOT NULL,
    [Note] varchar(max)  NULL,
    [Phone_Number] varchar(13)  NULL,
    [is_Address_Private] tinyint  NOT NULL,
    [Id_Company] int  NULL
);
GO

-- Creating table 'user_address'
CREATE TABLE [dbo].[user_address] (
    [id_user] int  NOT NULL,
    [id_address] int  NOT NULL,
    [address_Name] varchar(50)  NULL
);
GO

-- Creating table 'UserBooking'
CREATE TABLE [dbo].[UserBooking] (
    [is_Driver] tinyint  NOT NULL,
    [is_Going] tinyint  NOT NULL,
    [Id_Booking] int  NOT NULL,
    [Id_User] int  NOT NULL
);
GO

-- Creating table 'PasswordResetToken'
CREATE TABLE [dbo].[PasswordResetToken] (
    [Id] int  NOT NULL,
    [expiry_date] datetime  NULL,
    [token] varchar(255)  NULL,
    [user_id] int  NOT NULL
);
GO

-- Creating table 'ActionRole'
CREATE TABLE [dbo].[ActionRole] (
    [Action_Id] int  NOT NULL,
    [Role_Id] int  NOT NULL
);
GO

-- Creating table 'user_role'
CREATE TABLE [dbo].[user_role] (
    [Role_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Action'
ALTER TABLE [dbo].[Action]
ADD CONSTRAINT [PK_Action]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Address'
ALTER TABLE [dbo].[Address]
ADD CONSTRAINT [PK_Address]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Booking'
ALTER TABLE [dbo].[Booking]
ADD CONSTRAINT [PK_Booking]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Licence_Plate] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [PK_Car]
    PRIMARY KEY CLUSTERED ([Licence_Plate] ASC);
GO

-- Creating primary key on [id] in table 'CarMake'
ALTER TABLE [dbo].[CarMake]
ADD CONSTRAINT [PK_CarMake]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CarModel'
ALTER TABLE [dbo].[CarModel]
ADD CONSTRAINT [PK_CarModel]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CarReport'
ALTER TABLE [dbo].[CarReport]
ADD CONSTRAINT [PK_CarReport]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoryCost'
ALTER TABLE [dbo].[CategoryCost]
ADD CONSTRAINT [PK_CategoryCost]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [PK_Company]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cost'
ALTER TABLE [dbo].[Cost]
ADD CONSTRAINT [PK_Cost]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Event'
ALTER TABLE [dbo].[Event]
ADD CONSTRAINT [PK_Event]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'RequestBooking'
ALTER TABLE [dbo].[RequestBooking]
ADD CONSTRAINT [PK_RequestBooking]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StopOver'
ALTER TABLE [dbo].[StopOver]
ADD CONSTRAINT [PK_StopOver]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [is_Departure], [Id_Stop_Over], [id_Address] in table 'StopOverAddress'
ALTER TABLE [dbo].[StopOverAddress]
ADD CONSTRAINT [PK_StopOverAddress]
    PRIMARY KEY CLUSTERED ([is_Departure], [Id_Stop_Over], [id_Address] ASC);
GO

-- Creating primary key on [Id] in table 'StopOverType'
ALTER TABLE [dbo].[StopOverType]
ADD CONSTRAINT [PK_StopOverType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id_user], [id_address] in table 'user_address'
ALTER TABLE [dbo].[user_address]
ADD CONSTRAINT [PK_user_address]
    PRIMARY KEY CLUSTERED ([id_user], [id_address] ASC);
GO

-- Creating primary key on [Id_Booking], [Id_User] in table 'UserBooking'
ALTER TABLE [dbo].[UserBooking]
ADD CONSTRAINT [PK_UserBooking]
    PRIMARY KEY CLUSTERED ([Id_Booking], [Id_User] ASC);
GO

-- Creating primary key on [Id] in table 'PasswordResetToken'
ALTER TABLE [dbo].[PasswordResetToken]
ADD CONSTRAINT [PK_PasswordResetToken]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Action_Id], [Role_Id] in table 'ActionRole'
ALTER TABLE [dbo].[ActionRole]
ADD CONSTRAINT [PK_ActionRole]
    PRIMARY KEY CLUSTERED ([Action_Id], [Role_Id] ASC);
GO

-- Creating primary key on [Role_Id], [User_Id] in table 'user_role'
ALTER TABLE [dbo].[user_role]
ADD CONSTRAINT [PK_user_role]
    PRIMARY KEY CLUSTERED ([Role_Id], [User_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_Address] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [FK__Company__id_Addr__4BAC3F29]
    FOREIGN KEY ([id_Address])
    REFERENCES [dbo].[Address]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Company__id_Addr__4BAC3F29'
CREATE INDEX [IX_FK__Company__id_Addr__4BAC3F29]
ON [dbo].[Company]
    ([id_Address]);
GO

-- Creating foreign key on [id_Address] in table 'StopOverAddress'
ALTER TABLE [dbo].[StopOverAddress]
ADD CONSTRAINT [FK__StopOverA__id_Ad__71D1E811]
    FOREIGN KEY ([id_Address])
    REFERENCES [dbo].[Address]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__StopOverA__id_Ad__71D1E811'
CREATE INDEX [IX_FK__StopOverA__id_Ad__71D1E811]
ON [dbo].[StopOverAddress]
    ([id_Address]);
GO

-- Creating foreign key on [id_address] in table 'user_address'
ALTER TABLE [dbo].[user_address]
ADD CONSTRAINT [FK__user_addr__id_ad__571DF1D5]
    FOREIGN KEY ([id_address])
    REFERENCES [dbo].[Address]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__user_addr__id_ad__571DF1D5'
CREATE INDEX [IX_FK__user_addr__id_ad__571DF1D5]
ON [dbo].[user_address]
    ([id_address]);
GO

-- Creating foreign key on [id_Request_Booking] in table 'Booking'
ALTER TABLE [dbo].[Booking]
ADD CONSTRAINT [FK__Booking__id_Requ__5FB337D6]
    FOREIGN KEY ([id_Request_Booking])
    REFERENCES [dbo].[RequestBooking]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Booking__id_Requ__5FB337D6'
CREATE INDEX [IX_FK__Booking__id_Requ__5FB337D6]
ON [dbo].[Booking]
    ([id_Request_Booking]);
GO

-- Creating foreign key on [Licence_Plate] in table 'Booking'
ALTER TABLE [dbo].[Booking]
ADD CONSTRAINT [FK__Booking__Licence__5EBF139D]
    FOREIGN KEY ([Licence_Plate])
    REFERENCES [dbo].[Car]
        ([Licence_Plate])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Booking__Licence__5EBF139D'
CREATE INDEX [IX_FK__Booking__Licence__5EBF139D]
ON [dbo].[Booking]
    ([Licence_Plate]);
GO

-- Creating foreign key on [Id_Booking] in table 'CarReport'
ALTER TABLE [dbo].[CarReport]
ADD CONSTRAINT [FK__CarReport__Id_Bo__74AE54BC]
    FOREIGN KEY ([Id_Booking])
    REFERENCES [dbo].[Booking]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CarReport__Id_Bo__74AE54BC'
CREATE INDEX [IX_FK__CarReport__Id_Bo__74AE54BC]
ON [dbo].[CarReport]
    ([Id_Booking]);
GO

-- Creating foreign key on [Id_Booking] in table 'Cost'
ALTER TABLE [dbo].[Cost]
ADD CONSTRAINT [FK__Cost__Id_Booking__66603565]
    FOREIGN KEY ([Id_Booking])
    REFERENCES [dbo].[Booking]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Cost__Id_Booking__66603565'
CREATE INDEX [IX_FK__Cost__Id_Booking__66603565]
ON [dbo].[Cost]
    ([Id_Booking]);
GO

-- Creating foreign key on [Id_Booking] in table 'StopOver'
ALTER TABLE [dbo].[StopOver]
ADD CONSTRAINT [FK__StopOver__Id_Boo__6D0D32F4]
    FOREIGN KEY ([Id_Booking])
    REFERENCES [dbo].[Booking]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__StopOver__Id_Boo__6D0D32F4'
CREATE INDEX [IX_FK__StopOver__Id_Boo__6D0D32F4]
ON [dbo].[StopOver]
    ([Id_Booking]);
GO

-- Creating foreign key on [Id_Booking] in table 'UserBooking'
ALTER TABLE [dbo].[UserBooking]
ADD CONSTRAINT [FK__UserBooki__Id_Bo__628FA481]
    FOREIGN KEY ([Id_Booking])
    REFERENCES [dbo].[Booking]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_Car_Model] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [FK__Car__id_Car_Mode__5BE2A6F2]
    FOREIGN KEY ([id_Car_Model])
    REFERENCES [dbo].[CarModel]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Car__id_Car_Mode__5BE2A6F2'
CREATE INDEX [IX_FK__Car__id_Car_Mode__5BE2A6F2]
ON [dbo].[Car]
    ([id_Car_Model]);
GO

-- Creating foreign key on [Id_Company] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [FK__Car__Id_Company__59FA5E80]
    FOREIGN KEY ([Id_Company])
    REFERENCES [dbo].[Company]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Car__Id_Company__59FA5E80'
CREATE INDEX [IX_FK__Car__Id_Company__59FA5E80]
ON [dbo].[Car]
    ([Id_Company]);
GO

-- Creating foreign key on [Id_User] in table 'Car'
ALTER TABLE [dbo].[Car]
ADD CONSTRAINT [FK__Car__Id_User__5AEE82B9]
    FOREIGN KEY ([Id_User])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Car__Id_User__5AEE82B9'
CREATE INDEX [IX_FK__Car__Id_User__5AEE82B9]
ON [dbo].[Car]
    ([Id_User]);
GO

-- Creating foreign key on [Licence_Plate] in table 'Event'
ALTER TABLE [dbo].[Event]
ADD CONSTRAINT [FK__Event__Licence_P__6A30C649]
    FOREIGN KEY ([Licence_Plate])
    REFERENCES [dbo].[Car]
        ([Licence_Plate])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Event__Licence_P__6A30C649'
CREATE INDEX [IX_FK__Event__Licence_P__6A30C649]
ON [dbo].[Event]
    ([Licence_Plate]);
GO

-- Creating foreign key on [id_Car_Make] in table 'CarModel'
ALTER TABLE [dbo].[CarModel]
ADD CONSTRAINT [FK__CarModel__id_Car__47DBAE45]
    FOREIGN KEY ([id_Car_Make])
    REFERENCES [dbo].[CarMake]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CarModel__id_Car__47DBAE45'
CREATE INDEX [IX_FK__CarModel__id_Car__47DBAE45]
ON [dbo].[CarModel]
    ([id_Car_Make]);
GO

-- Creating foreign key on [Id_Category_Cost] in table 'Cost'
ALTER TABLE [dbo].[Cost]
ADD CONSTRAINT [FK__Cost__Id_Categor__6754599E]
    FOREIGN KEY ([Id_Category_Cost])
    REFERENCES [dbo].[CategoryCost]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Cost__Id_Categor__6754599E'
CREATE INDEX [IX_FK__Cost__Id_Categor__6754599E]
ON [dbo].[Cost]
    ([Id_Category_Cost]);
GO

-- Creating foreign key on [Id_Company] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK__User__Id_Company__4F7CD00D]
    FOREIGN KEY ([Id_Company])
    REFERENCES [dbo].[Company]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__User__Id_Company__4F7CD00D'
CREATE INDEX [IX_FK__User__Id_Company__4F7CD00D]
ON [dbo].[User]
    ([Id_Company]);
GO

-- Creating foreign key on [Id_Status] in table 'RequestBooking'
ALTER TABLE [dbo].[RequestBooking]
ADD CONSTRAINT [FK__RequestBo__Id_St__3E52440B]
    FOREIGN KEY ([Id_Status])
    REFERENCES [dbo].[Status]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__RequestBo__Id_St__3E52440B'
CREATE INDEX [IX_FK__RequestBo__Id_St__3E52440B]
ON [dbo].[RequestBooking]
    ([Id_Status]);
GO

-- Creating foreign key on [Id_Stop_Over_Type] in table 'StopOver'
ALTER TABLE [dbo].[StopOver]
ADD CONSTRAINT [FK__StopOver__Id_Sto__6E01572D]
    FOREIGN KEY ([Id_Stop_Over_Type])
    REFERENCES [dbo].[StopOverType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__StopOver__Id_Sto__6E01572D'
CREATE INDEX [IX_FK__StopOver__Id_Sto__6E01572D]
ON [dbo].[StopOver]
    ([Id_Stop_Over_Type]);
GO

-- Creating foreign key on [Id_Stop_Over] in table 'StopOverAddress'
ALTER TABLE [dbo].[StopOverAddress]
ADD CONSTRAINT [FK__StopOverA__Id_St__70DDC3D8]
    FOREIGN KEY ([Id_Stop_Over])
    REFERENCES [dbo].[StopOver]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__StopOverA__Id_St__70DDC3D8'
CREATE INDEX [IX_FK__StopOverA__Id_St__70DDC3D8]
ON [dbo].[StopOverAddress]
    ([Id_Stop_Over]);
GO

-- Creating foreign key on [id_user] in table 'user_address'
ALTER TABLE [dbo].[user_address]
ADD CONSTRAINT [FK__user_addr__id_us__5629CD9C]
    FOREIGN KEY ([id_user])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id_User] in table 'UserBooking'
ALTER TABLE [dbo].[UserBooking]
ADD CONSTRAINT [FK__UserBooki__Id_Us__6383C8BA]
    FOREIGN KEY ([Id_User])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UserBooki__Id_Us__6383C8BA'
CREATE INDEX [IX_FK__UserBooki__Id_Us__6383C8BA]
ON [dbo].[UserBooking]
    ([Id_User]);
GO

-- Creating foreign key on [Action_Id] in table 'ActionRole'
ALTER TABLE [dbo].[ActionRole]
ADD CONSTRAINT [FK_ActionRole_Action]
    FOREIGN KEY ([Action_Id])
    REFERENCES [dbo].[Action]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role_Id] in table 'ActionRole'
ALTER TABLE [dbo].[ActionRole]
ADD CONSTRAINT [FK_ActionRole_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionRole_Role'
CREATE INDEX [IX_FK_ActionRole_Role]
ON [dbo].[ActionRole]
    ([Role_Id]);
GO

-- Creating foreign key on [Role_Id] in table 'user_role'
ALTER TABLE [dbo].[user_role]
ADD CONSTRAINT [FK_user_role_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [User_Id] in table 'user_role'
ALTER TABLE [dbo].[user_role]
ADD CONSTRAINT [FK_user_role_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_user_role_User'
CREATE INDEX [IX_FK_user_role_User]
ON [dbo].[user_role]
    ([User_Id]);
GO

-- Creating foreign key on [user_id] in table 'PasswordResetToken'
ALTER TABLE [dbo].[PasswordResetToken]
ADD CONSTRAINT [FK_PasswordResetToken_UserID]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PasswordResetToken_UserID'
CREATE INDEX [IX_FK_PasswordResetToken_UserID]
ON [dbo].[PasswordResetToken]
    ([user_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------