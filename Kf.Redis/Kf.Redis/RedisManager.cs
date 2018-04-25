using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;

namespace Kf.Redis
{
    /// <summary>
    /// 配置Redis链接
    /// </summary>
    public class RedisManager
    {
        private static string FileRedisConfig = System.AppDomain.CurrentDomain.BaseDirectory + "\\Config\\Redis.kcg";

        /// <summary>
        /// redis配置文件信息
        /// </summary>
        private static RedisConfig RedisConfig;

                /// <summary>
        /// 创建链接池管理对象
        /// </summary>
        private static void CreateManagerByConfig()
        {
            RedisConfig = RedisConfig.GetConfig();
            string[] WriteServerConStr = SplitString(RedisConfig.WriteServerConStr, ",");
            string[] ReadServerConStr = SplitString(RedisConfig.ReadServerConStr, ",");
            prcm = new PooledRedisClientManager(ReadServerConStr, WriteServerConStr,
                             new RedisClientManagerConfig
                             {
                                 MaxWritePoolSize = RedisConfig.MaxWritePoolSize,
                                 MaxReadPoolSize = RedisConfig.MaxReadPoolSize,
                                 AutoStart = RedisConfig.AutoStart,
                             });
        }

        private static PooledRedisClientManager prcm;

        /// <summary>
        /// 静态构造方法，初始化链接池管理对象
        /// </summary>
        static RedisManager()
        {
            CreateManager();
        }

        /// <summary>
        /// 创建链接池管理对象
        /// </summary>
        private static void CreateManager()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            if (System.IO.File.Exists(FileRedisConfig))
                doc.Load(FileRedisConfig);
            else
                doc.LoadXml(string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?><config>
    <run>0</run>
    <readurl>{0}</readurl>
    <writeurl>{1}</writeurl>
    <maxreadpool>{2}</maxreadpool>
    <maxwritepool>{3}</maxwritepool>
    <Expire>{4}</Expire>
</config>", "127.0.0.1:6379", "127.0.0.1:6379", 3, 1, 180));
            var redisWriteHost = doc.SelectSingleNode("config/writeurl").InnerText;
            var redisReadHost = doc.SelectSingleNode("config/readurl").InnerText;
            var RedisMaxReadPool = Convert.ToInt32(doc.SelectSingleNode("config/maxreadpool").InnerText);
            var RedisMaxWritePool = Convert.ToInt32(doc.SelectSingleNode("config/maxwritepool").InnerText);

            if (!string.IsNullOrEmpty(redisWriteHost))
            {
                var redisWriteHosts = redisWriteHost.Split(',');
                var redisReadHosts = redisReadHost.Split(',');

                if (redisReadHosts.Length > 0)
                {
                    prcm = new PooledRedisClientManager(redisWriteHosts, redisReadHosts,
                        new RedisClientManagerConfig()
                        {
                            MaxWritePoolSize = RedisMaxWritePool,
                            MaxReadPoolSize = RedisMaxReadPool,
                            AutoStart = true
                        });
                }
            }
        }

        private static string[] SplitString(string strSource, string split)
        {
            return strSource.Split(split.ToArray());
        }
        /// <summary>
        /// 客户端缓存操作对象
        /// </summary>
        public static IRedisClient GetClient()
        {
            if (prcm == null)
                CreateManager();
            return prcm.GetClient();
        }
    }
}
