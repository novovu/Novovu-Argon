using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novovu.Argon
{
    public class ARTComposition
    {
        private ChromiumWebBrowser handle;
        public bool CWB_Run = false;
        public void SetHandle(object ha)
        {
            handle = (ChromiumWebBrowser)ha;
            handle.LoadingStateChanged += Handle_LoadingStateChanged;
        }

        private void Handle_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                if (OnLoadComplete != null)
                {
                    OnLoadComplete.Invoke(this, null);
                }
                
            }
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
                if (ax.GetType() == typeof(string))
                {
                    query += "'" + ax.ToString() +"'"+ ",";
                }
                else
                {
                    query += ax.ToString() + ",";
                }
                
            }
            query = query.TrimEnd(',');
            query += ")";
            return await JSEvalAsync<T>(query);
        }
        public void Build(string src)
        {
            handle.GetBrowser().MainFrame.LoadHtml(src);
            
        }
        public event EventHandler OnLoadComplete;
        public void Bind(string name, object binder)
        {
            handle.JavascriptObjectRepository.Register(name, binder, true);
        }
    }
}
