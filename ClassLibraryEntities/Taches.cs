using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntities
{
    public class Taches
    {
        [Key]///*,DatabaseGenerated(DatabaseGeneratedOption.Identity)*/]
        private Int32 tachesId;
        private string description;
        private DateTime dateCreation, dateEcheance;
        private List<Employes> employes;

        public Taches() { }

        public int TachesId { get => tachesId; set => tachesId = value; }
        public string Description { get => description; set => description = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public DateTime DateEcheance { get => dateEcheance; set => dateEcheance = value; }
        public List<Employes> Employes { get => employes; set => employes = value; }

        public Taches(string description, DateTime dateCreation, DateTime dateEcheance)
        {
            this.Description = description;
            this.DateCreation = dateCreation;
            this.DateEcheance = dateEcheance;
        }

    }
}
