using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web
{
    public partial class www : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Dictionary<string, Dictionary<string, string>>> List = new List<Dictionary<string, Dictionary<string, string>>>();

            Dictionary<string, string> dicbaseinfo = new Dictionary<string, string>();
            dicbaseinfo.Add("success", "True");
            dicbaseinfo.Add("msg", "");
            dicbaseinfo.Add("state", "");

            Dictionary<string, Dictionary<string, string>> dddicbaseinfo = new Dictionary<string, Dictionary<string, string>>();
            dddicbaseinfo.Add("baseinfo", dicbaseinfo);

            Dictionary<string, string> dicclientinfo = new Dictionary<string, string>();
            dicclientinfo.Add("success", "True");
            dicclientinfo.Add("msg", "");
            dicclientinfo.Add("state", "");

            Dictionary<string, Dictionary<string, string>> ddclieninfo = new Dictionary<string, Dictionary<string, string>>();
            dddicbaseinfo.Add("clien", dicbaseinfo);

            Dictionary<string, string> dicsampleinfo1 = new Dictionary<string, string>();
            dicsampleinfo1.Add("success", "True");
            dicsampleinfo1.Add("msg", "");
            dicsampleinfo1.Add("state", "");

            Dictionary<string, string> dicsampleinfo2 = new Dictionary<string, string>();
            dicsampleinfo2.Add("success", "True");
            dicsampleinfo2.Add("msg", "");
            dicsampleinfo2.Add("state", "");

            Dictionary<string, string> dicsampleinfo3 = new Dictionary<string, string>();
            dicsampleinfo3.Add("success", "True");
            dicsampleinfo3.Add("msg", "");
            dicsampleinfo3.Add("state", "");
            Dictionary<string, Dictionary<string, string>> dddsampleinfo = new Dictionary<string, Dictionary<string, string>>();
            dddsampleinfo.Add("sampleinfo1", dicsampleinfo1);
            dddsampleinfo.Add("sampleinfo1", dicsampleinfo2);
            dddsampleinfo.Add("sampleinfo1", dicsampleinfo3);
            List.Add(dddicbaseinfo);
            List.Add(dddsampleinfo);
            List.Add(ddclieninfo);


            Response.Write(FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(List));
        }
    }
}