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
namespace RuRo.Web.SurgeryInfo
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
		RuRo.BLL.SurgeryInfo bll=new RuRo.BLL.SurgeryInfo();
		RuRo.Model.SurgeryInfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblSurgeryRequestID.Text=model.SurgeryRequestID.ToString();
		this.lblICDCode.Text=model.ICDCode;
		this.lblSurgeryName.Text=model.SurgeryName;
		this.lblRequestExecutiveDateTime.Text=model.RequestExecutiveDateTime.ToString();
		this.lblRequestDoctorEmployeeID.Text=model.RequestDoctorEmployeeID.ToString();

	}


    }
}
