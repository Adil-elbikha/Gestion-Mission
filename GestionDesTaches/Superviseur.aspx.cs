using ClassLibraryEntities;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDesTaches
{
    public partial class Superviseur : System.Web.UI.Page
    {
        dbContextGestionDesTaches db = new dbContextGestionDesTaches();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AfficherTout();
                PopulationDesFiltres();
            }
        }

        private void PopulationDesFiltres()
        {
            var VarDataSource = (from i in db.Superviseurs
                                 select new
                                 {
                                     i.SuperviseursId,
                                     i.Matricule,
                                     NomComplet = i.Nom + " " + i.Prenom,
                                     i.Address
                                 }).ToList();
            DdlFiltreEquipe.DataSource = VarDataSource;
            DdlFiltreEquipe.DataTextField = "NomComplet";
            DdlFiltreEquipe.DataValueField = "SuperviseursId";
            DdlFiltreEquipe.DataBind();

            DdlFiltrePrenom.DataSource = (from i in db.Superviseurs
                                          select i).ToList();
            DdlFiltrePrenom.DataTextField = "Prenom";
            DdlFiltrePrenom.DataValueField = "Prenom";
            DdlFiltrePrenom.DataBind();
        }

        private void AfficherTout()
        {
            GvAfficher.DataSource = (from sups in db.Superviseurs
                                     select sups).ToList();
            GvAfficher.DataBind();
        }

        public int NbrEmploye(int Id)
        {
            return (from sup in db.Employes
                     where sup.SuperviseursId == Id
                     select sup).Count();
        }
        
        public void Vider()
        {
            TbIdSuperviseur.Text = "";
            TbMatricule.Text = "";
            TbPrenom.Text = "";
            TbNom.Text = "";
            TbAddress.Text = "";
            BtAjouter.Enabled = true;
        }

        public bool MatriculeExiste(string matricule)
        {
            return ((from sup in db.Superviseurs
                     where sup.Matricule.Equals(matricule)
                     select sup).FirstOrDefault()) != null;
        }
       
        protected void GvAfficher_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = int.Parse(GvAfficher.SelectedRow.Cells[1].Text);
            Superviseurs superviseur = (from sup in db.Superviseurs
                                        where sup.SuperviseursId == Id
                                        select sup).First();
            TbIdSuperviseur.Text =superviseur.SuperviseursId.ToString();
            TbMatricule.Text = superviseur.Matricule.ToString();
            TbNom.Text = superviseur.Nom.ToString();
            TbPrenom.Text = superviseur.Prenom.ToString();
            TbAddress.Text = superviseur.Address.ToString();
            BtAjouter.Enabled = false;
        }

        protected void BtAjouter_Click(object sender, EventArgs e)
        {
            if(TbMatricule.Text!="" && TbNom.Text!="" && TbPrenom.Text!="" && TbAddress.Text!="")
            {
                if(!MatriculeExiste(TbMatricule.Text))
                {
                    Superviseurs superviseur = new Superviseurs(TbMatricule.Text, TbNom.Text, TbPrenom.Text, TbAddress.Text);
                    db.Superviseurs.Add(superviseur);
                    db.SaveChanges();
                    Response.Write("<script>" +
                        "alert(\"Employe bien ajouter\");" +
                        "</script>");
                    AfficherTout();
                    Vider();
                    PopulationDesFiltres();
                    BtAjouter.Enabled = true;
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

        protected void BtModifier_Click(object sender, EventArgs e)
        {
            if (TbIdSuperviseur.Text!="" && TbMatricule.Text != "" && TbNom.Text != "" && TbPrenom.Text != "" && TbAddress.Text != "")
            {
                int id = int.Parse(TbIdSuperviseur.Text);
                string AncientMatricule = (from i in db.Superviseurs
                                           where i.SuperviseursId == id
                                           select i.Matricule).FirstOrDefault();
                string NouveauMatricule = TbMatricule.Text;
                if(AncientMatricule.Equals(NouveauMatricule) || (!MatriculeExiste(NouveauMatricule)))
                {
                    Superviseurs superviseur = (from sup in db.Superviseurs
                                                where sup.SuperviseursId == id
                                                select sup).First();
                    superviseur.Matricule = TbMatricule.Text;
                    superviseur.Nom = TbNom.Text;
                    superviseur.Prenom = TbPrenom.Text;
                    superviseur.Address = TbAddress.Text;
                    db.SaveChanges();
                    Response.Write("<script>" +
                        "alert(\"Employe bien modifier\");" +
                        "</script>");
                    AfficherTout();
                    Vider();
                    PopulationDesFiltres();
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

        protected void BtSupprimer_Click(object sender, EventArgs e)
        {
            if(TbIdSuperviseur.Text!="")
            {
                int id=int.Parse(TbIdSuperviseur.Text);
                if (NbrEmploye(id) == 0)
                {
                    Superviseurs superviseur = (from sup in db.Superviseurs
                                                where sup.SuperviseursId == id
                                                select sup).First();
                    db.Superviseurs.Remove(superviseur);
                    db.SaveChanges();
                    Response.Write("<script>" +
                            "alert(\"Employe supprimer\");" +
                            "</script>");
                    AfficherTout();
                    Vider();
                    PopulationDesFiltres();
                }
                else
                {
                    Response.Write("<script>" +
                            "alert(\"Impossible de le supprimer \nIl a une équipe de "+NbrEmploye(id)+" employes\");" +
                            "</script>");
                }
            }
        }

        protected void DdlFiltreEquipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdSup = int.Parse(DdlFiltreEquipe.SelectedValue.ToString());
            GvFiltre.DataSource = (from i in db.Employes
                                   where i.SuperviseursId == IdSup
                                   select new
                                   {
                                       i.Matricule,
                                       NomComplet=i.Nom+" "+i.Prenom,
                                       i.Address,
                                   }).ToList();
            GvFiltre.DataBind();
        }

        protected void DdlFiltrePrenom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Prenom = DdlFiltrePrenom.SelectedValue.ToString();
            GvFiltre.DataSource = (from i in db.Superviseurs
                                   where i.Prenom.Equals(Prenom)
                                   select new
                                   {
                                       i.Matricule,
                                       NomComplet = i.Nom + " " + i.Prenom,
                                       i.Address
                                   }).ToList();
            GvFiltre.DataBind();
        }

        protected void BtVider_Click(object sender, EventArgs e)
        {
            Vider();
        }
    }
}