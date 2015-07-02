using FreezerProUtility.Fp_Common;
using FreezerProUtility.Fp_DAL;
using FreezerProUtility.Fp_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class SampleSocrce
    {
        string username, password;
        //创建数据层对象
        DataWithFP dataWithFP = new DataWithFP();

        #region 获取Sample_Source_Types对象集合 + public List<SampleSourceTypes> Sample_Source_Types()
        /// <summary>
        /// 获取Sample_Source_Types对象集合
        /// </summary>
        /// <returns> 获取Sample_Source_Types对象集合</returns>
        public List<SampleSourceTypes> Sample_Source_Types()
        {
            List<SampleSourceTypes> list_Sample_Source_Types = new List<SampleSourceTypes>() { };
            string str_Json = dataWithFP.getDateFromFp(FpMethod.sample_source_types, "");
            if (ValidationData.checkTotal(str_Json))
            {
                list_Sample_Source_Types = FpJsonHelper.JObjectToList<SampleSourceTypes>("SampleSourceTypes", str_Json);
            }
            return list_Sample_Source_Types;
        }
        #endregion

        #region 获取指定名称的samplesource 对象 +public SampleSourceTypes GetSampleSourceTypeByTypeName(string typeName)
        /// <summary>
        /// 指定样本源类型名称获取样本源
        /// </summary>
        /// <param name="typeName">样本源类型名称</param>
        /// <returns>样本源类型</returns>
        public SampleSourceTypes GetSampleSourceTypeByTypeName(string typeName)
        {
            SampleSourceTypes sampleSourceType = new SampleSourceTypes();
            if (Sample_Source_Types().Count > 0)
            {
                foreach (SampleSourceTypes item in Sample_Source_Types())
                {
                    if (item.name == typeName)
                    {
                        sampleSourceType = item;
                        break;
                    }
                }
            }
            return sampleSourceType;
        } 
        #endregion

        #region 获取样本源类型及描述字典 +  public Dictionary<string, string> GetSampleSourceTypeNameAndDecToDic()
        /// <summary>
        /// 获取样本源类型及描述字典 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetSampleSourceTypeNameAndDecToDic()
        {
            Dictionary<string, string> SampleSourceTypeNameAndDecDic = new Dictionary<string, string>();
            if (Sample_Source_Types().Count > 0)
            {
                foreach (SampleSourceTypes item in Sample_Source_Types())
                {
                    SampleSourceTypeNameAndDecDic.Add(item.name, item.descr);
                }
            }
            return SampleSourceTypeNameAndDecDic;
        }
        #endregion

        #region 获取样本源类型中的字段 + public List<string> GetSampleSourceTypeFieldByTypeName(string typeName)


        /// <summary>
        /// 使用样本源类型名称获取样本源类型中的字段集合list<string>
        /// </summary>
        /// <param name="typeName">指定样本元类型名称</param>
        /// <returns>字段集合</returns>
        public List<string> GetSampleSourceTypeFieldByTypeName(string typeName)
        {
            List<string> sampleSourceTypeField = new List<string>();
            if (GetSampleSourceTypeByTypeName(typeName) != null)
            {
                string fieldsStr = GetSampleSourceTypeByTypeName(typeName).fields;
                if (fieldsStr != null)
                {
                    string[] fields = ((fieldsStr.Replace("<br>", "$")).Replace("</br>", "$")).Split('$');
                    foreach (string item in fields)
                    {
                        if (!String.IsNullOrEmpty(item))
                        {
                            sampleSourceTypeField.Add(item);
                        }
                    }
                }

            }
            return sampleSourceTypeField;
        }

        #endregion

        #region 导入样本源 + public string ImportSampleSourceDataToFp(string sampleSourceTypeName, string sampleSourceFieldsJsonStr)
        /// <summary>
        /// 导入样本源
        /// </summary>
        /// <param name="sampleSourceTypeName">样品源类型名称</param>
        /// <param name="sampleSourceFieldsJsonStr">样品源字段json字符串</param>
        /// <returns></returns>
        public string ImportSampleSourceDataToFp(string sampleSourceTypeName, string sampleSourceFieldsJsonStr)
        {
            //01.将字典转换成json格式的字符串
            //02.将此字符串转换成Fp需要的格式
            //03.调用数据层方法提交数据到Fp，并接受返回值
            string result = dataWithFP.postDateToFp(FpMethod.import_sources, "&sample_source_type=" + sampleSourceTypeName + "&json=" + sampleSourceFieldsJsonStr);
            return result;
        } 
        #endregion

        #region 根据id获取样品源信息 +public Sample_Source Get_Sample_Source_Info(int sample_source_id)
        /// <summary>
        /// 根据id获取样品源信息
        /// </summary>
        /// <param name="sample_source_id">样品源id</param>
        /// <returns>返回 Sample_Source 对象</returns>
        public Sample_Source Get_Sample_Source_Info(int sample_source_id)
        {
            Sample_Source samplesource = new Sample_Source();
            string jsonStr = dataWithFP.postDateToFp(FpMethod.sample_source_info, string.Format("&id={0}", sample_source_id));
            samplesource = FpJsonHelper.JsonStrToObject<Sample_Source>(jsonStr);
            return samplesource;
        } 
        #endregion

    }
}
