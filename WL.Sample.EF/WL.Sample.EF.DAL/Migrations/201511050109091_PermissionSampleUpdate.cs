namespace WL.Sample.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PermissionSampleUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysEmployeeRoles",
                c => new
                    {
                        SysEmployeeRoleId = c.Int(nullable: false, identity: true),
                        SysEmployeeId = c.Int(nullable: false),
                        SysRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SysEmployeeRoleId)
                .ForeignKey("dbo.SysEmployees", t => t.SysEmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.SysRoles", t => t.SysRoleId, cascadeDelete: true)
                .Index(t => t.SysEmployeeId)
                .Index(t => t.SysRoleId);
            
            CreateTable(
                "dbo.SysEmployees",
                c => new
                    {
                        SysEmployeeId = c.Int(nullable: false),
                        Name = c.String(maxLength: 200),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SysEmployeeId);
            
            CreateTable(
                "dbo.SysRoles",
                c => new
                    {
                        SysRoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SysRoleId);
            
            CreateTable(
                "dbo.SysFunctions",
                c => new
                    {
                        SysFunctionId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Uri = c.String(maxLength: 1000),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SysFunctionId);
            
            CreateTable(
                "dbo.SysFunctionRoles",
                c => new
                    {
                        SysFunctionRoleId = c.Int(nullable: false, identity: true),
                        SysFunctionId = c.Int(nullable: false),
                        SysRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SysFunctionRoleId)
                .ForeignKey("dbo.SysFunctions", t => t.SysFunctionId, cascadeDelete: true)
                .ForeignKey("dbo.SysRoles", t => t.SysRoleId, cascadeDelete: true)
                .Index(t => t.SysFunctionId)
                .Index(t => t.SysRoleId);
            
            CreateTable(
                "dbo.SysRoleSysEmployees",
                c => new
                    {
                        SysRole_SysRoleId = c.Int(nullable: false),
                        SysEmployee_SysEmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SysRole_SysRoleId, t.SysEmployee_SysEmployeeId })
                .ForeignKey("dbo.SysRoles", t => t.SysRole_SysRoleId, cascadeDelete: true)
                .ForeignKey("dbo.SysEmployees", t => t.SysEmployee_SysEmployeeId, cascadeDelete: true)
                .Index(t => t.SysRole_SysRoleId)
                .Index(t => t.SysEmployee_SysEmployeeId);
            
            CreateTable(
                "dbo.SysFunctionSysRoles",
                c => new
                    {
                        SysFunction_SysFunctionId = c.Int(nullable: false),
                        SysRole_SysRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SysFunction_SysFunctionId, t.SysRole_SysRoleId })
                .ForeignKey("dbo.SysFunctions", t => t.SysFunction_SysFunctionId, cascadeDelete: true)
                .ForeignKey("dbo.SysRoles", t => t.SysRole_SysRoleId, cascadeDelete: true)
                .Index(t => t.SysFunction_SysFunctionId)
                .Index(t => t.SysRole_SysRoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SysFunctionRoles", "SysRoleId", "dbo.SysRoles");
            DropForeignKey("dbo.SysFunctionRoles", "SysFunctionId", "dbo.SysFunctions");
            DropForeignKey("dbo.SysEmployeeRoles", "SysRoleId", "dbo.SysRoles");
            DropForeignKey("dbo.SysEmployeeRoles", "SysEmployeeId", "dbo.SysEmployees");
            DropForeignKey("dbo.SysFunctionSysRoles", "SysRole_SysRoleId", "dbo.SysRoles");
            DropForeignKey("dbo.SysFunctionSysRoles", "SysFunction_SysFunctionId", "dbo.SysFunctions");
            DropForeignKey("dbo.SysRoleSysEmployees", "SysEmployee_SysEmployeeId", "dbo.SysEmployees");
            DropForeignKey("dbo.SysRoleSysEmployees", "SysRole_SysRoleId", "dbo.SysRoles");
            DropIndex("dbo.SysFunctionSysRoles", new[] { "SysRole_SysRoleId" });
            DropIndex("dbo.SysFunctionSysRoles", new[] { "SysFunction_SysFunctionId" });
            DropIndex("dbo.SysRoleSysEmployees", new[] { "SysEmployee_SysEmployeeId" });
            DropIndex("dbo.SysRoleSysEmployees", new[] { "SysRole_SysRoleId" });
            DropIndex("dbo.SysFunctionRoles", new[] { "SysRoleId" });
            DropIndex("dbo.SysFunctionRoles", new[] { "SysFunctionId" });
            DropIndex("dbo.SysEmployeeRoles", new[] { "SysRoleId" });
            DropIndex("dbo.SysEmployeeRoles", new[] { "SysEmployeeId" });
            DropTable("dbo.SysFunctionSysRoles");
            DropTable("dbo.SysRoleSysEmployees");
            DropTable("dbo.SysFunctionRoles");
            DropTable("dbo.SysFunctions");
            DropTable("dbo.SysRoles");
            DropTable("dbo.SysEmployees");
            DropTable("dbo.SysEmployeeRoles");
        }
    }
}
