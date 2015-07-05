using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace RuRo.Common
{
  public  class LogHelper
    {
        //记录错误日志
        public static void WriteError(string errorMessage)
        {
            try
            {
                string path = "~/Error/AppError/" + DateTime.Today.ToString("yyMMdd") + ".txt";
                if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
                }
                using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    w.WriteLine("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    w.WriteLine(errorMessage);
                    w.WriteLine("________________________________________________________");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }
        }

        public static void WriteExcError(Exception ex)
        {
            // 在出现未处理的错误时运行的代码
            Exception objErr = ex.GetBaseException();
            string errorMessage = Environment.NewLine + "Error Data【" + objErr.Data.ToString() + "】" + Environment.NewLine + "Error HelpLink【" + objErr.HelpLink.ToString() + "】" + Environment.NewLine + "Error InnerException【" + objErr.InnerException.ToString() + "】" + "Error Message【" + objErr.Message.ToString() + "】" + Environment.NewLine + "Error Source【" + objErr.Source.ToString() + "】" + Environment.NewLine + "Error StackTrace【" + objErr.StackTrace.ToString() + "】" + "Error TargetSite【" + objErr.TargetSite.ToString() + "】";
            //记录错误
            try
            {
                string path = "~/Error/ExError/" + DateTime.Today.ToString("yyMMdd") + ".txt";
                if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
                }
                using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    w.WriteLine("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    w.WriteLine(errorMessage);
                    w.WriteLine("________________________________________________________");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception err)
            {
                WriteExcError(err);
            }
        }
    }
}
