using System;
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
            strSql.Append("BASE_ID,CLINICAL_ID,SAMPLE_TYPE,SAMPLE_TIJI,SAMPLE_QTY,STATUS,MSG,LOG_DATE,LOG_UP)");
            strSql.Append(" values (");
            strSql.Append("@BASE_ID,@CLINICAL_ID,@SAMPLE_TYPE,@SAMPLE_TIJI,@SAMPLE_QTY,@STATUS,@MSG,@LOG_DATE,@LOG_UP)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BASE_ID", SqlDbType.Int,4),
					new SqlParameter("@CLINICAL_ID", SqlDbType.Int,4),
					new SqlParameter("@SAMPLE_TYPE", SqlDbType.VarChar,50),
					new SqlParameter("@SAMPLE_TIJI", SqlDbType.VarChar,50),
					new SqlParameter("@SAMPLE_QTY", SqlDbType.Int,4),
					new SqlParameter("@STATUS", SqlDbType.Char,10),
					new SqlParameter("@MSG", SqlDbType.VarChar,100),
					new SqlParameter("@LOG_DATE", SqlDbType.DateTime),
					new SqlParameter("@LOG_UP", SqlDbType.VarChar,50)};
            parameters[0].Value = model.BASE_ID;
            parameters[1].Value = model.CLINICAL_ID;
            parameters[2].Value = model.SAMPLE_TYPE;
            parameters[3].Value = model.SAMPLE_TIJI;
            parameters[4].Value = model.SAMPLE_QTY;
            parameters[5].Value = model.STATUS;
            parameters[6].Value = model.MSG;
            parameters[7].Value = model.LOG_DATE;
            parameters[8].Value = model.LOG_UP;

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
            strSql.Append("BASE_ID=@BASE_ID,");
            strSql.Append("CLINICAL_ID=@CLINICAL_ID,");
            strSql.Append("SAMPLE_TYPE=@SAMPLE_TYPE,");
            strSql.Append("SAMPLE_TIJI=@SAMPLE_TIJI,");
            strSql.Append("SAMPLE_QTY=@SAMPLE_QTY,");
            strSql.Append("STATUS=@STATUS,");
            strSql.Append("MSG=@MSG,");
            strSql.Append("LOG_DATE=@LOG_DATE,");
            strSql.Append("LOG_UP=@LOG_UP");
            strSql.Append(" where LOG_ID=@LOG_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@BASE_ID", SqlDbType.Int,4),
					new SqlParameter("@CLINICAL_ID", SqlDbType.Int,4),
					new SqlParameter("@SAMPLE_TYPE", SqlDbType.VarChar,50),
					new SqlParameter("@SAMPLE_TIJI", SqlDbType.VarChar,50),
					new SqlParameter("@SAMPLE_QTY", SqlDbType.Int,4),
					new SqlParameter("@STATUS", SqlDbType.Char,10),
					new SqlParameter("@MSG", SqlDbType.VarChar,100),
					new SqlParameter("@LOG_DATE", SqlDbType.DateTime),
					new SqlParameter("@LOG_UP", SqlDbType.VarChar,50),
					new SqlParameter("@LOG_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.BASE_ID;
            parameters[1].Value = model.CLINICAL_ID;
            parameters[2].Value = model.SAMPLE_TYPE;
            parameters[3].Value = model.SAMPLE_TIJI;
            parameters[4].Value = model.SAMPLE_QTY;
            parameters[5].Value = model.STATUS;
            parameters[6].Value = model.MSG;
            parameters[7].Value = model.LOG_DATE;
            parameters[8].Value = model.LOG_UP;
            parameters[9].Value = model.LOG_ID;

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
            strSql.Append("select  top 1 LOG_ID,BASE_ID,CLINICAL_ID,SAMPLE_TYPE,SAMPLE_TIJI,SAMPLE_QTY,STATUS,MSG,LOG_DATE,LOG_UP from TB_SAMPLE_LOG ");
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
                if (row["BASE_ID"] != null && row["BASE_ID"].ToString() != "")
                {
                    model.BASE_ID = int.Parse(row["BASE_ID"].ToString());
                }
                if (row["CLINICAL_ID"] != null && row["CLINICAL_ID"].ToString() != "")
                {
                    model.CLINICAL_ID = int.Parse(row["CLINICAL_ID"].ToString());
                }
                if (row["SAMPLE_TYPE"] != null)
                {
                    model.SAMPLE_TYPE = row["SAMPLE_TYPE"].ToString();
                }
                if (row["SAMPLE_TIJI"] != null)
                {
                    model.SAMPLE_TIJI = row["SAMPLE_TIJI"].ToString();
                }
                if (row["SAMPLE_QTY"] != null && row["SAMPLE_QTY"].ToString() != "")
                {
                    model.SAMPLE_QTY = int.Parse(row["SAMPLE_QTY"].ToString());
                }
                if (row["STATUS"] != null)
                {
                    model.STATUS = row["STATUS"].ToString();
                }
                if (row["MSG"] != null)
                {
                    model.MSG = row["MSG"].ToString();
                }
                if (row["LOG_DATE"] != null && row["LOG_DATE"].ToString() != "")
                {
                    model.LOG_DATE = DateTime.Parse(row["LOG_DATE"].ToString());
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
            strSql.Append("select LOG_ID,BASE_ID,CLINICAL_ID,SAMPLE_TYPE,SAMPLE_TIJI,SAMPLE_QTY,STATUS,MSG,LOG_DATE,LOG_UP ");
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
            strSql.Append(" LOG_ID,BASE_ID,CLINICAL_ID,SAMPLE_TYPE,SAMPLE_TIJI,SAMPLE_QTY,STATUS,MSG,LOG_DATE,LOG_UP ");
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

