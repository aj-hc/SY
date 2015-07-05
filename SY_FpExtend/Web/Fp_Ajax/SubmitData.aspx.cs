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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //页面第一次加载时初始化变量
                sampleTypeIdAndNamedic = FreezerProUtility.Fp_BLL.Samples.GetAllSample_TypesNames(Common.CreatFpUrl.FpUrl);
                organIdAndNamedic = fp_linkage.GetOrganDic();
                clinicalDiagnoseTypeFlagdic = PageConData.DiagnoseTypeFlagDic();

            }
            string action = Request.Params["action"].ToString();
            if (action == "postData")
            {
                ImportDataToFp();
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
        private List<Dictionary<string, string>> GetClinicalInfoDgDicList(Dictionary<string, string> BaseInfoDic)
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
            foreach (PageClinicalInfo item in pageClinicalInfoList)
            {
                //给对象拼接--临床数据中需要添加基本信息中的RegisterID,InPatientID
                if (BaseInfoDic != null && pageClinicalInfoList.Count > 0)
                {
                    //拼接好了临床数据list--需要将数据转换成字典。
                    if (BaseInfoDic.ContainsKey("InPatientID"))
                    {
                        item.InPatientID = BaseInfoDic["InPatientID"];
                    }
                    if (BaseInfoDic.ContainsKey("InPatientID"))
                    {
                        item.RegisterID = BaseInfoDic["RegisterID"];
                    }
                }
                ClinicalInfoDgDicList.Add(ConvertClinicalDgObjToDic(item));
            }
            return ClinicalInfoDgDicList;
        }
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
                                case "1": pageBaseInfoDic.Add(item.Name, "A"); break;
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
                    Common.LogHelper.WriteExcError(ex);
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
             pageSampleDgDic.Add("SampleType",sampleTypeIdAndNamedic[pageSampleDg.SampleType] );
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
                    Common.LogHelper.WriteExcError(ex);
                    continue;
                }

            }
            return t;
        }
        #endregion

        private Dictionary<string, string> MatchBaseInfoDic(Dictionary<string, string> baseinfoDic)
        {

            return baseinfoDic;
        }
        private Dictionary<string, string> MatchClinicalDic(Dictionary<string, string> baseinfoDic)
        {
            return baseinfoDic;
        }
        private Dictionary<string, string> MatchSampleInfoDic(Dictionary<string, string> baseinfoDic)
        {
            return baseinfoDic;
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
        #endregion

        #region 导入样本源 + private string ImportSampleSource(Dictionary<string, string> dataDic)
        /// <summary>
        /// 导入样本源
        /// </summary>
        /// <param name="dataDic"></param>
        /// <returns></returns>
        private string ImportSampleSource(Dictionary<string, string> dataDic)
        {
            string sample_source_type = "基本资料--心研所";

            string result = FreezerProUtility.Fp_BLL.SampleSocrce.ImportSampleSource(url, sample_source_type, dataDic);
            return result;
        }
        #endregion

        #region 导入临床数据 + private string ImportTestData(Dictionary<string, string> dataDic)
        /// <summary>
        /// 导入临床数据
        /// </summary>
        /// <param name="dataDic"></param>
        /// <returns></returns>
        private string ImportTestData(Dictionary<string, string> dataDic)
        {
            string test_data_type = string.Empty;

            FreezerProUtility.Fp_BLL.TestData.ImportTestData(url, test_data_type, dataDic);
            return "";
        }
        #endregion
    }
}