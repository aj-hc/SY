using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace RuRo.BLL
{
    public class Log_Show_Model
    {
        //{ field: 'Id', title: 'Id', width: 80, hidden: true },
        //{ field: 'PatientID', title: '唯一标识', width: "10%", align: 'center' },
        //{ field: 'PatientName', title: '姓名', width: "10%", align: 'center' },
        //{ field: 'SexFlag', title: '性别', width: "10%", align: 'center' },
        //{ field: 'Import_Date', title: '日期', width: "15%", align: 'center' },
        //{ field: 'TB_CONSENT_FORM', title: '知情同意', width: '10%', align: 'center' },
        //{ field: 'Others', title: '样本信息', width: '40%', align: 'center' },
        public int Id { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string SexFlag { get; set; }
        public DateTime Import_Date { get; set; }
        public string Others { get; set; }
        public string TB_CONSENT_FORM { get; set; }
        // tb_CONSENT_FORM
    }
    enum Import_Type
    {
        import_Sample,
        import_Sample_Source,
        import_Test_Data
    }
    /// <summary>
    /// 日志展现
    /// </summary>
    public class Log_Show
    {

        /// <summary>
        /// 获取数据根据当前日期
        /// </summary>
        /// <param name="date"></param>
        public DataSet GetDate(string user, string department)
        {
            //默认情况下查询当前日期下的当前用户的数据
            //根据用户获取当前日期的数据
            //判断department是否为空

            return new DataSet();
        }
        public DataSet GetDate(string user, string department, string start_date, string end_date)
        {
            //根据用户传入的日期范围查询数据
            //判断department是否为空
            return new DataSet();
        }
		public	void GetData(){
		
		}
		        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere">默认请指定科室或用户</param>
        /// <param name="stratIndex"></param>
        /// <param name="endIndex"></param>
        private void GetDateByDate(StringBuilder strWhere, int stratIndex, int endIndex)
        {
            Log_Import log_Import = new Log_Import();
            BasedInfo basedInfo = new BasedInfo();
            TB_CONSENT_FORM tb_CONSENT_FORM = new TB_CONSENT_FORM();
			RuRo.Model.ModelForDataGrid model = new RuRo.Model.ModelForDataGrid ();
			int count = log_Import.GetRecordCount (strWhere.ToString());

			model.Total = count.ToString ();
            if (string.IsNullOrEmpty(strWhere.ToString()))
            {
                strWhere = new StringBuilder();
                strWhere.Append(" T.Import_State=1 and T.Import_Type = 'import_Sample' ");
            }
            else
            {
                strWhere.Append(" and T.Import_State=1 and T.Import_Type = 'import_Sample' ");
            }
            DataSet ds_Log_Import = log_Import.GetListByPage(strWhere.ToString(), "", stratIndex, endIndex);
            String strWherePatients = CreatPatientIDWhere(ds_Log_Import);
			if (strWherePatients.ToString ().Length > 0) {
				//查询基本信息
				DataSet ds_BaseInfo = basedInfo.GetList (" PatientID in " + strWherePatients);
				//查询知情同意信息
				DataSet ds_Tb_CONSENT_FORM = tb_CONSENT_FORM.GetList (" PatientID in " + strWherePatients);	
				model.JsonData=CreatResultDataSet (ds_Log_Import, ds_BaseInfo, ds_Tb_CONSENT_FORM);
			} else {
				model.JsonData= ds_Log_Import;
			}
        }

		#region 根据查询出来的数据创建唯一号字符串 + private string CreatPatientIDWhere (DataSet ds_Log_Import)

		/// <summary>
		/// 根据查询出来的数据创建唯一号字符串
		/// </summary>
		/// <returns>The patient identifier where.</returns>
		/// <param name="ds_Log_Import">Ds log import.</param>
		private string CreatPatientIDWhere (DataSet ds_Log_Import)
		{
			StringBuilder strWherePatients = new StringBuilder ();
			if (ds_Log_Import.Tables [0].Rows.Count > 0) {
				foreach (DataRow row in ds_Log_Import.Tables[0].Rows) {
					if (row ["PatientID"].ToString () != null) {
						if (string.IsNullOrEmpty (row ["PatientID"].ToString ().Trim ())) {
							strWherePatients.Append (row ["PatientID"].ToString ().Trim () + ",");
						}
					}
					strWherePatients.ToString ().TrimEnd (',');
				}
			}
			return strWherePatients.ToString ();
		}

		#endregion
		#region 合并查询之后的结果 + private DataSet CreatResultDataSet (DataSet log, DataSet ds_Base, DataSet ds_Tb)
		/// <summary>
		/// 合并查询之后的结果
		/// </summary>
		/// <returns>合并之后的结果</returns>
		/// <param name="log">记录表数据</param>
		/// <param name="ds_Base">基本信息表数据</param>
		/// <param name="ds_Tb">知情同意表数据</param>
		private DataSet CreatResultDataSet (DataSet log, DataSet ds_Base, DataSet ds_Tb)
		{
			DataSet ds = new DataSet ();
			//添加列
			if (log != null) {
				ds = ChangeDataSetColum (log);
				if (ds != null && ds.Tables.Count > 0) {
					foreach (DataRow row in ds.Tables[0].Rows) {
						//赋值
						foreach (DataRow ds_Base_row in ds_Base.Tables[0].Rows)
						{
							if (ds_Base_row ["PatientID"]== row ["PatientID"])
							{
								row ["PatientName"]= ds_Base_row ["PatientName"];
								row ["SexFlag"] = ds_Base_row ["SexFlag"];
							}
						}
						foreach (DataRow ds_Tb_row in ds_Tb.Tables[0].Rows)
						{
							if (ds_Tb_row ["PatientID"] == row ["PatientID"]){
								row ["TB_CONSENT_FORM"] = "有";
							}
						else {
								row ["TB_CONSENT_FORM"] = "";
							}
						}
					}
				}
			}
			return ds;
		}
		#endregion
		#region 给查询出的日志表添加列 + private DataSet ChangeDataSetColum (DataSet ds)

		/// <summary>
		/// 给查询出的日志表添加列
		/// </summary>
		/// <returns>添加列之后的数据集</returns>
		/// <param name="ds">查询出的数据集</param>
		private DataSet ChangeDataSetColum (DataSet ds)
		{
			//添加列
			DataColumn PatientName = new DataColumn ("PatientName", typeof(string));
			DataColumn SexFlag = new DataColumn ("SexFlag", typeof(string));
			DataColumn TB_CONSENT_FORM = new DataColumn ("TB_CONSENT_FORM", typeof(string));
			if (!ds.Tables [0].Columns.Contains ("PatientName")) {
				ds.Tables [0].Columns.Add (PatientName);
			}
			if (!ds.Tables [0].Columns.Contains ("SexFlag")) {
				ds.Tables [0].Columns.Add (SexFlag);
			}
			if (!ds.Tables [0].Columns.Contains ("TB_CONSENT_FORM")) {
				ds.Tables [0].Columns.Add (TB_CONSENT_FORM);
			}
			return ds;
		}

		#endregion
    }
}
