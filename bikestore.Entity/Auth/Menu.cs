using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bikestore.Entity.Auth
{
    [Table("menu")]
    public class Menu : BaseEntity
    {
        [Required]
        [Column("name")]
        public string Name { get; set; }

        public virtual List<RoleMenu> RoleMenus { get; set; }
    }
}
