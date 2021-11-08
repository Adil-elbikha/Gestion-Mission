using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibraryEntities;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics.CodeAnalysis;

namespace GestionDesTaches
{
    public partial class Employe : System.Web.UI.Page
    {
        dbContextGestionDesTaches db = new dbContextGestionDesTaches();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DdlSuperviseur.DataSource = (from i in db.Superviseurs
                                             select new
                                             {
                                                 i.SuperviseursId,
                                                 NomComplet = i.Nom + " " + i.Prenom
                                             }).ToList();
                DdlSuperviseur.DataTextField = "NomComplet";
                DdlSuperviseur.DataValueField = "SuperviseursId";
                DdlSuperviseur.DataBind();
                AfficherTout();
                PopulationDeDropLists();
            }

        }
        private void PopulationDeDropLists()
        {
            DdlFiltreAddress.DataSource = (from x in db.Employes
                                           select new
                                           {
                                               x.EmployesId,
                                               x.Address
                                           }).Distinct().ToList();
            DdlFiltreAddress.DataTextField = "Address";
            DdlFiltreAddress.DataValueField = "Address";
            DdlFiltreAddress.DataBind();

            DdlAffectationEmploye.DataSource = (from i in db.Employes
                                                select new
                                                {
                                                    i.EmployesId,
                                                    Name = i.Nom + " " + i.Prenom
                                                }).ToList();
            DdlAffectationEmploye.DataTextField = "Name";
            DdlAffectationEmploye.DataValueField = "EmployesId";
            DdlAffectationEmploye.DataBind();

            var DataSourceTache = (from x in db.Taches
                                   select new
                                   {
                                       x.TachesId,
                                       x.Description
                                   }).ToList();
            DdlFiltreTaches.DataSource = DataSourceTache;
            DdlFiltreTaches.DataTextField = "Description";
            DdlFiltreTaches.DataValueField = "TachesId";
            DdlFiltreTaches.DataBind();

            DdlAffectationTache.DataSource = DataSourceTache;
            DdlAffectationTache.DataTextField = "Description";
            DdlAffectationTache.DataValueField = "TachesId";
            DdlAffectationTache.DataBind();
        }

        private void AfficherTout()
        {
            GvAfficher.DataSource = (from emp in db.Employes
                                     select new
                                     {
                                         emp.EmployesId,
                                         emp.Matricule,
                                         NomComplet = emp.Nom + " " + emp.Prenom,
                                         emp.Address,
                                         Superviseur = emp.Superviseur.Nom + " " + emp.Superviseur.Prenom,
                                         Tache = emp.Tache.Description
                                     }).ToList();
            GvAfficher.DataBind();
        }

        public bool Existe(string matricle)
        {
            return ((from x in db.Employes where x.Matricule == matricle select x).FirstOrDefault()) != null;
        }
        public bool MatriculeExiste(string matricule)
        {
            return ((from sup in db.Employes
                     where sup.Matricule.Equals(matricule)
                     select sup).FirstOrDefault()) != null;
        }
        public void Vider()
        {
            TbIdEmploye.Text = "";
            TbMatricule.Text = "";
            TbPrenom.Text = "";
            TbNom.Text = "";
            TbAddress.Text = "";
            BtAjouter.Enabled = true;
        }
        protected void GvAfficher_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = int.Parse(GvAfficher.SelectedRow.Cells[1].Text);
            Employes employes = (from emp in db.Employes
                                 where emp.EmployesId == Id
                                 select emp).First();
            TbIdEmploye.Text = employes.EmployesId.ToString();
            TbMatricule.Text = employes.Matricule.ToString();
            TbNom.Text = employes.Nom.ToString();
            TbPrenom.Text = employes.Prenom.ToString();
            TbAddress.Text = employes.Address.ToString();
            DdlSuperviseur.Text = employes.SuperviseursId.ToString();
            BtAjouter.Enabled = false;
        }

        protected void BtAjouter_Click(object sender, EventArgs e)
        {
            if (TbMatricule.Text != "" && TbNom.Text != "" && TbPrenom.Text != "" && TbAddress.Text != "" && DdlSuperviseur.SelectedValue.ToString() != "")
            {
                if (!MatriculeExiste(TbMatricule.Text))
                {
                    Employes employe = new Employes(TbMatricule.Text, TbNom.Text, TbPrenom.Text, TbAddress.Text, int.Parse(DdlSuperviseur.SelectedValue.ToString()));

                    db.Employes.Add(employe);
                    db.SaveChanges();
                    AfficherTout();
                    Vider();
                    PopulationDeDropLists();
                }
                else
                {
                    Response.Write("<script>" +
                        "alert(\"Matricule :" + TbMatricule.Text + " déjà assigner à un superviseur\");" +
                        "</script>");
                }
            }
            else
            {
                Response.Write("<script>" +
                           "alert(\"Un de vos champ est vide. \");" +
                           "</script>");
            }
        }

        protected void BtSupprimer_Click(object sender, EventArgs e)
        {
            if (TbIdEmploye.Text != "")
            {
                int id = int.Parse(TbIdEmploye.Text);
                Employes employe = (from emp in db.Employes
                                    where emp.EmployesId == id
                                    select emp).First();
                db.Employes.Remove(employe);
                db.SaveChanges();
                AfficherTout();
                Vider();
                PopulationDeDropLists();
            }
        }

        protected void BtModifier_Click(object sender, EventArgs e)
        {
            if (TbIdEmploye.Text != "" && TbMatricule.Text != "" && TbNom.Text != "" && TbPrenom.Text != "" && TbAddress.Text != "" && DdlSuperviseur.SelectedValue.ToString() != "")
            {
                int id = int.Parse(TbIdEmploye.Text);
                string AncientMatricule = (from i in db.Employes
                                           where i.EmployesId == id
                                           select i.Matricule).FirstOrDefault();
                string NouveauMatricule = TbMatricule.Text;
                if (AncientMatricule.Equals(NouveauMatricule) || (!MatriculeExiste(NouveauMatricule)))
                {
                    Employes employes = (from emp in db.Employes
                                         where emp.EmployesId == id
                                         select emp).First();
                    employes.Matricule = TbMatricule.Text;
                    employes.Nom = TbNom.Text;
                    employes.Prenom = TbPrenom.Text;
                    employes.Address = TbAddress.Text;
                    employes.SuperviseursId = int.Parse(DdlSuperviseur.SelectedValue.ToString());
                    db.SaveChanges();
                    AfficherTout();
                    Vider();
                    PopulationDeDropLists();
                }
                else
                {
                    Response.Write("<script>" +
                    "alert(\"Matricule :" + TbMatricule + " déjà assigner à un superviseur\");" +
                    "</script>");
                }
            }
            else
            {
                Response.Write("<script>" +
                           "alert(\"Un de vos champ est vide. \");" +
                           "</script>");
            }

        }

        protected void DdlFiltreTaches_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Tache = int.Parse(DdlFiltreTaches.SelectedValue.ToString());
            GvFiltres.DataSource = (from i in db.Employes
                                    where i.TachesId == Tache
                                    select new
                                    {
                                        i.Matricule,
                                        NomComplet = i.Nom + " " + i.Prenom,
                                        i.Address
                                    }).ToList();
            GvFiltres.DataBind();
        }

        protected void DdlFiltreAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Address = DdlFiltreAddress.SelectedValue.ToString();
            GvFiltres.DataSource = ((from i in db.Employes
                                     where i.Address.Equals(Address)
                                     select new
                                     {
                                         i.Matricule,
                                         NomComplet = i.Nom + " " + i.Prenom,
                                         i.Address
                                     }).ToList()).Distinct();
            GvFiltres.DataBind();
        }

        protected void BtAffecter_Click(object sender, EventArgs e)
        {
            if (DdlAffectationTache.SelectedValue.ToString() != "" && DdlAffectationEmploye.SelectedValue.ToString() != "")
            {
                int TacheId = int.Parse(DdlAffectationTache.SelectedValue.ToString());
                int Id = int.Parse(DdlAffectationEmploye.SelectedValue.ToString());
                Employes employe = (from i in db.Employes
                                    where i.EmployesId == Id
                                    select i).First();
                employe.TachesId = TacheId;
                db.SaveChanges();
                Response.Write("<script>" +
                        "alert(\"La tache " + DdlAffectationTache.SelectedItem.Text + " a été affecter a l'employe " + DdlAffectationEmploye.SelectedItem.Text + "\");" +
                        "</script>");
                AfficherTout();
            }
        }

        protected void BtDesaffecter_Click(object sender, EventArgs e)
        {
            if (DdlAffectationEmploye.SelectedValue.ToString() != "")
            {
                int Id = int.Parse(DdlAffectationEmploye.SelectedValue.ToString());
                Employes employe = (from i in db.Employes
                                    where i.EmployesId == Id
                                    select i).First();
                DdlAffectationTache.Text = employe.TachesId.ToString();
                string Tache = DdlAffectationTache.SelectedItem.Text;
                employe.TachesId = null;
                Response.Write("<script>" +
                        "alert(\"La tache " + Tache + " a été retirer de l'employe " + DdlAffectationEmploye.SelectedItem.Text + "\");" +
                        "</script>");
                db.SaveChanges();
                AfficherTout();
            }
        }

        protected void BtVider_Click(object sender, EventArgs e)
        {
            Vider();
        }
    }
}