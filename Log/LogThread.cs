using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Log
{
    public sealed class LogThread : IDisposable
    {
        private string sLogFormat;
        private string sErrorTime;




        private static readonly object Locker = new object();
        private static readonly StreamWriter Writer = new StreamWriter(@"d:\log.txt", true);
        private static bool _disposed;

        public static void WriteLine(string message)
        {

           
            ThreadPool.QueueUserWorkItem(MessageWriter, message);

        }

        private static void MessageWriter(object message)
        {
            if (!(message is string)) return;

            lock (Locker)
            {

                Writer.WriteLine(DateTime.Now.ToString("MMM ddd d HH:mm yyyy") + " " + message);
                Writer.Flush();
            }
        }

        ~LogThread()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            lock (Locker)
            {

                if (_disposed)
                    return;

                if (disposing)
                {
                    if (Writer != null)
                        Writer.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
