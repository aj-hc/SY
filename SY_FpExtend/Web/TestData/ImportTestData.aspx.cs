using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web.TestData
{
    public partial class ImportTestData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string u = U.Text.Trim();
            string p = P.Text.Trim();
            string t = T.Text.Trim();
            string w = W.Text.Trim();
            string y = Y.Text.Trim();

            FreezerProUtility.Fp_Common.UnameAndPwd up = new FreezerProUtility.Fp_Common.UnameAndPwd(u, p);
            FreezerProUtility.Fp_BLL.TestData testData = new FreezerProUtility.Fp_BLL.TestData();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Sample Source", y);
            dic.Add("网络链接地址", w);
            dic.Add("图片网络链接地址", t);
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>() { dic };
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                str.Append(i + ";");
                string res = FreezerProUtility.Fp_BLL.TestData.ImportTestData(up, "知情同意书管理--心妍所", list);
            }
            Response.Write(str.ToString());
        }
    }
}