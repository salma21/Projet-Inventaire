using Domain;
using Log;
using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Service;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
       private IUserService db = new UserService();

       
        public ActionResult Index()
        {
            

                return View();

           
           
        }

        [HttpPost]
        public async Task<ActionResult> Index(Utilisateur g)
        {

            Utilisateur result;
            try
            {

                if (ModelState.IsValid)
                {

                    if ((result = db.Authentification(g)) != null)
                    {
                        if (result.etatUtilisateur == true)
                        {

                            Session["identifiant"] = result.login;
                         
                           
                            return RedirectToAction("RapportBien", "Admin");
                        }
                        else
                        {
                            //
                            ViewBag.msg1 = "Votre Compte est désactivé !!! ";
                            return View();

                          
                        }
                    }
                    else
                        ViewBag.msg1 = "Vérifiez Votre Login ou Password !!!";
                    return View();
                    // ModelState.AddModelError("Error", "Vérifiez Votre Login ou Password !!!");
                }
                else
                {
                    ViewBag.msg1 = "Wrong Input";
                    return View();
                }
            }

            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return View();
            }

        }

        [HttpPost, ActionName("SaveUploadedFile")]

        public ActionResult SaveUploadedFile(string id)
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            string fileName1 = "";
            string fileExtension = "";
            string pathFile = "";
            DataTable ds = new DataTable();
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;
                    fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);
                    if (file != null && file.ContentLength > 0)
                    {
                        var originalDirectory = new DirectoryInfo(string.Format("{0}Fichiers", Server.MapPath(@"\")));
                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "Files");
                        fileName1 = Path.GetFileName(file.FileName);
                        bool isExists = System.IO.Directory.Exists(pathString);
                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);
                        pathFile = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(pathFile);
                    }
                }
            }
            catch
            {
                isSavedSuccessfully = false;
            }

            if (isSavedSuccessfully)
            {
                List<AtbDataTest> list = new List<AtbDataTest>();


                ds = ExcelParser.Instance.ExcelParserToDataTable(pathFile, null);
                foreach (DataRow row in ds.Rows)
                {
                    AtbDataTest catalogue = new AtbDataTest();
                    catalogue.Code_materiel = (int)row["test1"];

                    catalogue.Num_serie = row["test2"].ToString();
                    catalogue.Categorie = row["test3"].ToString();
                    catalogue.Modele = row["test4"].ToString();
                    catalogue.Marque = row["test5"].ToString();
                    catalogue.Statut = row["test6"].ToString();
                    catalogue.Fin_garantie = row["test7"].ToString();
                    catalogue.Localisation_dernier = row["test8"].ToString();

                    catalogue.Entite_dernier = row["test9"].ToString();
                    catalogue.Date_inventaire = row["test10"].ToString();
                    catalogue.Date_installation = row["test11"].ToString();
                    catalogue.Localisation_complet = row["test12"].ToString();

                    catalogue.Entite_complet = row["test13"].ToString();
                    list.Add(catalogue);

                }

              
                return View("Dashboard", "Admin");
            }
            return HttpNotFound();
        }

        public ActionResult Logout()
        {

            //User u = db.GetUser((Session["identifiant"].ToString()));


        
            db.SaveEmploye();
            Session["id"] = null;
            Session["role"] = null;
           // LogThread.WriteLine(u.nom + " " + u.prenom + "de Matricule " + u.identifiant + " quitte  l'application");
            return RedirectToAction("Index", "Home");


        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}