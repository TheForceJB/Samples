using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WL.Sample.EF.DAL.Model
{
    public class SysEmployeeRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SysEmployeeRoleId { get; set; }
        public int SysEmployeeId { get; set; }
        public int SysRoleId { get; set; }


        //Foreign Key
        [ForeignKey("SysEmployeeId")]
        public virtual SysEmployee SysEmployee { get; set; }

        //Foreign Key
        [ForeignKey("SysRoleId")]
        public virtual SysRole SysRole { get; set; }
    }
}
