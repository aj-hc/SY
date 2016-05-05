using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL
{
    /// <summary>
    /// 数据访问类:TB_SETTING_VALUE
    /// </summary>
    public partial class TB_SETTING_VALUE
    {
        public TB_SETTING_VALUE()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RuRo.Model.TB_SETTING_VALUE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_SETTING_VALUE(");
            strSql.Append("SETTING_TYPE,SETTING_VALUE,DEPARTMENTS,ADD_TIME)");
            strSql.Append(" values (");
            strSql.Append("@SETTING_TYPE,@SETTING_VALUE,@DEPARTMENTS,@ADD_TIME)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SETTING_TYPE", SqlDbType.VarChar,50),
					new SqlParameter("@SETTING_VALUE", SqlDbType.VarChar,-1),
					new SqlParameter("@DEPARTMENTS", SqlDbType.VarChar,30),
					new SqlParameter("@ADD_TIME", SqlDbType.DateTime)};
            parameters[0].Value = model.SETTING_TYPE;
            parameters[1].Value = model.SETTING_VALUE;
            parameters[2].Value = model.DEPARTMENTS;
            parameters[3].Value = model.ADD_TIME;

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
        public bool Update(RuRo.Model.TB_SETTING_VALUE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_SETTING_VALUE set ");
            strSql.Append("SETTING_TYPE=@SETTING_TYPE,");
            strSql.Append("SETTING_VALUE=@SETTING_VALUE,");
            strSql.Append("DEPARTMENTS=@DEPARTMENTS,");
            strSql.Append("ADD_TIME=@ADD_TIME");
            strSql.Append(" where SETTING_ID=@SETTING_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@SETTING_TYPE", SqlDbType.VarChar,50),
					new SqlParameter("@SETTING_VALUE", SqlDbType.VarChar,-1),
					new SqlParameter("@DEPARTMENTS", SqlDbType.VarChar,30),
					new SqlParameter("@ADD_TIME", SqlDbType.DateTime),
					new SqlParameter("@SETTING_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.SETTING_TYPE;
            parameters[1].Value = model.SETTING_VALUE;
            parameters[2].Value = model.DEPARTMENTS;
            parameters[3].Value = model.ADD_TIME;
            parameters[4].Value = model.SETTING_ID;

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
        public bool Delete(int SETTING_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_SETTING_VALUE ");
            strSql.Append(" where SETTING_ID=@SETTING_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@SETTING_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = SETTING_ID;

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
        public bool DeleteList(string SETTING_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_SETTING_VALUE ");
            strSql.Append(" where SETTING_ID in (" + SETTING_IDlist + ")  ");
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
        public RuRo.Model.TB_SETTING_VALUE GetModel(int SETTING_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SETTING_ID,SETTING_TYPE,SETTING_VALUE,DEPARTMENTS,ADD_TIME from TB_SETTING_VALUE ");
            strSql.Append(" where SETTING_ID=@SETTING_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@SETTING_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = SETTING_ID;

            RuRo.Model.TB_SETTING_VALUE model = new RuRo.Model.TB_SETTING_VALUE();
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
        public RuRo.Model.TB_SETTING_VALUE DataRowToModel(DataRow row)
        {
            RuRo.Model.TB_SETTING_VALUE model = new RuRo.Model.TB_SETTING_VALUE();
            if (row != null)
            {
                if (row["SETTING_ID"] != null && row["SETTING_ID"].ToString() != "")
                {
                    model.SETTING_ID = int.Parse(row["SETTING_ID"].ToString());
                }
                if (row["SETTING_TYPE"] != null)
                {
                    model.SETTING_TYPE = row["SETTING_TYPE"].ToString();
                }
                if (row["SETTING_VALUE"] != null)
                {
                    model.SETTING_VALUE = row["SETTING_VALUE"].ToString();
                }
                if (row["DEPARTMENTS"] != null)
                {
                    model.DEPARTMENTS = row["DEPARTMENTS"].ToString();
                }
                if (row["ADD_TIME"] != null && row["ADD_TIME"].ToString() != "")
                {
                    model.ADD_TIME = DateTime.Parse(row["ADD_TIME"].ToString());
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
            strSql.Append("select SETTING_ID,SETTING_TYPE,SETTING_VALUE,DEPARTMENTS,ADD_TIME ");
            strSql.Append(" FROM TB_SETTING_VALUE ");
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
            strSql.Append(" SETTING_ID,SETTING_TYPE,SETTING_VALUE,DEPARTMENTS,ADD_TIME ");
            strSql.Append(" FROM TB_SETTING_VALUE ");
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
            strSql.Append("select count(1) FROM TB_SETTING_VALUE ");
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
                strSql.Append("order by T.SETTING_ID desc");
            }
            strSql.Append(")AS Row, T.*  from TB_SETTING_VALUE T ");
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
            parameters[0].Value = "TB_SETTING_VALUE";
            parameters[1].Value = "SETTING_ID";
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

