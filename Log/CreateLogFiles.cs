using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Threading;

namespace Log
{
    public class CreateLogFiles
    {
        private string sLogFormat;
        private string sErrorTime;

        public CreateLogFiles()
        {
            //sLogFormat used to create log files format :
            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

            //this variable used to create log filename format "
            //for example filename : ErrorLogYYYYMMDD
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sErrorTime = sYear + sMonth + sDay;
        }
        public void ErrorLog(string sErrMsg)
        {
            var filename = @"c:\log.txt";
            FileInfo txtfile = new FileInfo(filename);
            if (txtfile.Length > (2 * 1024 * 1024))       // ## NOTE: 2MB max file size
            {
                var lines = File.ReadAllLines(filename).Skip(10).ToArray();  // ## Set to 10 lines remove first 10 line
                File.WriteAllLines(filename, lines);
            }
            StreamWriter sw = new StreamWriter(filename, true);
            sw.WriteLine(sLogFormat + sErrMsg);
            sw.Flush();
            sw.Close();
        }
    }
}
