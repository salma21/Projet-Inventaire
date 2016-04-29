using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Controllers
{
    public class ExportController : Controller
    {
     
        // GET: Export
        public ActionResult Index()
        {
            return View();
        }
        public void ExportBatiment()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Batiment.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeBatiment_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportAchat()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Achat.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeAchat_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportContrat()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Contrat.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeContrat_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportFournisseur()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Fournisseur.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeFournisseur_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportBureau()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Bureau.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeBureaux_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
       
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportCategorie()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Categorie.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeCategorie_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportDelegation()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Delegation.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeDelegation_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportDepot()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Depot.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeDepot_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportDirection()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Direction.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeDirection_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportEtage()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Etage.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeEtage_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportGouvernorat()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Gouvernorat.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeGouvernorat_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportInventaire()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Inventaire.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=ListeInventaire_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportMarque()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Marque.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeMarque_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportModele()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Modele.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeModele_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportMouvementBien()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.MouvementBien.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeMouvementBien_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportMouvementVehicule()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.MouvementVehicule.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeMouvementVehicule_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportOrganisation()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Organisation.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeOrganisation_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportParc_auto()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Parc_auto.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeParc_auto_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportPays()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Pays.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListePays_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportPersonnel()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Personnel.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListePersonnel_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportRegion()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Region.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeRegion_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportRole()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Role.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeRole_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportServiceD()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.ServiceD.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeServiceD_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportSous_categorie()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Sous_categorie.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeSous_categorie_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportSous_modele()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Sous_modele.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeSous_modele_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportTrace()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Trace.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeTrace_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportUtilisateur()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Utilisateur.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeUtilisateur_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportVehicule()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Vehicule.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireListeVehicule_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportInventaireVehicule()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.InventaireVehicule.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=ListeInventaireVehicule_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportInventaireBien()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.InventaireBien.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=ListeInventaireBien_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportInventaireBienAnnuel()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Bien.ToList();
            grid.DataSource = from p in inv
                              select new
                              {
                                  Catégorie = p.Categorie.Description,
                                  Désignation = p.Designation,
                                  code_à_barre_bien = p.Code_a_barre,
                                  Quantité_initiale = p.Quantite,
                                  Date_Achat =p.Achat.Date_d_achat,
                                  Prix_Achat = p.Achat.Prix_d_achat,
                                  Quantité_2016 = p.Qte_inv1,
                                  Quantité_2017 = p.Qte_inv2,
                                  Quantité_2018 = p.Qte_inv3,
                                  Quantité_2019 = p.Qte_inv4,
                                  Quantité_2020 = p.Qte_inv5,
                                  Quantité_2021 = p.Qte_inv6,

                              };
          
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=ListeInventaireBienAnnuel_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void PrintCode()
        {

            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Bien.ToList();
            grid.DataSource = from p in inv
                              select new
                              {
                                  
                                  Code_à_barre_bien = p.Code_a_barre,

                              } ;

            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=ListeInventaireBienAnnuel_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
    }
}