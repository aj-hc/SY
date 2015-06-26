using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace RuRo.Web.ExamineInfo
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int id=(Convert.ToInt32(strid));
					ShowInfo(id);
				}
			}
		}
		
	private void ShowInfo(int id)
	{
		RuRo.BLL.ExamineInfo bll=new RuRo.BLL.ExamineInfo();
		RuRo.Model.ExamineInfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblExamineRequestID.Text=model.ExamineRequestID.ToString();
		this.lblItemSetNo.Text=model.ItemSetNo;
		this.lblDescription.Text=model.Description;
		this.lblItemSetID.Text=model.ItemSetID.ToString();

	}


    }
}
