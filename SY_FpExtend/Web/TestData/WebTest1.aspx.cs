using RuRo.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web.TestData
{
    public partial class WebTest1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Common.HttpHelper http = new Common.HttpHelper();
            //Common.HttpItem item = new Common.HttpItem();
            //Common.HttpResult result = new Common.HttpResult();
            //    item.URL = "http://192.168.183.137/api";//URL     必需项    
            //    item.Method = "post";//URL     可选项 默认为Get   
            //    item.IsToLower = false;//得到的HTML代码是否转成小写     可选项默认转小写   
            //   item.Cookie = "";//字符串Cookie     可选项   
            //   item.Referer ="";//来源URL     可选项   
            //   item. Postdata = "username=XYS&password=123456&method=import_samples&sample_type=正常组织--心研所&create_storage=Tem,XYS,7月,12日&box_type=100&json=[{\"Name\":\"1000456613\",\"取材日期\":\"2015.07.12\",\"取材时间\":\"01:37\",\"Volume\":\"100\",\"Sample Source\":\"1000456613\",\"ALIQUOT\":\"85\",\"Freezer\":\"Tem\",\"Level1\":\"XYS\",\"Level2\":\"7月\",\"Level3\":\"12\",\"Box\":\"3\",\"Position\":\"2\"},{\"Name\":\"1000456613\",\"取材日期\":\"2015.07.12\",\"取材时间\":\"01:37\",\"Volume\":\"100\",\"Sample Source\":\"1000456613\",\"ALIQUOT\":\"85\",\"Freezer\":\"Tem\",\"Level1\":\"XYS\",\"Level2\":\"7月\",\"Level3\":\"12\",\"Box\":\"3\",\"Position\":\"3\"},{\"Name\":\"1000456613\",\"取材日期\":\"2015.07.12\",\"取材时间\":\"01:37\",\"Volume\":\"100\",\"Sample Source\":\"1000456613\",\"ALIQUOT\":\"85\",\"Freezer\":\"Tem\",\"Level1\":\"XYS\",\"Level2\":\"7月\",\"Level3\":\"12\",\"Box\":\"3\",\"Position\":\"4\"}{\"Name\":\"1000456613\",\"取材日期\":\"2015.07.12\",\"取材时间\":\"01:37\",\"Volume\":\"100\",\"Sample Source\":\"1000456613\",\"ALIQUOT\":\"85\",\"Freezer\":\"Tem\",\"Level1\":\"XYS\",\"Level2\":\"7月\",\"Level3\":\"12\",\"Box\":\"3\",\"Position\":\"5\"}]";//Post数据     可选项GET时不需要写   
            //     item.Timeout = 100000;//连接超时时间     可选项默认为100000    
            //     item.ReadWriteTimeout = 30000;//写入Post数据超时时间     可选项默认为30000   
            //    item. UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";//用户的浏览器类型，版本，操作系统     可选项有默认值   
            //   item.  ContentType = "text/html";//返回类型    可选项有默认值   
            //    item. Allowautoredirect = false;//是否根据301跳转     可选项   
            //    //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数   
            //    //Connectionlimit = 1024,//最大连接数     可选项 默认为1024    
            //    item. ProxyIp = "";//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数    
            //    //ProxyPwd = "123456",//代理服务器密码     可选项    
            //    //ProxyUserName = "administrator",//代理服务器账户名     可选项   
            //    item. ResultType = RuRo.Common.ResultType.String;
            //string html = result.Html;
            //string cookie = result.Cookie;

            //Response.Write(html);
            //Response.Write("<br/>");
            //Response.Write(cookie);

            //string url = "http://192.168.183.137/api?username=XYS&password=123456&method=import_samples";
            //string method= "post";
            //string requestContentType = "string";
            //string userAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            //Dictionary<string,string> head =new Dictionary<string,string>(); 
            //string data= "sample_type=正常组织--心研所&create_storage=Tem,XYS,7月,12日&box_type=100&json=[{\"Name\":\"1000456613\",\"取材日期\":\"2015.07.12\",\"取材时间\":\"01:37\",\"Volume\":\"100\",\"Sample Source\":\"1000456613\",\"ALIQUOT\":\"85\",\"Freezer\":\"Tem\",\"Level1\":\"XYS\",\"Level2\":\"7月\",\"Level3\":\"12\",\"Box\":\"3\",\"Position\":\"2\"},{\"Name\":\"1000456613\",\"取材日期\":\"2015.07.12\",\"取材时间\":\"01:37\",\"Volume\":\"100\",\"Sample Source\":\"1000456613\",\"ALIQUOT\":\"85\",\"Freezer\":\"Tem\",\"Level1\":\"XYS\",\"Level2\":\"7月\",\"Level3\":\"12\",\"Box\":\"3\",\"Position\":\"3\"},{\"Name\":\"1000456613\",\"取材日期\":\"2015.07.12\",\"取材时间\":\"01:37\",\"Volume\":\"100\",\"Sample Source\":\"1000456613\",\"ALIQUOT\":\"85\",\"Freezer\":\"Tem\",\"Level1\":\"XYS\",\"Level2\":\"7月\",\"Level3\":\"12\",\"Box\":\"3\",\"Position\":\"4\"}{\"Name\":\"1000456613\",\"取材日期\":\"2015.07.12\",\"取材时间\":\"01:37\",\"Volume\":\"100\",\"Sample Source\":\"1000456613\",\"ALIQUOT\":\"85\",\"Freezer\":\"Tem\",\"Level1\":\"XYS\",\"Level2\":\"7月\",\"Level3\":\"12\",\"Box\":\"3\",\"Position\":\"5\"}]";
            //Encoding requestEnc =Encoding.UTF8;

            //string ss = GetResponseText( url,  method,  requestContentType,  userAgent,head,  data, requestEnc);

            //Response.Write(ss);

            // item.URL = "http://192.168.183.130/api?username=admin&password=123456&method=get_perfect_box";

            //http://192.168.183.130/api?username=admin&password=123456&method=get_perfect_box&space=1&container_id=2



            #region ok
            //http://192.168.183.130/api?username=admin&password=123456&method=get_perfect_box&space=1&freezer_name=tem->admin->06
            //{"success":true,"box_id":1347,"location":"tem->admin->06->02"} 
            #endregion

            //item.PostEncoding = Encoding.UTF8;
            ////item.Method = "GET";
            //item.Method = "POST";
            //item.Postdata = "freezer_name=001号冰箱&container_id=1&space=1";


            //if (!IsPostBack)
            //{
            //    res = http.GetHtml(item);
            //    Response.Write("html：" + res.Html + "<br/><br/>" + "Header：" + res.Header);
            //}

            //string url = "http://192.168.183.130/api?username=admin&password=123456";
            //Dictionary<string, string> dic = FreezerProUtility.Fp_BLL.Samples.GetAllSample_TypesNames(url);
            //List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            //if (dic.Count>0)
            //{
            //    foreach (KeyValuePair<string,string> dd in dic)
            //    {
            //        Dictionary<string, string> temdic = new Dictionary<string, string>();
            //        temdic.Add("value", dd.Key);
            //        temdic.Add("text", dd.Value);
            //        list.Add(temdic);

            //    }
            //}
            //string jsonList = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            //string jsonDic = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryToJsonString(dic);
            //Response.Write(jsonDic);
            //Response.Write("<br />");
            //Response.Write(jsonList);

            //BLL.BasedInfo bas = new BLL.BasedInfo();
            //try
            //{
            //    bas.Delete(1);
            //}
            //catch (Exception ex)
            //{
            //    Common.LogHelper.WriteError(ex);
            //}
            //Response.Write("ok");
            
          TestImportSamples();

            // Response.Write(DateTime.Now + "<br/>" + DateTime.Now.Month + "<br/>" + DateTime.Now.Date.ToString("dd"));
        }
        public static HttpWebResponse GetResponseStream(string url, string method, string requestContentType, string userAgent, Dictionary<string, string> head, string data, Encoding requestEnc)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.ContentType = requestContentType;
            request.Timeout = 10000;//10秒
            request.UserAgent = userAgent;
            if (head != null && head.Count > 0)
            {
                foreach (var item in head)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }
            if (string.IsNullOrEmpty(data) == false)
            {
                byte[] dataByte = requestEnc.GetBytes(data);
                request.ContentLength = dataByte.Length;
                Stream writer = request.GetRequestStream();
                writer.Write(dataByte, 0, dataByte.Length);
                writer.Close();
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return response;
            }
            catch (WebException)
            {
                return null;
                // throw new Exception(string.Format("message:{0};status:{1};url:{2};data:{3}", ex.Message, ex.Status, url, data));
            }
        }

        public static string GetResponseText(string url, string method, string requestContentType, string userAgent, Dictionary<string, string> head, string data, Encoding requestEnc)
        {
            HttpWebResponse response = GetResponseStream(url, method, requestContentType, userAgent, head, data, requestEnc);
            if (response != null)
            {
                Encoding responseEnc = Encoding.UTF8;
                if (!string.IsNullOrEmpty(response.CharacterSet))
                {
                    responseEnc = Encoding.GetEncoding(response.CharacterSet);
                }
                StreamReader sr = new StreamReader(response.GetResponseStream(), responseEnc);
                return sr.ReadToEnd();
            }
            return "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string u = url.Text.Trim();
            string d = data.Text.Trim();
            string m = met.SelectedValue;
            string r = "";
            string requestContentType = "application/x-www-form-urlencoded";
            string userAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";

            Dictionary<string, string> head = new Dictionary<string, string>();
            Encoding requestEnc = Encoding.UTF8;
            Common.WebClient web = new Common.WebClient();
            web.Encoding = Encoding.UTF8;
            web.Proxy = null;

            // 

            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem();
            HttpResult hres = new HttpResult();
            item.ContentType = "application/x-www-form-urlencoded";
            item.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            item.URL = u;
            item.Method = m;
            item.Postdata = d;
            item.PostDataType = PostDataType.String;
            item.PostEncoding = Encoding.UTF8;
            item.KeepAlive = false;
            item.ProxyIp = "";


            if (m == "post")
            {
                // r = GetResponseText(u, m, requestContentType, userAgent, head, d, requestEnc);
                r = http.GetHtml(item).Html;
            }
            if (m == "get")
            {
                r = web.GetHtml(u);
            }
            res.Text = r;


        }


        private void TestImportSamples()
        {
            //推荐方式
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem();
            HttpResult hres = new HttpResult();
            item.ContentType = "application/x-www-form-urlencoded";
            item.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            item.URL = "http://192.168.183.137/api";
            item.Method = "post";
            item.PostDataType = PostDataType.String;
            item.PostEncoding = Encoding.UTF8;
            item.KeepAlive = false;
            item.ProxyIp = "";
            
            for (int i= 1; i <2; i++)
            {
                for (int k = 1; k < 501; k++)
                {
                    string s2 = "username=XYS&password=123456&method=import_samples&&create_storage=Tem,XYS,7&box_type=bag&json=[{\"Name\":\"1000456613\",\"Sample Type\":\"组织--心研所\",\"Freezer\":\"Tem\",\"Level1\":\"XYS\",\"Level2\":\"7\",\"Box\":\"5\"}]";
                    item.Postdata = s2;
                string  RES =   http.GetHtml(item).Html;
                }
            }
        }

    }
}