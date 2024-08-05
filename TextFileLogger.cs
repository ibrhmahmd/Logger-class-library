using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogger
{
    public class TextFileLogger : Logger
    {

        public TextFileLogger(string fileName)
        {
            this.Path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

        public override void log(string msg)
        {
            StreamWriter logWriter;
            logWriter = new StreamWriter(Path, append: true);

            DateTime time = DateTime.Now;

            try
            {
                string data = $"AT {time}   :{msg}";
                logWriter.WriteLine(data);
                Console.WriteLine("Log written successfully ");
            }
            catch (Exception e)
            {
                Console.WriteLine("Logging Error");
                //logWriter.WriteLine($"Error AT {time}:       {e.Message}");
                //should be written some whete else 
            }
            finally
            {
                if (logWriter != null)
                {
                    logWriter.Close();
                }
            }
        }
    }

}
