namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Students", new[] { "Gender_Id" });
            RenameColumn(table: "dbo.Students", name: "Gender_Id", newName: "GenderId");
            AlterColumn("dbo.Students", "GenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "GenderId");
            AddForeignKey("dbo.Students", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "GenderId", "dbo.Genders");
            DropIndex("dbo.Students", new[] { "GenderId" });
            AlterColumn("dbo.Students", "GenderId", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "GenderId", newName: "Gender_Id");
            CreateIndex("dbo.Students", "Gender_Id");
            AddForeignKey("dbo.Students", "Gender_Id", "dbo.Genders", "Id");
        }
    }
}
