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
namespace RuRo.Web.BasedInfo
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
		RuRo.BLL.BasedInfo bll=new RuRo.BLL.BasedInfo();
		RuRo.Model.BasedInfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblPatientName.Text=model.PatientName;
		this.lblIPSeqNoText.Text=model.IPSeqNoText;
		this.lblPatientCardNo.Text=model.PatientCardNo;
		this.lblSexFlag.Text=model.SexFlag;
		this.lblBirthday.Text=model.Birthday.ToString();
		this.lblBloodTypeFlag.Text=model.BloodTypeFlag;
		this.lblPhone.Text=model.Phone;
		this.lblContactPhone.Text=model.ContactPhone;
		this.lblContactPerson.Text=model.ContactPerson;
		this.lblNativePlace.Text=model.NativePlace;
		this.lblRegisterSeqNO.Text=model.RegisterSeqNO;
		this.lblPatientID.Text=model.PatientID.ToString();
		this.lblRegisterID.Text=model.RegisterID.ToString();
		this.lblInPatientID.Text=model.InPatientID.ToString();

	}


    }
}
