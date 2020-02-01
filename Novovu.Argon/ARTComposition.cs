using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novovu.Argon
{
    public class ARTComposition
    {
        private ChromiumWebBrowser handle;
        public bool CWB_Run = false;
        public ARTComposition(object handl)
        {
            handle = (ChromiumWebBrowser)handl;
        }
        private async Task<T> JSEvalAsync<T>(string scr)
        {
            JavascriptResponse response = await handle.GetBrowser().MainFrame.EvaluateScriptAsync(scr);
            return (T)response.Result;
        }
        public async Task<T> RunJSMethod<T>(string method, params object[] methodPs)
        {
            string query = method + "(";
            foreach (object ax in methodPs)
            {
                query += ax.ToString() + ",";
            }
            query = query.TrimEnd(',');
            query += ")";
            return await JSEvalAsync<T>(query);
        }
        public void Bind(string name, object binder)
        {
            handle.JavascriptObjectRepository.Register(name, binder, true);
        }
    }
}
