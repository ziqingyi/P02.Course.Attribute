using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P33.Course.Model.Models
{
    [Table("SysRoleMenuMapping")]
    public partial class SysRoleMenuMapping
    {
        public int Id { get; set; }
        public int SysRoleId { get; set; }
        public int SysMenuId { get; set; }
        public virtual SysRole SysRole { get; set; }
        public virtual SysMenu SysMenu { get; set; }

    }
}
