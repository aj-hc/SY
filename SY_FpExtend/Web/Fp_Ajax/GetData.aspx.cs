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
                    Model.FP_SY_HIS_IP_PublicInterface model = new Model.FP_SY_HIS_IP_PublicInterface();
                    model.In_Code = In_Code;
                    model.In_CodeType = int.Parse(In_CodeType);
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    #region 将获取到的存储过程转化为JSON再存放到dic里面，然后dic序列化成json
                    strPatientInfoJson = GetSY_HC_GetPatientInfoJson(model);
                    if (!string.IsNullOrEmpty(strPatientInfoJson) || strPatientInfoJson != "")
                    {
                        strDiagnoseInfoJson = GetSY_HC_GetDiagnoseInfoJson(model);
                        if (!string.IsNullOrEmpty(strDiagnoseInfoJson))
                        {
                            dic.Add("_BaseInfo", strPatientInfoJson);
                            dic.Add("_ClinicalInfo", strDiagnoseInfoJson);
                        }
                    }
                    Response.Write(FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryToJsonString(dic));

                    //string testRes = "{\"_BaseInfo\":{\"ds\":[{\"PatientID\":1000456613,\"PatientName\":\"黄燕娥                        \",\"SexFlag\":2,\"BirthDay\":\"1952-07-24\",\"PatientCardNo\":\"诊疗卡号\",\"BloodTypeFlag\":6,\"InPatientID\":1000435093,\"IPSeqNoText\":\"P114083\",\"IPTimes\":1,\"InDateTime\":\"2003-10-08\",\"OutDate\":\"1900-01-01\",\"Phone\":\"13610187509         \",\"ContactPhone\":\"110\",\"ContactPerson\":\"110\",\"NativePlace\":\"广州市              \",\"RegisterID\":-1,\"RegisterSeqNO\":\"\"}]},\"_ClinicalInfo\":{\"ds\":[{\"DiagnoseTypeFlag\":0,\"DiagnoseDateTime\":\"1900-01-01\",\"DiseaseName\":\"子宫平滑肌瘤\",\"ICDCode\":\"D25.902\",\"Description\":\"                                        \"},{\"DiagnoseTypeFlag\":2,\"DiagnoseDateTime\":\"2014-11-18\",\"DiseaseName\":\"子宫平滑肌瘤\",\"ICDCode\":\"D25.902\",\"Description\":\"\"}]}}";

                    //Response.Write(testRes);
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

        #region 员工信息
        /// <summary>
        /// 员工信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSY_HC_GetEmployeeInfoJson()
        {
            FP_SY_HIS_IP_PublicInterface_Bll fp = new FP_SY_HIS_IP_PublicInterface_Bll();
            return fp.GetSY_HC_GetEmployeeInfoJson();
        }

        #endregion

    }
}