using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RuRo.BLL;

namespace RuRo.Web.Pages.Log_Import
{
    public partial class ShowImportSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
    }
    public class Result_Model
    {
        public string state { get; set; }
        public fenye_Model jsonData { get; set; }
        public string  msg { get; set; }
    }

    public class fenye_Model
    {
        public string total { get; set; }
        public System.Data.DataSet rows { get; set; }
    }

}