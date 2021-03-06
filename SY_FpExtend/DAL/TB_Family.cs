﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL
{
    /// <summary>
    /// 数据访问类:TB_Family
    /// </summary>
    public partial class TB_Family
    {
        public TB_Family()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TB_Family");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL_SY.ExistsSY(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RuRo.Model.TB_Family model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TB_Family(");
            strSql.Append("PatientID,PatientName,SexFlag,Birthday,PFamilyID,PFamilyName,FamilyNeuxs)");
            strSql.Append(" values (");
            strSql.Append("@PatientID,@PatientName,@SexFlag,@Birthday,@PFamilyID,@PFamilyName,@FamilyNeuxs)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PatientID", SqlDbType.Int,4),
					new SqlParameter("@PatientName", SqlDbType.VarChar,50),
					new SqlParameter("@SexFlag", SqlDbType.VarChar,50),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@PFamilyID", SqlDbType.Int,4),
					new SqlParameter("@PFamilyName", SqlDbType.VarChar,50),
					new SqlParameter("@FamilyNeuxs", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PatientID;
            parameters[1].Value = model.PatientName;
            parameters[2].Value = model.SexFlag;
            parameters[3].Value = model.Birthday;
            parameters[4].Value = model.PFamilyID;
            parameters[5].Value = model.PFamilyName;
            parameters[6].Value = model.FamilyNeuxs;

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
        public bool Update(RuRo.Model.TB_Family model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TB_Family set ");
            strSql.Append("PatientID=@PatientID,");
            strSql.Append("PatientName=@PatientName,");
            strSql.Append("SexFlag=@SexFlag,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("PFamilyID=@PFamilyID,");
            strSql.Append("PFamilyName=@PFamilyName,");
            strSql.Append("FamilyNeuxs=@FamilyNeuxs");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@PatientID", SqlDbType.Int,4),
					new SqlParameter("@PatientName", SqlDbType.VarChar,50),
					new SqlParameter("@SexFlag", SqlDbType.VarChar,50),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@PFamilyID", SqlDbType.Int,4),
					new SqlParameter("@PFamilyName", SqlDbType.VarChar,50),
					new SqlParameter("@FamilyNeuxs", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.PatientID;
            parameters[1].Value = model.PatientName;
            parameters[2].Value = model.SexFlag;
            parameters[3].Value = model.Birthday;
            parameters[4].Value = model.PFamilyID;
            parameters[5].Value = model.PFamilyName;
            parameters[6].Value = model.FamilyNeuxs;
            parameters[7].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_Family ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TB_Family ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public RuRo.Model.TB_Family GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,PatientID,PatientName,SexFlag,Birthday,PFamilyID,PFamilyName,FamilyNeuxs from TB_Family ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            RuRo.Model.TB_Family model = new RuRo.Model.TB_Family();
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
        public RuRo.Model.TB_Family DataRowToModel(DataRow row)
        {
            RuRo.Model.TB_Family model = new RuRo.Model.TB_Family();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["PatientID"] != null && row["PatientID"].ToString() != "")
                {
                    model.PatientID = int.Parse(row["PatientID"].ToString());
                }
                if (row["PatientName"] != null)
                {
                    model.PatientName = row["PatientName"].ToString();
                }
                if (row["SexFlag"] != null)
                {
                    model.SexFlag = row["SexFlag"].ToString();
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["PFamilyID"] != null && row["PFamilyID"].ToString() != "")
                {
                    model.PFamilyID = int.Parse(row["PFamilyID"].ToString());
                }
                if (row["PFamilyName"] != null)
                {
                    model.PFamilyName = row["PFamilyName"].ToString();
                }
                if (row["FamilyNeuxs"] != null)
                {
                    model.FamilyNeuxs = row["FamilyNeuxs"].ToString();
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
            strSql.Append("select ID,PatientID,PatientName,SexFlag,Birthday,PFamilyID,PFamilyName,FamilyNeuxs ");
            strSql.Append(" FROM TB_Family ");
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
            strSql.Append(" ID,PatientID,PatientName,SexFlag,Birthday,PFamilyID,PFamilyName,FamilyNeuxs ");
            strSql.Append(" FROM TB_Family ");
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
            strSql.Append("select count(1) FROM TB_Family ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from TB_Family T ");
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
            parameters[0].Value = "TB_Family";
            parameters[1].Value = "ID";
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

