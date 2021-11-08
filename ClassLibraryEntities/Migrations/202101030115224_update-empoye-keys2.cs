namespace ClassLibraryEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateempoyekeys2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employes", "Superviseur_SuperviseursId", "dbo.Superviseurs");
            DropIndex("dbo.Employes", new[] { "Superviseur_SuperviseursId" });
            RenameColumn(table: "dbo.Employes", name: "Superviseur_SuperviseursId", newName: "SuperviseursId");
            AlterColumn("dbo.Employes", "SuperviseursId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employes", "SuperviseursId");
            AddForeignKey("dbo.Employes", "SuperviseursId", "dbo.Superviseurs", "SuperviseursId", cascadeDelete: true);
            DropColumn("dbo.Employes", "SuperviseurId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employes", "SuperviseurId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employes", "SuperviseursId", "dbo.Superviseurs");
            DropIndex("dbo.Employes", new[] { "SuperviseursId" });
            AlterColumn("dbo.Employes", "SuperviseursId", c => c.Int());
            RenameColumn(table: "dbo.Employes", name: "SuperviseursId", newName: "Superviseur_SuperviseursId");
            CreateIndex("dbo.Employes", "Superviseur_SuperviseursId");
            AddForeignKey("dbo.Employes", "Superviseur_SuperviseursId", "dbo.Superviseurs", "SuperviseursId");
        }
    }
}
