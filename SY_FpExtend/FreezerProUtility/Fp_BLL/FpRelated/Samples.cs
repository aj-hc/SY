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
        //创建数据层对象
        FreezerProUtility.Fp_DAL.DataWithFP dataWithFP = new FreezerProUtility.Fp_DAL.DataWithFP();

        #region 泛型方法处理从Fp中获取到的数据 +  private List<T> getdata<T>(FpMethod fpMethod, string param, string datawith)
        /// <summary>
        /// 泛型方法处理从Fp中获取到的数据
        /// </summary>
        /// <typeparam name="T">返回集合参数的类型</typeparam>
        /// <param name="fpMethod">调用的api方法</param>
        /// <param name="param">调用方法的参数</param>
        /// <param name="datawith">从fp返回值中取什么数据</param>
        /// <returns>返回集合</returns>
        private List<T> getdata<T>(FpMethod fpMethod, string param, string datawith)
        {
            List<T> list = new List<T>();
            string str_Json = dataWithFP.getDateFromFp(fpMethod, param);
            //默认取出来的数据只有100条
            if (ValidationData.checkTotal(str_Json))
            {
                list = FpJsonHelper.JObjectToList<T>(datawith, str_Json);
            }
            return list;
        }
        #endregion

        #region 根据日期查询样本samples_by_date +  public List<Sample> GetSamples_By_Date(string date, string param)
        //根据日期查询样本samples_by_date  lists samples by date:# today, yesterday, week, month, 1/1/2008
        /// <summary>
        /// 根据日期查询样本samples_by_date
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Sample> GetSamples_By_Date(string date, string param)
        {
            List<Sample> sample_By_DateList = getdata<Sample>(FpMethod.samples_by_date, string.Format("&date={0}&limit={1}", date, param), "Samples");
            return sample_By_DateList;
        }
        #endregion

        #region 获取出库的样本 + public List<Sample_Out> GetSamples_Out(string param)
        //获取出库的样本retrieves a list of samples that are taken out of the freezer:
        public List<Sample_Out> GetSamples_Out(string param)
        {
            List<Sample_Out> sampleOutList = getdata<Sample_Out>(FpMethod.samples_out, string.Format("&limit={0}", param), "Samples");
            return sampleOutList;
        }
        #endregion

        #region 获取删除的样本samples in the trashbin + public List<Samples_Trashbin> GetSamples_Trashbin(string param)
        //获取删除的样本samples in the trashbin
        /// <summary>
        /// 获取删除的样本
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Samples_Trashbin> GetSamples_Trashbin(string param)
        {
            List<Samples_Trashbin> sampleLocationsList = getdata<Samples_Trashbin>(FpMethod.samples_trashbin, string.Format("&limit={0}", param), "Locations");

            return sampleLocationsList;
        }
        #endregion

        #region 根据样本源id获取样本 + public List<Sample> GetSampleSource_Samples(string samplesource_id)
        //根据样本源id获取样本
        public List<Sample> GetSampleSource_Samples(string samplesource_id)
        {
            List<Sample> sampleSource_Sampleslist = getdata<Sample>(FpMethod.samplesource_samples, string.Format("&id={0}", samplesource_id), "Samples");
            return sampleSource_Sampleslist;
        }
        #endregion

        #region 根据样本id获取样本的信息
        /// <summary>
        /// 根据样本id获取样本的信息
        /// </summary>
        /// <param name="sample_id">样本id</param>
        /// <returns>Sample_Info对象</returns>
        public Sample_Info GetSample_Info(string sample_id)
        {
            Sample_Info sample_info = new Sample_Info();
            string strJson = dataWithFP.getDateFromFp(FpMethod.sample_info, string.Format("&id={0}", sample_id));
            sample_info = FpJsonHelper.JsonStrToObject<Sample_Info>(strJson);
            return sample_info;
        }
        #endregion

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

        /// <summary>
        /// 导入样本数据到fp
        /// </summary>
        /// <param name="url">导入数据的url</param>
        /// <param name="jsondata">要导入的数据</param>
        /// <returns>导入之后的结果</returns>
        public string Import_Sample(string url, string jsondata)
        {
            string json = "";
            string background_job = "";//boolean (true or false)
            string next_box = "";//boolean (true or false)
            string subdivision_barcode = "";
            string sample_type = "";
            string create_storage = ""; //创建储存结构才有 box_type
            string box_type = "";

            //01.先判断储存结构是否存在，存在就添加--先获取冰箱，查看冰箱是否存在，不存在就添加样品时直接创建冰箱结构（Tem-->username-->month-->bag）
            //02.储存结构空间不足则再次添加储存结构
            //03.储存结构命名-->Tem-->username-->month-->bag
            //------>判断存储结构是否存在------>判断条件---冰箱--当前用户--月份。冰箱名指定（TEM）,用户名：当前用户全名，月份--当前日期
            //添加样品时需要查找指定盒子是否存在，不存在就添加，存在就检查数量是否合规




            return Fp_DAL.DataWithFP.postDateToFp(url, jsondata);
        }

        #region 获取样品类型集合 +  public List<SampleTypes>  GetAllSample_Types(string url)
        public static List<SampleTypes> GetAllSample_Types(string url)
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
        public static Dictionary<string, string> GetAllSample_TypesNames(string url)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<SampleTypes> sample_TypesList = GetAllSample_Types(url);
            foreach (var item in sample_TypesList)
            {
                dic.Add(item.id, item.name);
            }
            return dic;
        }
        #endregion

        #region 获取样品类型根据名称 +  public List<SampleTypes>  GetAllSample_Types(string url)
        public SampleTypes GetSample_TypeByTypeName(string url,string name)
        {
            List<SampleTypes> sample_TypesList = GetAllSample_Types(url);
            SampleTypes sample = sample_TypesList.Where(a => a.name == name).FirstOrDefault();
            return sample;
        }
        #endregion

    }
}
