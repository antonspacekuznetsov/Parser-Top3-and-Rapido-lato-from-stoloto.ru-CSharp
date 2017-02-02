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
        
        

        public Proccess2()
        {
            _sender = new MailSender();
            _net = new NetRequest();
        }


        public void Start()
        {
            Console.WriteLine("\t\t\rTop 3 Started!");
            for(;;)
            {
           // Console.WriteLine(_net.GetHtmlCode(_link));
            List<Top3> top3 = new List<Top3>();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(_net.GetHtmlCode(@"http://www.stoloto.ru/top3/archive"));
            var el = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("elem"));
            foreach (HtmlNode node in el)
            {
                var top = new Top3();

                var znach = node.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("draw_date"));
                var zn = node.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("draw"));
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
                foreach (HtmlNode b in zn)
                {
                    var tt = b.Descendants("a");
                    foreach (HtmlNode bb in tt)
                        top.date = bb.InnerHtml;
                }

                top3.Add(top);
            }
            int limit = Settings.top3Count;
            int sequence = Settings.top3Seq;
            int Nsequence = Settings.top3NSeq;
            int[] chisla = {0,0,0};
            int[] chisla2 = { 0, 0, 0 };
            int counter = 0;
            List<string> list = new List<string>();
            List<string> Nlist = new List<string>();
            List<string> points = new List<string>();
            List<string> Npoints = new List<string>();
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
                            if (sequence > 0 && Nsequence > 0)
                            {
                                if ((mbr % 2) == 0)
                                {


                                    chisla[j]++;

                                    if (chisla[j] >= sequence)
                                    {
                                        list.Add((j + 1) + "." + chisla[j].ToString());
                                        points.Add(t.date);//end;
                                        chisla[j] = 0;
                                    }

                                    if (chisla2[j] >= Nsequence)
                                    {
                                        Nlist.Add((j + 1) + "." + chisla2[j].ToString());
                                        Npoints.Add(t.date);//end;
                                        chisla2[j] = 0;
                                    }
                                    else
                                        chisla2[j] = 0;
                                    
                                }
                                else
                                {
                                    chisla2[j]++;

                                    if (chisla2[j] >= Nsequence)
                                    {
                                        Nlist.Add((j + 1) + "." + chisla2[j].ToString());
                                        Npoints.Add(t.date);//end;
                                        chisla2[j] = 0;
                                    }

                                    if (chisla[j] >= sequence)
                                    {
                                        list.Add((j + 1) + "." + chisla[j].ToString());
                                        points.Add(t.date);//end;
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
           /* if (list.Count == 0 && Nlist.Count == 0)
            {
                Console.WriteLine("\t\t\rFor TOP 3 No data...");
                continue;
            }*/

            string lastFile = Settings.lastFile;

            string result = "";
            FileWriter fl = new FileWriter("TOP3");
            int index = 0;
            fl.Write("<html><head></head><body><h2>Четные</h2><table><tr><td>Ряд</td><td>Подряд (раз)</td><td>Тираж</td></tr>");
            foreach (string str in list)
            {
                
                string  outer = "<tr> ";
                foreach (char c in str)
                {
                    if (c == '.')
                    {
                        continue;
                    }
                    outer += "<td>" + c.ToString()+"</td>";

                }
                int aqq;
                int.TryParse(points[index], out aqq);
                outer += " " + "<td>"+ (aqq+ Settings.top3Seq-1)+"</td></tr>";
                fl.Write(outer);
                result += outer;
                index++;
            }
            result = "<h2>Четные</h2><table><tr><td>Ряд</td><td>Подряд (раз)</td><td>Тираж</td></tr>" + result + "</table><br>";

            fl.Write("</table><br><h2>Нечетные</h2><table><tr><td>Ряд</td><td>Подряд (раз)</td><td>Тираж</td></tr>");

            index = 0;
            string result2 = "";
            foreach (string str in Nlist)
            {
                string outer = "<tr> ";

                foreach (char c in str)
                {
                    if (c == '.')
                    {
                        continue;
                    }
                    outer += "<td>" + c.ToString() + "</td>";

                }
                int aqq;
                int.TryParse(Npoints[index], out aqq);
                outer += " " + "<td>" + (aqq + Settings.top3NSeq-1) + "</td></tr>";
                fl.Write(outer);
                result2 += outer;
                index++;
            }

            result2 = "<h2>Нечетные</h2><table><tr><td>Ряд</td><td>Подряд (раз)</td><td>Тираж</td></tr>" + result2 + "</table>";
            result += result2;
            result = "<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"><title> TOP 3</title></head><body>" + result + "</body></html>";

            fl.Write("</table></body></html>");

            Console.WriteLine("\t\t\rTOP 3 data saved in file!\t");

            if (Settings.emailOn == 1)
            {
                _sender.SendMail(result, "TOP 3");
            }
             /*   if(lastFile != null)
            if(fl.NotEqualFile(lastFile, Settings.lastFile))
            Settings.soundLoop++;*/
            string tmpmd5 = "";
            if (Settings.top3MD5 != null)
            {
                tmpmd5 = fl.GetMD5();
                if (tmpmd5 != null)
                if (Settings.top3MD5 != tmpmd5)
                {
                    
                    Settings.soundLoop++;
                    Console.WriteLine("***Top 3 NEW Combination***");
                    Console.WriteLine("{0} != {1}", Settings.top3MD5, tmpmd5);
                }
                else
                    Console.WriteLine("{0} = {1}", Settings.top3MD5, tmpmd5);
            }
            Settings.top3MD5 = fl.GetMD5();
            int timer = 0;
            while (true)
            {
                if (!Settings.top3Thread)
                {
                    Console.WriteLine("\t\t\rTop 3 stoped!");
                    return;
                }
                   
                if (timer >= Settings.top3Time)
                    break;

                timer++;
                    //Console.WriteLine("Next TOP 3 in {0} ", Settings.top3Time - timer);
                Thread.Sleep(1000);
            }
        }
        }


        public void StartRedio()
        {
            int Vcounter = 1;
            Console.WriteLine("\t\t\rRapido Started!");
            for(;;)
            {
            List<Top3> radeo = new List<Top3>();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(_net.GetHtmlCode(@"http://www.stoloto.ru/rapido/archive"));
            var el = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("elem"));
            foreach (HtmlNode node in el)
            {
                var top = new Top3();

                var znach = node.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("draw_date"));
                var zn = node.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("draw"));
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
                foreach (HtmlNode b in zn)
                {
                    var tt = b.Descendants("a");
                    foreach (HtmlNode bb in tt)
                        top.date = bb.InnerHtml;
                }
                radeo.Add(top);
                
            }
            int limit = Settings.rCount;
            int sequence = Settings.rSeq;
            int Nsequence = Settings.rNSeq;
            int r18 = Settings.rSrav18;
            int[] chisla = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] chisla2 = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] chislo18 = { 0, 0 };
            int[] Rchsila = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] RchsilaCount = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int chislo1 = 0; 
            int counter = 0;
            int ChisloRacCount = 0;
            List<string> list = new List<string>();
            List<string> Nlist = new List<string>();
            List<string> points = new List<string>();
            List<string> Npoints = new List<string>();
            List<Chislo18> Rch18 = new List<Chislo18>();
            List<Chislo18> MRch18 = new List<Chislo18>();
            List<RRchislo> ChisloRaz = new List<RRchislo>();
            string previosDate = "";

            int Rchislo = 0;
            int Rraz = 0;
            string tmmp="";
            foreach (char rr in Settings.rChislo)
            {
                if (rr == ';')
                {
                    int.TryParse(tmmp, out Rchislo);
                    tmmp = "";
                    continue;
                }

                tmmp += rr;
            }
            int.TryParse(tmmp, out Rraz);

            foreach (Top3 t in radeo)
            {
                if (counter == limit)
                    break;

                int j = 0;
                string astr = "";

                foreach (char v in t.numbers)
                {
                    if (v != '.')
                    {
                        astr += v;
                        continue;
                    }

                    int mbr = -1;
                    int.TryParse(astr, out  mbr);
                    astr = "";
                    if (mbr != -1)
                    {
                        if (sequence > 0 && Nsequence > 0)
                        {


                           /* if (mbr == Rchislo)
                            {
                                Rchsila[j]++;

                                if (Rchsila[j] >= Rraz)
                                {
                                    ChisloRaz.Add(new RRchislo {chislo= Rraz, date=t.date, number=j+1 });
                                    Rchsila[j] = 0;
                                }
                            }
                            else
                            {
                                Rchsila[j] = 0;
                            }*/
                            bool prznk = false;
                            int coord = -1;
                            if (counter == 0 && Rraz!=1)
                            {
                                Rchsila[j] = mbr;
                            }
                            else
                            {
                                foreach (int Xz in Rchsila)
                                {
                                    if (mbr == Xz)
                                    {
                                        prznk = true;
                                        break;
                                    }

                                    coord++;
                                }
                                if (prznk)
                                {
                                    RchsilaCount[j]++;
                                    if (RchsilaCount[j] >= Rraz-1)
                                    {
                                        ChisloRaz.Add(new RRchislo { chislo = Rchsila[j], date = t.date, number = j + 1 });
                                        RchsilaCount[j] = 0;
                                        Rchsila[j] = -1;
                                    }
                                }
                                else
                                {
                                    Rchsila[j] = mbr;
                                    RchsilaCount[j] = 0;
                                }
                            }
                            if (Rraz == 1)
                            {
                                ChisloRaz.Add(new RRchislo { chislo = mbr, date = t.date, number = j + 1 });
                            }

                            if (j == 0)
                            {
                                chislo1 = mbr;
                            }
                            if (j == 7)
                            {
                                if (chislo18[0] >= r18)
                                {
                                    Rch18.Add(new Chislo18 { chislo = chislo18[0], date = previosDate });
                                    chislo18[0] = 0;
                                }

                                if (chislo18[1] >= r18)
                                {
                                    MRch18.Add(new Chislo18 { chislo = chislo18[1], date = previosDate });
                                    chislo18[1] = 0;
                                }

                                if (chislo1 > mbr)
                                {
                                    chislo18[0]++;
                                    chislo18[1] = 0;
                                }
                                if (chislo1 < mbr)
                                {
                                    chislo18[1]++;
                                    chislo18[0] = 0;
                                }
                            }

                            if ((mbr % 2) == 0)
                            {
                                chisla[j]++;

                                if (chisla[j] >= sequence)
                                {
                                    list.Add((j + 1) + "." + chisla[j].ToString());
                                    points.Add(t.date);//end;
                                    chisla[j] = 0;
                                }

                                if (chisla2[j] >= Nsequence)
                                {
                                    Nlist.Add((j + 1) + "." + chisla2[j].ToString());
                                    Npoints.Add(t.date);//end;
                                    chisla2[j] = 0;
                                }
                                else
                                    chisla2[j] = 0;

                            }
                            else
                            {
                                chisla2[j]++;

                                if (chisla2[j] >= Nsequence)
                                {
                                    Nlist.Add((j + 1) + "." + chisla2[j].ToString());
                                    Npoints.Add(t.date);//end;
                                    chisla2[j] = 0;
                                }

                                if (chisla[j] >= sequence)
                                {
                                    list.Add((j + 1) + "." + chisla[j].ToString());
                                    points.Add(t.date);//end;
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
                previosDate = t.date;
            }
           /* if (list.Count == 0 && Nlist.Count == 0)
            {
               // Console.WriteLine("\t\t\rFor Rapido No data...");
                continue;
            }*/

            string lastFile = Settings.lastFile;

            string result = "";
            FileWriter fl = new FileWriter("RAPIDO");
            int index = 0;
            fl.Write("<html><head></head><body><h2>Четные</h2><table><tr><td>Ряд</td><td>Подряд (раз)</td><td>Тираж</td></tr>");
            foreach (string str in list)
            {

                string outer = "<tr> ";
                foreach (char c in str)
                {
                    if (c == '.')
                    {
                        continue;
                    }
                    outer += "<td>" + c.ToString() + "</td>";

                }
                int aqq;
                int.TryParse(points[index], out aqq);
                outer += " " + "<td>" + (aqq + Settings.rSeq-1) + "</td></tr>";
                fl.Write(outer);
                result += outer;
                index++;
            }
            result = "<h2>Четные</h2><table><tr><td>Ряд</td><td>Подряд (раз)</td><td>Тираж</td></tr>" + result + "</table><br>";

            fl.Write("</table><br><h2>Нечетные</h2><table><tr><td>Ряд</td><td>Подряд (раз)</td><td>Тираж</td></tr>");

            index = 0;
            string result2 = "";
            foreach (string str in Nlist)
            {
                string outer = "<tr> ";

                foreach (char c in str)
                {
                    if (c == '.')
                    {
                        continue;
                    }
                    outer += "<td>" + c.ToString() + "</td>";

                }
                int aqq;
                int.TryParse(Npoints[index], out aqq);
                outer += " " + "<td>" + (aqq + Settings.rNSeq-1) + "</td></tr>";
                fl.Write(outer);
                result2 += outer;
                index++;
            }

            fl.Write("</table><h2>1 больше 8</h2><table><tr><td>Кол-во раз</td><td>Тираж</td></tr>");
            string _rch18 = "";
            foreach(Chislo18 gg in Rch18)
            {
                int aqq;
                int.TryParse(gg.date, out aqq);
                _rch18 += "<tr><td>"+ gg.chislo+"</td><td>"+(aqq+Settings.rSrav18-1)+"</td></tr>";
            }
            fl.Write(_rch18);
            fl.Write("</table><h2>1 меньше 8</h2><table><tr><td>Кол-во раз</td><td>Тираж</td></tr>");
            string _rch182 = "";
            foreach (Chislo18 gg in MRch18)
            {
                int aqq;
                int.TryParse(gg.date, out aqq);
                _rch182 += "<tr><td>" + gg.chislo + "</td><td>" + (aqq + Settings.rSrav18 - 1) + "</td></tr>";
            }
            fl.Write(_rch182 + "</table><h2>Число  подряд "+Rraz+" раз</h2><table><tr><td>Ряд</td><td>Число</td><td>Тираж</td></tr>");

            string _chosloRaz = "";
            foreach (RRchislo _rtr in ChisloRaz)
            {
                int aqq,aqq2;
                int.TryParse(_rtr.date, out aqq);
                int.TryParse(Settings.rChislo, out aqq2);
                _chosloRaz += "<tr><td>" + _rtr.number + "</td><td>" + _rtr.chislo + "</td><td>" + _rtr.date + "</td></tr>";
            }

            result2 = "<h2>Нечетные</h2><table><tr><td>Ряд</td><td>Подряд (раз)</td><td>Тираж</td></tr>" + result2 + "</table><br>";
            result += result2;

            result2 = "<h2>1 больше 8</h2><table><tr><td>Кол-во раз</td><td>Тираж</td></tr>" + _rch18 +"</table><br>";
            result += result2;

            result2 = "<h2>1 меньше 8</h2><table><tr><td>Кол-во раз</td><td>Тираж</td></tr>" + _rch182 + "</table><br>";
            result += result2;

            result2 = "<h2>Число  подряд " + Rraz + " раз</h2><table><tr><td>Ряд</td><td>Число</td><td>Тираж</td></tr>" + _chosloRaz + "</table>";
            result += result2;

            result = "<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"><title> TOP 3</title></head><body>" + result + "</body></html>";

            fl.Write(_chosloRaz+"</table></body></html>");


            Console.WriteLine("\t\t\rRapido data saved in file!");

            if (Settings.emailOn == 1)
            {
                _sender.SendMail(result, "Rapido");
            }

            /*if (lastFile != null)
                if (fl.NotEqualFile(lastFile, Settings.lastFile))
                    Settings.soundLoop++;*/
            string tmpmd5 = "";
            if (Settings.rMD5 != null)
            {
                tmpmd5 = fl.GetMD5();
                if (tmpmd5 != null)
                    if (Settings.rMD5 != tmpmd5)
                    {

                        Settings.soundLoop++;
                        Console.WriteLine("***Rapido NEW Combination***");
                        Console.WriteLine("{0} != {1}", Settings.rMD5, tmpmd5);
                    }
                    else
                    {
                        Console.WriteLine("{0} = {1}", Settings.rMD5, tmpmd5);
                    }
            }
            Settings.rMD5 = fl.GetMD5();
            int timer = 0;
            while (true)
            {
                if (!Settings.rThread)
                {
                    Console.WriteLine("\t\t\rRapido stoped!\t");
                    return;
                }
                if (timer >= Settings.rTime)
                    break;

                timer++;
                
                  //  Console.WriteLine("Next RAPIDO in {0}",  Settings.rTime - timer);
                Thread.Sleep(1000);
            }
        }


        }


    }
}
