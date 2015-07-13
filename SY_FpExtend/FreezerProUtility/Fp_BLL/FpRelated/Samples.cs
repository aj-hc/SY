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

        //导入样本方式6
        //创建存储结构盒子使用bag 导入失败创建新的bag

        //综上所述：使用方式 1 +方式 4   非常规方式使用6
        #region 导入样本数据到fp + public static string Import_Sample(string url, string sample_type, string count, Dictionary<string, string> dataDic)
        /// <summary>
        /// 导入样本数据到fp
        /// </summary>
        /// <param name="url">链接fp的url包含username，password</param>
        /// <param name="sample_type">样本类型</param>
        /// <param name="count">管数</param>
        /// <param name="dataDic">数据字典</param>
        /// <returns></returns>
        public static string Import_Sample(Fp_Common.UnameAndPwd up, string sample_type, string count, Dictionary<string, string> dataDic)
        {
            string username = Fp_Common.CookieHelper.GetCookieValue("username");
            string result = string.Empty;
            bool check;
            Box_Path box_path = CreatTemFreezerPath(up, out check);
            if (check)
            {
                
            }
            return result;
        }
        //创建盒子保存样本
        private static string ImportSamplesToFp(Fp_Common.UnameAndPwd up, string sample_type, string count, Box_Path box_path, Dictionary<string, string> dataDic)
        {
            string jsonsampledata = string.Empty;
            List<Dictionary<string, string>> jsonDicList = new List<Dictionary<string, string>>();
            string box_type = "bag"; //默认放入袋子中
            string create_storage = string.Empty;
            int kk = 1;
            Random rand = new Random();
            int ALIQUOT = rand.Next(1, 1000);
            #region 创建样本信息字符串&json=
            if (int.TryParse(count, out kk))
            {
                dataDic.Add("ALIQUOT", ALIQUOT.ToString());
                dataDic.Add("Freezer", box_path.Freezer);//Tem
                dataDic.Add("Level1", box_path.Level1);//Username
                dataDic.Add("Level2", box_path.Level2);//月
                dataDic.Add("Level3", box_path.Level3);//日
                create_storage = string.Format("{0},{1},{2},{3}", box_path.Freezer, box_path.Level1, box_path.Level2, box_path.Level3);
                dataDic.Add("Sample Type", sample_type);
                dataDic.Add("Box", box_path.Box);//袋子中不需要指定位置
                if (kk == 1)
                {
                    //单条数据
                    jsonsampledata = FpJsonHelper.DictionaryToJsonString(dataDic);
                }
                else if (kk > 1 && kk < 500)
                {
                    for (int i = 0; i < kk; i++)
                    {
                        //扩展数据成多条
                        Dictionary<string, string> tem = new Dictionary<string, string>();
                        //字典复制需要两次循环，这里是利用字典的序列化和反序列化
                        tem = Fp_Common.FpJsonHelper.DeserializeObject<Dictionary<string, string>>(Fp_Common.FpJsonHelper.DictionaryToJsonString(dataDic));
                        jsonDicList.Add(tem);
                    }
                    //多条数据
                    jsonsampledata = FpJsonHelper.DictionaryListToJsonString(jsonDicList);
                }
            } 
            #endregion
            Dictionary<string, string> jsonDic = new Dictionary<string, string>();
            jsonDic.Add("create_storage", create_storage);
            jsonDic.Add("box_type", box_type);
            jsonDic.Add("json", jsonsampledata);
            string importRes = ImportSampleToFp(up,jsonDic);
            return importRes;
        }

        #endregion

        #region 获取样品类型集合 +  public List<SampleTypes>  GetAllSample_Types(string url)
        public static List<SampleTypes> GetAll(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.sample_types.ToString());
            Fp_DAL.CallApi call = new Fp_DAL.CallApi(dic);
            List<Fp_Model.SampleTypes> List = call.getdata<Fp_Model.SampleTypes>("SampleTypes");
            return List;
        }
        #endregion

        #region 获取所有样品类型名称和id字典
        /// <summary>
        /// 获取所有样品类型名称和id字典
        /// </summary>
        /// <param name="url">带有username和password的url</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllIdAndNamesDic(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<SampleTypes> list = GetAll(up);
            if (list!=null&&list.Count>0)
            {
                foreach (var item in list)
                {
                    dic.Add(item.id, item.name);
                }
            }
            return dic;
        }
        #endregion

        #region 获取样品类型根据名称 + public static SampleTypes GetSample_TypeByTypeName(string url, string name)
        public static SampleTypes GetBy(Fp_Common.UnameAndPwd up, string name)
        {
            List<SampleTypes> list = GetAll(up);
            SampleTypes sample = new SampleTypes();
            if (list != null && list.Count > 0)
            {
               sample = list.Where(a => a.name == name).FirstOrDefault();
            }
            return sample;
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
        private static Fp_Model.Box_Path CreatTemFreezerPath(Fp_Common.UnameAndPwd up, out bool creat)
        {
            FreezerProUtility.Fp_Model.Box_Path box_path = new Box_Path();
            ////Tem-->username-->month-->day(-->box)
            //string box_path = string.Empty;
            string username = Fp_Common.CookieHelper.GetCookieValue("username");
            string department = Fp_Common.CookieHelper.GetCookieValue(username+"department");
            string freezerName = "Tem";
            if (!string.IsNullOrEmpty(username))
            {
                Fp_Model.Freezer freezer = Freezers.GetBy(up, freezerName);

                string _path = string.Format("{0}→{1}→{2}月→{3}日", freezerName, username, DateTime.Now.Month, DateTime.Now.Date.ToString("dd"));//创建盒子路径
                //获取次路径下的盒子
                if (freezer != null)
                {
                    Fp_Model.Subdivision subdivision = Subdivisions.CheckBy(up,freezer.id, _path);
                    if (subdivision.name.Contains("日"))
                    {
                        List<Fp_Model.Box> boxsList = Fp_BLL.Boxes.GetAll(up, subdivision.id);
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

        #region 提交数据到fp +private static string ImportSampleToFp(Fp_Common.UnameAndPwd up, Dictionary<string, string> jsonDic)
        private static string ImportSampleToFp(Fp_Common.UnameAndPwd up, Dictionary<string, string> jsonDic)
        {
            string result = string.Empty;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", FpMethod.import_samples.ToString());
            if (jsonDic != null && jsonDic.Count > 0)
            {
                foreach (KeyValuePair<string, string> item in jsonDic)
                {
                    dic.Add(item.Key.Trim(), item.Value.Trim());
                }
            }
            Fp_DAL.CallApi call = new Fp_DAL.CallApi(dic);
            result = call.PostData();
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
