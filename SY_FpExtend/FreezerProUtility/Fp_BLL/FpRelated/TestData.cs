using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class TestData
    {
        /// <summary>
        /// 导入临床数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="test_data_type"></param>
        /// <param name="dataDic">需指定Sample Source</param>
        /// <returns></returns>
        public static string ImportTestData(string url, string test_data_type, Dictionary<string, string> dataDic)
        {
            string result = string.Empty;
            string jsonDic = Fp_Common.FpJsonHelper.DictionaryToJsonString(dataDic); ;
            if (!string.IsNullOrEmpty(jsonDic))
            {
                string jsonData = string.Format("&test_data_type={0}&json={1}", test_data_type, jsonDic);
                result = ImportTestDataToFp(url, jsonData);

            }
            return "";
        }
        /// <summary>
        /// 导入多条临床数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="test_data_type"></param>
        /// <param name="dataDicList">需指定Sample Source</param>
        /// <returns></returns>
        public static string ImportTestData(string url, string test_data_type, List<Dictionary<string, string>> dataDicList)
        {
            string result = string.Empty;
            string jsonDicList = Fp_Common.FpJsonHelper.DictionaryListToJsonString(dataDicList);
            if (!string.IsNullOrEmpty(jsonDicList))
            {
                string jsonData = string.Format("&test_data_type={0}&json={1}", test_data_type, jsonDicList);
                result = ImportTestDataToFp(url, jsonData);
            }
            return "";
        }

        private static string ImportTestDataToFp(string url, string jsonData)
        {
            bool check;
            string result = string.Empty;
            string connFpUrl = Fp_Common.UrlHelper.ConnectionUrlAndPar(url, Fp_Common.FpMethod.import_tests, "", out check);
            if (check)
            {   
                //转换成功
                result = Fp_DAL.DataWithFP.postDateToFp(connFpUrl, jsonData);
            }
            return result;
        }
        private static string CheckRes(string jsonResStr)
        {

            return "";
        }
    }
}
