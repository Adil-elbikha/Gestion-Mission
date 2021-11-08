namespace ClassLibraryEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        EmployesId = c.Int(nullable: false, identity: true),
                        Matricule = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Address = c.String(),
                        Superviseur = c.String(),
                        Taches = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployesId);
            
            CreateTable(
                "dbo.Superviseurs",
                c => new
                    {
                        SuperviseursId = c.Int(nullable: false, identity: true),
                        Matricule = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.SuperviseursId);
            
            CreateTable(
                "dbo.Taches",
                c => new
                    {
                        TachesId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateEcheance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TachesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Taches");
            DropTable("dbo.Superviseurs");
            DropTable("dbo.Employes");
        }
    }
}
