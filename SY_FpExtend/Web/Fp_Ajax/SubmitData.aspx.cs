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
        BLL.FP_LINKAGE_Bll fp_linkage = new BLL.FP_LINKAGE_Bll();
        Dictionary<string, string> sampleTypeIdAndNamedic = new Dictionary<string, string>();
        Dictionary<string, string> organIdAndNamedic = new Dictionary<string, string>();
        Dictionary<string, string> clinicalDiagnoseTypeFlagdic = new Dictionary<string, string>();
        string departments = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //页面第一次加载时初始化变量
            if (!IsPostBack)
            {
               organIdAndNamedic = fp_linkage.GetOrganDic();
                clinicalDiagnoseTypeFlagdic = PageConData.DiagnoseTypeFlagDic();
                sampleTypeIdAndNamedic = FreezerProUtility.Fp_BLL.Samples.GetAllSample_TypesNames(Common.CreatFpUrl.FpUrl);
            }
            string action = Request.Params["action"].Trim();
            departments = Request.Params["departments"].Trim();
            if (action == "postPatientinfo")
            {
              string result = ImportPatientInfo();

              Response.Write(result);
            }
            if (action == "postSampleInfo")
            {

            }
        }

        private void ImportDataToFp()
        {
            //导入数据
            //第一步：导入样本源
            //01.创建样本源信息字典
            //02.指定样本源类型----根据什么获取？
            //第二部：导入临床数据
            //01.创建临床数据字典
            //02.指定临床数据类型
            //03.指定临床数据对应的样本源
            //第三部：导入样本信息
            //01.获取样本类型
            //02.获取管数
            //03.提交
            Dictionary<string, string> baseInfoDic = GetBaseInfoDic();
            List<Dictionary<string, string>> sampleInfoDgDicList = GetSampleInfoDgDicList();
            Dictionary<string, string> sampleInfoDic = GetSampleInfoDic();
            List<Dictionary<string, string>> clinicalInfoDgDicList = GetClinicalInfoDgDicList(baseInfoDic);

            string PatientID = string.Empty;
            if (baseInfoDic.ContainsKey("PatientID"))
            {
                PatientID = baseInfoDic["PatientID"];
            }
            string PatientName = string.Empty;
            if (baseInfoDic.ContainsKey("PatientName"))
            {
                PatientName = baseInfoDic["PatientName"];
            }
            baseInfoDic.Add("Name", PatientID);
            baseInfoDic.Add("Description", PatientName);
            sampleInfoDic.Add("Name", PatientID);

            //导入样本源数据
            string resultImpSS = ImportSampleSource(MatchBaseInfoDic(baseInfoDic));


            if (FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("success", resultImpSS) == "True" || resultImpSS.Contains("should be unique."))
            {
                //导入成功
                //导入临床数据
                if (clinicalInfoDgDicList.Count > 0)
                {

                    //添加额外字段
                    foreach (var item in clinicalInfoDgDicList)
                    {
                        item.Add("Sample Source", PatientID);
                    }
                }
                //导入临床数据
                string resultImpCl = ImportTestData(MatchClinicalDic(clinicalInfoDgDicList));
                if (resultImpCl.Contains("\"status\":\"DONE\""))
                {
                    //导入成功--保存数据到本地数据库
                    //需要将字典转换为对象

                }
                if (sampleInfoDgDicList.Count > 0)//类型列表中有数据
                {
                    //取出一条数据，然后将此数据和样本信息数据合并
                    //将整个集合的数据都传至业务层
                    foreach (var item in sampleInfoDgDicList)
                    {
                        //样本信息需要单独提交，存在多个样品中导入失败情况

                    }
                }
            }
            //导入样本数据
        }
        private string ImportPatientInfo()
        {
            //导入数据
            //第一步：导入样本源
            //01.创建样本源信息字典
            //02.指定样本源类型----根据什么获取？
            //第二部：导入临床数据
            //01.创建临床数据字典
            //02.指定临床数据类型
            //03.指定临床数据对应的样本源

            Dictionary<string, string> baseInfoDic = GetBaseInfoDic();
            List<Dictionary<string, string>> clinicalInfoDgDicList = GetClinicalInfoDgDicList(baseInfoDic);

            string PatientID = string.Empty;
            if (baseInfoDic.ContainsKey("PatientID"))
            {
                PatientID = baseInfoDic["PatientID"];
            }
            string PatientName = string.Empty;
            if (baseInfoDic.ContainsKey("PatientName"))
            {
                PatientName = baseInfoDic["PatientName"];
            }
            baseInfoDic.Add("Name", PatientID);
            baseInfoDic.Add("Description", PatientName);

            //导入样本源数据
            string improtBaseInfoResult = ImportSampleSource(MatchBaseInfoDic(baseInfoDic));

            if (FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("success", improtBaseInfoResult) == "True" || improtBaseInfoResult.Contains("should be unique."))
            {
                //导入成功
                //导入临床数据
                if (clinicalInfoDgDicList.Count > 0)
                {
                    //添加额外字段
                    foreach (var item in clinicalInfoDgDicList)
                    {
                        item.Add("Sample Source", PatientID);
                    }
                }
                //导入临床数据
                string improtTestDataResult = ImportTestData(MatchClinicalDic(clinicalInfoDgDicList));
                if (improtTestDataResult.Contains("\"status\":\"DONE\""))
                {
                    //导入成功--保存数据到本地数据库
                    //需要将字典转换为对象
                    SaveClinicalDicToLocalBase(clinicalInfoDgDicList, departments);
                    string success = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("success", improtTestDataResult);
                    string msg = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("msg", improtTestDataResult);
                    Dictionary<string, string> dic = new Dictionary<string, string>(); dic.Add("success", success); dic.Add("msg", msg);
                    return FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryToJsonString(dic);
                }
                else
                {
                    string success = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("success", improtBaseInfoResult);
                    string msg = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("msg", improtBaseInfoResult);
                    Dictionary<string, string> dic = new Dictionary<string, string>(); dic.Add("success", success); dic.Add("msg", msg);
                   return FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryToJsonString(dic);
                }

            }
            else
            {
                string success = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("success", improtBaseInfoResult);
                string msg = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("msg", improtBaseInfoResult);
                Dictionary<string, string> dic = new Dictionary<string, string>(); dic.Add("success", success); dic.Add("msg", msg + "   临床数据已存在");
                return FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryToJsonString(dic);
            }


            //导入样本数据


        }
        #region 获取基本信息字典（样本源）
        //获取基本信息字典（样本源）
        private Dictionary<string, string> GetBaseInfoDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string baseinfo = Request.Params["baseinfo"];//form
            //基本信息对象
            PageBaseInfo pageBaseInfo = new PageBaseInfo();

            if (!string.IsNullOrEmpty(baseinfo) && baseinfo != "[]")
            {
                //转换页面上的baseinfo为对象
                List<Dictionary<string, string>> dicList = new List<Dictionary<string, string>>();
                dicList = FreezerProUtility.Fp_Common.FpJsonHelper.JsonStrToObject<List<Dictionary<string, string>>>(baseinfo);
                pageBaseInfo = GetFromInfo<PageBaseInfo>(dicList);
                dic = ConvertBaseInfoObjToDic(pageBaseInfo);
            }
            return dic;
        }
        #endregion
        #region 获取临床数据字典 + private List<Dictionary<string, string>> GetClinicalInfoDgDicList(Dictionary<string, string> baseInfoDic)
        /// <summary>
        /// 获取临床数据字典 会直接剔除本地数据有的
        /// </summary>
        /// <param name="baseInfoDic">基本信息</param>
        /// <returns></returns>
        private List<Dictionary<string, string>> GetClinicalInfoDgDicList(Dictionary<string, string> baseInfoDic)
        {
            string clinicalInfoDg = Request.Params["clinicalInfoDg"];//dg
            //页面上临床数据对象集合
            List<PageClinicalInfo> pageClinicalInfoList = new List<PageClinicalInfo>();
            List<Dictionary<string, string>> ClinicalInfoDgDicList = new List<Dictionary<string, string>>();
            //将页面上的临床信息转换成对象集合

            if (!string.IsNullOrEmpty(clinicalInfoDg) && clinicalInfoDg != "[]")
            {
                //转换页面上的clinicalInfoDg为对象集合
                pageClinicalInfoList = FreezerProUtility.Fp_Common.FpJsonHelper.JsonStrToObject<List<PageClinicalInfo>>(clinicalInfoDg);//转换ok
            }
            BLL.ClinicalInfo cl = new BLL.ClinicalInfo();

            foreach (PageClinicalInfo item in pageClinicalInfoList)
            {
                //给对象拼接--临床数据中需要添加基本信息中的RegisterID,InPatientID
                if (baseInfoDic != null && pageClinicalInfoList.Count > 0)
                {
                    //拼接好了临床数据list--需要将数据转换成字典。
                    if (baseInfoDic.ContainsKey("InPatientID"))
                    {
                        item.InPatientID = baseInfoDic["InPatientID"];
                    }
                    if (baseInfoDic.ContainsKey("InPatientID"))
                    {
                        item.RegisterID = baseInfoDic["RegisterID"];
                    }
                }
                try
                {
                    if (cl.Get_ClinicalInfoCount_Bll(item.InPatientID, item.RegisterID, item.DiagnoseDateTime, departments))
                    {
                        //数据库中有该条数据
                        continue;
                    }
                }
                catch (Exception)
                {

                }

                ClinicalInfoDgDicList.Add(ConvertClinicalDgObjToDic(item));
            }
            return ClinicalInfoDgDicList;
        }
        #endregion
        private Dictionary<string, string> GetSampleInfoDic()
        {
            string sampleInfo = Request.Params["sampleInfo"];//form
            //基本信息对象
            PageBaseInfo pageBaseInfo = new PageBaseInfo();
            //将页面上的样本信息转换成对象，然后将对象转换成字典
            //样本信息共有部分数据对象
            PageSampleInfo pageSampleInfo = new PageSampleInfo();
            //样本信息字典
            Dictionary<string, string> sampleinfoDic = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(sampleInfo) && sampleInfo != "[]")
            {
                //sampleinfo对象
                List<Dictionary<string, string>> dicList = new List<Dictionary<string, string>>();
                dicList = FreezerProUtility.Fp_Common.FpJsonHelper.JsonStrToObject<List<Dictionary<string, string>>>(sampleInfo);
                pageSampleInfo = GetFromInfo<PageSampleInfo>(dicList);
                sampleinfoDic = ConvertSampleObjToDic(pageSampleInfo);
            }
            return sampleinfoDic;
        }
        private List<Dictionary<string, string>> GetSampleInfoDgDicList()
        {
            string sampleInfoDg = Request.Params["sampleInfoDg"];
            //将页面上的样本类型信息转换成对象集合
            //样本类型信息数据集合
            List<PageSampleDg> pageSampleDgList = new List<PageSampleDg>();
            List<Dictionary<string, string>> SampleInfoDgDicList = new List<Dictionary<string, string>>();
            if (!string.IsNullOrEmpty(sampleInfoDg) && sampleInfoDg != "[]")
            {
                //sampleInfoDg对象--[{"SampleType":"27","Scount":"1","Organ":"1","Classification":"肺"}]
                pageSampleDgList = FreezerProUtility.Fp_Common.FpJsonHelper.JsonStrToObject<List<PageSampleDg>>(sampleInfoDg);//转换ok
            }
            //将对象集合转换成字典集合
            foreach (PageSampleDg item in pageSampleDgList)
            {
                SampleInfoDgDicList.Add(ConvertSampleDgToDic(item));
            }

            return SampleInfoDgDicList;
        }

        #region 转换对象数据为字典或者字典集合
        #region 转换患者基本信息为字典 +private Dictionary<string, string> ConvertBaseInfoObjToDic(PageBaseInfo pageBaseInfo)
        /// <summary>
        /// 转换患者基本信息为字典  包含Name和描述
        /// </summary>
        /// <param name="pageBaseInfo"></param>
        /// <returns></returns>
        private Dictionary<string, string> ConvertBaseInfoObjToDic(PageBaseInfo pageBaseInfo)
        {
            Dictionary<string, string> pageBaseInfoDic = new Dictionary<string, string>();
            Type type = pageBaseInfo.GetType();
            PropertyInfo[] propertys = type.GetProperties();
            foreach (PropertyInfo item in propertys)
            {
                try
                {

                        string value = Common.ReflectHelper.GetValue(pageBaseInfo, item.Name);
                        pageBaseInfoDic.Add(item.Name, value);
                    }
                catch (Exception ex)
                {
                    continue;
                }
            }
            return pageBaseInfoDic;
        }
        #endregion

        #region 转换样本信息为字典 + private Dictionary<string, string> ConvertSampleObjToDic(PageSampleInfo sampleInfo)
        /// <summary>
        /// 转换样本信息为字典
        /// </summary>
        /// <param name="sampleInfo"></param>
        /// <returns></returns>
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
                    continue;
                }
            }

            return sampleDic;
        }
        #endregion

        #region 转换临床数据为字典 + private Dictionary<string, string> ConvertClinicalDgObjToDic(PageClinicalInfo clinicalInfo)
        /// <summary>
        /// 转换临床数据为字典
        /// </summary>
        /// <param name="clinicalInfo">临床数据对象</param>
        /// <returns></returns>
        private Dictionary<string, string> ConvertClinicalDgObjToDic(PageClinicalInfo clinicalInfo)
        {
            //{"DiagnoseTypeFlag":0,"DiagnoseDateTime":"1900-01-01","DiseaseName":"肝恶性肿瘤","ICDCode":"C22.902","Description":""}
            Dictionary<string, string> clinicalInfoDic = new Dictionary<string, string>();
            Type type = clinicalInfo.GetType();
            PropertyInfo[] propertys = type.GetProperties();
            foreach (PropertyInfo item in propertys)
            {
                try
                {
                    if (item.Name == "DiagnoseTypeFlag")
                    {
                        string value = Common.ReflectHelper.GetValue(clinicalInfo, item.Name);
                        if (clinicalDiagnoseTypeFlagdic.ContainsKey(value))
                        {
                            clinicalInfoDic.Add(item.Name, clinicalDiagnoseTypeFlagdic[value]);
                        }
                    }
                    else
                    {
                        string value = Common.ReflectHelper.GetValue(clinicalInfo, item.Name);
                        clinicalInfoDic.Add(item.Name, value);
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            return clinicalInfoDic;
        }
        #endregion

        #region 转换样本类型特殊字段为字典 + private Dictionary<string, string> ConvertSampleDgToDic(PageSampleDg pageSampleDg)
        /// <summary>
        /// 转换样本类型特殊字段为字典
        /// </summary>
        /// <param name="pageSampleDg"></param>
        /// <returns></returns>
        private Dictionary<string, string> ConvertSampleDgToDic(PageSampleDg pageSampleDg)
        {
            Dictionary<string, string> pageSampleDgDic = new Dictionary<string, string>();
            //[{"SampleType":"27","Scount":"1","Organ":"1","Classification":"肺"}]
            //01.获取样本类型id和名称的字典
            //02.获取脏器id和名称字典
            #region 反射方法
            //Type type = pageSampleDg.GetType();
            //PropertyInfo[] propertys = type.GetProperties();
            //foreach (PropertyInfo item in propertys)
            //{
            //    try
            //    {
            //        if (item.Name == "SampleType")
            //        {
            //            string value = Common.ReflectHelper.GetValue(pageSampleDg, item.Name);
            //            if (sampleTypeIdAndNamedic.ContainsKey(value))
            //            {
            //                pageSampleDgDic.Add(item.Name, sampleTypeIdAndNamedic[value]);
            //            }
            //        }
            //        if (item.Name == "Organ")
            //        {
            //            string value = Common.ReflectHelper.GetValue(pageSampleDg, item.Name);
            //            if (organIdAndNamedic.ContainsKey(value))
            //            {
            //                pageSampleDgDic.Add(item.Name, organIdAndNamedic[value]);
            //            }
            //        }
            //        else
            //        {
            //            string value = Common.ReflectHelper.GetValue(pageSampleDg, item.Name);
            //            pageSampleDgDic.Add(item.Name, value);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        continue;
            //    }
            //} 
            #endregion
            if (sampleTypeIdAndNamedic.ContainsKey(pageSampleDg.SampleType))
            {
                pageSampleDgDic.Add("SampleType", sampleTypeIdAndNamedic[pageSampleDg.SampleType]);
            }
            if (sampleTypeIdAndNamedic.ContainsKey(pageSampleDg.Organ))
            {
                string Organ = sampleTypeIdAndNamedic[pageSampleDg.Organ];
                string Classification = pageSampleDg.Classification;
                pageSampleDgDic.Add("_117", Organ + ";" + Classification);
            }
            pageSampleDgDic.Add("Scount", pageSampleDg.Scount.ToString());
            return pageSampleDgDic;
        }
        #endregion

        #endregion

        #region 将前台返回的form转换成对象
        /// <summary>
        /// 将前台返回的form转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dicList"></param>
        /// <returns></returns>
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

                        }
                        Common.ReflectHelper.SetValue(t, name, value);
                    }
                    else
                    {
                        Common.ReflectHelper.SetValue(t, name, value);
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }

            }
            return t;
        }
        #endregion

        //匹配字段，并添加额外字段
        private Dictionary<string, string> MatchBaseInfoDic(Dictionary<string, string> baseinfoDic)
        {
            Dictionary<string, string> dic = BLL.MatchFileds.BaseInfoMatchDic();
            Dictionary<string, string> resDic = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> item in baseinfoDic)
            {
                if (dic.ContainsKey(item.Key))
                {
                    string key = dic[item.Key];
                    if (!resDic.ContainsKey(key))
                    {
                        resDic.Add(key, item.Value);
                    }
                }
            }
            Dictionary<string, string> orderResDic = new Dictionary<string, string>();
            orderResDic.Add("Name", resDic["Name"]);
            foreach (KeyValuePair<string, string> item in resDic)
            {
                if (item.Key == "Name")
                {
                    continue;
                }
                else
                {
                    orderResDic.Add(item.Key, item.Value);
                }
            }
            return orderResDic;
        }
        private List<Dictionary<string, string>> MatchClinicalDic(List<Dictionary<string, string>> clinicalDicList)
        {
            Dictionary<string, string> dic = BLL.MatchFileds.ClinicalFiledsMatchDic();
            List<Dictionary<string, string>> resDicList = new List<Dictionary<string, string>>();
            foreach (var clinicalDic in clinicalDicList)
            {
                Dictionary<string, string> resDic = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> item in clinicalDic)
                {
                    if (dic.ContainsKey(item.Key))
                    {
                        string key = dic[item.Key];
                        if (!resDic.ContainsKey(key))
                        {
                            resDic.Add(key, item.Value);
                        }
                    }
                }
                resDicList.Add(resDic);
            }

            return resDicList;
        }
        private Dictionary<string, string> MatchSampleInfoDic(Dictionary<string, string> sampleinfoDic)
        {
            Dictionary<string, string> dic = BLL.MatchFileds.SampleFiledsMatchDic();
            Dictionary<string, string> resDic = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> item in sampleinfoDic)
            {
                if (dic.ContainsKey(item.Key))
                {
                    string key = dic[item.Key];
                    if (!resDic.ContainsKey(key))
                    {
                        resDic.Add(key, item.Value);
                    }
                }
            }
            return resDic;
        }

        #region 导入样本信息 + private string ImportSamples(Dictionary<string, string> dataDic ,string sample_type,string count)
        /// <summary>
        /// 导入样本信息
        /// </summary>
        /// <param name="dataDic"></param>
        /// <returns></returns>
        private string ImportSamples(Dictionary<string, string> dataDic, string sample_type, string count)
        {
            string result = FreezerProUtility.Fp_BLL.Samples.Import_Sample(url, sample_type, count, dataDic);
            return result;
        }
        //private string ImportSamples(List<Dictionary<string, string>> dataDicList, Dictionary<string, string> dataDic)
        //{
        //    foreach (var item in dataDicList)
        //    {
        //        dataDic.Add("_117", item["_117"]);
        //        string result = FreezerProUtility.Fp_BLL.Samples.Import_Sample(url, item["sample_type"], item["Scount"], MatchSampleInfoDic(dataDic));
        //    }

        //    return result;
        //}


        #endregion

        #region 导入样本源 + private string ImportSampleSource(Dictionary<string, string> dataDic)
        /// <summary>
        /// 导入样本源
        /// </summary>
        /// <param name="dataDic"></param>
        /// <returns></returns>
        private string ImportSampleSource(Dictionary<string, string> dataDic)
        {
            string result = FreezerProUtility.Fp_BLL.SampleSocrce.ImportSampleSource(url, "基本资料", dataDic);
            return result;
        }
        #endregion

        #region 导入临床数据 + private string ImportTestData(Dictionary<string, string> dataDic)
        /// <summary>
        /// 导入临床数据
        /// </summary>
        /// <param name="dataDic"></param>
        /// <returns></returns>
        private string ImportTestData(List<Dictionary<string, string>> dataDicList)
        {
            string test_data_type = string.Empty;
            if (!string.IsNullOrEmpty(departments))
                {
                    try
                    {
                        test_data_type = "临床诊断--" + departments;
                    }
                    catch (Exception)
                    {
                    }
            }
            string result = FreezerProUtility.Fp_BLL.TestData.ImportTestData(url, test_data_type, dataDicList);

            return result;
        }
        #endregion

        private void SaveClinicalDicToLocalBase(List<Dictionary<string, string>> clinicalInfoDgDicList, string departments)
        {
            BLL.ClinicalInfo clinicalBll = new BLL.ClinicalInfo();

            foreach (var item in clinicalInfoDgDicList)
            {
                Model.ClinicalInfo clinical = new Model.ClinicalInfo();
                item.Remove("Sample Source");
                foreach (KeyValuePair<string, string> dic in item)
                {
                    try
                    {
                        if (dic.Key == "DiagnoseDateTime")
                        {
                            clinical.DiagnoseDateTime = DateTime.ParseExact(dic.Value, "yyyy-MM-dd", null);
                        }
                        if (dic.Key == "DiagnoseTypeFlag")
                        {
                            clinical.DiagnoseTypeFlag = dic.Value;
                        }
                        if (dic.Key == "DiseaseName")
                        {
                            clinical.DiseaseName = dic.Value;
                        }
                        if (dic.Key == "ICDCode")
                        {
                            clinical.ICDCode = dic.Value;
                        }
                        if (dic.Key == "InPatientID")
                        {
                            clinical.InPatientID = int.Parse(dic.Value);
                        }
                        if (dic.Key == "RegisterID")
                        {
                            clinical.RegisterID = int.Parse(dic.Value);
                        }
                        clinical.type = departments;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
                clinicalBll.Add(clinical);
            }
        }
    }
}