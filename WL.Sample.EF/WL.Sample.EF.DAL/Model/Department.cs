using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WL.Sample.EF.DAL.Model
{
    public class Department
    {
        public Department()
        {
        }

        [Key]
        public int DepartmentId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }


        /// <summary>
        /// 一對多關係
        /// </summary>
        public virtual ICollection<User> User { get; set; }
    }
}