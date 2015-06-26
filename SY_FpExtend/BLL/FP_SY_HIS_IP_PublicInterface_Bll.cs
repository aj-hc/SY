using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RuRo.BLL
{
    public partial class FP_SY_HIS_IP_PublicInterface_Bll
    {
        private readonly RuRo.DAL.FP_SY_HIS_IP_PublicInterface dal = new RuRo.DAL.FP_SY_HIS_IP_PublicInterface();


        #region 门诊住院诊断信息
        /// <summary>
        /// 门诊住院诊断信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSY_HC_GetDiagnoseInfoJson(RuRo.Model.FP_SY_HIS_IP_PublicInterface model)
        {
            return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(dal.GetSY_HC_GetDiagnoseInfo(model));
        }
        #endregion

        #region 员工信息
        /// <summary>
        /// 员工信息
        /// </summary>
        /// <returns></returns>
        public string GetSY_HC_GetEmployeeInfoJson() 
        {
            return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(dal.GetSY_HC_GetEmployeeInfo()); 
        }
        #endregion

        #region 检验申请单信息
        /// <summary>
        /// 检验申请单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSY_HC_GetExamineRequestJson(RuRo.Model.FP_SY_HIS_IP_PublicInterface model)
        {
            return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(dal.GetSY_HC_GetExamineRequest(model)); 
        }
        #endregion

        #region 患者门诊住院信息
        /// <summary>
        /// 患者门诊住院信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSY_HC_GetPatientInfoJson(RuRo.Model.FP_SY_HIS_IP_PublicInterface model)
        {
           return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(dal.GetSY_HC_GetPatientInfo(model));
        }
        #endregion

        #region 手术申请单信息
        /// <summary>
        /// 手术申请单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSY_HC_GetSurgeryRequestJson(RuRo.Model.FP_SY_HIS_IP_PublicInterface model)
        {
            return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(dal.GetSY_HC_GetSurgeryRequest(model));
        }
        #endregion





    }
}
