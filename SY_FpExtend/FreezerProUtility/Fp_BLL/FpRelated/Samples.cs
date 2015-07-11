using FreezerProUtility.Fp_Common;
using FreezerProUtility.Fp_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class Samples
    {

        #region 根据样本id获取样本的信息
        //根据样本id获取样本的信息
        public Sample_Info GetSample_Info(string url, string sample_id)
        {
            Sample_Info sample_info = new Sample_Info();
            if (!string.IsNullOrEmpty(sample_id))
            {
                //sample_info = getdata<Sample_Info>(string.Format("{0}&id=", url, sample_id), FpMethod.sample_info, "");
            }
            return sample_info;
        }
        #endregion

        #region 导入样本数据到fp + public static string Import_Sample(string url, string sample_type, string count, Dictionary<string, string> dataDic)
        /// <summary>
        /// 导入样本数据到fp
        /// </summary>
        /// <param name="url">链接fp的url包含username，password</param>
        /// <param name="sample_type">样本类型</param>
        /// <param name="count">管数</param>
        /// <param name="dataDic">数据字典</param>
        /// <returns></returns>
        public static string Import_Sample(string url, string sample_type, string count, Dictionary<string, string> dataDic)
        {
            #region 思路分析
            //string json = "";
            //string background_job = "false";//boolean (true or false)
            //string next_box = "";   //boolean (true or false)
            //string subdivision_barcode = "";//细分结构---id+样本类型（将样本导入到该分支结构下的可用位置）
            //string sample_type = "";
            //string create_storage = ""; //创建储存结构才有 box_type
            //string box_type = "";
            //string box_path ="";  //盒子位置
            //01.先判断储存结构是否存在，存在就添加--先获取冰箱，查看冰箱是否存在，不存在就添加样品时直接创建冰箱结构（Tem-->username-->month-->bag）
            //02.储存结构空间不足则再次添加储存结构
            //03.储存结构命名-->Tem-->username-->month-->bag
            //------>判断存储结构是否存在------>判断条件---冰箱--当前用户--月份。冰箱名指定（TEM）,用户名：当前用户全名，月份--当前日期
            //添加样品时需要查找指定盒子是否存在，不存在就添加，存在就检查数量是否合规
            //判断储存结果是否存在（指定位置）--需要用到用户名Users,检查位置Get_Perfect_Box,
            //先判断日期分支下是有有满足条件的盒子，有就直接添加样本，没有就获取该分支下的所有盒子----然后创建分支并添加样本 
            #endregion
            string username = Fp_Common.CookieHelper.GetCookieValue("username");
            string result = string.Empty;
            string jsondata = string.Empty;

            bool creat;
            Box_Path box_path = CreatTemFreezerPath(url, out creat);
            if (creat)
            {
                //需要创建盒子
              result= ImportSamplesByCreat(url, sample_type, count, box_path, dataDic);
            }
            else
            {
                //不需要创建盒子
              result = ImportSamplesByPath(url, sample_type, count, box_path, dataDic);
            }

            return result;
        }

        private static string  ImportSamplesByPath(string url, string sample_type, string count, Box_Path box_path, Dictionary<string, string> dataDic)
        {
            string jsonsampledata = string.Empty;
            int kk = 1;
            string path = string.Empty;
            Random rand = new Random();
            int ALIQUOT = rand.Next(1, 1000);
            List<Dictionary<string, string>> jsonDicList = new List<Dictionary<string, string>>();
            if (int.TryParse(count, out kk))
            {
                dataDic.Add("ALIQUOT", ALIQUOT.ToString());
                path = string.Format("{0},{1},{2},{3},{4}", box_path.Freezer, box_path.Level1, box_path.Level2, box_path.Level3,box_path.Box);
                if (kk == 1)
                {
                    //单条数据
                    jsonsampledata = FpJsonHelper.DictionaryToJsonString(dataDic);
                }
                else if (kk > 1 && kk < 100)
                {
                    for (int i = 0; i < kk; i++)
                    {
                        jsonDicList.Add(dataDic);
                    }
                    //多条数据
                    jsonsampledata = FpJsonHelper.DictionaryListToJsonString(jsonDicList);
                }
            }
            string jsonData = string.Format("&sample_type={0}&box_path={1}&json={3}", sample_type, path, jsonsampledata);
            return ImportSampleToFp(url, jsonData);

        }

        //创建盒子保存样本
        private static string ImportSamplesByCreat(string url, string sample_type, string count, Box_Path box_path, Dictionary<string, string> dataDic)
        {
            string jsonsampledata = string.Empty;
            List<Dictionary<string, string>> jsonDicList = new List<Dictionary<string, string>>();
            string box_type = "10 x 10"; //默认10x10的盒子
            string create_storage = string.Empty;
            int kk = 1;
            Random rand = new Random();
            int ALIQUOT = rand.Next(1, 1000);
            if (int.TryParse(count, out kk))
            {
                dataDic.Add("ALIQUOT", ALIQUOT.ToString());
                dataDic.Add("Freezer", box_path.Freezer);//Tem
                dataDic.Add("Level1", box_path.Level1);//Username
                dataDic.Add("Level2", box_path.Level2);//月
                dataDic.Add("Level3", box_path.Level3);//日
                create_storage = string.Format("{0},{1},{2},{3}", box_path.Freezer, box_path.Level1, box_path.Level2, box_path.Level3);
                if (kk == 1)
                {

                    dataDic.Add("Box", box_path.Box);//Box
                    dataDic.Add("Position", kk.ToString());
                    //单条数据
                    jsonsampledata = FpJsonHelper.DictionaryToJsonString(dataDic);
                }
                else if (kk > 1 && kk < 100)
                {
                    Dictionary<string, string> tem = new Dictionary<string, string>();
                    dataDic.Add("Box", box_path.Box);//Box
                    for (int i = 0; i < kk; i++)
                    {
                        if (dataDic.Keys.Contains("Position"))
                        {
                            dataDic["Position"] = (i + 2).ToString();
                        }
                        else
                        {
                            dataDic.Add("Position", (i + 2).ToString());
                        }
                        jsonDicList.Add(dataDic);
                    }
                    //多条数据
                    jsonsampledata = FpJsonHelper.DictionaryListToJsonString(jsonDicList);
                }
            }
            string jsonData = string.Format("&sample_type={0}&create_storage={1}&box_type={2}&json={3}", sample_type, create_storage, box_type, jsonsampledata);
            return ImportSampleToFp(url, jsonData);
        }

        #endregion

        #region 获取样品类型集合 +  public List<SampleTypes>  GetAllSample_Types(string url)
        public static List<SampleTypes> GetAll(string url)
        {
            List<SampleTypes> sample_TypesList = Fp_DAL.DataWithFP.getdata<SampleTypes>(url, FpMethod.sample_types, "", "SampleTypes");
            return sample_TypesList;
        }
        #endregion

        #region 获取所有样品类型名称和id字典
        /// <summary>
        /// 获取所有样品类型名称和id字典
        /// </summary>
        /// <param name="url">带有username和password的url</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllIdAndNamesDic(string url)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<SampleTypes> sample_TypesList = GetAll(url);
            foreach (var item in sample_TypesList)
            {
                dic.Add(item.id, item.name);
            }
            return dic;
        }
        #endregion

        #region 获取样品类型根据名称 + public static SampleTypes GetSample_TypeByTypeName(string url, string name)
        public static SampleTypes GetSample_TypeByTypeName(string url, string name)
        {
            List<SampleTypes> sample_TypesList = GetAll(url);
            SampleTypes sample = sample_TypesList.Where(a => a.name == name).FirstOrDefault();
            return sample;
        }
        #endregion

        //导入样品方式1
        //指定sample_type，box_path(","分割)，jsondata

        //导入样品方式2
        //指定样品jsondata、sample_type，box_path(","分割)，use_positions(指定位置)

        //导入样品方式3
        //指定样品jsondata、sample_type，box_path(","分割)，next_box (true)

        //导入样品方式4
        //指定样品jsondata、sample_type，create_storage，box_type (true)

        //导入样品方式5
        //指定样品jsondata、sample_type，subdivision_barcode


        //综上所述：使用方式 1 +方式 4
        #region 导入数据到fp私有方法，包含直接导入和创建存储结构 +  private static string ImportSamples(string url, string sample_type, string json)
        /// <summary>
        /// 导入数据到fp私有方法，包含直接导入和创建存储结构
        /// </summary>
        /// <param name="url"></param>
        /// <param name="sample_type"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        private static string ImportSamples(string url, string sample_type, string json)
        {
            string jsonResStr = string.Empty;
            string box_type = "10 x 10"; //默认10x10的盒子
            bool check;
            string connFpUrl = UrlHelper.ConnectionUrlAndPar(url, FpMethod.import_samples, "", out check);
            bool creat = false;
            string box_path = CreatTemFreezerPath(url).Replace('→', ',');
            FreezerProUtility.Fp_Model.Box_Path boxpath = new Box_Path();
            CreatTemFreezerPath(url, out creat);

            if (creat)
            {
                //需要创建盒子
                //string Freezer = "";//TEM
                //string Level1 = "";//username
                //string Level2 = "";//月
                //string Level3 = "";//日
                //string Box = "";//盒子
                //string Position = "";//位置


            }
            else
            {
                //不需要创建盒子

            }

            string jsonData = string.Format("&sample_type={0}&box_path={1}&json={2}", sample_type, box_path, json);
            jsonResStr = ImportSampleToFp(url, jsonData);
            
            return jsonResStr;//导入样本最后的返回信息
        }
        #endregion

        private string ImportSamples(string url, string sample_type)
        {
            return "";
        }



        //第一步到指定位置查找空位
        //第二部找到位置就添加样本
        //第三部没好到就添加样本盒（样本盒名称怎么获取）--获取冰箱（根据名称）--->根据冰箱名获取冰箱id-->根据冰箱id获取冰箱分支---->根据用户名获取对应的分支id---->月份分支---->日分支id----->boxes获取当前分支下的所有盒子，判断盒子是否存在（根据名字判断盒子）

        //生成默认临时储存结构的方法--目的，查看对应位置是否存在可以存放样本的孔

        #region 生成默认临时储存结构的方法 +  private static string CreatTemFreezerPath(string url)
        /// <summary>
        /// 生成默认临时储存结构的方法
        /// </summary>
        /// <param name="url"></param>
        /// <returns>生成默认临时储存结构的方法Tem→username→month→day→1</returns>
        private static string CreatTemFreezerPath(string url)
        {
            //tem-->username-->month-->day(-->box)
            string box_path = string.Empty;
            string username = Fp_Common.CookieHelper.GetCookieValue("username");
            string freezerName = "Tem";
            if (!string.IsNullOrEmpty(username))
            {
                Fp_Model.Freezer freezer = Freezers.GetBy(url, freezerName);
                string _path = string.Format("{0}→{1}→{2}月→{3}日", freezerName, username, DateTime.Now.Month, DateTime.Now.Date.ToString("dd"));//创建盒子路径
                //获取次路径下的盒子
                if (freezer != null)
                {
                    Fp_Model.Subdivision subdivision = Subdivisions.CheckBy(freezer.id, _path, url);
                    if (subdivision.name.Contains("日"))
                    {
                        List<Fp_Model.Box> boxsList = Fp_BLL.Boxes.GetAll(url, subdivision.id);
                        if (boxsList.Count > 0)
                        {
                            //当前节点下有盒子
                            string maxBoxName = boxsList.OrderByDescending(a => a.name).FirstOrDefault().name;
                            if (string.IsNullOrEmpty(maxBoxName))
                            {
                                box_path = string.Format("{0}→{1}→{2}月→{3}日→{4}", freezerName, username, DateTime.Now.Month, DateTime.Now.Date.ToString("dd"), maxBoxName);
                            }
                        }
                        else
                        {
                            //当前节点下没盒子
                            box_path = string.Format("{0}→{1}→{2}月→{3}日→{4}", freezerName, username, DateTime.Now.Month, DateTime.Now.Date.ToString("dd"), "1");
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    box_path = string.Format("{0}→{1}→{2}月→{3}日→{4}", freezerName, username, DateTime.Now.Month, DateTime.Now.Date.ToString("dd"), "1");
                }
            }
            return box_path;
        }
        #endregion
        private static Fp_Model.Box_Path CreatTemFreezerPath(string url, out bool creat)
        {
            FreezerProUtility.Fp_Model.Box_Path box_path = new Box_Path();
            ////tem-->username-->month-->day(-->box)
            //string box_path = string.Empty;
            string username = Fp_Common.CookieHelper.GetCookieValue("username");
            string freezerName = "Tem";
            if (!string.IsNullOrEmpty(username))
            {
                Fp_Model.Freezer freezer = Freezers.GetBy(url, freezerName);

                string _path = string.Format("{0}→{1}→{2}月→{3}日", freezerName, username, DateTime.Now.Month, DateTime.Now.Date.ToString("dd"));//创建盒子路径
                //获取次路径下的盒子
                if (freezer != null)
                {
                    Fp_Model.Subdivision subdivision = Subdivisions.CheckBy(freezer.id, _path, url);
                    if (subdivision.name.Contains("日"))
                    {
                        List<Fp_Model.Box> boxsList = Fp_BLL.Boxes.GetAll(url, subdivision.id);
                        if (boxsList.Count > 0)
                        {
                            //日期节点下有盒子
                            string maxBoxName = boxsList.OrderByDescending(a => a.name).FirstOrDefault().name;
                            if (string.IsNullOrEmpty(maxBoxName))
                            {
                                box_path.Freezer = "Tem";
                                box_path.Level1 = username;
                                box_path.Level2 = DateTime.Now.Month + "月";
                                box_path.Level3 = DateTime.Now.Date.ToString("dd");
                                box_path.Box = maxBoxName;
                                creat = false;
                            }
                            else
                            {
                                int max = 0;
                                //意外报错
                                if (int.TryParse(maxBoxName, out max))
                                {
                                    box_path.Freezer = "Tem";
                                    box_path.Level1 = username;
                                    box_path.Level2 = DateTime.Now.Month + "月";
                                    box_path.Level3 = DateTime.Now.Date.ToString("dd");
                                    box_path.Box = (max + 1).ToString();
                                }
                                creat = true;
                            }
                        }
                        else
                        {
                            creat = true;
                            //日期节点下没盒子
                            box_path.Freezer = "Tem";
                            box_path.Level1 = username;
                            box_path.Level2 = DateTime.Now.Month + "月";
                            box_path.Level3 = DateTime.Now.Date.ToString("dd");
                            box_path.Box = "1";
                        }
                    }
                    else
                    {
                        creat = true;
                        //当前节点下没盒子
                        box_path.Freezer = "Tem";
                        box_path.Level1 = username;
                        box_path.Level2 = DateTime.Now.Month + "月";
                        box_path.Level3 = DateTime.Now.Date.ToString("dd");
                        box_path.Box = "1";
                    }
                }
                else
                {
                    creat = true;
                    box_path.Freezer = "Tem";
                    box_path.Level1 = username;
                    box_path.Level2 = DateTime.Now.Month + "月";
                    box_path.Level3 = DateTime.Now.Date.ToString("dd");
                    box_path.Box = "1"; ;
                }
            }
            else
            {
                creat = true;
            }
            return box_path;
        }

        #region 提交数据到fp +private static string ImportSampleToFp(string url, string jsonData)
        /// <summary> 
        /// 提交数据到fp
        /// </summary>
        /// <param name="url">链接地址</param>
        /// <param name="jsonData">要提交的数据</param>
        /// <returns>返回提交后的状态</returns>
        private static string ImportSampleToFp(string url, string jsonData)
        {
            bool ckeck;
            string result = string.Empty;
            string connFpUrl = UrlHelper.ConnectionUrlAndPar(url, FpMethod.import_samples, "", out  ckeck);
            if (ckeck)
            {
                //转换成功
                result = Fp_DAL.DataWithFP.postDateToFp(connFpUrl, jsonData);
            }
            return result;
        }
        #endregion


        private static string CheckImportRes(string jsonResStr)
        {
            //检测是否导入成功
            if (string.IsNullOrEmpty(jsonResStr))
            {
                return "url或方法错误";
            }
            else if (jsonResStr == "1")
            {
                return "";
            }
            else
            {
                return "";
            }
        }

    }
}
