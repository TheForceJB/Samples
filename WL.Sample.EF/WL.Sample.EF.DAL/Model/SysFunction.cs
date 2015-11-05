using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WL.Sample.EF.DAL.Model
{
    public class SysFunction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SysFunctionId { get; set; }
        [StringLength(200)]
        public String Name { get; set; }
        [StringLength(1000)]
        public String Uri { get; set; }
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 一對多關係
        /// </summary>
        public virtual ICollection<SysRole> SysRole { get; set; }
    }
}
