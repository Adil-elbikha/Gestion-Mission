namespace ClassLibraryEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreingkey2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employes", "Superviseur", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employes", "Superviseur", c => c.String());
        }
    }
}
