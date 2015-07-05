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
                ImportDataToFp();
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
                    
                    if (name == "_113")
                    {
                        //多选下拉框
                        Type type = t.GetType();
                        try
                        {
                            PropertyInfo property = type.GetProperty(name);
                            string str = property.GetValue(t, null).ToString();
                            if (!string.IsNullOrEmpty(str))
                            {
                                value += ";" + str;
                            }
                        }
                        catch (Exception ex )
                        {
                            Common.LogHelper.WriteExcError(ex);
                        }
                    }
                    Common.ReflectHelper.SetValue(t, name, value);
                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteExcError(ex);
                    continue;
                }

            }
            return t;
        }

        private void ImportDataToFp()
        {
            //获取页面上的数据
            string baseinfo = Request.Params["baseinfo"];//form
            string clinicalInfoDg = Request.Params["clinicalInfoDg"];//dg
            string sampleInfo = Request.Params["sampleInfo"];//form
            string sampleInfoDg = Request.Params["sampleInfoDg"];//dg

            //将页面上的数据转换成对象
            #region 将页面上的数据转换成对象
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
                //sampleinfo对象
                List<Dictionary<string, string>> dicList = new List<Dictionary<string, string>>();
                dicList = FreezerProUtility.Fp_Common.FpJsonHelper.JsonStrToObject<List<Dictionary<string, string>>>(sampleInfo);
                pageSampleInfo = GetFromInfo<PageSampleInfo>(dicList);
            }
            if (!string.IsNullOrEmpty(sampleInfoDg) && sampleInfoDg != "[]")
            {
                //sampleInfoDg对象
                pageSampleDgList = FreezerProUtility.Fp_Common.FpJsonHelper.JsonStrToObject<List<PageSampleDg>>(sampleInfoDg);//转换ok
            }
            #endregion

            //给对象拼接--临床数据中需要添加基本信息中的RegisterID,InPatientID
            if (pageBaseInfo != null && pageClinicalInfoList.Count > 0)
            {
                foreach (PageClinicalInfo item in pageClinicalInfoList)
                {
                    if (string.IsNullOrEmpty(pageBaseInfo.InPatientID))
                    {
                        item.InPatientID = pageBaseInfo.InPatientID;
                    }
                    if (string.IsNullOrEmpty(pageBaseInfo.RegisterID))
                    {
                        item.RegisterID = pageBaseInfo.RegisterID;
                    }
                }
            }
        }

        //导入数据存在的情况
        //1、只导入样品源，手动添加样本
        //2、导入样本源和临床信息、手动添加样本
        //3、导入样本源、样本
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