using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL
{
	/// <summary>
	/// 数据访问类:Log_Import
	/// </summary>
	public partial class Log_Import
	{
		public Log_Import()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		    return DbHelperSQL.GetMaxID("Id", "Log_Import"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Log_Import");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(RuRo.Model.Log_Import model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Log_Import(");
			strSql.Append("PatientID,Import_Date,Import_State,Import_Date_Msg,Import_User_Id,Import_User_Department,Import_Type,Others)");
			strSql.Append(" values (");
			strSql.Append("@PatientID,@Import_Date,@Import_State,@Import_Date_Msg,@Import_User_Id,@Import_User_Department,@Import_Type,@Others)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PatientID", SqlDbType.NVarChar,50),
					new SqlParameter("@Import_Date", SqlDbType.DateTime),
					new SqlParameter("@Import_State", SqlDbType.Bit,1),
					new SqlParameter("@Import_Date_Msg", SqlDbType.NVarChar,-1),
					new SqlParameter("@Import_User_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Import_User_Department", SqlDbType.NVarChar,50),
					new SqlParameter("@Import_Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Others", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.PatientID;
			parameters[1].Value = model.Import_Date;
			parameters[2].Value = model.Import_State;
			parameters[3].Value = model.Import_Date_Msg;
			parameters[4].Value = model.Import_User_Id;
			parameters[5].Value = model.Import_User_Department;
			parameters[6].Value = model.Import_Type;
			parameters[7].Value = model.Others;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(RuRo.Model.Log_Import model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Log_Import set ");
			strSql.Append("PatientID=@PatientID,");
			strSql.Append("Import_Date=@Import_Date,");
			strSql.Append("Import_State=@Import_State,");
			strSql.Append("Import_Date_Msg=@Import_Date_Msg,");
			strSql.Append("Import_User_Id=@Import_User_Id,");
			strSql.Append("Import_User_Department=@Import_User_Department,");
			strSql.Append("Import_Type=@Import_Type,");
			strSql.Append("Others=@Others");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@PatientID", SqlDbType.NVarChar,50),
					new SqlParameter("@Import_Date", SqlDbType.DateTime),
					new SqlParameter("@Import_State", SqlDbType.Bit,1),
					new SqlParameter("@Import_Date_Msg", SqlDbType.NVarChar,-1),
					new SqlParameter("@Import_User_Id", SqlDbType.NVarChar,50),
					new SqlParameter("@Import_User_Department", SqlDbType.NVarChar,50),
					new SqlParameter("@Import_Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Others", SqlDbType.NVarChar,-1),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.PatientID;
			parameters[1].Value = model.Import_Date;
			parameters[2].Value = model.Import_State;
			parameters[3].Value = model.Import_Date_Msg;
			parameters[4].Value = model.Import_User_Id;
			parameters[5].Value = model.Import_User_Department;
			parameters[6].Value = model.Import_Type;
			parameters[7].Value = model.Others;
			parameters[8].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Log_Import ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Log_Import ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public RuRo.Model.Log_Import GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,PatientID,Import_Date,Import_State,Import_Date_Msg,Import_User_Id,Import_User_Department,Import_Type,Others from Log_Import ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			RuRo.Model.Log_Import model=new RuRo.Model.Log_Import();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public RuRo.Model.Log_Import DataRowToModel(DataRow row)
		{
			RuRo.Model.Log_Import model=new RuRo.Model.Log_Import();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["PatientID"]!=null)
				{
					model.PatientID=row["PatientID"].ToString();
				}
				if(row["Import_Date"]!=null && row["Import_Date"].ToString()!="")
				{
					model.Import_Date=DateTime.Parse(row["Import_Date"].ToString());
				}
				if(row["Import_State"]!=null && row["Import_State"].ToString()!="")
				{
					if((row["Import_State"].ToString()=="1")||(row["Import_State"].ToString().ToLower()=="true"))
					{
						model.Import_State=true;
					}
					else
					{
						model.Import_State=false;
					}
				}
				if(row["Import_Date_Msg"]!=null)
				{
					model.Import_Date_Msg=row["Import_Date_Msg"].ToString();
				}
				if(row["Import_User_Id"]!=null)
				{
					model.Import_User_Id=row["Import_User_Id"].ToString();
				}
				if(row["Import_User_Department"]!=null)
				{
					model.Import_User_Department=row["Import_User_Department"].ToString();
				}
				if(row["Import_Type"]!=null)
				{
					model.Import_Type=row["Import_Type"].ToString();
				}
				if(row["Others"]!=null)
				{
					model.Others=row["Others"].ToString();
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
			strSql.Append("select Id,PatientID,Import_Date,Import_State,Import_Date_Msg,Import_User_Id,Import_User_Department,Import_Type,Others ");
			strSql.Append(" FROM Log_Import ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" Id,PatientID,Import_Date,Import_State,Import_Date_Msg,Import_User_Id,Import_User_Department,Import_Type,Others ");
			strSql.Append(" FROM Log_Import ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Log_Import ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from Log_Import T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
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
			parameters[0].Value = "Log_Import";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

