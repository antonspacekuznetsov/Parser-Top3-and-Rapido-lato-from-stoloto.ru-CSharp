using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace LinkParser
{
    class Process
    {

        private ISmtpSender _sender;
        private IRegularEx _reqrequest;
        private IParser _parser;
        private ISaver _saver;
        private NetRequest _net;
        private string _link;

        public Process(string link)
        {
            _sender = new MailSender();
            _reqrequest = new RegExWorker();
            _net = new NetRequest(_sender);
            //_saver = new FileWriter(_sender);
            _parser = new DataParser(_sender,_net);
            _link = link;
        }

        public void Runner()
        {
            int deep;
            Int32.TryParse(ConfigurationManager.AppSettings["deep"], out deep);
            List <LinkInfo> parts1 = new List<LinkInfo>();
            List<LinkInfo> parts2 = new List<LinkInfo>();

            parts1.Add(new LinkInfo() { Url = _link, Code = _net.GetStatusCode(_link) });
            for (int i = 0; i < deep; ++i)
            {
                foreach (LinkInfo line in parts1)
                    _parser.Parse(ref parts2, line.Url);
               // _saver.Save(ref parts2);
                parts1.Clear();
                parts1 = parts2.CloneList().ToList();
                parts2.Clear();
            }
        }
    }

    internal static class Extensions
    {
        public static IList<LinkInfo> CloneList<LinkInfo>(this IList<LinkInfo> list) where LinkInfo : ICloneable
        {
            return list.Select(item => (LinkInfo)item.Clone()).ToList();
        }
    }
}
