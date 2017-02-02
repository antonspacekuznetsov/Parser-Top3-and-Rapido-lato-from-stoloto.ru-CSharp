using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace LinkParser
{
    class FileWriter:ISaver
    {
        private static string _filepath;
        private ISmtpSender _errorSend;

        public FileWriter()
        {
           FileCheker(ConfigurationManager.AppSettings["path"], ConfigurationManager.AppSettings["filename"]);
        }

        private void FileCheker(string path, string name)
        {

            int t = 0;
            if (File.Exists(path + "\\" + name + ConfigurationManager.AppSettings["fileformat"]))
            {
                while (File.Exists(path + "\\" + name + t.ToString() + ConfigurationManager.AppSettings["fileformat"]))
                {
                    t++;
                }
                _filepath = path + "\\" + name + t.ToString() + ConfigurationManager.AppSettings["fileformat"];
                try
                {
                    using (FileStream fs = File.Create(_filepath)) { }
                }
                catch (Exception ex)
                {
                    _errorSend.SendMail(ex.Message);
                    DisplayInfo.ShowInfo(ex.Message.ToString());
                }

            }
            else
            {
                _filepath = path + "\\" + name + ConfigurationManager.AppSettings["fileformat"];
                try
                {
                    using (FileStream fs = File.Create(_filepath)) { }
                }
                catch (Exception ex)
                {
                    _errorSend.SendMail(ex.Message);
                    DisplayInfo.ShowInfo(ex.Message.ToString());
                }
            }
        }

        public void Save(string str)
        {
            try
            {

                    File.AppendAllText(_filepath, str, Encoding.UTF8);
                    File.AppendAllText(_filepath, "\r\n", Encoding.UTF8);
                //DisplayInfo.ShowDataWritten();
            }
            catch (Exception ex)
            {
                DisplayInfo.ShowInfo(ex.Message.ToString());
            }
        }
    }
}
