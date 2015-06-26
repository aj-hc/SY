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
namespace RuRo.Web.Fp_UserFields_Match
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
		RuRo.BLL.Fp_UserFields_Match bll=new RuRo.BLL.Fp_UserFields_Match();
		RuRo.Model.Fp_UserFields_Match model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblFpudf_Id.Text=model.Fpudf_Id.ToString();
		this.lblMatchFields.Text=model.MatchFields;
		this.lblIsSearch.Text=model.IsSearch;

	}


    }
}
