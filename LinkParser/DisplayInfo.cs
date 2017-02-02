using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkParser
{
    public static class DisplayInfo
    {
        public static void ShowInfo(string infomessage)
        {
            Console.WriteLine(infomessage);
            Console.Write("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static void ShowLink(string link, int code, int count)
        {
            Console.WriteLine(link+", "+code);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("TOTAL: {0}", count+"\r");
            Console.ResetColor();
        }

        public static void ShowDataWritten()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Data written in file!");
            Console.ResetColor();
            Console.WriteLine("Press any key to go to next step or '0' to exit");
            string key = Console.ReadLine();
            if(key=="0")
                Environment.Exit(0);

        }
    }
}
