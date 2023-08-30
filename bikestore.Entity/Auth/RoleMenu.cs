using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bikestore.Entity.Auth
{
    [Table("role_menu")]
    public class RoleMenu : BaseEntity
    {
        [ForeignKey("role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey("menu")]
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
