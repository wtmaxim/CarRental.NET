﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRental.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CarRentalEntities : DbContext
    {
        public CarRentalEntities()
            : base("name=CarRentalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarMake> CarMake { get; set; }
        public virtual DbSet<CarModel> CarModel { get; set; }
        public virtual DbSet<CarReport> CarReport { get; set; }
        public virtual DbSet<CategoryCost> CategoryCost { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Cost> Cost { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<RequestBooking> RequestBooking { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<StopOver> StopOver { get; set; }
        public virtual DbSet<StopOverAddress> StopOverAddress { get; set; }
        public virtual DbSet<StopOverType> StopOverType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<user_address> user_address { get; set; }
        public virtual DbSet<UserBooking> UserBooking { get; set; }
        public virtual DbSet<PasswordResetToken> PasswordResetToken { get; set; }
    
        public virtual ObjectResult<Car> usp_Car_Get(string licence_Plate)
        {
            var licence_PlateParameter = licence_Plate != null ?
                new ObjectParameter("licence_Plate", licence_Plate) :
                new ObjectParameter("licence_Plate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Car>("usp_Car_Get", licence_PlateParameter);
        }
    
        public virtual ObjectResult<Car> usp_Car_Get(string licence_Plate, MergeOption mergeOption)
        {
            var licence_PlateParameter = licence_Plate != null ?
                new ObjectParameter("licence_Plate", licence_Plate) :
                new ObjectParameter("licence_Plate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Car>("usp_Car_Get", mergeOption, licence_PlateParameter);
        }
    
        public virtual ObjectResult<Car> usp_Car_List()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Car>("usp_Car_List");
        }
    
        public virtual ObjectResult<Car> usp_Car_List(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Car>("usp_Car_List", mergeOption);
        }
    
        public virtual int usp_Car_Insert(Nullable<byte> is_Available, Nullable<int> mileage, string licencePlate, Nullable<int> energy_value, Nullable<byte> is_Active, Nullable<int> id_Company, Nullable<int> id_User, Nullable<int> id_Car_Model)
        {
            var is_AvailableParameter = is_Available.HasValue ?
                new ObjectParameter("is_Available", is_Available) :
                new ObjectParameter("is_Available", typeof(byte));
    
            var mileageParameter = mileage.HasValue ?
                new ObjectParameter("mileage", mileage) :
                new ObjectParameter("mileage", typeof(int));
    
            var licencePlateParameter = licencePlate != null ?
                new ObjectParameter("licencePlate", licencePlate) :
                new ObjectParameter("licencePlate", typeof(string));
    
            var energy_valueParameter = energy_value.HasValue ?
                new ObjectParameter("energy_value", energy_value) :
                new ObjectParameter("energy_value", typeof(int));
    
            var is_ActiveParameter = is_Active.HasValue ?
                new ObjectParameter("is_Active", is_Active) :
                new ObjectParameter("is_Active", typeof(byte));
    
            var id_CompanyParameter = id_Company.HasValue ?
                new ObjectParameter("id_Company", id_Company) :
                new ObjectParameter("id_Company", typeof(int));
    
            var id_UserParameter = id_User.HasValue ?
                new ObjectParameter("id_User", id_User) :
                new ObjectParameter("id_User", typeof(int));
    
            var id_Car_ModelParameter = id_Car_Model.HasValue ?
                new ObjectParameter("id_Car_Model", id_Car_Model) :
                new ObjectParameter("id_Car_Model", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_Car_Insert", is_AvailableParameter, mileageParameter, licencePlateParameter, energy_valueParameter, is_ActiveParameter, id_CompanyParameter, id_UserParameter, id_Car_ModelParameter);
        }
    
        public virtual ObjectResult<Address> usp_Adress_List()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Address>("usp_Adress_List");
        }
    
        public virtual ObjectResult<Address> usp_Adress_List(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Address>("usp_Adress_List", mergeOption);
        }
    
        public virtual ObjectResult<CarModel> usp_CarModel_Get_id(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CarModel>("usp_CarModel_Get_id", idParameter);
        }
    
        public virtual ObjectResult<CarModel> usp_CarModel_Get_id(Nullable<int> id, MergeOption mergeOption)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CarModel>("usp_CarModel_Get_id", mergeOption, idParameter);
        }
    
        public virtual ObjectResult<CarMake> usp_CarMake_Get_Id(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CarMake>("usp_CarMake_Get_Id", idParameter);
        }
    
        public virtual ObjectResult<CarMake> usp_CarMake_Get_Id(Nullable<int> id, MergeOption mergeOption)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CarMake>("usp_CarMake_Get_Id", mergeOption, idParameter);
        }
    
        public virtual ObjectResult<Booking> usp_Booking_Get_Id(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Booking>("usp_Booking_Get_Id", idParameter);
        }
    
        public virtual ObjectResult<Booking> usp_Booking_Get_Id(Nullable<int> id, MergeOption mergeOption)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Booking>("usp_Booking_Get_Id", mergeOption, idParameter);
        }
    
        public virtual ObjectResult<Booking> usp_Booking_List_LicencePlate(string licencePlate)
        {
            var licencePlateParameter = licencePlate != null ?
                new ObjectParameter("licencePlate", licencePlate) :
                new ObjectParameter("licencePlate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Booking>("usp_Booking_List_LicencePlate", licencePlateParameter);
        }
    
        public virtual ObjectResult<Booking> usp_Booking_List_LicencePlate(string licencePlate, MergeOption mergeOption)
        {
            var licencePlateParameter = licencePlate != null ?
                new ObjectParameter("licencePlate", licencePlate) :
                new ObjectParameter("licencePlate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Booking>("usp_Booking_List_LicencePlate", mergeOption, licencePlateParameter);
        }
    
        public virtual ObjectResult<StopOver> usp_StopOver_List_idBooking(Nullable<int> idBooking)
        {
            var idBookingParameter = idBooking.HasValue ?
                new ObjectParameter("idBooking", idBooking) :
                new ObjectParameter("idBooking", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StopOver>("usp_StopOver_List_idBooking", idBookingParameter);
        }
    
        public virtual ObjectResult<StopOver> usp_StopOver_List_idBooking(Nullable<int> idBooking, MergeOption mergeOption)
        {
            var idBookingParameter = idBooking.HasValue ?
                new ObjectParameter("idBooking", idBooking) :
                new ObjectParameter("idBooking", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StopOver>("usp_StopOver_List_idBooking", mergeOption, idBookingParameter);
        }
    
        public virtual ObjectResult<StopOverAddress> usp_StopOverAddress_Get_idStopOver(Nullable<int> idStopOver)
        {
            var idStopOverParameter = idStopOver.HasValue ?
                new ObjectParameter("idStopOver", idStopOver) :
                new ObjectParameter("idStopOver", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StopOverAddress>("usp_StopOverAddress_Get_idStopOver", idStopOverParameter);
        }
    
        public virtual ObjectResult<StopOverAddress> usp_StopOverAddress_Get_idStopOver(Nullable<int> idStopOver, MergeOption mergeOption)
        {
            var idStopOverParameter = idStopOver.HasValue ?
                new ObjectParameter("idStopOver", idStopOver) :
                new ObjectParameter("idStopOver", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StopOverAddress>("usp_StopOverAddress_Get_idStopOver", mergeOption, idStopOverParameter);
        }
    
        public virtual ObjectResult<StopOverType> usp_StopOverType_Get_id(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StopOverType>("usp_StopOverType_Get_id", idParameter);
        }
    
        public virtual ObjectResult<StopOverType> usp_StopOverType_Get_id(Nullable<int> id, MergeOption mergeOption)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StopOverType>("usp_StopOverType_Get_id", mergeOption, idParameter);
        }
    
        public virtual ObjectResult<CarMake> usp_CarMake_List()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CarMake>("usp_CarMake_List");
        }
    
        public virtual ObjectResult<CarMake> usp_CarMake_List(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CarMake>("usp_CarMake_List", mergeOption);
        }
    
        public virtual ObjectResult<CarModel> usp_CarModel_List_idMake(Nullable<int> idMake)
        {
            var idMakeParameter = idMake.HasValue ?
                new ObjectParameter("idMake", idMake) :
                new ObjectParameter("idMake", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CarModel>("usp_CarModel_List_idMake", idMakeParameter);
        }
    
        public virtual ObjectResult<CarModel> usp_CarModel_List_idMake(Nullable<int> idMake, MergeOption mergeOption)
        {
            var idMakeParameter = idMake.HasValue ?
                new ObjectParameter("idMake", idMake) :
                new ObjectParameter("idMake", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CarModel>("usp_CarModel_List_idMake", mergeOption, idMakeParameter);
        }
    
        public virtual ObjectResult<usp_Event_List_Result> usp_Event_List(string licencePlate)
        {
            var licencePlateParameter = licencePlate != null ?
                new ObjectParameter("licencePlate", licencePlate) :
                new ObjectParameter("licencePlate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_Event_List_Result>("usp_Event_List", licencePlateParameter);
        }
    
        public virtual ObjectResult<User> usp_User_GET(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("usp_User_GET", emailParameter);
        }
    
        public virtual ObjectResult<User> usp_User_GET(string email, MergeOption mergeOption)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("usp_User_GET", mergeOption, emailParameter);
        }
    
        public virtual ObjectResult<User> Usp_User_List()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("Usp_User_List");
        }
    
        public virtual ObjectResult<User> Usp_User_List(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("Usp_User_List", mergeOption);
        }
    
        public virtual ObjectResult<User> usp_User_Get_By_Email_And_Password(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("usp_User_Get_By_Email_And_Password", emailParameter, passwordParameter);
        }
    
        public virtual ObjectResult<User> usp_User_Get_By_Email_And_Password(string email, string password, MergeOption mergeOption)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("usp_User_Get_By_Email_And_Password", mergeOption, emailParameter, passwordParameter);
        }
    
        public virtual ObjectResult<PasswordResetToken> usp_PasswordResetToken_get(string token)
        {
            var tokenParameter = token != null ?
                new ObjectParameter("token", token) :
                new ObjectParameter("token", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PasswordResetToken>("usp_PasswordResetToken_get", tokenParameter);
        }
    
        public virtual ObjectResult<PasswordResetToken> usp_PasswordResetToken_get(string token, MergeOption mergeOption)
        {
            var tokenParameter = token != null ?
                new ObjectParameter("token", token) :
                new ObjectParameter("token", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PasswordResetToken>("usp_PasswordResetToken_get", mergeOption, tokenParameter);
        }
    
        public virtual int usp_PasswordResetToken_Insert(string token, Nullable<System.DateTime> expiry_date, Nullable<int> user_Id)
        {
            var tokenParameter = token != null ?
                new ObjectParameter("token", token) :
                new ObjectParameter("token", typeof(string));
    
            var expiry_dateParameter = expiry_date.HasValue ?
                new ObjectParameter("expiry_date", expiry_date) :
                new ObjectParameter("expiry_date", typeof(System.DateTime));
    
            var user_IdParameter = user_Id.HasValue ?
                new ObjectParameter("user_Id", user_Id) :
                new ObjectParameter("user_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_PasswordResetToken_Insert", tokenParameter, expiry_dateParameter, user_IdParameter);
        }
    }
}
