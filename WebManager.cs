using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace VST
{
    public class WebManager
    {
        private CookieContainer cookies;
        public Uri target;
        public WebManager(string uri)
        {
            cookies = new CookieContainer();
            string src = "http://example.vn";
            if (string.IsNullOrEmpty(uri))
                src = uri;

            target = new Uri(src);
        }

        public void AddCookie(string key, string value)
        {
            cookies.Add(new Cookie(key, value) { Domain = target.Host });
        }

        public string GetWebContent(string url)
        {
            string retContent = "";
            try
            {
                HttpWebRequest WebRequestObject = GenerateWebRequest(url);
                WebRequestObject.UserAgent = ".NET Framework/2.0";

                WebResponse Response = WebRequestObject.GetResponse();

                // Open data stream:
                System.IO.Stream WebStream = Response.GetResponseStream();

                // Create reader object:
                System.IO.StreamReader Reader = new System.IO.StreamReader(WebStream);

                // Read the entire stream content:
                retContent = Reader.ReadToEnd();

                // Cleanup
                Reader.Close();
                WebStream.Close();
                Response.Close();
            }
            catch (Exception ex)
            {
                retContent = "";
                //throw ex;
            }
            return retContent;
        }

        public string GetWebContentPOST(string url, string parameters)
        {
            string retContent = "";
            try
            {
                HttpWebRequest WebRequestObject = GenerateWebRequest(url);

                WebRequestObject.ContentLength = parameters.Length;
                WebRequestObject.UserAgent = ".NET Framework/2.0";

                try
                {
                    WebRequestObject.Method = "POST";

                    //fix error message 471 code
                    WebRequestObject.ServicePoint.Expect100Continue = false;

                    // Post to the login form.
                    System.IO.StreamWriter swRequestWriter = new System.IO.StreamWriter(WebRequestObject.GetRequestStream());

                    swRequestWriter.Write(parameters);
                    swRequestWriter.Close();

                    using (System.Net.HttpWebResponse hwrWebResponse = (System.Net.HttpWebResponse)WebRequestObject.GetResponse())
                    {
                        bool isSuccess = (int)hwrWebResponse.StatusCode < 299 && (int)hwrWebResponse.StatusCode >= 200;
                        if (isSuccess)
                        {
                            CookieCollection ccCookies = hwrWebResponse.Cookies;
                            using (System.IO.StreamReader reader = new System.IO.StreamReader(hwrWebResponse.GetResponseStream()))
                            {
                                retContent = reader.ReadToEnd();
                                reader.Close();
                            }
                        }
                    }
                }
                catch (System.Net.WebException ex)
                {
                    throw (ex);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retContent;
        }

        private HttpWebRequest GenerateWebRequest(string url)
        {
            HttpWebRequest WebRequestObject = WebRequest.Create(url) as HttpWebRequest;

            WebRequestObject.CookieContainer = cookies;
            WebRequestObject.Timeout = 50000;

            WebRequestObject.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            WebRequestObject.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.114";
            WebRequestObject.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            WebRequestObject.KeepAlive = true;
            WebRequestObject.Accept = "*/*";
            WebRequestObject.Headers.Add("X-Requested-With", "XMLHttpRequest");

            return WebRequestObject;
        }
    }
}
