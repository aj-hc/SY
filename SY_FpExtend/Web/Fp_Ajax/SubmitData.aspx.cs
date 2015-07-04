using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web.Fp_Ajax
{
    public partial class SubmitData : System.Web.UI.Page
    {
        string url = Common.CreatFpUrl.FpUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.Params["action"].ToString();
            string codeform = Request.Params["codeform"].ToString();
            string _ClinicalInfoDg = Request.Params["_ClinicalInfoDg"].ToString();
            string strSampleInfoDiv = Request.Params["strSampleInfoDiv"].ToString();
            string _dg_SampleInfo = Request.Params["_dg_SampleInfo"].ToString();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (action == "gethisdata")
            {
                dic.Add("codeform", codeform);
                dic.Add("_ClinicalInfoDg", _ClinicalInfoDg);
                dic.Add("strSampleInfoDiv", strSampleInfoDiv);
                dic.Add("_dg_SampleInfo", _dg_SampleInfo);
            }
            else
            {
                Response.Write("错误信息");
            }
        }

        private string ImportSamples()
        {
            
            return "";
        }
        private string ImportSampleSource()
        {
            return "";
        }
        private string ImportTestData()
        {
            return "";
        }
    }
}