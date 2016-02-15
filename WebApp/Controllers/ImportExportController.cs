//using Domain;
//using Microsoft.AspNet.Identity;
//using Models;
//using Service;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.OleDb;
//using System.Data.SqlClient;
//using System.IO;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Windows.Forms;
//using Exel = Microsoft.Office.Interop.Excel;

//namespace WebApp.Controllers
//{

    
//    public class ImportExportController : Controller
//    {
//        private ICategorieService db = new CategorieService();
//        public ActionResult Index()
//        {
//            if (Session["identifiant"] == null)
//            { return RedirectToAction("Index", "Home"); }
//            return View();
//        }
//        public ActionResult Succes()
//        {
//            if (Session["identifiant"] == null)
//            { return RedirectToAction("Index", "Home"); }
//            return View();
//        }

       



//        [HttpPost, ActionName("SaveUploadedFile")]
//        public ActionResult SaveUploadedFile(string id)
//        {
//            bool isSavedSuccessfully = true;
//            string fName = "";
//            string fileName1 = "";
//            string fileExtension = "";
//            string pathFile = "";
//            DataTable ds = new DataTable();
//            try
//            {
//                foreach (string fileName in Request.Files)
//                {
//                    HttpPostedFileBase file = Request.Files[fileName];

//                    fName = file.FileName;
//                    fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);
//                    if (file != null && file.ContentLength > 0 && (file.FileName.EndsWith("xls") || file.FileName.EndsWith("xlsx")))
//                    {
//                        var originalDirectory = new DirectoryInfo(string.Format("{0}Fichiers", Server.MapPath(@"\")));
//                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "Exels");
//                        fileName1 = Path.GetFileName(file.FileName);
//                        bool isExists = System.IO.Directory.Exists(pathString);
//                        if (!isExists)
//                            System.IO.Directory.CreateDirectory(pathString);
//                        pathFile = string.Format("{0}\\{1}", pathString, file.FileName);
//                        file.SaveAs(pathFile);
//                    }
//                    else
//                    {
//                        ViewBag.Error = "Selectionner un fichier Excel SVP !!!";
//                        return View("Index");
//                    }


//                }
//            }
//            catch (Exception ex)
//            {
//                isSavedSuccessfully = false;
//            }

//            if (isSavedSuccessfully)
//            {
//                List<Bien> list = new List<Bien>();


//                ds = ExcelParser.Instance.ExcelParserToDataTable(pathFile, null);
//                foreach (DataRow row in ds.Rows)
//                {
//                    Bien catalogue = new Bien();

//                    catalogue.Code_a_barre = Convert.ToInt32(row["Code matériel "]);

//                    catalogue.Num_Serie = row["N° de série "].ToString();
//                    ///var i = db.FindCategorie_materielByNom(row["Catégorie "].ToString());
//                    //catalogue.Categorie_materiel = Convert.ToString(i.Id_Categorie_materiel);

//                    catalogue.Modele = row["Modèle "].ToString();
//                    catalogue.Marque = row["Marque "].ToString();
//                    catalogue.Etat = row["Statut "].ToString();
//                    catalogue.Fin_garantie = Convert.ToDateTime(row["Fin de garantie "]);
//                    catalogue.Id_etage = Convert.ToInt32(row["Localisation (dernier niveau) "]);

//                    catalogue.idBatiment = Convert.ToInt32(row["Entité (dernier niveau) "]);
//                    catalogue.Date_d_inventaire = Convert.ToDateTime(row["Date inventaire "]);
//                    catalogue.Date_d_installation = Convert.ToDateTime(row["Date d'installation "]);
//                    catalogue.idBatiment = Convert.ToInt32(row["Localisation (complet) "]);

//                    catalogue.id_direction = Convert.ToInt32(row["Entité (complet) "]);
//                    //catalogue.Code_materiel.ToString() = Code;
//                    list.Add(catalogue);
//                    BissInventaireEntities.Instance.Bien.Add(catalogue);

//                    BissInventaireEntities.Instance.SaveChanges();
//                }

//                Session["Tesst"] = list.ToList();

//                return View("Create1");
//            }
//            return HttpNotFound();
//        }

//        public ActionResult Create1(Bien customer)
//        {
//            if (Session["identifiant"] == null)
//            { return RedirectToAction("Index", "Home"); }

//            return View();
//        }
//        // GET: ImportExport
//        public void ExportToExel()
//        {
            
//            var grid = new GridView();
//            var inv = BissInventaireEntities.Instance.Bien.ToList();
//            grid.DataSource = inv;
//            grid.DataBind();
//            Response.ClearContent();
//            String DateExp = DateTime.Now.ToString();
//            Response.AddHeader("content-disposition", "attachment;filename=InventaireList_" + DateExp + ".xls");
//            Response.ContentType = "text/excel";
//            StringWriter sw = new StringWriter();
//            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
//            grid.RenderControl(htmltexxt);
//            Response.Write(sw.ToString());
//            Response.End();


//        }
//        public void ExportToCSV()
//        {
//            StringWriter sw = new StringWriter();
//            sw.WriteLine("\"Code materiel\",\"Num de serie\",\"Categorie_materiel\",\"Modele\",\"Marque\",\"Statut\",\"Date instalation\",\"Localisation\"");
//            Response.ClearContent();
//            String DateExp = DateTime.Now.ToString();
//            Response.AddHeader("content-disposition", "attachment;filename=InventaireList_" + DateExp + ".csv");
//            Response.ContentType = "text/csv";
//            var inv = BissInventaireEntities.Instance.Bien.ToList();
//            foreach (var DataTest in inv)
//            {
//                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\"",
//                    DataTest.Code_a_barre,
//                    DataTest.Num_Serie,
//                    DataTest.Categorie.libelle,
                    
//                    DataTest.Etat,
//                    DataTest.Date_d_installation,
                   
//                    DataTest.Etage.description));
//            }
//            Response.Write(sw.ToString());
//            Response.End();
//        }


      
//        public ActionResult ImportTxt()
//        {
//            if (Session["identifiant"] == null)
//            { return RedirectToAction("Index", "Home"); }
//            bool isSavedSuccessfully = true;
//            string fName = "";
//            string fileName1 = "";
//            string fileExtension = "";
//            string pathFile = "";
//            DataTable ds = new DataTable();
//            try
//            {
//                foreach (string fileName in Request.Files)
//                {
//                    HttpPostedFileBase file = Request.Files[fileName];

//                    fName = file.FileName;
//                    fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);
//                    if (file != null && file.ContentLength > 0 && (file.FileName.EndsWith("txt")))
//                    {
//                        var originalDirectory = new DirectoryInfo(string.Format("{0}Fichiers", Server.MapPath(@"\")));
//                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "Exels");
//                        fileName1 = Path.GetFileName(file.FileName);
//                        bool isExists = System.IO.Directory.Exists(pathString);
//                        if (!isExists)
//                            System.IO.Directory.CreateDirectory(pathString);
//                        pathFile = string.Format("{0}\\{1}", pathString, file.FileName);
//                        file.SaveAs(pathFile);
//                        System.IO.Stream fileStream = file.InputStream;
//                        using (System.IO.StreamReader sr = new System.IO.StreamReader(fileStream))
//                        {

//                            int nbRows = System.IO.File.ReadAllLines(pathFile).Length;
//                            //Read the first line from the file and write it the textbox.
//                            var str = sr.ReadLine();
//                            bool insert_test = true;
//                            while (sr.Peek() != -1)
//                            {
//                                try
//                                {
//                                    str = sr.ReadLine();
//                                    string[] splitVou = str.Split(new char[] { ';' });
//                                    //Définition de la variable de récupération du résultat de l'exécution de la requête ci-dessus

//                                    Bien a = new Bien();
//                                    a.Code_a_barre = Convert.ToInt32(splitVou[0]) ;
//                                    a.Code = Convert.ToInt32(splitVou[1]);
//                                    BissInventaireEntities.Instance.Bien.Add(a);
//                                    BissInventaireEntities.Instance.SaveChanges();
//                                    insert_test = false;
//                                }

//                                catch (Exception)
//                                {
//                                    insert_test = false;
//                                    return View("ImportTxt");
                                 
//                                }
//                                return RedirectToAction("Cipherlab");
//                            }
//                        }
//                    }
//                    else
//                    {
//                        ViewBag.Error = "Selectionner un fichier Text SVP !!!";
//                        return View("ImportTxt");
//                    }


//                }
//            }
//            catch (Exception ex)
//            {
//                isSavedSuccessfully = false;
//                return View("ImportTxt");
//            }
//            return View("ImportTxt");
//        }


//        public ActionResult Cipherlab()
//        {
//            var cipher = BissInventaireEntities.Instance.Bien.ToList();
//            return View(cipher);
//        }
//    }
//}




