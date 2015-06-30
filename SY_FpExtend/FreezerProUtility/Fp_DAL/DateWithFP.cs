
using FreezerProUtility.Fp_BLL;
using FreezerProUtility.Fp_Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreezerProUtility.Fp_DAL
{
    /// <summary>
    /// 和Fp交换数据
    /// </summary>
    internal class DataWithFP
    {
        #region 访问Fp的用户名属性
        private string username = "";
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        #endregion

        #region 访问Fp的密码属性
        private string passWord = "";
        public string Password
        {
            get { return passWord; }
            set { passWord = value; }
        }
        #endregion

        //连接字符串（包含username、password）
        string uriStr = string.Empty;

        #region  获取fp数据方法 + public static string getDateFromFp(string url)
        /// <summary>
        /// 获取fp数据方法
        /// </summary>
        /// <param name="url">获取数据人url</param>
        /// <returns></returns>
        public static string getDateFromFp(string url)
        {
            HttpItem item = new HttpItem();
            HttpHelper http = new HttpHelper();
            item.URL = url;
            return http.GetHtml(item).Html;
        } 
        #endregion

        #region 提交数据到fp方法 + private static string postDateToFp(string url, string data)
        /// <summary>
        /// 提交数据到fp方法
        /// </summary>
        /// <param name="url">获取数据url</param>
        /// <param name="data">需要提交的数据</param>
        /// <returns></returns>
        public static string postDateToFp(string url, string data)
        {
            HttpItem item = new HttpItem();
            HttpHelper http = new HttpHelper();
            HttpResult hres = new HttpResult();
            item.URL = url;
            item.Method = "POST";
            item.Postdata = data;
            hres = http.GetHtml(item);
            return hres.Html;
        } 
        #endregion
        
        #region 有参取数据方法 + public string getDateFromFp(FpMethod fpMethod, string parameters)
        /// <summary>
        /// 有参取数据方法
        /// </summary>
        /// <param name="fpMethod">具体方法</param>
        /// <param name="parameters">可选参数如（&id=1）“没有就空字符串”</param>
        /// <returns>查询到的结果字符串</returns>
        [Fp_Common.Help("过时方法，请调用新的静态方法：getDateFromFp(FpMethod fpMethod, string parameters)")]
        public string getDateFromFp(FpMethod fpMethod, string parameters)
        {
            WebClient web = new WebClient();
            web.Encoding = Encoding.UTF8;
            string url = string.Format("{0}username={1}&password={2}&method={3}", uriStr, username, passWord, fpMethod);
            return web.Post(url, parameters);
        }
        #endregion

        #region post数据到fp + public string postDateToFp(FpMethod fpMethod, string date) 如import_source
        /// <summary>
        /// post数据到fp（update_source）
        /// </summary>
        /// <param name="fpMethod">api方法</param>
        /// <param name="date">数据（要包含参数,不包含账号和密码、passWord）</param>
        /// <returns>返回结果</returns>
        [Fp_Common.Help("过时方法，请调用新的静态方法：postDateToFp(FpMethod fpMethod, string date)")]
        public string postDateToFp(FpMethod fpMethod, string date)
        {
            WebClient webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;
            string url = string.Format("{0}username={1}&password={2}&method={3}", uriStr, username, passWord, fpMethod);
            string result = webclient.Post(url, date);
            return result;
        }
        #endregion

        #region 泛型方法处理从Fp中获取到的数据 +  private List<T> getdata<T>(string url, FpMethod fpMethod, string param, string datawith)
        /// <summary>
        /// 泛型方法处理从Fp中获取到的数据
        /// </summary>
        /// <typeparam name="T">返回集合参数的类型</typeparam>
        /// <param name="fpMethod">调用的api方法</param>
        /// <param name="param">调用方法的参数</param>
        /// <param name="datawith">从fp返回值中取什么数据</param>
        /// <returns>返回集合</returns>
        internal static List<T> getdata<T>(string url, FpMethod fpMethod, string param, string datawith)
        {
            List<T> list = new List<T>();
            bool check;
            string connUrl = Fp_Common.UrlHelper.ConnectionUrlAndPar(url, fpMethod, param, out check);
            if (check)
            {
                string str_Json = Fp_DAL.DataWithFP.getDateFromFp(connUrl);
                if (ValidationData.checkTotal(str_Json))
                {
                    list = FpJsonHelper.JObjectToList<T>(datawith, str_Json);
                }
            }
            return list;
        }

        #endregion

        #region 从fP中获取数据的泛型方法
        /// <summary>
        /// 从fP中获取数据的泛型方法
        /// </summary>
        /// <typeparam name="T">返回的对象</typeparam>
        /// <param name="url">链接fp的url</param>
        /// <param name="fpMethod">获取数据的方法</param>
        /// <param name="param">获取数据的参数</param>
        /// <returns></returns>
        internal static T getdata<T>(string url, FpMethod fpMethod, string param) where T : class,new()
        {
            T t = new T();
            bool check;
            string connUrl = Fp_Common.UrlHelper.ConnectionUrlAndPar(url, fpMethod, param, out check);
            if (check)
            {
                string str_Json = Fp_DAL.DataWithFP.getDateFromFp(connUrl);
                if (ValidationData.checkTotal(str_Json))
                {
                    t = FpJsonHelper.JsonStrToObject<T>(str_Json);
                }
            }
            return t;
        }
        #endregion
    }
}
