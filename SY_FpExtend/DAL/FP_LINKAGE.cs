using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RuRo.DAL
{
    public partial class FP_LINKAGE
    {
        public FP_LINKAGE()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL_SY.GetMaxIDSY("id", "FP_LINKAGE");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FP_LINKAGE");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL_SY.ExistsSY(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RuRo.Model.FP_LINKAGE model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("insert into FP_LINKAGE(");
            strSql.Append("fromid,name)");
            strSql.Append(" values (");
            strSql.Append("@fromid,@name)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                            new SqlParameter("@fromid", SqlDbType.Int),
                            new SqlParameter("@Name", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.fromid;
            parameters[1].Value = model.name;

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
        public bool Update(RuRo.Model.FP_LINKAGE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FP_LINKAGE set");
            strSql.Append("fromid=@fromid,");
            strSql.Append("name=@name,");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@fromid", SqlDbType.Int),
					new SqlParameter("@id", SqlDbType.Int)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.fromid;
            parameters[3].Value = model.id;

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
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FP_LINKAGE ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FP_LINKAGE ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public RuRo.Model.FP_LINKAGE GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,fromid,name from FP_LINKAGE ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            RuRo.Model.FP_LINKAGE model = new RuRo.Model.FP_LINKAGE();
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
        public RuRo.Model.FP_LINKAGE DataRowToModel(DataRow row)
        {
            RuRo.Model.FP_LINKAGE model = new RuRo.Model.FP_LINKAGE();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["fromid"] != null && row["fromid"].ToString() != "")
                {
                    model.fromid = int.Parse(row["fromid"].ToString());
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
            strSql.Append("select id,fromid,name");
            strSql.Append(" FROM FP_LINKAGE ");
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
            strSql.Append(" id,fromid,name");
            strSql.Append(" FROM FP_LINKAGE ");
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
            strSql.Append("select count(1) FROM FP_LINKAGE ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from FP_LINKAGE T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL_SY.QuerySY(strSql.ToString());
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 查询联动
        /// </summary>
        /// <returns></returns>
        public DataSet GetFP_LINKAGE()
        {
            string strSql = "SELECT ID,NAME FROM FP_LINKAGE WHERE FROMID=0";
            DataSet ds = new DataSet();
            ds= DbHelperSQL_SY.QuerySY(strSql);
            return ds;
        }
        /// <summary>
        /// 查询联动二级
        /// </summary>
        /// <returns></returns>
        public DataSet GetFP_LINKAGE(int index)
        {
            string strSql = "SELECT ID,NAME FROM FP_LINKAGE WHERE FROMID="+index;
            DataSet ds = new DataSet();
            ds = DbHelperSQL_SY.QuerySY(strSql);
            return ds;
        }
        #endregion  ExtensionMethod
    }
}
