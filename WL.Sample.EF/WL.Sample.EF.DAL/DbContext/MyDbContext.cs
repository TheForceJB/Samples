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


        public DbSet<SysEmployee> SysEmployees { get; set; }
        public DbSet<SysFunction> SysFunctions { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysFunctionRole> SysFunctionRoles { get; set; }
        public DbSet<SysEmployeeRole> SysEmployeeRoles { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                //Department 一對多 User
                modelBuilder.Entity<Department>().HasMany(m => m.User).WithRequired(m => m.Department);

            }
            catch (Exception ex) { }
        }
    }

}
