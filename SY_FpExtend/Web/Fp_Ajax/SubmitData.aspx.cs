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
        Common.CreatFpUrl fpurl = new Common.CreatFpUrl(); //获取链接字符串对象
        string url = string.Empty;
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
                url = fpurl.FpUrl;
               organIdAndNamedic = fp_linkage.GetOrganDic();
                clinicalDiagnoseTypeFlagdic = PageConData.DiagnoseTypeFlagDic();
                sampleTypeIdAndNamedic = FreezerProUtility.Fp_BLL.Samples.GetAllSample_TypesNames(url);
            }
            string action = Request.Params["action"].Trim();
            departments = Request.Params["departments"].Trim();
            if (action == "postPatientinfo")
            {
                ImportPatientInfo();
            }
            if (action == "postSampleInfo")
            {
                //string id=获取样本的行号
                //使用方法提交样本数据到fp
                //返回提交后的结果
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

            //获取页面上的基本信息表单
            Dictionary<string, string> baseInfoDic = GetBaseInfoDic();
            //获取页面上的样本信息Dg表单
            List<Dictionary<string, string>> sampleInfoDgDicList = GetSampleInfoDgDicList();
            //获取页面上的样本信息表单
            Dictionary<string, string> sampleInfoDic = GetSampleInfoDic();
            //获取页面上的临床信息Dg表单
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
            //检查样本源是否存在？？----无API操作

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
                //导入样本数据
                //循环样本信息列表
                foreach (var item in sampleInfoDgDicList)
                {
                    
                }


            }
            
        }
        private void ImportPatientInfo()
        {
            //导入数据
            //第一步：导入样本源
            //01.创建样本源信息字典
            //02.指定样本源类型----根据什么获取？
            //第二部：导入临床数据
            //01.创建临床数据字典
            //02.指定临床数据类型
            //03.指定临床数据对应的样本源

            //获取页面上的基本信息表单
            Dictionary<string, string> baseInfoDic = GetBaseInfoDic();
            //获取页面上的样本信息Dg表单
            List<Dictionary<string, string>> sampleInfoDgDicList = GetSampleInfoDgDicList();
            //获取页面上的样本信息表单
            Dictionary<string, string> sampleInfoDic = GetSampleInfoDic();
            //获取页面上的临床信息Dg表单
            List<Dictionary<string, string>> clinicalInfoDgDicList = GetClinicalInfoDgDicList(baseInfoDic);

            List<Dictionary<string, Dictionary<string, string>>> importResult = new List<Dictionary<string, Dictionary<string, string>>>();
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
            string success = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("success", improtBaseInfoResult);
            string msg = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("msg", improtBaseInfoResult);
            Dictionary<string, Dictionary<string, string>> importSampleSourceResult = new Dictionary<string, Dictionary<string, string>>();
            importSampleSourceResult.Add("importSample", new Dictionary<string, string>() { { "success", success }, { "msg", msg } });
            importResult.Add(importSampleSourceResult);
            
            if ( success== "True" || improtBaseInfoResult.Contains("should be unique."))
            {
                //导入样品源成功
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
                    success = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("success", improtTestDataResult);
                    msg = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("msg", improtTestDataResult);
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    Dictionary<string, Dictionary<string, string>> dicr = new Dictionary<string, Dictionary<string, string>>();
                    dicr.Add("ImportClinicalResult", new Dictionary<string, string>() { { "success", success }, { "msg", msg } });
                    importResult.Add(dicr);
                }
                else
                {
                    Dictionary<string, Dictionary<string, string>> dicr = new Dictionary<string, Dictionary<string, string>>();
                    dicr.Add("ImportClinicalResult", new Dictionary<string, string>() { { "success", "False" }, { "msg", "该临床数据已存在" } });
                    importResult.Add(dicr);
                }
                //导入样本数据
                //调用方法导入样品

                foreach (Dictionary<string,string> item in sampleInfoDgDicList)
                {
                    //循环类型列表
                    //组合样本信息
                    //提交样本信息到fp
                    //记录返回结果
                    //将结果返回给前台
                    

                    //将列表中的字段添加到样本信息字典
                    //将样本信息字典匹配成Fp中的字段
                    //调用方法提交数据到fp
                    //将结果添加到列字典中
                    //将Dg字典转换成对象，将对象添加到对象集合
                    //将对象结合序列化成json发送到前台Dg中重新绑定
                    sampleInfoDic.Add("Name ", "");
                    sampleInfoDic.Add("Volume", item["Volume"]);
                    sampleInfoDic.Add("Name ", "");

                }
            }
            else
            {
                //导入样本源失败
                 Dictionary<string, Dictionary<string, string>> dicr = new Dictionary<string, Dictionary<string, string>>();
                 dicr.Add("ImportClinicalResult", new Dictionary<string, string>() { { "success", "False" }, { "msg", "请先导入基本信息" } });
                importResult.Add(dicr);
            }
        }

        private Dictionary<string, Dictionary<string, string>> SplitJson(string returnjson, string mark)
        {
            Dictionary<string, Dictionary<string, string>> dic = new Dictionary<string, Dictionary<string, string>>();
            string success = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("success", returnjson);
            string msg = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("msg", returnjson);
            Dictionary<string, string> dicdd = new Dictionary<string, string>();
            dicdd.Add("success", success); 
            dicdd.Add("msg", msg);
            dic.Add(mark, dicdd);
            return dic;
        }

        #region 获取页面信息
        #region 获取基本信息字典（样本源） +  private Dictionary<string, string> GetBaseInfoDic()
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
        #region 获取页面上的样本信息form并转换成字典 + private Dictionary<string, string> GetSampleInfoDic()
        /// <summary>
        /// 获取页面上的样本信息form并转换成字典
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetSampleInfoDic()
        {
            string sampleInfo = Request.Params["sampleInfoForm"];//form
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
        #endregion
        #region 获取页面上的样本信息dg并转换成字典 + private List<Dictionary<string, string>> GetSampleInfoDgDicList()
        /// <summary>
        /// 获取页面上的样本信息dg并转换成字典
        /// </summary>
        /// <returns>字典集合</returns>
        private List<Dictionary<string, string>> GetSampleInfoDgDicList()
        {
            string sampleInfoDg = Request.Params["dg_SampleInfo"];
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
        #endregion 
        #endregion

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
                    Common.LogHelper.WriteError(ex);
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
                    Common.LogHelper.WriteError(ex);
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
                    Common.LogHelper.WriteError(ex);
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
                //添加当前样本类型,将id转换成汉字
                pageSampleDgDic.Add("SampleType", sampleTypeIdAndNamedic[pageSampleDg.SampleType]);
            }
            if (!string.IsNullOrEmpty(pageSampleDg.Organ.ToString())&&!string.IsNullOrEmpty(pageSampleDg.OrganSubdivision))
            {
                string Organ = sampleTypeIdAndNamedic[pageSampleDg.Organ];
                string OrganSubdivision = pageSampleDg.OrganSubdivision;
                pageSampleDgDic.Add("_117", Organ + ";" + OrganSubdivision);
            }
            pageSampleDgDic.Add("Volume", pageSampleDg.Volume);
            pageSampleDgDic.Add("Scount", pageSampleDg.Scount.ToString());
            return pageSampleDgDic;
        }
        #endregion

        #endregion

        #region 匹配字段，并添加额外字段
        #region 匹配基本信息字典 + private Dictionary<string, string> MatchBaseInfoDic(Dictionary<string, string> baseinfoDic)
        /// <summary>
        /// 匹配基本信息字典
        /// </summary>
        /// <param name="baseinfoDic">基本信息字段</param>
        /// <returns>匹配完成的字典</returns>
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
        #endregion
        #region 匹配临床信息字典 + private List<Dictionary<string, string>> MatchClinicalDic(List<Dictionary<string, string>> clinicalDicList)
        /// <summary>
        /// 匹配临床信息字典
        /// </summary>
        /// <param name="clinicalDicList">临床信息字典</param>
        /// <returns>匹配完成的字典</returns>
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
        #endregion
        #region 匹配样本信息字典 + private Dictionary<string, string> MatchSampleInfoDic(Dictionary<string, string> sampleinfoDic)
        /// <summary>
        /// 匹配样本信息字典
        /// </summary>
        /// <param name="sampleinfoDic">样本信息字典</param>
        /// <returns>匹配后的字典</returns>
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
        #endregion
        #endregion

        #region 导入数据
        #region 导入样本信息 + private string ImportSamples(Dictionary<string, string> dataDic ,string sample_type,string count)
        /// <summary>
        /// 导入样本信息
        /// </summary>
        /// <param name="dataDic">数据字典</param>
        /// <param name="sample_type">样本类型</param>
        /// <param name="count">数量</param>
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
        #endregion

        #region 将临床数据字典转换成对象并保存至数据库 + private void SaveClinicalDicToLocalBase(List<Dictionary<string, string>> clinicalInfoDgDicList, string departments)
        /// <summary>
        /// 将临床数据字典转换成对象并保存至数据库
        /// </summary>
        /// <param name="clinicalInfoDgDicList">临床数据字典</param>
        /// <param name="departments">科室</param>
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
                    catch (Exception ex)
                    {
                        Common.LogHelper.WriteError(ex);
                        continue;
                    }
                }
                clinicalBll.Add(clinical);
            }
        } 
        #endregion
        #region 将前台返回的form字典转换成对象 + private T GetFromInfo<T>(List<Dictionary<string, string>> dicList) where T : class,new()
        /// <summary>
        /// 将前台返回的form字典转换成对象
        /// </summary>
        /// <typeparam name="T">要转换成的对象</typeparam>
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
                            Common.LogHelper.WriteError(ex);
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
                    Common.LogHelper.WriteError(ex);
                    continue;
                }

            }
            return t;
        }
        #endregion
    }
}