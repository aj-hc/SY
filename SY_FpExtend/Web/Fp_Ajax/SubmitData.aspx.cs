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
                        catch (Exception ex)
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
            ConnetInfo();
        }
        private void ConnetInfo()
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

            Dictionary<string, string> baseinfoDic = new Dictionary<string, string>();
            Dictionary<string, string> sampleinfoDic = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(baseinfo) && baseinfo != "[]")
            {
                //转换页面上的baseinfo为对象
                List<Dictionary<string, string>> dicList = new List<Dictionary<string, string>>();
                dicList = FreezerProUtility.Fp_Common.FpJsonHelper.JsonStrToObject<List<Dictionary<string, string>>>(baseinfo);
                pageBaseInfo = GetFromInfo<PageBaseInfo>(dicList);
                baseinfoDic = ConvertBaseInfoObjToDic(pageBaseInfo);
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
                sampleinfoDic = ConvertSampleObjToDic(pageSampleInfo);
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
                //拼接好了临床数据list--需要将数据转换成字典。
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
        private Dictionary<string, string> ConvertBaseInfoObjToDic(PageBaseInfo pageBaseInfo)
        {
            Dictionary<string, string> pageBaseInfoDic = new Dictionary<string, string>();
            Type type = pageBaseInfo.GetType();
            PropertyInfo[] propertys = type.GetProperties();
            foreach (PropertyInfo item in propertys)
            {
                try
                {
                    if (item.Name == "SexFlag")
                    {
                        string value = Common.ReflectHelper.GetValue(pageBaseInfo, item.Name);
                        if (!string.IsNullOrEmpty(value))
                        {
                            switch (value)
                            {
                                case "0":
                                    pageBaseInfoDic.Add(item.Name, "未知");
                                    break;
                                case "1":
                                    pageBaseInfoDic.Add(item.Name, "男");
                                    break;
                                case "2":
                                    pageBaseInfoDic.Add(item.Name, "女");
                                    break;
                                default:
                                    pageBaseInfoDic.Add(item.Name, "未知");
                                    break;
                            }
                        }
                    }
                   else if (item.Name == "BloodTypeFlag")
                    {
                        string value = Common.ReflectHelper.GetValue(pageBaseInfo, item.Name);
                        if (!string.IsNullOrEmpty(value))
                        {
                            switch (value)
                            {
                                case "1":pageBaseInfoDic.Add(item.Name, "A");break;
                                case "2": pageBaseInfoDic.Add(item.Name, "B"); break;
                                case "3": pageBaseInfoDic.Add(item.Name, "AB"); break;
                                case "4": pageBaseInfoDic.Add(item.Name, "O"); break;
                                case "5": pageBaseInfoDic.Add(item.Name, "其它"); break;
                                case "6": pageBaseInfoDic.Add(item.Name, "未查"); break;
                                default: pageBaseInfoDic.Add(item.Name, "未查"); break;
                            }
                        }
                    }
                    else
                    {
                        string value = Common.ReflectHelper.GetValue(pageBaseInfo, item.Name);
                        pageBaseInfoDic.Add(item.Name, value);
                    }
                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteExcError(ex);
                    continue;
                }
            }
            //添加额外的信息
            //01.样本源名称
            if (pageBaseInfoDic.ContainsKey("PatientID") || pageBaseInfoDic.ContainsKey("InPatientID"))
            {
                if (!string.IsNullOrEmpty(pageBaseInfoDic["PatientID"]))
                {
                    pageBaseInfoDic.Add("Name", pageBaseInfoDic["PatientID"]);
                }
                else if (!string.IsNullOrEmpty(pageBaseInfoDic["InPatientID"]))
                {
                    pageBaseInfoDic.Add("Name", pageBaseInfoDic["InPatientID"]);
                }
            }
            //01.样本源描述
            if (pageBaseInfoDic.ContainsKey("PatientName"))
            {
                if (!string.IsNullOrEmpty(pageBaseInfoDic["PatientName"]))
                {
                    pageBaseInfoDic.Add("Description", pageBaseInfoDic["PatientName"]);
                }
            }
            return pageBaseInfoDic;
        }
        private Dictionary<string, string> ConvertSampleObjToDic(PageSampleInfo sampleInfo)
        {
            Dictionary<string, string> sampleDic = new Dictionary<string, string>();
            Type type = sampleInfo.GetType();
            PropertyInfo[] propertys = type.GetProperties();
            foreach (PropertyInfo item in propertys)
            {
                try
                {
                    string value = Common.ReflectHelper.GetValue(sampleInfo, item.Name);
                    sampleDic.Add(item.Name, value);

                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteExcError(ex);
                    continue;
                }
            }

            return sampleDic;
        }

        private Dictionary<string, string> ConvertClinicalDgObjToDic(PageClinicalInfo clinicalInfo)
        {
            Dictionary<string, string> clinicalInfoDic = new Dictionary<string, string>();
            Type type = clinicalInfo.GetType();
            PropertyInfo[] propertys = type.GetProperties();
            foreach (PropertyInfo item in propertys)
            {
                try
                {
                    string value = Common.ReflectHelper.GetValue(clinicalInfo, item.Name);
                    clinicalInfoDic.Add(item.Name, value);

                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteExcError(ex);
                    continue;
                }
            }

            return clinicalInfoDic;
        }

        private Dictionary<string, string> ConvertSampleDgToDic(PageSampleInfo sampleInfo)
        {
            Dictionary<string, string> sampleDic = new Dictionary<string, string>();
            Type type = sampleInfo.GetType();
            PropertyInfo[] propertys = type.GetProperties();
            foreach (PropertyInfo item in propertys)
            {
                try
                {
                    string value = Common.ReflectHelper.GetValue(sampleInfo, item.Name);
                    sampleDic.Add(item.Name, value);

                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteExcError(ex);
                    continue;
                }
            }

            return sampleDic;
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