using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LinkParser
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

        /*    MessageBox.Show(
    "Error when starting LinkParser: не является приложением Win32",
    "Error occured",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1,
    MessageBoxOptions.DefaultDesktopOnly);

            return;*/

           // Process proc = new Process(args[0]);
           // proc.Runner();
            NetRequest net = new NetRequest();
           string check= net.GetHtmlCode(@"http://cu51882.tmweb.ru/top3rapido.html");
           if (check == "008")
           {
               MessageBox.Show("Нет соединения с интернетом");
               return;
           }
           /*if (check != "123q")
           {
               MessageBox.Show("Возникла ошибка в работе программы обратитесь к разработчику: as.ky@ya.ru");
               return;
           }*/
                Application.EnableVisualStyles();
                Application.Run(new MainForm());
                //Proccess2 proc = new Proccess2();
                //proc.Start();
                //proc.StartRedio();
            //ISmtpSender m = new MailSender();
            //m.SendMail("hello");
        }
    }
}
