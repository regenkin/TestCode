using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using ServiceStack.Common.Extensions;
using ServiceStack.Redis;
using ServiceStack.Logging;

namespace Kf.Redis
{
    public class RedisCacheHelper
    {
        string FileRedisConfig = System.AppDomain.CurrentDomain.BaseDirectory + "\\Config\\Redis.kcg";
        private readonly PooledRedisClientManager pool = null;
        private string[] redisReadHosts ;
        private string[] redisWriteHosts ;
        public int RedisMaxReadPool = 3;//int.Parse(ConfigurationManager.AppSettings["redis_max_read_pool"]);
        public int RedisMaxWritePool = 1;//int.Parse(ConfigurationManager.AppSettings["redis_max_write_pool"]);

        public RedisCacheHelper(int dbid=0)
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
</config>", "127.0.0.1:6379", "127.0.0.1:6379",3,1,180));
            var redisWriteHost = doc.SelectSingleNode("config/writeurl").InnerText;
            var redisReadHost = doc.SelectSingleNode("config/readurl").InnerText;
            RedisMaxReadPool =Convert.ToInt32(doc.SelectSingleNode("config/maxreadpool").InnerText);
            RedisMaxWritePool = Convert.ToInt32(doc.SelectSingleNode("config/maxwritepool").InnerText);

            if (!string.IsNullOrEmpty(redisWriteHost))
            {
                redisWriteHosts = redisWriteHost.Split(',');
                redisReadHosts = redisReadHost.Split(',');

                if (redisReadHosts.Length > 0)
                {
                    pool = new PooledRedisClientManager(redisWriteHosts, redisReadHosts,
                        new RedisClientManagerConfig()
                        { 
                            DefaultDb = dbid,
                            MaxWritePoolSize = RedisMaxWritePool,
                            MaxReadPoolSize = RedisMaxReadPool,
                            AutoStart = true
                        });
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">泛型值</param>
        public void Add<T>(string key, T value)
        {
            if (value == null)
            {
                return;
            }
            try
            {
                if (pool != null)
                {
                    using (var r = pool.GetClient())
                    {
                        if (r != null)
                        {
                            r.SendTimeout = 1000;
                            r.Set(key, value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0}:{1}发生异常!{2}", "cache", "存储", key);

            }

        }

        /// <summary>
        /// 加入键
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">泛型值</param>
        /// <param name="expiry">过期时间</param>
        public void Add<T>(string key, T value, DateTime expiry)
        {
            TimeSpan slidingExpiration = expiry - DateTime.Now;
            Add<T>(key, value, slidingExpiration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">泛型值</param>
        /// <param name="second">秒</param>
        public void Add<T>(string key, T value, double second)
        { 
            Add<T>(key,value,TimeSpan.FromSeconds(second));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">泛型值</param>
        /// <param name="slidingExpiration"></param>
        public void Add<T>(string key, T value, TimeSpan slidingExpiration)
        {
            if (value == null)
            {
                return;
            }

            if (slidingExpiration.TotalSeconds <= 0)
            {
                Remove(key);
                return;
            }

            try
            {
                if (pool != null)
                {
                    using (var r = pool.GetClient())
                    {
                        if (r != null)
                        {
                            r.SendTimeout = 1000;
                            r.Set(key, value, slidingExpiration);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0}:{1}发生异常!{2}", "cache", "存储", key);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return default(T);
            }

            T obj = default(T);

            try
            {
                if (pool != null)
                {
                    using (var r = pool.GetClient())
                    {
                        if (r != null)
                        {
                            r.SendTimeout = 1000;
                            obj = r.Get<T>(key);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0}:{1}发生异常!{2}", "cache", "获取", key);
            }


            return obj;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">键</param>
        public void Remove(string key)
        {
            try
            {
                if (pool != null)
                {
                    using (var r = pool.GetClient())
                    {
                        if (r != null)
                        {
                            r.SendTimeout = 1000;
                            r.Remove(key);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0}:{1}发生异常!{2}", "cache", "删除", key);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            try
            {
                if (pool != null)
                {
                    using (var r = pool.GetClient())
                    {
                        if (r != null)
                        {
                            r.SendTimeout = 1000;
                            return r.ContainsKey(key);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format("{0}:{1}发生异常!{2}", "cache", "是否存在", key);
            }

            return false;
        }
    }
}
