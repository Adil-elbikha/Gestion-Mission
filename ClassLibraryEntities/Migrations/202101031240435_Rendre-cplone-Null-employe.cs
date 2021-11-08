namespace ClassLibraryEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RendrecploneNullemploye : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employes", "SuperviseursId", "dbo.Superviseurs");
            DropForeignKey("dbo.Employes", "TachesId", "dbo.Taches");
            DropIndex("dbo.Employes", new[] { "SuperviseursId" });
            DropIndex("dbo.Employes", new[] { "TachesId" });
            AlterColumn("dbo.Employes", "SuperviseursId", c => c.Int());
            AlterColumn("dbo.Employes", "TachesId", c => c.Int());
            CreateIndex("dbo.Employes", "SuperviseursId");
            CreateIndex("dbo.Employes", "TachesId");
            AddForeignKey("dbo.Employes", "SuperviseursId", "dbo.Superviseurs", "SuperviseursId");
            AddForeignKey("dbo.Employes", "TachesId", "dbo.Taches", "TachesId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employes", "TachesId", "dbo.Taches");
            DropForeignKey("dbo.Employes", "SuperviseursId", "dbo.Superviseurs");
            DropIndex("dbo.Employes", new[] { "TachesId" });
            DropIndex("dbo.Employes", new[] { "SuperviseursId" });
            AlterColumn("dbo.Employes", "TachesId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employes", "SuperviseursId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employes", "TachesId");
            CreateIndex("dbo.Employes", "SuperviseursId");
            AddForeignKey("dbo.Employes", "TachesId", "dbo.Taches", "TachesId", cascadeDelete: true);
            AddForeignKey("dbo.Employes", "SuperviseursId", "dbo.Superviseurs", "SuperviseursId", cascadeDelete: true);
        }
    }
}
