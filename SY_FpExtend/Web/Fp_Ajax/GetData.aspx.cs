using RuRo.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web.Fp_Ajax
{
    public partial class GetData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取页面传来的值
            string action = Request.Params["action"].ToString();
            string strPatientInfoJson = "";//患者门诊住院信息
            string strDiagnoseInfoJson = "";//门诊住院诊断信息
            //string strExamineRequestJson = "";//检验申请单信息
            //string strSurgeryRequestJson = "";//手术申请单信息
            //string strEmployeeInfoJson = "";//员工信息
            if (action == "gethisdata")
            {
                string In_CodeType = Request.Params["In_CodeType"].ToString();
                string In_Code = Request.Params["In_Code"].ToString();
                if (string.IsNullOrEmpty(In_Code) || string.IsNullOrEmpty(In_CodeType) || In_Code == "" || In_CodeType == "") { }
                else
                {
                    Model.FP_SY_HIS_IP_PublicInterface model = new Model.FP_SY_HIS_IP_PublicInterface();
                    model.In_Code = In_Code;
                    model.In_CodeType = int.Parse(In_CodeType);
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    #region 将获取到的存储过程转化为JSON再存放到dic里面，然后dic序列化成json
                    //strPatientInfoJson = GetSY_HC_GetPatientInfoJson(model);
                    //if (!string.IsNullOrEmpty(strPatientInfoJson))
                    //{
                    //    strDiagnoseInfoJson = GetSY_HC_GetDiagnoseInfoJson(model);
                    //    if (!string.IsNullOrEmpty(strDiagnoseInfoJson))
                    //    {
                    //        dic.Add("_BaseInfo", strPatientInfoJson);
                    //        dic.Add("_ClinicalInfo", strDiagnoseInfoJson);
                    //    }
                    //}
                    //Response.Write(FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryToJsonString(dic));
                    #endregion
                    #region 临时数据
                    string testRes1 = "{\"_BaseInfo\":{\"ds\":[{\"PatientID\":1000456613,\"PatientName\":\"黄燕娥                        \",\"SexFlag\":2,\"BirthDay\":\"1952-07-24\",\"PatientCardNo\":\"诊疗卡号\",\"BloodTypeFlag\":3,\"InPatientID\":1000435093,\"IPSeqNoText\":\"P114083\",\"IPTimes\":1,\"InDateTime\":\"2003-10-08\",\"OutDate\":\"1900-01-01\",\"Phone\":\"13610187509         \",\"ContactPhone\":\"110\",\"ContactPerson\":\"110\",\"NativePlace\":\"广州市              \",\"RegisterID\":-1,\"RegisterSeqNO\":\"\"}]},\"_ClinicalInfo\":{\"ds\":[{\"DiagnoseTypeFlag\":0,\"DiagnoseDateTime\":\"1900-01-01\",\"DiseaseName\":\"子宫平滑肌瘤\",\"ICDCode\":\"D25.902\",\"Description\":\"                                        \"},{\"DiagnoseTypeFlag\":2,\"DiagnoseDateTime\":\"2014-11-18\",\"DiseaseName\":\"子宫平滑肌瘤\",\"ICDCode\":\"D25.902\",\"Description\":\"\"}]}}";
                    string testRes3 = "{\"_BaseInfo\":{\"ds\":[{\"PatientID\":3708555,\"PatientName\":\"叶万福\",\"SexFlag\":1,\"BirthDay\":\"1979-06-20T00:00:00\",\"PatientCardNo\":\"00000000000003186114\",\"BloodTypeFlag\":2,\"InPatientID\":1000930666,\"IPSeqNoText\":\"P369939\",\"IPTimes\":4,\"InDateTime\":\"2011-02-21T15:15:00\",\"OutDate\":\"2011-03-04T00:00:00\",\"Phone\":\"13727579435\",\"ContactPhone\":\"13727579435\",\"ContactPerson\":\"曾瑞丽\",\"NativePlace\":\"广东  韶关\",\"RegisterID\":-1,\"RegisterSeqNO\":\"13727579435\"}]},\"_ClinicalInfo\":{\"ds\":[{\"DiagnoseTypeFlag\":0,\"DiagnoseDateTime\":\"1900-01-01T00:00:00\",\"DiseaseName\":\"肝恶性肿瘤\",\"ICDCode\":\"C22.902\",\"Description\":\"\"},{\"DiagnoseTypeFlag\":2,\"DiagnoseDateTime\":\"1900-01-01T00:00:00\",\"DiseaseName\":\"肝恶性肿瘤\",\"ICDCode\":\"C22.902\",\"Description\":\"\"}]}}";
                    string testRes4 = "{\"_BaseInfo\":{\"ds\":[{\"PatientID\":2893599,\"PatientName\":\"朱家昌\",\"SexFlag\":1,\"BirthDay\":\"1992-12-06T00:00:00\",\"PatientCardNo\":\"00000000000002410204\",\"BloodTypeFlag\":0,\"InPatientID\":1000802037,\"IPSeqNoText\":\"P316855\",\"IPTimes\":1,\"InDateTime\":\"2009-08-17T19:15:00\",\"OutDate\":\"1900-01-01T00:00:00\",\"Phone\":\"13650067289\",\"ContactPhone\":\"\",\"ContactPerson\":\"朱庆业\",\"NativePlace\":\"广西合浦\",\"RegisterID\":-1,\"RegisterSeqNO\":\"\"}]},\"_ClinicalInfo\":{\"ds\":[{\"DiagnoseTypeFlag\":0,\"DiagnoseDateTime\":\"1900-01-01T00:00:00\",\"DiseaseName\":\"\",\"ICDCode\":\"\",\"Description\":\"鞍区占位\"},{\"DiagnoseTypeFlag\":2,\"DiagnoseDateTime\":\"1900-01-01T00:00:00\",\"DiseaseName\":\"颅内（脑）恶性肿瘤\",\"ICDCode\":\"C71.901\",\"Description\":\"\"}]}}";
                    string testRes5 = "{\"_BaseInfo\":{\"ds\":[{\"PatientID\":1000027755,\"PatientName\":\"金澧\",\"SexFlag\":2,\"BirthDay\":\"1928-11-15T00:00:00\",\"PatientCardNo\":\"00000000000001818570\",\"BloodTypeFlag\":3,\"InPatientID\":1000731655,\"IPSeqNoText\":\"P229252\",\"IPTimes\":4,\"InDateTime\":\"2008-09-28T18:24:00\",\"OutDate\":\"2008-10-13T00:00:00\",\"Phone\":\"37633105\",\"ContactPhone\":\"\",\"ContactPerson\":\"陈渝新\",\"NativePlace\":\"河南\",\"RegisterID\":-1,\"RegisterSeqNO\":\"\"}]},\"_ClinicalInfo\":\"\"}";
                    string testRes6 = "{\"_BaseInfo\":\"{\"ds\":[{\"PatientID\":4275746,\"PatientName\":\"黄启明\",\"SexFlag\":1,\"BirthDay\":\"1957-08-07T00:00:00\",\"PatientCardNo\":\"00000000000003763896\",\"BloodTypeFlag\":6,\"InPatientID\":1001167124,\"IPSeqNoText\":\"P451545\",\"IPTimes\":4,\"InDateTime\":\"2013-06-13T15:06:00\",\"OutDate\":\"2013-06-21T00:00:00\",\"Phone\":\"34149533\",\"ContactPhone\":\"\",\"ContactPerson\":\"\",\"NativePlace\":\"广东省增城市\",\"RegisterID\":-1,\"RegisterSeqNO\":\"\"}]}\",\"_ClinicalInfo\":\"{\"ds\":[{\"DiagnoseTypeFlag\":2,\"DiagnoseDateTime\":\"2013-06-21T00:00:00\",\"DiseaseName\":\"肺恶性肿瘤\",\"ICDCode\":\"C34.900\",\"Description\":\"左上肺腺癌 cT4N3M1b(颈部淋巴结\"}]}\"}";
                    string testRes7 = "{\"_BaseInfo\":\"{\"ds\":[{\"PatientID\":1000316238,\"PatientName\":\"郑思凌\",\"SexFlag\":1,\"BirthDay\":\"1926-05-05T00:00:00\",\"PatientCardNo\":\"                    \",\"BloodTypeFlag\":2,\"InPatientID\":1001388333,\"IPSeqNoText\":\"P30449\",\"IPTimes\":20,\"InDateTime\":\"2015-04-28T15:25:00\",\"OutDate\":\"2015-05-26T00:00:00\",\"Phone\":\"83588146\",\"ContactPhone\":\"\",\"ContactPerson\":\"郑向群\",\"NativePlace\":\"广东省恩平市\",\"RegisterID\":-1,\"RegisterSeqNO\":\"\"}]}\",\"_ClinicalInfo\":\"{\"ds\":[{\"DiagnoseTypeFlag\":2,\"DiagnoseDateTime\":\"2015-05-26T08:22:19.853\",\"DiseaseName\":\"冠状动脉粥样硬化性心脏病\",\"ICDCode\":\"I25.103\",\"Description\":\"\"}]}\"}";
                    string testRes8 = "{\"_BaseInfo\":\"{\"ds\":[{\"PatientID\":4549694,\"PatientName\":\"冼孔文\",\"SexFlag\":1,\"BirthDay\":\"1943-08-26T00:00:00\",\"PatientCardNo\":\"00000000000003988514\",\"BloodTypeFlag\":1,\"InPatientID\":1001146625,\"IPSeqNoText\":\"P493488\",\"IPTimes\":1,\"InDateTime\":\"2013-04-08T08:56:00\",\"OutDate\":\"2013-05-26T00:00:00\",\"Phone\":\"13652855444\",\"ContactPhone\":\"\",\"ContactPerson\":\"冼玉清\",\"NativePlace\":\"广东省吴川市黄坡县(区)\",\"RegisterID\":-1,\"RegisterSeqNO\":\"\"}]}\",\"_ClinicalInfo\":\"{\"ds\":[{\"DiagnoseTypeFlag\":2,\"DiagnoseDateTime\":\"2013-05-26T09:06:32.367\",\"DiseaseName\":\"主动脉瓣狭窄\",\"ICDCode\":\"I35.000\",\"Description\":\"\"}]}\"}";
                    //object obj=FreezerProUtility.Fp_Common.FpJsonHelper.DeserializeObjectStr(testRes2);
                    switch (In_Code)
                    {
                        case "1": Response.Write(testRes1); break;
                        case "3": Response.Write(testRes3); break;
                        case "4": Response.Write(testRes4); break;
                        case "5": Response.Write(testRes5); break;
                        case "6": Response.Write(testRes6); break;
                        case "7": Response.Write(testRes7); break;
                        case "8": Response.Write(testRes8); break;
                        default:
                            break;
                    }
                    #endregion
                }
            }
            //查询知情同意书
            if (action == "getConsentForm")
            {
                string name = Request.Params["gname"].ToString();
                string uid = Request.Params["guid"].ToString();
                Model.TB_CONSENT_FORM consent = new Model.TB_CONSENT_FORM();
                consent.PatientName = name;
                consent.PatientID = Convert.ToInt32(uid);
                BLL.TB_CONSENT_FORM bll = new TB_CONSENT_FORM();
                string strJson = bll.GetTB_CONSENT_FORM_BLL(consent);
                Response.Write(strJson);
            }
            //查询知情同意书数量
            if (action == "getConsentFormCount")
            {
                string name = Request.Params["gname"].ToString();
                string uid = Request.Params["guid"].ToString();
                Model.TB_CONSENT_FORM consent = new Model.TB_CONSENT_FORM();
                consent.PatientName = name;
                consent.PatientID = Convert.ToInt32(uid);
                BLL.TB_CONSENT_FORM bll = new TB_CONSENT_FORM();
                int count = bll.GetTB_CONSENT_FORM_BLL(consent, 1);
                Response.Write(count);
            }
            //查询设定
            if (action == "QuerySettingByCom")
            {
                string strJson = "";
                string type = Request.Params["valueType"].ToString();//获取传输类型
                string username = Common.CookieHelper.GetCookieValue("username");
                string keshi = Common.CookieHelper.GetCookieValue(username + "department");
                string StrDepartments = PageConData.DecryptDepartments(keshi);
                BLL.TB_SETTING_VALUE bll = new TB_SETTING_VALUE();
                System.Data.DataSet ds = bll.GetList("SETTING_TYPE='" + type + "' AND DEPARTMENTS='" + StrDepartments + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strJson = FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
                }
                Response.Write(strJson);
            }
            //删除设定
            if (action == "DelSetting")
            {
                string strJson = "";
                BLL.TB_SETTING_VALUE bll = new TB_SETTING_VALUE();
                string StrArray = Request.Params["settingID"].ToString();
                bool ISDel = bll.DeleteList(StrArray);
                if (ISDel)
                {
                    strJson = "删除成功";
                }
                else
                {
                    strJson = "删除失败";
                }
                Response.Write(strJson);
            }
            //根据日期及类型读取
            if (action == "getLogImport")
            {
                string strJson = "";
                string strGetDataType = "";
                string strImportType = Request.Params["Importtype"].ToString();
                string[] array = strImportType.Split('-');
                //获取传入的时间
                string strStartDate = Request.Params["stratDate"].ToString();
                string strendDate = Request.Params["endDate"].ToString();
                //获取页码
                int startCount = Convert.ToInt32(Request["startCount"]);
                int endCount = Convert.ToInt32(Request["endCount"]);
                //当第一次获取时，默认获取前10的数据
                if (startCount==0||endCount==0)
                {
                    startCount = 1;
                    endCount = 10;
                }
                else if (startCount>1)
                {
                    endCount = startCount+10-1;
                }
                //传入页码
                if (array.Length > 0)
                {
                    BLL.Log_Show log_bll = new Log_Show();
                    //1代表当前用户，2代表当前科室
                    if (array[0] == "1")
                    {
                        //获取当前用户
                        if (array[1].ToString() != "")
                        {
                            strGetDataType = array[1].ToString();
                            strJson = log_bll.GetDate(strGetDataType, "", strStartDate, strendDate, startCount, endCount);
                        }
                        else{}
                    }
                    else
                    {
                        //获取当前科室
                        if (array[1].ToString() != "")
                        {
                            strGetDataType= PageConData.DecryptDepartments(array[1].ToString());
                            strJson = log_bll.GetDate("", strGetDataType, strStartDate, strendDate, startCount, endCount);
                        }
                        else
                        {

                        }
                    }
                }
                Response.Write(strJson);
            }
            //默认获取
            if (action == "getDefaultImport")
            {
                try
                {
                    string user = Common.CookieHelper.GetCookieValue("username");
                    string department = Common.CookieHelper.GetCookieValue(user + "department");
                    string strJson = "";
                    if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(department))
                    {
                         Response.Redirect("../../Login.aspx");
                    }
                    BLL.Log_Show log_Show = new BLL.Log_Show();
                    strJson = log_Show.GetDate(user, "");
                    Response.Write(strJson);
                }
                catch (Exception)
                {
                    Response.Redirect("../../Login.aspx");
                }
            }
        }

        #region 患者门诊住院信息
        /// <summary>
        /// 患者门诊住院信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSY_HC_GetPatientInfoJson(Model.FP_SY_HIS_IP_PublicInterface model)
        {
            FP_SY_HIS_IP_PublicInterface_Bll fp = new FP_SY_HIS_IP_PublicInterface_Bll();
            return fp.GetSY_HC_GetPatientInfoJson(model);
        }
        #endregion

        #region 门诊住院诊断信息
        /// <summary>
        /// 门诊住院诊断信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSY_HC_GetDiagnoseInfoJson(Model.FP_SY_HIS_IP_PublicInterface model)
        {
            FP_SY_HIS_IP_PublicInterface_Bll fp = new FP_SY_HIS_IP_PublicInterface_Bll();
            return fp.GetSY_HC_GetDiagnoseInfoJson(model);
        }
        #endregion

        #region 检验申请单信息
        /// <summary>
        /// 检验申请单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSY_HC_GetExamineRequestJson(Model.FP_SY_HIS_IP_PublicInterface model)
        {
            FP_SY_HIS_IP_PublicInterface_Bll fp = new FP_SY_HIS_IP_PublicInterface_Bll();
            return fp.GetSY_HC_GetExamineRequestJson(model);
        }
        #endregion

        #region 手术申请单信息
        /// <summary>
        /// 手术申请单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSY_HC_GetSurgeryRequestJson(Model.FP_SY_HIS_IP_PublicInterface model)
        {
            FP_SY_HIS_IP_PublicInterface_Bll fp = new FP_SY_HIS_IP_PublicInterface_Bll();
            return fp.GetSY_HC_GetSurgeryRequestJson(model);
        }
        #endregion

        //#region 员工信息
        ///// <summary>
        ///// 员工信息
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public string GetSY_HC_GetEmployeeInfoJson()
        //{
        //    FP_SY_HIS_IP_PublicInterface_Bll fp = new FP_SY_HIS_IP_PublicInterface_Bll();
        //    return fp.GetSY_HC_GetEmployeeInfoJson();
        //}
        //#endregion

    }
}