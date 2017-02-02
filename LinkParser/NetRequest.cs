using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
namespace LinkParser
{
    class NetRequest
    {
        private string _responseFromServer;
        private int _code;

        public NetRequest()
        {
            _responseFromServer = "";
            _code = 0;

 
        }

        public string GetHtmlCode(string _link)
        {
            try
            {
                WebRequest request = WebRequest.Create(_link);
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                            _responseFromServer = "";
                            _responseFromServer = reader.ReadToEnd();
                    }
                    response.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "008";
            }

           return _responseFromServer;
        }

        public int GetStatusCode(string _link)
        {
            try
            {
                WebRequest request = WebRequest.Create(_link);
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        _code = (int)(((HttpWebResponse)response).StatusCode);
                    }
                    response.Close();
                }
            }
            catch (WebException e)
            {
 
                    Console.WriteLine(_link + " " + e.Message);
            }
            catch (UriFormatException e)
            {
                Console.WriteLine(e.Message);

            }

           return _code;
        }
    }
}
