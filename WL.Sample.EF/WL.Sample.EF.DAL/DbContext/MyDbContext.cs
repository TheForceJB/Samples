using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Sample.EF.DAL.Model;

namespace WL.Sample.EF.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyDbContext")  //指定對應的Connection String名稱 
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                ///Department 一對多 User
                modelBuilder.Entity<Department>().HasMany(m => m.User).WithRequired(m => m.Department);

            }
            catch (Exception ex) { }
        }
    }

}
