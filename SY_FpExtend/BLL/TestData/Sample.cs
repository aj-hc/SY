using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuRo.BLL.TestData
{
    public class Sample
    {
        BLL.TestData.Sample sample = new Sample();
        public string import_sample()
        {
            string json = "";
            string background_job = "";//boolean (true or false)
            string next_box = "";//boolean (true or false)
            string subdivision_barcode = "";
            string sample_type = "";
            string create_storage = ""; //创建储存结构才有 box_type
            string box_type = "";

            string tem = json + background_job + next_box + subdivision_barcode + sample_type + create_storage + box_type;
            //01.先判断储存结构是否存在，存在就添加
            //02.储存结构空间不足则再次添加储存结构
            //03.储存结构命名-->Tem-->username-->month-->bag
            //------>判断存储结构是否存在------>判断条件---冰箱--当前用户--月份。冰箱名指定（TEM）,用户名：当前用户全名，月份--当前日期

            //添加样品时需要查找指定盒子是否存在，不存在就添加，存在就检查数量是否合规
            return tem;
        }
    }
}
