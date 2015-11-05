using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WL.Sample.EF.DAL.Model
{
    public class SysEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SysEmployeeId { get; set; }
        [StringLength(200)]
        public String Name { get; set; }
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 一對多關係
        /// </summary>
        public virtual ICollection<SysRole> SysRole { get; set; }
    }
}
