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
namespace RuRo.Web.ClinicalInfo
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtDiagnoseTypeFlag.Text.Trim().Length==0)
			{
				strErr+="DiagnoseTypeFlag不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtDiagnoseDateTime.Text))
			{
				strErr+="DiagnoseDateTime格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtRegisterID.Text))
			{
				strErr+="RegisterID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtInPatientID.Text))
			{
				strErr+="InPatientID格式错误！\\n";	
			}
			if(this.txtICDCode.Text.Trim().Length==0)
			{
				strErr+="ICDCode不能为空！\\n";	
			}
			if(this.txtDiseaseName.Text.Trim().Length==0)
			{
				strErr+="DiseaseName不能为空！\\n";	
			}
			if(this.txtDescription.Text.Trim().Length==0)
			{
				strErr+="Description不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string DiagnoseTypeFlag=this.txtDiagnoseTypeFlag.Text;
			DateTime DiagnoseDateTime=DateTime.Parse(this.txtDiagnoseDateTime.Text);
			int RegisterID=int.Parse(this.txtRegisterID.Text);
			int InPatientID=int.Parse(this.txtInPatientID.Text);
			string ICDCode=this.txtICDCode.Text;
			string DiseaseName=this.txtDiseaseName.Text;
			string Description=this.txtDescription.Text;

			RuRo.Model.ClinicalInfo model=new RuRo.Model.ClinicalInfo();
			model.DiagnoseTypeFlag=DiagnoseTypeFlag;
			model.DiagnoseDateTime=DiagnoseDateTime;
			model.RegisterID=RegisterID;
			model.InPatientID=InPatientID;
			model.ICDCode=ICDCode;
			model.DiseaseName=DiseaseName;
			model.Description=Description;

			RuRo.BLL.ClinicalInfo bll=new RuRo.BLL.ClinicalInfo();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
