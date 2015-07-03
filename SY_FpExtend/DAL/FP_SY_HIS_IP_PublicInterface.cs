using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RuRo.DAL
{
    public partial class FP_SY_HIS_IP_PublicInterface
    {

        #region 门诊住院诊断信息
        /// <summary>
        /// 门诊住院诊断信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet GetSY_HC_GetDiagnoseInfo(Model.FP_SY_HIS_IP_PublicInterface model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@In_RegisterID", SqlDbType.Int),
                    new SqlParameter("@In_InPatientID", SqlDbType.Int)
					};
            parameters[0].Value = model.In_RegisterID;
            parameters[1].Value = model.In_InPatientID;
            return DbHelperSQL.RunProcedure("SY_HC_GetDiagnoseInfo", parameters, "ds",200);
        }
        #endregion

        #region 员工信息
        /// <summary>
        /// 员工信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetSY_HC_GetEmployeeInfo()
        {
            SqlParameter[] parameters = null;
            return DbHelperSQL.RunProcedure("SY_HC_GetEmployeeInfo", parameters, "ds", 200);
        }
        #endregion

        #region 检验申请单信息
        /// <summary>
        /// 检验申请单信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetSY_HC_GetExamineRequest(RuRo.Model.FP_SY_HIS_IP_PublicInterface model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@In_RegisterID", SqlDbType.Int),
                    new SqlParameter("@In_InPatientID", SqlDbType.Int)
				
					};
            parameters[0].Value = model.In_RegisterID;
            parameters[1].Value = model.In_InPatientID;
            return DbHelperSQL.RunProcedure("SY_HC_GetExamineRequest", parameters, "ds", 200);
        }
        #endregion

        #region 患者门诊住院信息
        /// <summary>
        /// 患者门诊住院信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetSY_HC_GetPatientInfo(RuRo.Model.FP_SY_HIS_IP_PublicInterface model)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlParameter[] parameters = 
                {
                     new SqlParameter("@In_CodeType", SqlDbType.Int),
                     new SqlParameter("@In_Code", SqlDbType.NVarChar,50)
                };
            parameters[0].Value = model.In_CodeType;
            parameters[1].Value = model.In_Code;
            ds = DbHelperSQL.RunProcedure("SY_HC_GetPatientInfo", parameters, "ds", 200);
            return ds;

        }
        #endregion

        #region 手术申请单信息
        /// <summary>
        /// 手术申请单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet GetSY_HC_GetSurgeryRequest(RuRo.Model.FP_SY_HIS_IP_PublicInterface model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@In_RegisterID", SqlDbType.Int),
                    new SqlParameter("@In_InPatientID", SqlDbType.Int)
					};
            parameters[0].Value = model.In_RegisterID;
            parameters[1].Value = model.In_InPatientID;
            return DbHelperSQL.RunProcedure("SY_HC_GetSurgeryRequest", parameters, "ds", 200);
        }
        #endregion

    }
}
