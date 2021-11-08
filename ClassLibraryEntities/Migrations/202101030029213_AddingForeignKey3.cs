namespace ClassLibraryEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingForeignKey3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employes", "SuperviseurId", c => c.Int(nullable: false));
            AddColumn("dbo.Employes", "TachesId", c => c.Int(nullable: false));
            AddColumn("dbo.Employes", "Superviseur_SuperviseursId", c => c.Int());
            CreateIndex("dbo.Employes", "TachesId");
            CreateIndex("dbo.Employes", "Superviseur_SuperviseursId");
            AddForeignKey("dbo.Employes", "Superviseur_SuperviseursId", "dbo.Superviseurs", "SuperviseursId");
            AddForeignKey("dbo.Employes", "TachesId", "dbo.Taches", "TachesId", cascadeDelete: true);
            DropColumn("dbo.Employes", "Superviseur");
            DropColumn("dbo.Employes", "Taches");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employes", "Taches", c => c.Int(nullable: false));
            AddColumn("dbo.Employes", "Superviseur", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employes", "TachesId", "dbo.Taches");
            DropForeignKey("dbo.Employes", "Superviseur_SuperviseursId", "dbo.Superviseurs");
            DropIndex("dbo.Employes", new[] { "Superviseur_SuperviseursId" });
            DropIndex("dbo.Employes", new[] { "TachesId" });
            DropColumn("dbo.Employes", "Superviseur_SuperviseursId");
            DropColumn("dbo.Employes", "TachesId");
            DropColumn("dbo.Employes", "SuperviseurId");
        }
    }
}
