using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WL.Sample.EF.DAL.Model
{
    public class SysRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SysRoleId { get; set; }
        [StringLength(100)]
        public String Name { get; set; }
        [StringLength(500)]
        public String Description { get; set; }
        public bool IsEnabled { get; set; }


        /// <summary>
        /// 一對多關係
        /// </summary>
        public virtual ICollection<SysEmployee> SysEmployee { get; set; }

        /// <summary>
        /// 一對多關係
        /// </summary>
        public virtual ICollection<SysFunction> SysFunction { get; set; }
    }
}
