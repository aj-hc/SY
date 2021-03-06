﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL
{
    /// <summary>
    /// 数据访问类:TB_SAMPLE_LOG
    /// </summary>
    public partial class TB_SAMPLE_LOG
    {
        public TB_SAMPLE_LOG()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LOG_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_SAMPLE_LOG");
            strSql.Append(" where LOG_ID=@LOG_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@LOG_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = LOG_ID;

            return DbHelperSQL_SY.ExistsSY(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RuRo.Model.TB_SAMPLE_LOG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_SAMPLE_LOG(");
            strSql.Append("PatientID,BASE_MSG,CLINICAL_MSG,MSG,STATE,LOG_DATE,type,LOG_UP)");
            strSql.Append(" values (");
            strSql.Append("@PatientID,@BASE_MSG,@CLINICAL_MSG,@MSG,@STATE,@LOG_DATE,@type,@LOG_UP)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PatientID", SqlDbType.Int,4),
					new SqlParameter("@BASE_MSG", SqlDbType.VarChar,100),
					new SqlParameter("@CLINICAL_MSG", SqlDbType.VarChar,100),
					new SqlParameter("@MSG", SqlDbType.VarChar,-1),
					new SqlParameter("@STATE", SqlDbType.NChar,10),
					new SqlParameter("@LOG_DATE", SqlDbType.DateTime),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@LOG_UP", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PatientID;
            parameters[1].Value = model.BASE_MSG;
            parameters[2].Value = model.CLINICAL_MSG;
            parameters[3].Value = model.MSG;
            parameters[4].Value = model.STATE;
            parameters[5].Value = model.LOG_DATE;
            parameters[6].Value = model.type;
            parameters[7].Value = model.LOG_UP;
            object obj = DbHelperSQL_SY.GetSingleSY(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(RuRo.Model.TB_SAMPLE_LOG model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_SAMPLE_LOG set ");
            strSql.Append("PatientID=@PatientID,");
            strSql.Append("BASE_MSG=@BASE_MSG,");
            strSql.Append("CLINICAL_MSG=@CLINICAL_MSG,");
            strSql.Append("MSG=@MSG,");
            strSql.Append("STATE=@STATE,");
            strSql.Append("LOG_DATE=@LOG_DATE,");
            strSql.Append("type=@type,");
            strSql.Append("LOG_UP=@LOG_UP");
            strSql.Append(" where LOG_ID=@LOG_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@PatientID", SqlDbType.Int,4),
					new SqlParameter("@BASE_MSG", SqlDbType.VarChar,100),
					new SqlParameter("@CLINICAL_MSG", SqlDbType.VarChar,100),
					new SqlParameter("@MSG", SqlDbType.VarChar,-1),
					new SqlParameter("@STATE", SqlDbType.NChar,10),
					new SqlParameter("@LOG_DATE", SqlDbType.DateTime),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@LOG_UP", SqlDbType.VarChar,50),
					new SqlParameter("@LOG_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.PatientID;
            parameters[1].Value = model.BASE_MSG;
            parameters[2].Value = model.CLINICAL_MSG;
            parameters[3].Value = model.MSG;
            parameters[4].Value = model.STATE;
            parameters[5].Value = model.LOG_DATE;
            parameters[6].Value = model.type;
            parameters[7].Value = model.LOG_UP;
            parameters[8].Value = model.LOG_ID;

            int rows = DbHelperSQL_SY.ExecuteSqlSY(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int LOG_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_SAMPLE_LOG ");
            strSql.Append(" where LOG_ID=@LOG_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@LOG_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = LOG_ID;

            int rows = DbHelperSQL_SY.ExecuteSqlSY(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string LOG_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_SAMPLE_LOG ");
            strSql.Append(" where LOG_ID in (" + LOG_IDlist + ")  ");
            int rows = DbHelperSQL_SY.ExecuteSqlSY(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RuRo.Model.TB_SAMPLE_LOG GetModel(int LOG_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LOG_ID,PatientID,BASE_MSG,CLINICAL_MSG,MSG,STATE,LOG_DATE,type,LOG_UP from TB_SAMPLE_LOG ");
            strSql.Append(" where LOG_ID=@LOG_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@LOG_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = LOG_ID;

            RuRo.Model.TB_SAMPLE_LOG model = new RuRo.Model.TB_SAMPLE_LOG();
            DataSet ds = DbHelperSQL_SY.QuerySY(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RuRo.Model.TB_SAMPLE_LOG DataRowToModel(DataRow row)
        {
            RuRo.Model.TB_SAMPLE_LOG model = new RuRo.Model.TB_SAMPLE_LOG();
            if (row != null)
            {
                if (row["LOG_ID"] != null && row["LOG_ID"].ToString() != "")
                {
                    model.LOG_ID = int.Parse(row["LOG_ID"].ToString());
                }
                if (row["PatientID"] != null && row["PatientID"].ToString() != "")
                {
                    model.PatientID = int.Parse(row["PatientID"].ToString());
                }
                if (row["BASE_MSG"] != null)
                {
                    model.BASE_MSG = row["BASE_MSG"].ToString();
                }
                if (row["CLINICAL_MSG"] != null)
                {
                    model.CLINICAL_MSG = row["CLINICAL_MSG"].ToString();
                }
                if (row["MSG"] != null)
                {
                    model.MSG = row["MSG"].ToString();
                }
                if (row["STATE"] != null)
                {
                    model.STATE = row["STATE"].ToString();
                }
                if (row["LOG_DATE"] != null && row["LOG_DATE"].ToString() != "")
                {
                    model.LOG_DATE = DateTime.Parse(row["LOG_DATE"].ToString());
                }
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["LOG_UP"] != null)
                {
                    model.LOG_UP = row["LOG_UP"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LOG_ID,PatientID,BASE_MSG,CLINICAL_MSG,MSG,STATE,LOG_DATE,type,LOG_UP ");
            strSql.Append(" FROM TB_SAMPLE_LOG ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL_SY.QuerySY(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" LOG_ID,PatientID,BASE_MSG,CLINICAL_MSG,MSG,STATE,LOG_DATE,type,LOG_UP ");
            strSql.Append(" FROM TB_SAMPLE_LOG ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL_SY.QuerySY(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM TB_SAMPLE_LOG ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL_SY.GetSingleSY(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.LOG_ID desc");
            }
            strSql.Append(")AS Row, T.*  from TB_SAMPLE_LOG T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL_SY.QuerySY(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "TB_SAMPLE_LOG";
            parameters[1].Value = "LOG_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL_SY.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

