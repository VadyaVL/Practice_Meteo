using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Parser
{
    public class LOG
    {
        private static LOG log = null;

        public string LOG_FilePath { get; set; }
        private StreamWriter sw;

        private LOG()
        {
            LOG_FilePath = "log/Log_" + System.DateTime.Now.ToString().Replace(' ', '_').Replace(':', '-') + ".txt";
            sw = new StreamWriter(LOG_FilePath);
        }

        public static LOG GetInstance()
        {
            if (log == null)
            {
                log = new LOG();
                log.Write(System.DateTime.Now.ToString(), "початок роботи програми;");
            }
            return log;
        }
     
        public void Write(string date, string str)
        {
            sw.Write("{0,11}", date);
            sw.Write("{0,8}", "---");
            sw.Write("     ");
            sw.WriteLine(str);
        }

        public void Commit()
        {
            log.Write(System.DateTime.Now.ToString(), "кінець роботи програми;");
            sw.Close();
            log = null;
        }    
    }
}
