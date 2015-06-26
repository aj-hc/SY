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
namespace RuRo.Web.ClinicalInfo
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
		RuRo.BLL.ClinicalInfo bll=new RuRo.BLL.ClinicalInfo();
		RuRo.Model.ClinicalInfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblDiagnoseTypeFlag.Text=model.DiagnoseTypeFlag;
		this.lblDiagnoseDateTime.Text=model.DiagnoseDateTime.ToString();
		this.lblRegisterID.Text=model.RegisterID.ToString();
		this.lblInPatientID.Text=model.InPatientID.ToString();
		this.lblICDCode.Text=model.ICDCode;
		this.lblDiseaseName.Text=model.DiseaseName;
		this.lblDescription.Text=model.Description;

	}


    }
}
