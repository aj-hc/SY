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
namespace RuRo.Web.FP_UserFields
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
					int userFieldId=(Convert.ToInt32(strid));
					ShowInfo(userFieldId);
				}
			}
		}
		
	private void ShowInfo(int userFieldId)
	{
		RuRo.BLL.FP_UserFields bll=new RuRo.BLL.FP_UserFields();
		RuRo.Model.FP_UserFields model=bll.GetModel(userFieldId);
		this.lbluserFieldId.Text=model.userFieldId.ToString();
		this.lblid.Text=model.id.ToString();
		this.lblobj_id.Text=model.obj_id.ToString();
		this.lbldisplay_name.Text=model.display_name;
		this.lblname.Text=model.name;
		this.lbltype.Text=model.type;
		this.lblvalues.Text=model.values;
		this.lblshow.Text=model.show;
		this.lblcreated_at.Text=model.created_at;
		this.lblupdated_at.Text=model.updated_at;
		this.lblinuse.Text=model.inuse;

	}


    }
}
