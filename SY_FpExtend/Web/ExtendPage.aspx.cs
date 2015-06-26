using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RuRo.BLL;
using RuRo.Model;

namespace RuRo.Web
{
    public partial class ExtendPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        //private void BaseInfoUrl()
        //{
        //    string s = "Fp_ExtendPage/BaseInfo.aspx";
        //    ifBaseInfo.Attributes.Add("src", s);
        //}
        //private void ClinicalInfoUrl()
        //{
        //    string s = "Fp_ExtendPage/ClinicalInfo.aspx";
        //    ClinicalInfo.Attributes.Add("src", s);
        //}
        //private void SampleInfoUrl()
        //{
        //    string s = "Fp_ExtendPage/SampleInfo.aspx";
        //    SampleInfo.Attributes.Add("src", s);
        //}
    }
}