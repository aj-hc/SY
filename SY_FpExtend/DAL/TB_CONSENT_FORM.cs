using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL
{
    /// <summary>
    /// 数据访问类:TB_CONSENT_FORM
    /// </summary>
    public partial class TB_CONSENT_FORM
    {
        public TB_CONSENT_FORM()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RuRo.Model.TB_CONSENT_FORM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_CONSENT_FORM(");
            strSql.Append("Path,PatientName,PatientID,Consent_From,date)");
            strSql.Append(" values (");
            strSql.Append("@Path,@PatientName,@PatientID,@Consent_From,@date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Path", SqlDbType.NVarChar,200),
					new SqlParameter("@PatientName", SqlDbType.VarChar,50),
					new SqlParameter("@PatientID", SqlDbType.Int,4),
                    new SqlParameter("@Consent_From", SqlDbType.NVarChar,150),
                     new SqlParameter("@date",SqlDbType.DateTime)
                                        };
            parameters[0].Value = model.Path;
            parameters[1].Value = model.PatientName;
            parameters[2].Value = model.PatientID;
            parameters[3].Value = model.Consent_From;
            parameters[4].Value = model.Date;
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
        public bool Update(RuRo.Model.TB_CONSENT_FORM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_CONSENT_FORM set ");
            strSql.Append("Path=@Path,");
            strSql.Append("PatientName=@PatientName,");
            strSql.Append("PatientID=@PatientID");
            strSql.Append("Consent_From=@Consent_From");
            strSql.Append(" where Consent_ID=@Consent_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Path", SqlDbType.NVarChar,200),
					new SqlParameter("@PatientName", SqlDbType.VarChar,50),
					new SqlParameter("@PatientID", SqlDbType.Int,4),
					new SqlParameter("@Consent_ID", SqlDbType.Int,4),
                    new SqlParameter("@Consent_From", SqlDbType.NVarChar,150)
                                        };
            parameters[0].Value = model.Path;
            parameters[1].Value = model.PatientName;
            parameters[2].Value = model.PatientID;
            parameters[3].Value = model.Consent_ID;
            parameters[4].Value = model.Consent_From;
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
        public bool Delete(int Consent_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_CONSENT_FORM ");
            strSql.Append(" where Consent_ID=@Consent_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Consent_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = Consent_ID;

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
        public bool DeleteList(string Consent_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_CONSENT_FORM ");
            strSql.Append(" where Consent_ID in (" + Consent_IDlist + ")  ");
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
        public RuRo.Model.TB_CONSENT_FORM GetModel(int Consent_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Consent_ID,Path,PatientName,PatientID from TB_CONSENT_FORM ");
            strSql.Append(" where Consent_ID=@Consent_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Consent_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = Consent_ID;

            RuRo.Model.TB_CONSENT_FORM model = new RuRo.Model.TB_CONSENT_FORM();
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
        public RuRo.Model.TB_CONSENT_FORM DataRowToModel(DataRow row)
        {
            RuRo.Model.TB_CONSENT_FORM model = new RuRo.Model.TB_CONSENT_FORM();
            if (row != null)
            {
                if (row["Consent_ID"] != null && row["Consent_ID"].ToString() != "")
                {
                    model.Consent_ID = int.Parse(row["Consent_ID"].ToString());
                }
                if (row["Path"] != null)
                {
                    model.Path = row["Path"].ToString();
                }
                if (row["PatientName"] != null)
                {
                    model.PatientName = row["PatientName"].ToString();
                }
                if (row["PatientID"] != null && row["PatientID"].ToString() != "")
                {
                    model.PatientID = int.Parse(row["PatientID"].ToString());
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
            strSql.Append("select Consent_ID,Path,PatientName,PatientID ");
            strSql.Append(" FROM TB_CONSENT_FORM ");
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
            strSql.Append(" Consent_ID,Path,PatientName,PatientID ");
            strSql.Append(" FROM TB_CONSENT_FORM ");
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
            strSql.Append("select count(1) FROM TB_CONSENT_FORM ");
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
                strSql.Append("order by T.Consent_ID desc");
            }
            strSql.Append(")AS Row, T.*  from TB_CONSENT_FORM T ");
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
            parameters[0].Value = "TB_CONSENT_FORM";
            parameters[1].Value = "Consent_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL_SY.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 查询是否存在唯一标识
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet GetTB_CONSENT_FORM(RuRo.Model.TB_CONSENT_FORM model) 
        {
            string strsql = "SELECT * FROM TB_CONSENT_FORM WHERE PatientName='" + model.PatientName + "' AND PatientID=" + model.PatientID;
            return DbHelperSQL_SY.QuerySY(strsql);
        }
        public string Sel_TB_CONSENT_FORM_Count(string uid, string consent_from) 
        {
            string strsql = "SELECT COUNT(*) FROM TB_CONSENT_FORM WHERE PatientID=" + uid + " AND Consent_From='" + consent_from+"'";
            string mes = "";
            DataSet ds=DbHelperSQL_SY.QuerySY(strsql);
            mes=ds.Tables[0].Rows[0]["Column1"].ToString();
            if (mes=="0")
            {
                return "";
            }
            else
            {
                return "数据已存在";
            }
        }
        #endregion  ExtensionMethod
    }
}

