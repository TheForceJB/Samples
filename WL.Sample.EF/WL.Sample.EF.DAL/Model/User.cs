using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WL.Sample.EF.DAL.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        //Foreign Key
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}