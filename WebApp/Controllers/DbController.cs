using Domain;
using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class DbController : Controller
    {
        private IBiensService bien = new BiensService();
        // GET: Db
        public ActionResult Index()
        {
            return View();
        }

        // GET: Db/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "Exels");
                        fileName1 = Path.GetFileName(file.FileName);
                        bool isExists = System.IO.Directory.Exists(pathString);
                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);
                        pathFile = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(pathFile);
                    }
                }
            }
            catch (Exception ex)
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

                    catalogue.Code_materiel =Convert.ToInt32(row["Code matériel "]) ;

                    catalogue.Num_serie = row["N° de série "].ToString();
                    catalogue.Categorie = row["Catégorie "].ToString();
                    catalogue.Modele = row["Modèle "].ToString();
                    catalogue.Marque = row["Marque "].ToString();
                    catalogue.Statut = row["Statut "].ToString();
                    catalogue.Fin_garantie = row["Fin de garantie "].ToString();
                    catalogue.Localisation_dernier = row["Localisation (dernier niveau) "].ToString();

                    catalogue.Entite_dernier = row["Entité (dernier niveau) "].ToString();
                    catalogue.Date_inventaire = row["Date inventaire "].ToString();
                    catalogue.Date_installation = row["Date d'installation "].ToString();
                    catalogue.Localisation_complet = row["Localisation (complet) "].ToString();

                    catalogue.Entite_complet = row["Entité (complet) "].ToString();
                    //catalogue.Code_materiel.ToString() = Code;
                    list.Add(catalogue);

                }

                Session["Tesst"] = list.ToList();

                return View("Create1");
            }
            return HttpNotFound();
        }
        public ActionResult Create1(AtbDataTest customer)
        {
            var test = bien.GetBienss();
            return View(test);
        }
        // GET: Db/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Db/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Db/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Db/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Db/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Db/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
