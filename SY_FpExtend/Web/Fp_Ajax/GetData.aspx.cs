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
            string action=Request.Params["action"].ToString();
            string In_CodeType = Request.Params["In_CodeType"].ToString();
            string In_Code = Request.Params["In_Code"].ToString();
            string strPatientInfoJson = "";//患者门诊住院信息
            string strDiagnoseInfoJson = "";//门诊住院诊断信息
            //string strExamineRequestJson = "";//检验申请单信息
            //string strSurgeryRequestJson = "";//手术申请单信息
            //string strEmployeeInfoJson = "";//员工信息
            if (action=="gethisdata")
            {
                if (string.IsNullOrEmpty(In_Code) || string.IsNullOrEmpty(In_CodeType) || In_Code == "" || In_CodeType == "") { }
                else 
                {
                    //Model.FP_SY_HIS_IP_PublicInterface model = new Model.FP_SY_HIS_IP_PublicInterface();
                    //model.In_Code = In_Code;
                    //model.In_CodeType = int.Parse(In_CodeType);
                    //Dictionary<string, string> dic = new Dictionary<string, string>();
                    #region 将获取到的存储过程转化为JSON再存放到dic里面，然后dic序列化成json
                    //strPatientInfoJson = GetSY_HC_GetPatientInfoJson(model);
                    //if (!string.IsNullOrEmpty(strPatientInfoJson) || strPatientInfoJson != "")
                    //{
                    //    strDiagnoseInfoJson = GetSY_HC_GetDiagnoseInfoJson(model);
                    //    if (!string.IsNullOrEmpty(strDiagnoseInfoJson))
                    //    {
                    //        dic.Add("_BaseInfo", strPatientInfoJson);
                    //        dic.Add("_ClinicalInfo", strDiagnoseInfoJson);
                    //    }
                    //}
                    //Response.Write(FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryToJsonString(dic));

                    string testRes = "{\"_BaseInfo\":{\"ds\":[{\"PatientID\":1000456613,\"PatientName\":\"黄燕娥                        \",\"SexFlag\":2,\"BirthDay\":\"1952-07-24\",\"PatientCardNo\":\"诊疗卡号\",\"BloodTypeFlag\":6,\"InPatientID\":1000435093,\"IPSeqNoText\":\"P114083\",\"IPTimes\":1,\"InDateTime\":\"2003-10-08\",\"OutDate\":\"1900-01-01\",\"Phone\":\"13610187509         \",\"ContactPhone\":\"110\",\"ContactPerson\":\"110\",\"NativePlace\":\"广州市              \",\"RegisterID\":-1,\"RegisterSeqNO\":\"\"}]},\"_ClinicalInfo\":{\"ds\":[{\"DiagnoseTypeFlag\":0,\"DiagnoseDateTime\":\"1900-01-01\",\"DiseaseName\":\"子宫平滑肌瘤\",\"ICDCode\":\"D25.902\",\"Description\":\"                                        \"},{\"DiagnoseTypeFlag\":2,\"DiagnoseDateTime\":\"2014-11-18\",\"DiseaseName\":\"子宫平滑肌瘤\",\"ICDCode\":\"D25.902\",\"Description\":\"\"}]}}";
                    string testRes2 = "{\"_BaseInfo\":{\"ds\":[{\"PatientID\":1000027755,\"PatientName\":\"金澧\",\"SexFlag\":2,\"BirthDay\":\"1928-11-15T00:00:00\",\"PatientCardNo\":\"00000000000001818570\",\"BloodTypeFlag\":3,\"InPatientID\":1000731655,\"IPSeqNoText\":\"P229252\",\"IPTimes\":4,\"InDateTime\":\"2008-09-28T18:24:00\",\"OutDate\":\"2008-10-13T00:00:00\",\"Phone\":\"37633105\",\"ContactPhone\":\"\",\"ContactPerson\":\"陈渝新\",\"NativePlace\":\"河南\",\"RegisterID\":-1,\"RegisterSeqNO\":\"\"}]},\"_ClinicalInfo\":\"{\"ds\":[]}}";

                    string testRes3 = "{\"_BaseInfo\":{\"ds\":[{\"PatientID\":3708555,\"PatientName\":\"叶万福\",\"SexFlag\":1,\"BirthDay\":\"1979-06-20T00:00:00\",\"PatientCardNo\":\"00000000000003186114\",\"BloodTypeFlag\":6,\"InPatientID\":1000930666,\"IPSeqNoText\":\"P369939\",\"IPTimes\":4,\"InDateTime\":\"2011-02-21T15:15:00\",\"OutDate\":\"2011-03-04T00:00:00\",\"Phone\":\"13727579435\",\"ContactPhone\":\"\",\"ContactPerson\":\"曾瑞丽\",\"NativePlace\":\"广东  韶关\",\"RegisterID\":-1,\"RegisterSeqNO\":\"\"}]},\"_ClinicalInfo\":{\"ds\":[{\"DiagnoseTypeFlag\":0,\"DiagnoseDateTime\":\"1900-01-01T00:00:00\",\"DiseaseName\":\"肝恶性肿瘤\",\"ICDCode\":\"C22.902\",\"Description\":\"\"},{\"DiagnoseTypeFlag\":2,\"DiagnoseDateTime\":\"1900-01-01T00:00:00\",\"DiseaseName\":\"肝恶性肿瘤\",\"ICDCode\":\"C22.902\",\"Description\":\"\"}]}}";

                    string testRes4 = "{\"_BaseInfo\":{\"ds\":[{\"PatientID\":2893599,\"PatientName\":\"朱家昌\",\"SexFlag\":1,\"BirthDay\":\"1992-12-06T00:00:00\",\"PatientCardNo\":\"00000000000002410204\",\"BloodTypeFlag\":0,\"InPatientID\":1000802037,\"IPSeqNoText\":\"P316855\",\"IPTimes\":1,\"InDateTime\":\"2009-08-17T19:15:00\",\"OutDate\":\"1900-01-01T00:00:00\",\"Phone\":\"13650067289\",\"ContactPhone\":\"\",\"ContactPerson\":\"朱庆业\",\"NativePlace\":\"广西合浦\",\"RegisterID\":-1,\"RegisterSeqNO\":\"\"}]},\"_ClinicalInfo\":{\"ds\":[{\"DiagnoseTypeFlag\":0,\"DiagnoseDateTime\":\"1900-01-01T00:00:00\",\"DiseaseName\":\"\",\"ICDCode\":\"\",\"Description\":\"鞍区占位\"},{\"DiagnoseTypeFlag\":2,\"DiagnoseDateTime\":\"1900-01-01T00:00:00\",\"DiseaseName\":\"颅内（脑）恶性肿瘤\",\"ICDCode\":\"C71.901\",\"Description\":\"\"}]}}";
                    Response.Write(testRes3);
                    #endregion
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