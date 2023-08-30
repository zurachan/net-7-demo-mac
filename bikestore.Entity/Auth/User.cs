using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bikestore.Entity.Auth
{
    [Table("user")]
    public class User : BaseEntity
    {
        [Required]
        [Column("fullname")]
        public required string FullName { get; set; }
        [Column("address")]
        public string? Address { get; set; }
        public virtual Account Account { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
    }
}
