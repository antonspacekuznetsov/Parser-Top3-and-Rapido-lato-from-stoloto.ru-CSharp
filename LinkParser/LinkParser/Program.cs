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
                Application.EnableVisualStyles();
                Application.Run(new MainForm());
                //Proccess2 proc = new Proccess2();
                //proc.Start();
                //proc.StartRedio();
            Console.Write("Press any key to exit...!");
            Console.ReadKey();
        }
    }
}
