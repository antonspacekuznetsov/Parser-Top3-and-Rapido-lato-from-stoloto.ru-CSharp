using System;
using System.Collections.Generic;

using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
namespace LinkParser
{
    class FileWriter
    {
        private string _filepath;
        private string _firstArg;
        private string md5;
        public FileWriter(string arg)
        {
            if (ConfigurationSettings.AppSettings["path"] == "")
            {
                MessageBox.Show("Вы не указали в конфиге путь");
                Environment.Exit(0);
            }
            if (ConfigurationSettings.AppSettings["fileformat"] == "")
            {
                MessageBox.Show("Вы не указали в конфиге формат файла");
                Environment.Exit(0);
            }
            if (ConfigurationSettings.AppSettings["filename"] == "")
            {
                DateTime thisDate1 = DateTime.Now;
                // +thisDate1.ToString("_yy-MM-dd_H-m");

                FileCheker(ConfigurationSettings.AppSettings["path"], (arg +""+thisDate1.ToString("_yyyy-MM-dd_H-mm")));

            }
            else
            FileCheker(ConfigurationSettings.AppSettings["path"], ConfigurationSettings.AppSettings["filename"]);
        }


        private void FileCheker(string path, string name)
        {
            int t = 0;
            if (File.Exists(path + "\\" + name + ConfigurationSettings.AppSettings["fileformat"]))
            {
                while (File.Exists(path + "\\" + name + t.ToString() + ConfigurationSettings.AppSettings["fileformat"]))
                {
                    t++;
                }
                _filepath = path + "\\" + name + "-v"+t.ToString() + ConfigurationSettings.AppSettings["fileformat"];
                try
                {
                    using (FileStream fs = File.Create(_filepath))
                    {
                        Settings.lastFile = _filepath;

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Возникла ошибка при созании файла: " + ex.Message);
                    Environment.Exit(0);
                }

            }
            else
            {
                _filepath = path + "\\" + name + ConfigurationSettings.AppSettings["fileformat"];
                try
                {
                    using (FileStream fs = File.Create(_filepath))
                    { 
                        Settings.lastFile = _filepath;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла ошибка при создании файла: " + ex.Message);
                    Environment.Exit(0);
                }
            }
        }

        public void Write(string text)
        {
            try
            {
                File.AppendAllText(_filepath, text, Encoding.UTF8);
                File.AppendAllText(_filepath, "\r\n", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка при записи: " + ex.Message);
                Environment.Exit(0);
            }
        }



        public string GetMD5()
        {
            using (var md5 = MD5.Create())
            using (var stream=File.OpenRead(_filepath))
            {

                this.md5 = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
            }
            return this.md5;
        }
    }
}
