//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace Kf.Redis
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Redis写入缓存：zhong");
//            RedisCacheHelper rch = new RedisCacheHelper();
//            rch.Add("zhong", "zhongzhongzhong", DateTime.Now.AddDays(1));

//            Console.WriteLine("Redis获取缓存：zhong");

//            string str3 = rch.Get<string>("zhong");

//            Console.WriteLine(str3);

//            Console.WriteLine("Redis获取缓存：nihao");
//            string str = rch.Get<string>("nihao");
//            Console.WriteLine(str);


//            Console.WriteLine("Redis获取缓存：wei");
//            string str1 = rch.Get<string>("wei");
//            Console.WriteLine(str1);

//            Console.ReadKey();
//        }
//    }
//}
