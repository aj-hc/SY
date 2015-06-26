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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace RuRo.Web.SurgeryInfo
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(id);
				}
			}
		}
			
	private void ShowInfo(int id)
	{
		RuRo.BLL.SurgeryInfo bll=new RuRo.BLL.SurgeryInfo();
		RuRo.Model.SurgeryInfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtSurgeryRequestID.Text=model.SurgeryRequestID.ToString();
		this.txtICDCode.Text=model.ICDCode;
		this.txtSurgeryName.Text=model.SurgeryName;
		this.txtRequestExecutiveDateTime.Text=model.RequestExecutiveDateTime.ToString();
		this.txtRequestDoctorEmployeeID.Text=model.RequestDoctorEmployeeID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtSurgeryRequestID.Text))
			{
				strErr+="SurgeryRequestID格式错误！\\n";	
			}
			if(this.txtICDCode.Text.Trim().Length==0)
			{
				strErr+="ICDCode不能为空！\\n";	
			}
			if(this.txtSurgeryName.Text.Trim().Length==0)
			{
				strErr+="SurgeryName不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtRequestExecutiveDateTime.Text))
			{
				strErr+="RequestExecutiveDateTime格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtRequestDoctorEmployeeID.Text))
			{
				strErr+="RequestDoctorEmployeeID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			int SurgeryRequestID=int.Parse(this.txtSurgeryRequestID.Text);
			string ICDCode=this.txtICDCode.Text;
			string SurgeryName=this.txtSurgeryName.Text;
			DateTime RequestExecutiveDateTime=DateTime.Parse(this.txtRequestExecutiveDateTime.Text);
			int RequestDoctorEmployeeID=int.Parse(this.txtRequestDoctorEmployeeID.Text);


			RuRo.Model.SurgeryInfo model=new RuRo.Model.SurgeryInfo();
			model.id=id;
			model.SurgeryRequestID=SurgeryRequestID;
			model.ICDCode=ICDCode;
			model.SurgeryName=SurgeryName;
			model.RequestExecutiveDateTime=RequestExecutiveDateTime;
			model.RequestDoctorEmployeeID=RequestDoctorEmployeeID;

			RuRo.BLL.SurgeryInfo bll=new RuRo.BLL.SurgeryInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
