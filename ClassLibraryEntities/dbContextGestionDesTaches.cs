using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntities
{
    public class dbContextGestionDesTaches : DbContext
    {
        public dbContextGestionDesTaches() : base("dbGestionDesTaches")
        { }
        public DbSet<Employes> Employes { get; set; }
        public DbSet<Taches> Taches { get; set; }
        public DbSet<Superviseurs> Superviseurs { get; set; }
    }
}
