
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
        /// <summary>
        /// Fp访问名称
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        #endregion

        #region 访问Fp的密码属性
        private string passWord = "";
        /// <summary>
        /// Fp访问密码
        /// </summary>
        public string Password
        {
            get { return passWord; }
            set { passWord = value; }
        }
        #endregion

        #region auth_token 属性
        string auth_token;
        public string Auth_token
        {
            get { return auth_token; }
            set { auth_token = value; }
        }
        #endregion

        //连接字符串（包含username、password）
        string uriStr = "";
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="uri">“http://192.168.1.100”</param>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        public DataWithFP()
        {
            List<string> NameAndPasswd = AccountHelper.GetActiveAccountUesrName();
            if (NameAndPasswd != null)
            {
                if (NameAndPasswd.Count > 0)
                {
                    Username = NameAndPasswd[0];
                    passWord = NameAndPasswd[1];
                }
            }
            string url = System.Configuration.ConfigurationManager.AppSettings["FpUrl"];
            uriStr = string.Format("{0}/api?", url);
        }
        //指定账号密码
        public DataWithFP(string username, string password)
        {
            Username = username;
            passWord = password;
            string url = System.Configuration.ConfigurationManager.AppSettings["FpUrl"];
            uriStr = string.Format("{0}/api?", url);
        }
        #endregion
        /// <summary>
        /// 获取fp数据方法
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string getdata(string url)
        {
            HttpItem item = new HttpItem();
            HttpHelper http = new HttpHelper();
            item.URL = url;
            return http.GetHtml(item).Html;
        }
        //提交数据到fp方法
        private string postdata(string url, string data)
        {
            HttpItem item = new HttpItem();
            HttpHelper http = new HttpHelper();
            item.URL = url;
            item.Method = "POSt";
            item.Postdata = data;
            return http.GetHtml(item).Html;
        }

        #region 有参取数据方法 + public string getDateFromFp(FpMethod fpMethod, string parameters)
        /// <summary>
        /// 有参取数据方法
        /// </summary>
        /// <param name="fpMethod">具体方法</param>
        /// <param name="parameters">可选参数如（&id=1）“没有就空字符串”</param>
        /// <returns>查询到的结果字符串</returns>

        [Obsolete("不建议使用方法,建议传入拼装好的url和data方法", false)]
        public string getDateFromFp(FpMethod fpMethod, string parameters)
        {
            string url = string.Format("{0}username={1}&password={2}&method={3}", uriStr, username, passWord, fpMethod);
            return postdata(url, parameters);
        }
        #endregion

        #region post数据到fp + public string postDateToFp(FpMethod fpMethod, string date) 如import_source
        /// <summary>
        /// post数据到fp（update_source）
        /// </summary>
        /// <param name="fpMethod">api方法</param>
        /// <param name="date">数据（要包含参数,不包含账号和密码、passWord）</param>
        /// <returns>返回结果</returns>
        [Obsolete("不建议使用方法，建议传入拼装好的url和data方法，不确定是否会导致Fp瘫痪",false)]
        public string postDateToFp(FpMethod fpMethod, string date)
        {
            WebClient webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;
            string url = string.Format("{0}username={1}&password={2}&method={3}", uriStr, username, passWord, fpMethod);
            string result = webclient.Post(url, date);
            return result;
        }
        /// <summary>
        /// post 数据到Fp
        /// </summary>
        /// <param name="url">提交地址</param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string postDateToFp(string url, string date)
        {
            return postdata(url, date);
        }
        public string getDateFromFp(string url)
        {
            return getdata(url);
        }
        #endregion
    }
}
