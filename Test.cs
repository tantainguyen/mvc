using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VST
{
    class TestManager
    {
        private WebManager _web;
        public TestManager()
        {
            string uri = "http://example";
            _web = new WebManager(uri);
        }

        public string GetWebContent(string url)
        {
            string result = "";
            if (string.IsNullOrEmpty(url)) return result;

            result = _web.GetWebContent(url);

            return result;
        }

        public string GetWebContent(string url, int languageID)
        {
            if (string.IsNullOrEmpty(url)) return "";

            string languageCulture = GetLanguageCulture(languageID);
            _web.AddCookie("language", languageCulture);

            return _web.GetWebContent(url);
        }

        private string GetLanguageCulture(int languageID)
        {
            if (languageID == 2)
                return "en-GB";
            else
                return "vi-VN";
        }
    }
}
