using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yysfz
{
   public static class Cmd
    {

        public static int RandomInt(int n)
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();//生成字节数组
            int iRoot = BitConverter.ToInt32(buffer, 0);//利用BitConvert方法把字节数组转换为整数
            Random rd = new Random(iRoot);//以这个生成的整数为种子
            return rd.Next(10);
        }

        // 数字转2位字符串
       public static string NoToStr(int n)
        {
            string str;
            if (n < 10)
            {
                str = "0" + n.ToString();
            }
            else
            {
                str = n.ToString();
            }
            return str;
        }


        // 反序列化Json文件为Pic对象集合
        public static List<Pic> DeserPics(string path)
        {

            return JsonConvert.DeserializeObject<List<Pic>>(File.ReadAllText(path));
        }


    }
}
