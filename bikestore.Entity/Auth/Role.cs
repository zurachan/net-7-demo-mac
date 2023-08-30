using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bikestore.Entity.Auth
{
    [Table("role")]
    public class Role : BaseEntity
    {
        [Required]
        [Column("name")]
        public string Name { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<RoleMenu> RoleMenus { get; set; }
    }
}
