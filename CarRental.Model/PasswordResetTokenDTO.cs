using System;

namespace CarRental.Model
{
    public class PasswordResetTokenDTO
    {
        public PasswordResetTokenDTO()
        {
        }

        public PasswordResetTokenDTO(int userId)
        {
            Token = Guid.NewGuid().ToString();
            Expiry_date = DateTime.Now.AddHours(2);
            User_id = userId;
        }
        public int Id { get; set; }
        public DateTime? Expiry_date { get; set; }
        public string Token { get; set; }
        public int User_id { get; set; }

    }
}
