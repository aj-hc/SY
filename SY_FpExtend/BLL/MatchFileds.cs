using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuRo.BLL
{
    public class MatchFileds
    {
        public static Dictionary<string, string> BaseInfoMatchDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Name", "Name");
            dic.Add("Description", "Description");
            dic.Add("PatientName", "姓名");
            dic.Add("IPSeqNoText", "住院号");
            dic.Add("PatientCardNo", "就诊卡号");
            dic.Add("SexFlag", "性别");
            dic.Add("BirthDay", "出生日期");
            dic.Add("BloodTypeFlag", "血型");
            dic.Add("ContactPerson", "联系人");
            dic.Add("ContactPhone", "联系人电话");
            dic.Add("Phone", "联系电话");
            dic.Add("NativePlace", "籍贯");
            dic.Add("RegisterSeqNO", "门诊流水号");
            dic.Add("PatientID", "患者ID");
            dic.Add("InPatientID", "住院ID");
            dic.Add("RegisterID", "门诊ID");
            return dic;
        }
        public static Dictionary<string, string> SampleFiledsMatchDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Name", "Name");
            dic.Add("Volume", "Volume");
            dic.Add("Description", "Description");
            dic.Add("Sample Source", "Sample Source");
            dic.Add("_109", "取材医护");
            dic.Add("_105", "取材名称");
            dic.Add("_110", "取材描述");
            dic.Add("_101", "取材方式");
            dic.Add("_103", "取材日期");
            dic.Add("_113", "取材时段");
            dic.Add("_104", "取材时间");
            dic.Add("_108", "取材部位");
            dic.Add("_106", "处理时间");
            dic.Add("_112", "备注");
            dic.Add("_97", "疾病名称");
            dic.Add("_102", "研究方案");
            dic.Add("_107", "过期日期");
            dic.Add("_99", "采集人");
            dic.Add("_100", "采集目的");
            dic.Add("_117", "脏器");

            return dic;
        }
        public static Dictionary<string, string> ClinicalFiledsMatchDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Sample Source", "Sample Source");
            dic.Add("DiagnoseTypeFlag", "诊断类型");
            dic.Add("DiagnoseDateTime", "诊断日期");
            dic.Add("ICDCode", "ICD码");
            dic.Add("DiseaseName", "疾病名称");
            dic.Add("Description", "疾病描述");
            dic.Add("InPatientID", "住院ID");
            dic.Add("RegisterID", "挂号ID");
            return dic;
        }
    }
}
