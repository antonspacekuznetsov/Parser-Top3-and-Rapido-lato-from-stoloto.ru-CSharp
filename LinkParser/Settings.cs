using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkParser
{
    static class Settings
    {
        public static int rTime { get; set; }
        public static int rCount { get; set; }
        public static int rOn { get; set; }
        public static int rSeq { get; set; }
        public static int rNSeq { get; set; }
        public static int rSrav18 { get; set; }
        public static string rChislo { get; set; }
        public static string rMD5 { get; set; }

        public static int top3Time { get; set; }
        public static int top3Count { get; set; }
        public static int top3On { get; set; }
        public static int top3Seq { get; set; }
        public static int top3NSeq { get; set; }
        public static string top3MD5 { get; set; }

        public static string email { get; set; }
        public static int emailOn { get; set; }

        public static int sound { get; set; }
        public static int soundLoop { get; set; }

        public static bool top3Thread { get; set; }
        public static bool rThread { get; set; }

        public static string lastFile { get; set; }
    }
}
