using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntities
{
    public class Superviseurs
    {
        [Key]///*,DatabaseGenerated(DatabaseGeneratedOption.Identity)*/]
        private Int32 superviseursId;
        private string matricule;
        private string nom;
        private string prenom;
        private string address;
        private List<Employes> employes;

        public int SuperviseursId { get => superviseursId; set => superviseursId = value; }
        public string Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Address { get => address; set => address = value; }
        public List<Employes> Employes { get => employes; set => employes = value; }

        public Superviseurs() { }

        public Superviseurs(string matricule, string nom, string prenom, string address)
        {
            Matricule = matricule;
            Nom = nom;
            Prenom = prenom;
            Address = address;
        }
    }
}
