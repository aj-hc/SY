using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL
{
	/// <summary>
	/// 数据访问类:ClinicalInfo
	/// </summary>
	public partial class ClinicalInfo
	{
		public ClinicalInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL_SY.GetMaxIDSY("id", "ClinicalInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ClinicalInfo");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL_SY.ExistsSY(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(RuRo.Model.ClinicalInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ClinicalInfo(");
			strSql.Append("DiagnoseTypeFlag,DiagnoseDateTime,RegisterID,InPatientID,ICDCode,DiseaseName,Description)");
			strSql.Append(" values (");
			strSql.Append("@DiagnoseTypeFlag,@DiagnoseDateTime,@RegisterID,@InPatientID,@ICDCode,@DiseaseName,@Description)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DiagnoseTypeFlag", SqlDbType.NVarChar,20),
					new SqlParameter("@DiagnoseDateTime", SqlDbType.DateTime),
					new SqlParameter("@RegisterID", SqlDbType.Int,4),
					new SqlParameter("@InPatientID", SqlDbType.Int,4),
					new SqlParameter("@ICDCode", SqlDbType.NVarChar,30),
					new SqlParameter("@DiseaseName", SqlDbType.NVarChar,100),
					new SqlParameter("@Description", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.DiagnoseTypeFlag;
			parameters[1].Value = model.DiagnoseDateTime;
			parameters[2].Value = model.RegisterID;
			parameters[3].Value = model.InPatientID;
			parameters[4].Value = model.ICDCode;
			parameters[5].Value = model.DiseaseName;
			parameters[6].Value = model.Description;

			object obj = DbHelperSQL_SY.GetSingleSY(strSql.ToString(),parameters);
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
		public bool Update(RuRo.Model.ClinicalInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ClinicalInfo set ");
			strSql.Append("DiagnoseTypeFlag=@DiagnoseTypeFlag,");
			strSql.Append("DiagnoseDateTime=@DiagnoseDateTime,");
			strSql.Append("RegisterID=@RegisterID,");
			strSql.Append("InPatientID=@InPatientID,");
			strSql.Append("ICDCode=@ICDCode,");
			strSql.Append("DiseaseName=@DiseaseName,");
			strSql.Append("Description=@Description");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@DiagnoseTypeFlag", SqlDbType.NVarChar,20),
					new SqlParameter("@DiagnoseDateTime", SqlDbType.DateTime),
					new SqlParameter("@RegisterID", SqlDbType.Int,4),
					new SqlParameter("@InPatientID", SqlDbType.Int,4),
					new SqlParameter("@ICDCode", SqlDbType.NVarChar,30),
					new SqlParameter("@DiseaseName", SqlDbType.NVarChar,100),
					new SqlParameter("@Description", SqlDbType.NVarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.DiagnoseTypeFlag;
			parameters[1].Value = model.DiagnoseDateTime;
			parameters[2].Value = model.RegisterID;
			parameters[3].Value = model.InPatientID;
			parameters[4].Value = model.ICDCode;
			parameters[5].Value = model.DiseaseName;
			parameters[6].Value = model.Description;
			parameters[7].Value = model.id;

			int rows=DbHelperSQL_SY.ExecuteSqlSY(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ClinicalInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL_SY.ExecuteSqlSY(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ClinicalInfo ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL_SY.ExecuteSqlSY(strSql.ToString());
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
		public RuRo.Model.ClinicalInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,DiagnoseTypeFlag,DiagnoseDateTime,RegisterID,InPatientID,ICDCode,DiseaseName,Description from ClinicalInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			RuRo.Model.ClinicalInfo model=new RuRo.Model.ClinicalInfo();
			DataSet ds=DbHelperSQL_SY.QuerySY(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public RuRo.Model.ClinicalInfo DataRowToModel(DataRow row)
		{
			RuRo.Model.ClinicalInfo model=new RuRo.Model.ClinicalInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["DiagnoseTypeFlag"]!=null)
				{
					model.DiagnoseTypeFlag=row["DiagnoseTypeFlag"].ToString();
				}
				if(row["DiagnoseDateTime"]!=null && row["DiagnoseDateTime"].ToString()!="")
				{
					model.DiagnoseDateTime=DateTime.Parse(row["DiagnoseDateTime"].ToString());
				}
				if(row["RegisterID"]!=null && row["RegisterID"].ToString()!="")
				{
					model.RegisterID=int.Parse(row["RegisterID"].ToString());
				}
				if(row["InPatientID"]!=null && row["InPatientID"].ToString()!="")
				{
					model.InPatientID=int.Parse(row["InPatientID"].ToString());
				}
				if(row["ICDCode"]!=null)
				{
					model.ICDCode=row["ICDCode"].ToString();
				}
				if(row["DiseaseName"]!=null)
				{
					model.DiseaseName=row["DiseaseName"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,DiagnoseTypeFlag,DiagnoseDateTime,RegisterID,InPatientID,ICDCode,DiseaseName,Description ");
			strSql.Append(" FROM ClinicalInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL_SY.QuerySY(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,DiagnoseTypeFlag,DiagnoseDateTime,RegisterID,InPatientID,ICDCode,DiseaseName,Description ");
			strSql.Append(" FROM ClinicalInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL_SY.QuerySY(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ClinicalInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from ClinicalInfo T ");
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
			parameters[0].Value = "ClinicalInfo";
			parameters[1].Value = "id";
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

