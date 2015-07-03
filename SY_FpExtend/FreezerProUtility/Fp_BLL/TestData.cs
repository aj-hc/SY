using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class TestData
    {
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
