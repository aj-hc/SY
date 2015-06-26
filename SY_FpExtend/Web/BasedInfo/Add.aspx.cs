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
namespace RuRo.Web.BasedInfo
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtPatientName.Text.Trim().Length==0)
			{
				strErr+="PatientName不能为空！\\n";	
			}
			if(this.txtIPSeqNoText.Text.Trim().Length==0)
			{
				strErr+="IPSeqNoText不能为空！\\n";	
			}
			if(this.txtPatientCardNo.Text.Trim().Length==0)
			{
				strErr+="PatientCardNo不能为空！\\n";	
			}
			if(this.txtSexFlag.Text.Trim().Length==0)
			{
				strErr+="SexFlag不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtBirthday.Text))
			{
				strErr+="Birthday格式错误！\\n";	
			}
			if(this.txtBloodTypeFlag.Text.Trim().Length==0)
			{
				strErr+="BloodTypeFlag不能为空！\\n";	
			}
			if(this.txtPhone.Text.Trim().Length==0)
			{
				strErr+="Phone不能为空！\\n";	
			}
			if(this.txtContactPhone.Text.Trim().Length==0)
			{
				strErr+="ContactPhone不能为空！\\n";	
			}
			if(this.txtContactPerson.Text.Trim().Length==0)
			{
				strErr+="ContactPerson不能为空！\\n";	
			}
			if(this.txtNativePlace.Text.Trim().Length==0)
			{
				strErr+="NativePlace不能为空！\\n";	
			}
			if(this.txtRegisterSeqNO.Text.Trim().Length==0)
			{
				strErr+="RegisterSeqNO不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtPatientID.Text))
			{
				strErr+="PatientID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtRegisterID.Text))
			{
				strErr+="RegisterID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtInPatientID.Text))
			{
				strErr+="InPatientID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string PatientName=this.txtPatientName.Text;
			string IPSeqNoText=this.txtIPSeqNoText.Text;
			string PatientCardNo=this.txtPatientCardNo.Text;
			string SexFlag=this.txtSexFlag.Text;
			DateTime Birthday=DateTime.Parse(this.txtBirthday.Text);
			string BloodTypeFlag=this.txtBloodTypeFlag.Text;
			string Phone=this.txtPhone.Text;
			string ContactPhone=this.txtContactPhone.Text;
			string ContactPerson=this.txtContactPerson.Text;
			string NativePlace=this.txtNativePlace.Text;
			string RegisterSeqNO=this.txtRegisterSeqNO.Text;
			int PatientID=int.Parse(this.txtPatientID.Text);
			int RegisterID=int.Parse(this.txtRegisterID.Text);
			int InPatientID=int.Parse(this.txtInPatientID.Text);

			RuRo.Model.BasedInfo model=new RuRo.Model.BasedInfo();
			model.PatientName=PatientName;
			model.IPSeqNoText=IPSeqNoText;
			model.PatientCardNo=PatientCardNo;
			model.SexFlag=SexFlag;
			model.Birthday=Birthday;
			model.BloodTypeFlag=BloodTypeFlag;
			model.Phone=Phone;
			model.ContactPhone=ContactPhone;
			model.ContactPerson=ContactPerson;
			model.NativePlace=NativePlace;
			model.RegisterSeqNO=RegisterSeqNO;
			model.PatientID=PatientID;
			model.RegisterID=RegisterID;
			model.InPatientID=InPatientID;

			RuRo.BLL.BasedInfo bll=new RuRo.BLL.BasedInfo();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
