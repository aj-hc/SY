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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtid.Text))
			{
				strErr+="id格式错误！\\n";	
			}
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
			int id=int.Parse(this.txtid.Text);
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
