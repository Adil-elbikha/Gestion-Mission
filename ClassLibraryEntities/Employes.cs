using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntities
{
    public class Employes
    {
        [Key]//,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int employesId;
        private string matricule;
        private string nom, prenom, address;
        [ForeignKey("Superviseurs")]
        private Int32? superviseursId;
        private Superviseurs superviseur;
        [ForeignKey("Taches")]
        private Int32? tachesId;
        private Taches tache;

        public Employes() { }

        public Employes( string matricule, string nom, string prenom, string address, int superviseursId)
        {
            this.Matricule = matricule;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Address = address;
            this.SuperviseursId = superviseursId;
            this.tachesId = null;
        }

        public int EmployesId { get => employesId; set => employesId = value; }
        public string Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Address { get => address; set => address = value; }
        public int? SuperviseursId { get => superviseursId; set => superviseursId = value; }
        public Superviseurs Superviseur { get => superviseur; set => superviseur = value; }
        public int? TachesId { get => tachesId; set => tachesId = value; }
        public Taches Tache { get => tache; set => tache = value; }
    }
}
