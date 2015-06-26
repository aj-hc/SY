using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Maticsoft.Common;


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
            return DbHelperSQL.RunProcedure("SY_HC_GetDiagnoseInfo", parameters, "ds");
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
            return DbHelperSQL.RunProcedure("SY_HC_GetEmployeeInfo", parameters, "ds");
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
            return DbHelperSQL.RunProcedure("SY_HC_GetExamineRequest", parameters, "ds");
        }
        #endregion

        #region 患者门诊住院信息
        /// <summary>
        /// 患者门诊住院信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetSY_HC_GetPatientInfo(RuRo.Model.FP_SY_HIS_IP_PublicInterface model)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataView dv = new DataView();
            DataRow dr;
            DataTable dtt = new DataTable();
            SqlParameter[] parameters = 
                {
                     new SqlParameter("@In_CodeType", SqlDbType.Int),
                     new SqlParameter("@In_Code", SqlDbType.NVarChar,50)
                };
            parameters[0].Value = model.In_CodeType;
            parameters[1].Value = model.In_Code;
            ds = DbHelperSQL.RunProcedure("SY_HC_GetPatientInfo", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 1)
                {
                  
                }
                else
                {
                    model.In_InPatientID = Convert.ToInt32(ds.Tables[0].Rows[0]["InPatientID"]);
                    model.In_CodeType = Convert.ToInt32(ds.Tables[0].Rows[0]["InPatientID"]);
                }

            }
            #region
            //dv = ds.Tables[0].DefaultView;
            //dv.Sort = "RegisterSeqNO DESC";//排序值
            //dt = dv.ToTable();
            //if (dt.Rows.Count == 0) { }
            //else
            //{
            //    if (dt.Rows.Count == 1)
            //    {
            //        model.In_InPatientID = Convert.ToInt32(dt.Rows[0]["InPatientID"]);
            //        model.In_CodeType = Convert.ToInt32(dt.Rows[0]["RegisterID"]);
            //        dtt = dt;
            //    }
            //    else
            //    {
            //        dr = dt.Rows[0]; //获取排序后的第一行
            //        model.In_InPatientID = Convert.ToInt32(dt.Rows[0]["InPatientID"]);
            //        model.In_CodeType = Convert.ToInt32(dt.Rows[0]["RegisterID"]);
            //        dtt.Rows.Add(dr.ItemArray);
            //    }

            //}
            #endregion
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
            return DbHelperSQL.RunProcedure("SY_HC_GetSurgeryRequest", parameters, "ds");
        }
        #endregion

    }
}
