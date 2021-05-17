namespace Students.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeGenderData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Genders (Name) Values ('Male')");
            Sql("INSERT INTO dbo.Genders (Name) Values ('Female')");
        }
        
        public override void Down()
        {
        }
    }
}
