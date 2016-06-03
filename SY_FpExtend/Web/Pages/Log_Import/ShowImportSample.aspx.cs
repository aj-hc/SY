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
            try
            {
                string user = Common.CookieHelper.GetCookieValue("");
                string department = Common.CookieHelper.GetCookieValue("");
                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(department))
                {
                   // Response.Redirect("../../Login.aspx");
                }

                BLL.Log_Show log_Show = new BLL.Log_Show();
                if (!IsPostBack)
                {
                    //查询数据库
                    string pageSize = Request.Params["pageSize"];
                    string pageNumber = Request.Params["pageNumber"];
                    System.Data.DataSet ds = log_Show.GetDate(user, department);

                }
                else
                {
                    //接受参数
                    string start_date = Request.Params["start_date"];
                    string end_date = Request.Params["end_date"];

                    string pageSize = Request.Params["pageSize"];
                    string pageNumber = Request.Params["pageNumber"];

                    System.Data.DataSet ds = log_Show.GetDate(user, department, start_date, end_date);
                }
            }
            catch (Exception)
            {
                Response.Redirect("../../Login.aspx");
            }

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