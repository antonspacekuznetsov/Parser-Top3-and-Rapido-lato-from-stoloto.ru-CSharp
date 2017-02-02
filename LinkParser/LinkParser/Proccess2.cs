using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Threading;
namespace LinkParser
{
    class Proccess2
    {
        private NetRequest _net;
        private ISmtpSender _sender;
        private string _link;
        List<Top3> top3;
        List<Top3> radeo;

        public Proccess2()
        {
            _sender = new MailSender();
            _net = new NetRequest(_sender);
           top3 = new List<Top3>();
           radeo = new List<Top3>();

        }


        public void Start()
        {
            Console.WriteLine("Top 3 Started!");
            for(;;)
            {
           // Console.WriteLine(_net.GetHtmlCode(_link));
             
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(_net.GetHtmlCode(@"http://www.stoloto.ru/top3/archive"));
            var el = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("elem"));
            foreach (HtmlNode node in el)
            {
                var top = new Top3();

                var znach = node.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("draw_date"));
                foreach (HtmlNode b in znach)
                {
                    var znach2 = node.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("container cleared"));
                    top.date = b.InnerText;
                   // Console.Write(b.InnerText + " ");
                    foreach (HtmlNode f in znach2)
                    {
                        Regex rgx = new Regex(@"[^\d]");
                        top.numbers += (rgx.Replace(f.InnerText, ""));
                        

                    }
                    
                }
                top3.Add(top);
            }
            int limit = Settings.top3Count;
            int sequence = Settings.top3Seq;
            int[] chisla = {0,0,0};
            int counter = 0;
            List<string> list = new List<string>();
            foreach (Top3 t in top3)
            {
                if (counter == limit)
                    break;
                int j = 0;
                foreach (char v in t.numbers)
                {
                    int mbr=-1;
                    int.TryParse(v.ToString(), out  mbr);
                    if (mbr != -1)
                        {
                            if (sequence > 0)
                            {
                                if ((mbr % 2) == 0)
                                {
                                    chisla[j]++;
                                }
                                else
                                {
                                    if (chisla[j] >= sequence)
                                    {
                                        list.Add((j + 1) + "." + chisla[j].ToString());
                                        chisla[j] = 0;
                                    }
                                    else
                                        chisla[j] = 0;
                                }


                            }
                            else
                            {
                                if ((mbr % 2) != 0)
                                {
                                    chisla[j]++;
                                }
                                else
                                {
                                    if (chisla[j] >= (sequence*(-1)))
                                    {
                                        list.Add((j + 1) + "." + chisla[j].ToString());
                                        chisla[j] = 0;
                                    }
                                    else
                                        chisla[j] = 0;
                                }
                            }
                        }
                    j++;
                    
                }
               // Console.Write(t.date + " " + t.numbers+" ");
               // Console.WriteLine("\n");
                counter++;
            }
            FileWriter fl = new FileWriter();
            foreach (string str in list)
            {
                string outer="";
                if (sequence >0)
                    outer = "Четное: Ряд: ";
                else
                    outer = "Нечетное: Ряд: ";
                foreach (char c in str)
                {
                    if (c == '.')
                    {
                        outer += " Подрят: ";
                        continue;
                    }
                    outer += c.ToString();

                }
                fl.Save(outer);
            }

            Console.WriteLine("TOP 3 data saved in file!");
            Thread.Sleep(Settings.top3Time * 1000);
        }
        }

        public void StartRedio()
        {
            int Vcounter = 1;
            Console.WriteLine("Rapido Started!");
            for(;;)
            {

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(_net.GetHtmlCode(@"http://www.stoloto.ru/rapido/archive"));
            var el = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("elem"));
            foreach (HtmlNode node in el)
            {
                var top = new Top3();

                var znach = node.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("draw_date"));
                foreach (HtmlNode b in znach)
                {
                    var znach2 = node.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("container cleared"));
                    top.date = b.InnerText;
                    
                    // Console.Write(b.InnerText + " ");
                    foreach (HtmlNode f in znach2)
                    {
                        var znach3 = f.Descendants("b");
                        
                        //Console.Write(rgx.Replace(f.InnerText, ""));
                        foreach (HtmlNode ff in znach3)
                        {
                            Regex rgx = new Regex(@"[^\d]");
                            top.numbers += (rgx.Replace(ff.InnerText, "")+".");
                        }


                    }

                }
                radeo.Add(top);
                
            }
            Console.WriteLine("New request! number:{0}", Vcounter++);
            Thread.Sleep(Settings.rTime*1000);
        }
        }
    }
}
