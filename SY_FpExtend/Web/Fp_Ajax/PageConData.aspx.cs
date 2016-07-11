using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace RuRo.Web
{
    public partial class PageConData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/plain";
            string username = Common.CookieHelper.GetCookieValue("username");
            string pwd = Common.CookieHelper.GetCookieValue("password");
            string departments = Common.CookieHelper.GetCookieValue("departments");
            string password = string.Empty;
            if (!string.IsNullOrEmpty(pwd))
            {
                try
                {
                    password = Common.DEncrypt.DESEncrypt.Decrypt(pwd);
                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteError(ex);
                    Response.Redirect("Login.aspx");
                }
            }
            FreezerProUtility.Fp_Common.UnameAndPwd up = new FreezerProUtility.Fp_Common.UnameAndPwd(username, password);

            string mark = Request.Params["conMarc"];
            switch (mark)
            {
                case "SexFlag": Response.Write(ReturnGender()); break;
                case "In_CodeType": Response.Write(ReturnIn_CodeType()); break;
                case "BloodTypeFlag": Response.Write(ReturnBloodTypeFlag()); break;
                case "SamplingMethod": Response.Write(ReturnSamplingMethodData()); break;
                case "DiagnoseTypeFlag": Response.Write(ReturnDiagnoseTypeFlag()); break;
                case "linkage": Response.Write(ReturnGet_Linkage()); break;
                case "linkagefrom": Response.Write(ReturnGet_Linkage2()); break;
                case "Employee": Response.Write(ReturnGet_Employee()); break;
                case "SampleType": Response.Write(ReturnSampleType(up, username)); break;
                case "departments": Response.Write(ReturnDepartments()); break;
                case "SampleGroups": Response.Write(ReturnSampleGroups(up)); break;
                case "SampleType_S": Response.Write(ReturnSampleType_S(up)); break;
                case "SampleType_U": Response.Write(ReturnSampleType_U(up)); break;
                case "SampleType_keti": Response.Write(Returnketi(up)); break;
                case "ComSetting": Response.Write(ReturnComSetting()); break;
                case "QuerySetting": Response.Write(ReturnQuerySetting()); break;
                case "ICDCode": Response.Write(ReturnQuerySetting()); break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 显示设定字段
        /// </summary>
        /// <returns></returns>
        private string ReturnQuerySetting() 
        {
            string strJson = "";//返回的JSON
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();//存放数据
            Dictionary<string, string> dic = new Dictionary<string, string>();//数据转换
            string username = Common.CookieHelper.GetCookieValue("username");
            string keshi = Common.CookieHelper.GetCookieValue(username + "department");
            string type = Request.Params["valueType"].ToString().Trim();
            BLL.TB_SETTING_VALUE bll = new BLL.TB_SETTING_VALUE();
            //判断数据是否存在
            DataSet ds = bll.GetList("SETTING_TYPE='" + type + "' AND DEPARTMENTS='" + DecryptDepartments (keshi)+ "'");
            if (ds.Tables[0].Rows.Count>0)
            {
               //数据转换为JSON
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dic = new Dictionary<string, string>();
                    dic.Add("value", ds.Tables[0].Rows[i]["SETTING_VALUE"].ToString());
                    dic.Add("text", ds.Tables[0].Rows[i]["SETTING_VALUE"].ToString());
                    list.Add(dic);
                }
                strJson = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            }
            return strJson;
          
        }

        /// <summary>
        /// 返回当前科室
        /// </summary>
        /// <returns></returns>
        public static string DecryptDepartments(string keshi)
        {
            string StrDepartments = "";
            try
            {
                keshi = Common.DEncrypt.DESEncrypt.Decrypt(keshi);
            }
            catch (Exception ex)
            {
                Common.LogHelper.WriteError(ex);
                keshi = "";
            }
            if (keshi != "")
            {
                StrDepartments = keshi;
            }
            return StrDepartments;
        }

        /// <summary>
        /// 返回字段设定
        /// </summary>
        /// <returns></returns>
        private string ReturnComSetting()
        {
            string res = "[{\"ComSetting\": \"lur\",\"text\": \"录入人\" },{\"ComSetting\": \"cjmd\", \"text\": \"采集目的\"}, " +
                "{\"ComSetting\": \"qcyh\", \"text\": \"取材医护\"}," +
                "{\"ComSetting\": \"yjfa\", \"text\": \"研究方案\"}, { \"ComSetting\": \"qcsd\", \"text\": \"取材时段\"} ]";
            return res;
        }

        private string ReturnSampleGroups(FreezerProUtility.Fp_Common.UnameAndPwd up)
        {
            Common.CreatFpUrl fpurl = new Common.CreatFpUrl();
            string url = fpurl.FpUrl;
            Dictionary<string, string> dic = FreezerProUtility.Fp_BLL.SampleGroup.GetAllIdAndNameDic(up);
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            if (dic.Count > 0)
            {
                foreach (KeyValuePair<string, string> dd in dic)
                {
                    Dictionary<string, string> temdic = new Dictionary<string, string>();
                    temdic.Add("value", dd.Key);
                    temdic.Add("text", dd.Value);
                    list.Add(temdic);
                }
            }
            string json = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            return json;
        }
        //初始化唯一选择框
        private string ReturnIn_CodeType()
        {
            string res = "[{\"In_CodeType\": \"1\",\"text\": \"诊疗卡号码\" },{\"In_CodeType\": \"2\", \"text\": \"住院号\"}, { \"In_CodeType\": \"3\", \"text\": \"门诊流水号\"},{\"In_CodeType\": \"4\",\"text\": \"患者ID\" },{\"In_CodeType\": \"5\", \"text\": \"住院记录ID\"}, { \"In_CodeType\": \"6\", \"text\": \"检验标签条码\"} ]";
            return res;
        }
        //初始化性别
        private string ReturnGender()
        {
            string res = "[{\"SexFlag\": \"0\",\"text\": \"未知\" },{\"SexFlag\": \"1\", \"text\": \"男\"}, { \"SexFlag\": \"2\", \"text\": \"女\"} ]";
            return res;
        }
        //初始化血型
        private string ReturnBloodTypeFlag()
        {
            string res = "[{\"BloodTypeFlag\": \"1\",\"text\": \"A\" },{\"BloodTypeFlag\": \"2\", \"text\": \"B\"}, { \"BloodTypeFlag\": \"3\", \"text\": \"AB\"},{\"BloodTypeFlag\": \"4\",\"text\": \"O\" },{\"BloodTypeFlag\": \"5\", \"text\": \"其它\"}, { \"BloodTypeFlag\": \"6\", \"text\": \"未查\"} ]";
            return res;
        }
        private string ReturnSamplingMethodData()
        {
            string res = "[{ \"samplingMethod\": \"手术前\", \"text\": \"手术前\" }, { \"samplingMethod\": \"手术时\", \"text\": \"手术时\" },{ \"samplingMethod\": \"手术一周后\", \"text\": \"手术一周后\" }, { \"samplingMethod\": \"化疗前\", \"text\": \"化疗前\" },{ \"samplingMethod\": \"化疗两周期结束后，第三周化疗期前\", \"text\": \"化疗两周期结束后，第三周化疗期前\" },{ \"samplingMethod\": \"第五周期化疗前\", \"text\": \"第五周期化疗前\" },{ \"samplingMethod\": \"第六周期化疗技术后\", \"text\": \"第六周期化疗技术后\" },{ \"samplingMethod\": \"靶向治疗前\", \"text\": \"靶向治疗前\" },{ \"samplingMethod\": \"疾病出现进展时\", \"text\": \"疾病出现进展时\" },{ \"samplingMethod\": \"更换治疗方案前\", \"text\": \"更换治疗方案前\" },{ \"samplingMethod\": \"其他\", \"text\": \"其他\" } ]";
            return res;
        }
        private string ReturnDiagnoseTypeFlag()
        {
            string res = "[{\"DiagnoseTypeFlag\": \"0\",\"text\": \"门诊诊断\" },{\"DiagnoseTypeFlag\": \"1\", \"text\": \"入院诊断\"}, { \"DiagnoseTypeFlag\": \"2\", \"text\": \"出院主要诊断\"} , { \"DiagnoseTypeFlag\": \"3\", \"text\": \"出院次要诊\"} ]";
            return res;
        }
        public static Dictionary<string, string> DiagnoseTypeFlagDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("0", "门诊诊断");
            dic.Add("1", "入院诊断");
            dic.Add("2", "出院主要诊断");
            dic.Add("3", "出院次要诊");
            return dic;
        }

        /// <summary>
        /// 样品类型数据
        /// </summary>
        /// <returns></returns>
        private string ReturnSampleType(FreezerProUtility.Fp_Common.UnameAndPwd up, string user)
        {
            //string res = "[{\"value\": \"0\",\"text\": \"正常组织-心研所\" },{\"value\": \"1\", \"text\": \"正常组织-肺癌所\"}, { \"value\": \"2\", \"text\": \"组织-心研所\"} , { \"value\": \"3\", \"text\": \"组织-肺癌所\"} ]";
            Common.CreatFpUrl fpurl = new Common.CreatFpUrl();
            string url = fpurl.FpUrl;
            Dictionary<string, string> dic = FreezerProUtility.Fp_BLL.Samples.GetAllIdAndNamesDic(up);
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            string struser = user.ToUpper();
            if (dic.Count > 0)
            {
                #region 按照登陆科室不同选择
                if (struser == "ADMIN")
                {
                    foreach (KeyValuePair<string, string> dd in dic)
                    {
                        Dictionary<string, string> temdic = new Dictionary<string, string>();
                        temdic.Add("value", dd.Key);
                        temdic.Add("text", dd.Value);
                        list.Add(temdic);
                    }
                }
                else
                {
                    
                    if (struser.Contains("XYS"))
                    {
                        foreach (KeyValuePair<string, string> dd in dic)
                        {
                            Dictionary<string, string> temdic = new Dictionary<string, string>();

                            if (dd.Value.Contains("心研所"))
                            {
                                temdic.Add("value", dd.Key);
                                temdic.Add("text", dd.Value);
                                list.Add(temdic);
                            }
                        }
                    }
                    else
                    {
                        foreach (KeyValuePair<string, string> dd in dic)
                        {
                            Dictionary<string, string> temdic = new Dictionary<string, string>();

                            if (dd.Value.Contains("肺癌所"))
                            {
                                temdic.Add("value", dd.Key);
                                temdic.Add("text", dd.Value);
                                list.Add(temdic);
                            }
                        }
                    }

                }
                #endregion

            }
            string json = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            return json;
        }

        /// <summary>
        /// 样品类型数据
        /// </summary>
        /// <returns></returns>
        private string ReturnSampleSocrceType(FreezerProUtility.Fp_Common.UnameAndPwd up)
        {
            //string res = "[{\"value\": \"0\",\"text\": \"基本信息-心研所\" },{\"value\": \"1\", \"text\": \"基本信息-肺癌所\"}]";
            //Common.CreatFpUrl fpurl = new Common.CreatFpUrl();
            //string url = fpurl.FpUrl;
            Dictionary<string, string> dic = FreezerProUtility.Fp_BLL.SampleSocrce.GetAllIdAndNamesDic(up);
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            if (dic.Count > 0)
            {
                foreach (KeyValuePair<string, string> dd in dic)
                {
                    Dictionary<string, string> temdic = new Dictionary<string, string>();
                    temdic.Add("value", dd.Key);
                    temdic.Add("text", dd.Value);
                    list.Add(temdic);
                }
            }
            string json = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            return json;
        }

        private string ReturnGet_Linkage()
        {
            BLL.FP_LINKAGE_Bll Fp_Linkage = new BLL.FP_LINKAGE_Bll();
            string res = Fp_Linkage.Get_LINKAGEstr();
            return res;
        }
        private string ReturnGet_Linkage2()
        {
            BLL.FP_LINKAGE_Bll Fp_Linkage = new BLL.FP_LINKAGE_Bll();
            Model.FP_LINKAGE fp_linkage = new Model.FP_LINKAGE();
            int mark = int.Parse(Request.Params["id"]);
            string res = Fp_Linkage.Get_LINKAGEstr(mark);
            return res;
        }
        private string ReturnGet_Employee()
        {
            string mark = Request.Params["com"];
            RuRo.BLL.FP_SY_HIS_IP_PublicInterface_Bll fp_sy = new BLL.FP_SY_HIS_IP_PublicInterface_Bll();
            DataSet ds = new DataSet();
            string JSON = fp_sy.GetSY_HC_GetEmployeeInfoJson(mark);
            return JSON;
        }
        private string ReturnGet_TB_Disease()
        {
            string mark = Request.Params["com"];
            RuRo.BLL.FP_SY_HIS_IP_PublicInterface_Bll fp_sy = new BLL.FP_SY_HIS_IP_PublicInterface_Bll();
            DataSet ds = new DataSet();
            string JSON = fp_sy.GetSY_HC_GetEmployeeInfoJson(mark);
            return JSON;
        }

        private string ReturnDepartments()
        {
            string res = "[{ \"value\": \"0\", \"text\": \"肺癌所\" }, { \"value\": \"1\", \"text\": \"心研所\" }]";
            return res;
        }
        #region 读取样品来源
        /// <summary>
        /// 读取样品来源
        /// </summary>
        /// <param name="up"></param>
        /// <returns></returns>
        private string ReturnSampleType_S(FreezerProUtility.Fp_Common.UnameAndPwd up)
        {
            Common.CreatFpUrl fpurl = new Common.CreatFpUrl();
            string url = fpurl.FpUrl;
            Dictionary<string, string> dic = FreezerProUtility.Fp_BLL.UserFields.GetAllIdAndNamesDic(up);
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            if (dic.Count > 0)
            {
                foreach (KeyValuePair<string, string> dd in dic)
                {
                    Dictionary<string, string> temdic = new Dictionary<string, string>();
                    if (dd.Key == "样品来源")
                    {
                        String[] str = dd.Value.Split(new char[] { ',' });
                        for (int i = 0; i < str.Length; i++)
                        {
                            temdic = new Dictionary<string, string>();
                            temdic.Add("value", i.ToString());
                            temdic.Add("text", str[i]);
                            list.Add(temdic);
                        }
                    }
                }
            }
            string json = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            return json;
        }

        #endregion

        #region
        /// <summary>
        /// 读取样品来源
        /// </summary>
        /// <param name="up"></param>
        /// <returns></returns>
        private string ReturnSampleType_U(FreezerProUtility.Fp_Common.UnameAndPwd up)
        {
            Common.CreatFpUrl fpurl = new Common.CreatFpUrl();
            string url = fpurl.FpUrl;
            Dictionary<string, string> dic = FreezerProUtility.Fp_BLL.UserFields.GetAllIdAndNamesDic(up);
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            if (dic.Count > 0)
            {
                foreach (KeyValuePair<string, string> dd in dic)
                {
                    Dictionary<string, string> temdic = new Dictionary<string, string>();
                    if (dd.Key == "用途")
                    {
                        String[] str = dd.Value.Split(new char[] { ',' });
                        for (int i = 0; i < str.Length; i++)
                        {
                            temdic = new Dictionary<string, string>();
                            temdic.Add("value", i.ToString());
                            temdic.Add("text", str[i]);
                            list.Add(temdic);
                        }

                    }
                }
            }
            string json = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            return json;
        }

        private string Returnketi(FreezerProUtility.Fp_Common.UnameAndPwd up)
        {
            Common.CreatFpUrl fpurl = new Common.CreatFpUrl();
            string url = fpurl.FpUrl;
            Dictionary<string, string> dic = FreezerProUtility.Fp_BLL.UserFields.GetAllIdAndNamesDic(up);
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            if (dic.Count > 0)
            {
                foreach (KeyValuePair<string, string> dd in dic)
                {
                    Dictionary<string, string> temdic = new Dictionary<string, string>();
                    if (dd.Key == "样品课题组")
                    {
                        String[] str = dd.Value.Split(new char[] { ',' });
                        for (int i = 0; i < str.Length; i++)
                        {
                            temdic = new Dictionary<string, string>();
                            temdic.Add("value", i.ToString());
                            temdic.Add("text", str[i]);

                            list.Add(temdic);
                        }
                    }
                }
            }
            string json = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            return json;
            //string strDes = Request.Params["keti"];
            //string str = RuRo.Common.DEncrypt.DESEncrypt.Decrypt(strDes);
            //string res="";
            //switch (str)
            //{
            //    case"心研所":res="XYS";break;
            //    case "肺癌所": res = "FAS"; break;
            //    default:break;
            //}
            //return res;
        }
        #endregion


    }
}