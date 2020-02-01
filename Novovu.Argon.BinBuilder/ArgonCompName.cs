using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novovu.Argon.BinBuilder
{
    public class ArgonCompName : ARTComposition, IArgonCompositionBuild
    {
        private string b64 = "";

        public ArgonCompName(object handl, object binda, object bindb) : base(handl)
        {
            Bind("binda", binda);
            Bind("bindb", bindb);
        }

        public string Build()
        {
            return Encoding.Unicode.GetString(Convert.FromBase64String(b64));
        }

        public async Task<T> DoRandomStuff<T>(object p1, object p2)
        {
            return await RunJSMethod<T>("DoRandomStuff", p1, p2);
        }
    }
}
