using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL
{
    /// <summary>
    /// 数据访问类:TB_PARAMETER
    /// </summary>
    public partial class TB_PARAMETER
    {
        public TB_PARAMETER()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_PARAMETER");
            strSql.Append(" where PID=@PID");
            SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4)
			};
            parameters[0].Value = PID;

            return DbHelperSQL_SY.ExistsSY(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RuRo.Model.TB_PARAMETER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_PARAMETER(");
            strSql.Append("TYPE,NAME,TEXTID,PY,ISACTIVE)");
            strSql.Append(" values (");
            strSql.Append("@TYPE,@NAME,@TEXTID,@PY,@ISACTIVE)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TYPE", SqlDbType.VarChar,50),
					new SqlParameter("@NAME", SqlDbType.VarChar,50),
					new SqlParameter("@TEXTID", SqlDbType.VarChar,50),
					new SqlParameter("@PY", SqlDbType.VarChar,50),
					new SqlParameter("@ISACTIVE", SqlDbType.Bit,1)};
            parameters[0].Value = model.TYPE;
            parameters[1].Value = model.NAME;
            parameters[2].Value = model.TEXTID;
            parameters[3].Value = model.PY;
            parameters[4].Value = model.ISACTIVE;

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
        public bool Update(RuRo.Model.TB_PARAMETER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_PARAMETER set ");
            strSql.Append("TYPE=@TYPE,");
            strSql.Append("NAME=@NAME,");
            strSql.Append("TEXTID=@TEXTID,");
            strSql.Append("PY=@PY,");
            strSql.Append("ISACTIVE=@ISACTIVE");
            strSql.Append(" where PID=@PID");
            SqlParameter[] parameters = {
					new SqlParameter("@TYPE", SqlDbType.VarChar,50),
					new SqlParameter("@NAME", SqlDbType.VarChar,50),
					new SqlParameter("@TEXTID", SqlDbType.VarChar,50),
					new SqlParameter("@PY", SqlDbType.VarChar,50),
					new SqlParameter("@ISACTIVE", SqlDbType.Bit,1),
					new SqlParameter("@PID", SqlDbType.Int,4)};
            parameters[0].Value = model.TYPE;
            parameters[1].Value = model.NAME;
            parameters[2].Value = model.TEXTID;
            parameters[3].Value = model.PY;
            parameters[4].Value = model.ISACTIVE;
            parameters[5].Value = model.PID;

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
        public bool Delete(int PID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_PARAMETER ");
            strSql.Append(" where PID=@PID");
            SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4)
			};
            parameters[0].Value = PID;

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
        public bool DeleteList(string PIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_PARAMETER ");
            strSql.Append(" where PID in (" + PIDlist + ")  ");
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
        public RuRo.Model.TB_PARAMETER GetModel(int PID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PID,TYPE,NAME,TEXTID,PY,ISACTIVE from TB_PARAMETER ");
            strSql.Append(" where PID=@PID");
            SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4)
			};
            parameters[0].Value = PID;

            RuRo.Model.TB_PARAMETER model = new RuRo.Model.TB_PARAMETER();
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
        public RuRo.Model.TB_PARAMETER DataRowToModel(DataRow row)
        {
            RuRo.Model.TB_PARAMETER model = new RuRo.Model.TB_PARAMETER();
            if (row != null)
            {
                if (row["PID"] != null && row["PID"].ToString() != "")
                {
                    model.PID = int.Parse(row["PID"].ToString());
                }
                if (row["TYPE"] != null)
                {
                    model.TYPE = row["TYPE"].ToString();
                }
                if (row["NAME"] != null)
                {
                    model.NAME = row["NAME"].ToString();
                }
                if (row["TEXTID"] != null)
                {
                    model.TEXTID = row["TEXTID"].ToString();
                }
                if (row["PY"] != null)
                {
                    model.PY = row["PY"].ToString();
                }
                if (row["ISACTIVE"] != null && row["ISACTIVE"].ToString() != "")
                {
                    if ((row["ISACTIVE"].ToString() == "1") || (row["ISACTIVE"].ToString().ToLower() == "true"))
                    {
                        model.ISACTIVE = true;
                    }
                    else
                    {
                        model.ISACTIVE = false;
                    }
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
            strSql.Append("select PID,TYPE,NAME,TEXTID,PY,ISACTIVE ");
            strSql.Append(" FROM TB_PARAMETER ");
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
            strSql.Append(" PID,TYPE,NAME,TEXTID,PY,ISACTIVE ");
            strSql.Append(" FROM TB_PARAMETER ");
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
            strSql.Append("select count(1) FROM TB_PARAMETER ");
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
                strSql.Append("order by T.PID desc");
            }
            strSql.Append(")AS Row, T.*  from TB_PARAMETER T ");
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
            parameters[0].Value = "TB_PARAMETER";
            parameters[1].Value = "PID";
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

