using ClassLibraryEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionDesTaches
{
    public partial class Tache : System.Web.UI.Page
    {
        dbContextGestionDesTaches db = new dbContextGestionDesTaches();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AfficherToutLesTaches();
                Filtres();
            }
        }

        private void Filtres()
        {
            var dataSource = (from i in db.Taches
                              select new
                              {
                                  i.TachesId,
                                  dateEcheance = i.DateEcheance,
                                  dateCreation = i.DateCreation
                              }).Distinct().ToList();
            DdlFiltreDDCreation.DataSource = dataSource;
            DdlFiltreDDCreation.DataTextField = "dateCreation";
            DdlFiltreDDCreation.DataValueField = "dateCreation";
            DdlFiltreDDCreation.DataBind();
            DdlFiltreDDecheance.DataSource = dataSource;
            DdlFiltreDDecheance.DataTextField = "dateEcheance";
            DdlFiltreDDecheance.DataValueField = "dateEcheance";
            DdlFiltreDDecheance.DataBind();
        }

        private void AfficherToutLesTaches()
        {
            GvAfficher.DataSource = (from taches in db.Taches
                                     select taches).ToList();
            GvAfficher.DataBind();
        }

        public int ExisteInEmployes(int Id)
        {
            return (from x in db.Employes where x.TachesId == Id select x).Count();
        }

        public void Vider()
        {
            TbIdTache.Text = "";
            TbDescription.Text = "";
            TbDateDecheance.Text = "";
            BtAjouter.Enabled = true;
        }

        protected void BtAjouter_Click(object sender, EventArgs e)
        {
            if (TbDateDecheance.Text != "" && TbDescription.Text != "")
            {
                Taches tache = new Taches();
                tache.Description = TbDescription.Text;
                tache.DateCreation = DateTime.Now.Date;
                tache.DateEcheance = DateTime.Parse(TbDateDecheance.Text);

                db.Taches.Add(tache);
                db.SaveChanges();
                Response.Write("<script>" +
                      "alert(\"Ajoue bien fait\");" +
                      ">");
                Vider();
                Filtres();
                AfficherToutLesTaches();
            }
            else
            {
                Response.Write("<script>" +
                       "alert(\"Un de vos champs est vide !!\");" +
                       "");
            }
        }

        protected void BtModifier_Click(object sender, EventArgs e)
        {
            if (TbIdTache.Text != "" && TbDescription.Text != "" && TbDateDecheance.Text != "")
            {
                int Id = int.Parse(TbIdTache.Text);
                Taches tache = (from t in db.Taches
                                where t.TachesId == Id
                                select t).First();
                tache.DateEcheance = DateTime.Parse(TbDateDecheance.Text);
                tache.Description = TbDescription.Text;
                db.SaveChanges();
                Response.Write("<script>" +
                   "alert(\"Modification bien fait\");" +
                   "</script>");
                Vider();
                Filtres();
                AfficherToutLesTaches();
            }
            else
            {
                Response.Write("<script>" +
                       "alert(\"Un de vos champs est vide !!\");" +
                       "</script>");
            }
        }

        protected void GvAfficher_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = int.Parse(GvAfficher.SelectedRow.Cells[1].Text.ToString());
            Taches tache = (from i in db.Taches where i.TachesId == index select i).First();
            TbIdTache.Text = tache.TachesId.ToString();
            TbDescription.Text = tache.Description.ToString();
            TbDateDecheance.Text = tache.DateEcheance.Date.ToString();
            BtAjouter.Enabled = false;
        }

        protected void BtSupprimer_Click(object sender, EventArgs e)
        {
            if (TbIdTache.Text != "")
            {
                int Id = int.Parse(TbIdTache.Text);
                if (ExisteInEmployes(Id) == 0)
                {
                    Taches tache = (from i in db.Taches where i.TachesId == Id select i).First();
                    db.Taches.Remove(tache);
                    db.SaveChanges();
                    Response.Write("<script>" +
                           "alert(\"Suppression bien fait\");" +
                           "</script>");
                    Vider();
                    Filtres();
                    AfficherToutLesTaches();
                }
                else
                {
                    Response.Write("<script>" +
                       "alert(\"Désaffecter la tâche\");" +
                       "</script>");
                }
            }
            else
            {
                Response.Write("<script>" +
                       "alert(\"Le champs id est vide !!\");" +
                       "</script>");
            }
        }

        protected void DdlFiltreDDCreation_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime DateCreation = DateTime.Parse(DdlFiltreDDCreation.SelectedValue.ToString()).Date;
            GvFiltres.DataSource = (from taches in db.Taches
                                    where taches.DateCreation == DateCreation
                                    select taches).ToList();
            GvFiltres.DataBind();
        }

        protected void DdlFiltreDDecheance_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime DateEcheance = DateTime.Parse(DdlFiltreDDecheance.SelectedValue.ToString()).Date;
            GvFiltres.DataSource = (from taches in db.Taches
                                    where taches.DateEcheance == DateEcheance
                                    select taches).ToList();
            GvFiltres.DataBind();
        }

        protected void BtVider_Click(object sender, EventArgs e)
        {
            Vider();
        }
    }
}