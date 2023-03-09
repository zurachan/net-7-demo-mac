using System;
namespace bikestore.Entity.Management
{
    public class Account : BaseEntity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordResetCode { get; set; }
    }
}

