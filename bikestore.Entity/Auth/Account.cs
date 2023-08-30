using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bikestore.Entity.Auth
{
    [Table("account")]
    public class Account : BaseEntity
    {
        [Required]
        [Column("username")]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        public string Password { get; set; }
        [ForeignKey("user")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
