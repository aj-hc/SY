using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web.TestData
{
    public partial class WebTest1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Common.HttpHelper http = new Common.HttpHelper();
            Common.HttpItem item = new Common.HttpItem();
            Common.HttpResult res = new Common.HttpResult();


            // item.URL = "http://192.168.183.130/api?username=admin&password=123456&method=get_perfect_box";

            //http://192.168.183.130/api?username=admin&password=123456&method=get_perfect_box&space=1&container_id=2

            #region ok
            //http://192.168.183.130/api?username=admin&password=123456&method=get_perfect_box&space=1&freezer_name=tem->admin->06
            //{"success":true,"box_id":1347,"location":"tem->admin->06->02"} 
            #endregion

            //item.PostEncoding = Encoding.UTF8;
            ////item.Method = "GET";
            //item.Method = "POST";
            //item.Postdata = "freezer_name=001号冰箱&container_id=1&space=1";


            //if (!IsPostBack)
            //{
            //    res = http.GetHtml(item);
            //    Response.Write("html：" + res.Html + "<br/><br/>" + "Header：" + res.Header);
            //}

            string url = "http://192.168.183.130/api?username=admin&password=123456";
            Dictionary<string, string> dic = FreezerProUtility.Fp_BLL.Samples.GetAllSample_TypesNames(url);
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            if (dic.Count>0)
            {
                foreach (KeyValuePair<string,string> dd in dic)
                {
                    Dictionary<string, string> temdic = new Dictionary<string, string>();
                    temdic.Add("value", dd.Key);
                    temdic.Add("text", dd.Value);
                    list.Add(temdic);
                   
                }
            }
            string jsonList = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            string jsonDic = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryToJsonString(dic);
            Response.Write(jsonDic);
            Response.Write("<br />");
            Response.Write(jsonList);
        }
    }
}