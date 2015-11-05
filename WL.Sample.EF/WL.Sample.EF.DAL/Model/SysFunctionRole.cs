using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WL.Sample.EF.DAL.Model
{
    public class SysFunctionRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SysFunctionRoleId { get; set; }
        public int SysFunctionId { get; set; }
        public int SysRoleId { get; set; }

        //Foreign Key
        [ForeignKey("SysFunctionId")]
        public virtual SysFunction SysFunction { get; set; }

        //Foreign Key
        [ForeignKey("SysRoleId")]
        public virtual SysRole SysRole { get; set; }
    }
}
