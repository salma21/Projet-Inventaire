using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ExcelParser
    {
        private static ExcelParser instance;

        public static ExcelParser Instance
        {
            get {
                if (instance == null)
                {
                    instance = new ExcelParser();
                }
               
                return instance; }
        }

        private ExcelParser()
        {

        }
        /// <summary>
        /// Construction de la chaine de connexion Excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string buildConnectionString(string filePath)
        {
            string cnx = null;
              string extension = System.IO.Path.GetExtension(filePath);
            if(extension.Equals(".xlsx")){
            cnx = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=Yes;IMEX=2';",filePath);
            }
            else if (extension.Equals(".xls"))
            {

                cnx = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0} ;Extended Properties='Excel 8.0;HDR=Yes;IMEX=2\'", filePath);
            }
            return cnx;
        }
        /// <summary>
        /// Parseur d'un fichier excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public DataTable ExcelParserToDataTable(string filePath,List<string> columns)
        {
            DataTable dataTable = new DataTable();
            string cnx = buildConnectionString(filePath);
            OleDbConnection excelConnection = null;
            string query = null;
            try
            {
                excelConnection=new OleDbConnection(cnx);
                excelConnection.Open();
                DataTable dt = new DataTable();
                dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }
                String[] excelSheets = new String[dt.Rows.Count];
                int t = 0;
                //excel data saves in temp file here.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[t] = row["TABLE_NAME"].ToString();
                    t++;
                }
                if (columns != null && columns.Count> 0)
                {
                    string champs = " ";

                    foreach (string column in columns)
                    {
                        champs += column + " ,";
                    }
                    if (champs.Trim().Length > 0)
                    {
                        champs = champs.Substring(0, champs.Length - 2);
                    }
                    else
                    {
                        champs = " * ";
                    }
                    query = string.Format("Select {0} From [{1}] ", champs, excelSheets[0]);
                }
                else
                {
                    query = string.Format("Select * from [{0}]", excelSheets[0]);
                }


                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection))
                {
                    dataAdapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
            return dataTable;
        }
    }
}
