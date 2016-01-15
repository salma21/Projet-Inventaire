using Domain;
using Microsoft.AspNet.Identity;
using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Exel = Microsoft.Office.Interop.Excel;

namespace WebApp.Controllers
{

    
    public class ImportExportController : Controller
    {
        private ICategorie_materielService db = new Categorie_materielService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Succes()
        {
            return View();
        }

        //public ActionResult Import(HttpPostedFileBase excelfile)
        //{
        //    if (excelfile==null)
        //    {
        //        ViewBag.Error = "Selectionner un fichier Excel SVP !!!";
        //        return View("Index");
        //    }
        //    else
        //    {
        //        if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
        //        {
        //            string path = Server.MapPath("~/Content/UploadedFolder/" + excelfile.FileName);
        //            if (System.IO.File.Exists(path))
        //                  System.IO.File.Delete(path);
        //            excelfile.SaveAs(path);
        //            Exel.Application app = new Exel.Application();
        //            Exel.Workbook book = app.Workbooks.Open(path);
        //            Exel.Worksheet sheet = book.ActiveSheet;
        //            Exel.Range range = sheet.UsedRange;
        //            List<AtbDataTest> list = new List<AtbDataTest>();
        //            for (int row = 1; row < range.Rows.Count; row++)
        //            {
        //                AtbDataTest NewUpload = new AtbDataTest();
        //               NewUpload.Marque = ((Exel.Range)range.Cells[row, 1]).Text;
        //                NewUpload.Num_serie = ((Exel.Range)range.Cells[row, 2]).Text;
        //                //NewUpload.Categorie = ((Exel.Range)range.Cells[row, 3]).Text;
        //                //NewUpload.Modele = ((Exel.Range)range.Cells[row, 4]).Text;

        //                //NewUpload.Marque = ((Exel.Range)range.Cells[row, 5]).Text;
        //                //NewUpload.Statut = ((Exel.Range)range.Cells[row, 6]).Text;
        //                //NewUpload.Fin_garantie = ((Exel.Range)range.Cells[row, 7]).Text;

        //                //NewUpload.Localisation_dernier = ((Exel.Range)range.Cells[row, 8]).Text;
        //                //NewUpload.Entite_dernier = ((Exel.Range)range.Cells[row, 9]).Text;
        //                //NewUpload.Date_inventaire = ((Exel.Range)range.Cells[row, 10]).Text;
        //                //NewUpload.Date_installation = ((Exel.Range)range.Cells[row, 11]).Text;
        //                //NewUpload.Localisation_complet = ((Exel.Range)range.Cells[row, 12]).Text;
        //                list.Add(NewUpload);

        //            }
        //            ViewBag.list = list;
        //            return View("Succes");
        //        }
        //        else {
        //            ViewBag.Error = "Selectionner un fichier Excel SVP !!!";
        //            return View("Index");

        //             }

        //    }
        //}




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

                    fName = file.FileName;
                    fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);
                    if (file != null && file.ContentLength > 0 && (file.FileName.EndsWith("xls") || file.FileName.EndsWith("xlsx")))
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
                    else
                    {
                        ViewBag.Error = "Selectionner un fichier Excel SVP !!!";
                        return View("Index");
                    }


                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }

            if (isSavedSuccessfully)
            {
                List<Bien> list = new List<Bien>();


                ds = ExcelParser.Instance.ExcelParserToDataTable(pathFile, null);
                foreach (DataRow row in ds.Rows)
                {
                    Bien catalogue = new Bien();

                    catalogue.Code_a_barre = Convert.ToInt32(row["Code matériel "]);

                    catalogue.Num_Serie = row["N° de série "].ToString();
                    ///var i = db.FindCategorie_materielByNom(row["Catégorie "].ToString());
                    //catalogue.Categorie = Convert.ToString(i.Id_categorie);

                    catalogue.Modele = row["Modèle "].ToString();
                    catalogue.Marque = row["Marque "].ToString();
                    catalogue.Etat = row["Statut "].ToString();
                    catalogue.Fin_garantie = Convert.ToDateTime(row["Fin de garantie "]);
                    catalogue.Id_etage = Convert.ToInt32(row["Localisation (dernier niveau) "]);

                    catalogue.idBatiment = Convert.ToInt32(row["Entité (dernier niveau) "]);
                    catalogue.Date_d_inventaire = Convert.ToDateTime(row["Date inventaire "]);
                    catalogue.Date_d_installation = Convert.ToDateTime(row["Date d'installation "]);
                    catalogue.idBatiment = Convert.ToInt32(row["Localisation (complet) "]);

                    catalogue.id_direction = Convert.ToInt32(row["Entité (complet) "]);
                    //catalogue.Code_materiel.ToString() = Code;
                    list.Add(catalogue);
                    BissInventaireEntities.Instance.Bien.Add(catalogue);

                    BissInventaireEntities.Instance.SaveChanges();
                }

                Session["Tesst"] = list.ToList();

                return View("Create1");
            }
            return HttpNotFound();
        }

        public ActionResult Create1(Bien customer)
        {

            return View();
        }
        // GET: ImportExport
        public void ExportToExel()
        {
            var grid = new GridView();
            var inv = BissInventaireEntities.Instance.Bien.ToList();
            grid.DataSource = inv;
            grid.DataBind();
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireList_" + DateExp + ".xls");
            Response.ContentType = "text/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmltexxt = new HtmlTextWriter(sw);
            grid.RenderControl(htmltexxt);
            Response.Write(sw.ToString());
            Response.End();


        }
        public void ExportToCSV()
        {
            StringWriter sw = new StringWriter();
            sw.WriteLine("\"Code materiel\",\"Num de serie\",\"Categorie\",\"Modele\",\"Marque\",\"Statut\",\"Date instalation\",\"Localisation\"");
            Response.ClearContent();
            String DateExp = DateTime.Now.ToString();
            Response.AddHeader("content-disposition", "attachment;filename=InventaireList_" + DateExp + ".csv");
            Response.ContentType = "text/csv";
            var inv = BissInventaireEntities.Instance.Bien.ToList();
            foreach (var DataTest in inv)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\"",
                    DataTest.Code_a_barre,
                    DataTest.Num_Serie,
                    DataTest.Categorie_materiel.libelle,
                    DataTest.Modele,
                    DataTest.Marque,
                    DataTest.Etat,
                    DataTest.Date_d_installation,
                   
                    DataTest.Etage.description));
            }
            Response.Write(sw.ToString());
            Response.End();
        }


        //public ActionResult Submit(IEnumerable<HttpPostedFileBase> files)
        //{
        //    if (files != null)
        //    {
        //        string fileName;
        //        string filepath;
        //        string fileExtension;

        //        foreach (var f in files)
        //        {
        //            //Set file details.
        //            SetFileDetails(f, out fileName, out filepath, out fileExtension);


        //                f.SaveAs(Server.MapPath(@"d:\"));

        //                //Read Data From ExcelFiles.
        //                ReadDataFromExcelFiles(@"d:\");

        //        }
        //    }
        //    return RedirectToAction("RapportBien", "Admin");
        //}

        //private static void SetFileDetails(HttpPostedFileBase f, out string fileName, out string filepath, out string fileExtension)
        //{
        //    fileName = Path.GetFileName(f.FileName);
        //    fileExtension = Path.GetExtension(f.FileName);
        //    filepath = Path.GetFullPath(f.FileName);
        //}
        //private void ReadDataFromExcelFiles(string savedExcelFiles)
        //{
        //    //Create a connection string to access the data of Excel file by the help of Microsoft ACE OLEDB providers.
        //    var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", Server.MapPath(savedExcelFiles));

        //    //Fill the DataSet by the Sheets.
        //    var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
        //    var ds = new DataSet();
        //    List<AtbDataTest> uploadExl = new List<AtbDataTest>();

        //    adapter.Fill(ds, "Subscriber");
        //    DataTable data = ds.Tables["Subscriber"];

        //    GetSetUploadExcelData(uploadExl, data);
        //}

        //private static void GetSetUploadExcelData(List<AtbDataTest> uploadExl, DataTable data)
        //{
        //    for (int i = 0; i < data.Rows.Count - 1; i++)
        //    {
        //        AtbDataTest NewUpload = new AtbDataTest();
        //        NewUpload.Code_materiel = Convert.ToInt16(data.Rows[i]["ID"]);
        //        NewUpload.Num_serie = Convert.ToString(data.Rows[i]["CostCenter"]);
        //        NewUpload.Categorie = Convert.ToString(data.Rows[i]["FirstName"]);
        //        NewUpload.Modele = Convert.ToString(data.Rows[i]["LastName"]);

        //        NewUpload.Marque = Convert.ToString(data.Rows[i]["MobileNo"]);
        //        NewUpload.Statut = Convert.ToString(data.Rows[i]["EmailID"]);
        //        NewUpload.Fin_garantie = Convert.ToString(data.Rows[i]["Services"]);

        //        NewUpload.Localisation_dernier = Convert.ToString(data.Rows[i]["UsageType"]);
        //        NewUpload.Entite_dernier = Convert.ToString(data.Rows[i]["Network"]);
        //        NewUpload.Date_inventaire = Convert.ToString(data.Rows[i]["UsageIncluded"]);
        //        NewUpload.Date_installation = Convert.ToString(data.Rows[i]["UsageIncluded"]);
        //        NewUpload.Localisation_complet = Convert.ToString(data.Rows[i]["Unit"]);


        //        uploadExl.Add(NewUpload);
        //    }
        //}


        //public ActionResult Importexcel()
        //{string extension = System.IO.Path.GetExtension(Request.Files["FileUpload1"].FileName);
        //        string path1 = string.Format("{0}/{1}", Server.MapPath("~/Content/UploadedFolder"), Request.Files["FileUpload1"].FileName);
        //        if (System.IO.File.Exists(path1))
        //            System.IO.File.Delete(path1);

        //        Request.Files["FileUpload1"].SaveAs(path1);
        //        string sqlConnectionString = @"Data Source=192.168.1.2,31729;Database=BissInventaire;User Id=vitalail_sync_svm;password=sync_vitalait_svm;";


        //        //Create connection string to Excel work book
        //        string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Excel 12.0;Persist Security Info=False";
        //        //Create Connection to Excel work book
        //        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
        //        //Create OleDbCommand to fetch data from Excel
        //        OleDbCommand cmd = new OleDbCommand("Select [Code matériel ],[N° de série ],[Catégorie ],[Modèle ],[Marque ],[Statut ],[Fin de garantie ],[Localisation (dernier niveau) ],[Entité (dernier niveau) ],[Date inventaire ],[Date d'installation ],[Date inventaire ],[Localisation (complet) ],[Entité (complet) ] from [Sheet1$]", excelConnection);

        //        excelConnection.Open();
        //        OleDbDataReader dReader;
        //        dReader = cmd.ExecuteReader();

        //        SqlBulkCopy sqlBulk = new SqlBulkCopy(sqlConnectionString);
        //        //Give your Destination table name
        //        sqlBulk.DestinationTableName = "AtbDataTest";
        //        sqlBulk.WriteToServer(dReader);
        //        excelConnection.Close();
        //    return RedirectToAction("RapportBien", "Admin");
        //}

      
        public ActionResult ImportTxt()
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

                    fName = file.FileName;
                    fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);
                    if (file != null && file.ContentLength > 0 && (file.FileName.EndsWith("txt")))
                    {
                        var originalDirectory = new DirectoryInfo(string.Format("{0}Fichiers", Server.MapPath(@"\")));
                        string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "Exels");
                        fileName1 = Path.GetFileName(file.FileName);
                        bool isExists = System.IO.Directory.Exists(pathString);
                        if (!isExists)
                            System.IO.Directory.CreateDirectory(pathString);
                        pathFile = string.Format("{0}\\{1}", pathString, file.FileName);
                        file.SaveAs(pathFile);
                        System.IO.Stream fileStream = file.InputStream;
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(fileStream))
                        {

                            int nbRows = System.IO.File.ReadAllLines(pathFile).Length;
                            //Read the first line from the file and write it the textbox.
                            var str = sr.ReadLine();
                            bool insert_test = true;
                            while (sr.Peek() != -1)
                            {
                                try
                                {
                                    str = sr.ReadLine();
                                    string[] splitVou = str.Split(new char[] { ';' });
                                    //Définition de la variable de récupération du résultat de l'exécution de la requête ci-dessus

                                    Bien a = new Bien();
                                    a.Code_a_barre = Convert.ToInt32(splitVou[0]) ;
                                    a.Code = Convert.ToInt32(splitVou[1]);
                                    BissInventaireEntities.Instance.Bien.Add(a);
                                    BissInventaireEntities.Instance.SaveChanges();
                                    insert_test = false;
                                }

                                catch (Exception)
                                {
                                    insert_test = false;
                                    return View("ImportTxt");
                                 
                                }
                                return RedirectToAction("Cipherlab");
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Selectionner un fichier Text SVP !!!";
                        return View("ImportTxt");
                    }


                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                return View("ImportTxt");
            }
            return View("ImportTxt");
        }


        public ActionResult Cipherlab()
        {
            var cipher = BissInventaireEntities.Instance.Bien.ToList();
            return View(cipher);
        }
    }
}




