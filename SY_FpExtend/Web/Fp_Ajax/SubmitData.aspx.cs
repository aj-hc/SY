using RuRo.Model.PageInfoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web.Fp_Ajax
{
    public partial class SubmitData : System.Web.UI.Page
    {
        string url = Common.CreatFpUrl.FpUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.Params["action"].ToString();
            if (action == "postData")
            {
                string baseinfo = Request.Params["baseinfo"];//form
                string clinicalInfoDg = Request.Params["clinicalInfoDg"];//dg
                string sampleInfo = Request.Params["sampleInfo"];//form
                string sampleInfoDg = Request.Params["sampleInfoDg"];//dg


                PageBaseInfo pageBaseInfo = new PageBaseInfo();
                List<PageClinicalInfo> pageClinicalInfoList = new List<PageClinicalInfo>();
                PageSampleInfo pageSampleInfo = new PageSampleInfo();
                List<PageSampleDg> pageSampleDgList = new List<PageSampleDg>();

                if (!string.IsNullOrEmpty(baseinfo) && baseinfo != "[]")
                {
                    //转换页面上的baseinfo为对象
                    List<Dictionary<string, string>> dicList = new List<Dictionary<string, string>>();
                    dicList = FreezerProUtility.Fp_Common.FpJsonHelper.JsonStrToObject<List<Dictionary<string, string>>>(baseinfo);
                    pageBaseInfo = GetFromInfo<PageBaseInfo>(dicList);
                }
                if (!string.IsNullOrEmpty(clinicalInfoDg) && clinicalInfoDg != "[]")
                {
                    //转换页面上的clinicalInfoDg为对象集合
                    pageClinicalInfoList = FreezerProUtility.Fp_Common.FpJsonHelper.JsonStrToObject<List<PageClinicalInfo>>(clinicalInfoDg);//转换ok
                }
                if (!string.IsNullOrEmpty(sampleInfo) && sampleInfo != "[]")
                {
                    List<Dictionary<string, string>> dicList = new List<Dictionary<string, string>>();
                    dicList = FreezerProUtility.Fp_Common.FpJsonHelper.JsonStrToObject<List<Dictionary<string, string>>>(sampleInfo);
                    pageSampleInfo = GetFromInfo<PageSampleInfo>(dicList);
                }
                if (!string.IsNullOrEmpty(sampleInfoDg) && sampleInfoDg != "[]")
                {
                    pageSampleDgList = FreezerProUtility.Fp_Common.FpJsonHelper.JsonStrToObject<List<PageSampleDg>>(sampleInfoDg);//转换ok
                }
            }
        }
        private T GetFromInfo<T>(List<Dictionary<string, string>> dicList) where T : class,new()
        {
            T t = new T();
            foreach (var item in dicList)
            {
                string name = "";
                string value = "";
                foreach (var dic in item)
                {
                    if (dic.Key == "name")
                    {
                        name = dic.Value;
                    }
                    if (dic.Key == "value")
                    {
                        value = dic.Value;
                    }
                }
                try
                {
                    Common.ReflectHelper.SetValue(t, name, value);
                }
                catch (Exception)
                {
                    continue;
                }

            }
            return t;
        }

        private void ImportDataToFp()
        {

        }
        private string ImportSamples()
        {

            return "";
        }
        private string ImportSampleSource()
        {
            return "";
        }
        private string ImportTestData()
        {
            return "";
        }
    }
}