using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace Kf.Memcached
{
    public class MemcachedHelper : ICache
    {
        static string FileMemcachedConfig = System.AppDomain.CurrentDomain.BaseDirectory + "Config\\Memcached.kcg";
        private static readonly MemcachedClient CacheClient;

        static MemcachedHelper()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            if (System.IO.File.Exists(FileMemcachedConfig))
                doc.Load(FileMemcachedConfig);
            else
                doc.LoadXml(string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?><config>
    <run>0</run>
    <url>{0}</url>
    <port>{1}</port>
    <minpool>{2}</minpool>
    <maxpool>{3}</maxpool>
    <expire>{4}</expire>
    <username>{5}</username>
    <password>{6}</password>
</config>", "127.0.0.1","11215", 5, 200, 180,"",""));
            var HostUrl = doc.SelectSingleNode("config/url").InnerText;
            var Port = Convert.ToInt32(doc.SelectSingleNode("config/port").InnerText);
            var MinPool = Convert.ToInt32(doc.SelectSingleNode("config/minpool").InnerText);
            var MaxPool = Convert.ToInt32(doc.SelectSingleNode("config/maxpool").InnerText);
            var username = doc.SelectSingleNode("config/username").InnerText;
            var password = doc.SelectSingleNode("config/password").InnerText;
            //初始化缓存  
            MemcachedClientConfiguration memConfig = new MemcachedClientConfiguration();
            //System.Net.IPAddress newaddress = System.Net.IPAddress.Parse(System.Net.Dns.GetHostEntry(ReadHost).AddressList[0].ToString()); //xxxx替换为ocs控制台上的“内网地址”  
            //System.Net.IPEndPoint ipEndPoint = new System.Net.IPEndPoint(newaddress, ReadPort);
            //// 配置文件 - ip  
            //memConfig.Servers.Add(ipEndPoint);
            memConfig.AddServer(HostUrl, Port);
            // 配置文件 - 协议  
            memConfig.Protocol = MemcachedProtocol.Binary;
            // 配置文件-权限，如果使用了免密码功能，则无需设置userName和password  
            if (!string.IsNullOrWhiteSpace(username))
            {
                memConfig.Authentication.Type = typeof(PlainTextAuthenticator);
                memConfig.Authentication.Parameters["zone"] = "";
                memConfig.Authentication.Parameters["userName"] = username;
                memConfig.Authentication.Parameters["password"] = password;
            }
            //下面请根据实例的最大连接数进行设置  
            memConfig.SocketPool.MinPoolSize = MinPool;
            memConfig.SocketPool.MaxPoolSize = MaxPool;
            CacheClient = new MemcachedClient(memConfig);  
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public T GetCache<T>(string cacheKey) where T : class
        {
            try
            {
                return (T)CacheClient.Get(cacheKey);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 写入缓存，过期时间默认10分钟
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cacheKey"></param>
        public void WriteCache<T>(T value, string cacheKey) where T : class
        {
            CacheClient.Store(Exists(cacheKey) ? StoreMode.Replace : StoreMode.Set, cacheKey, value, DateTime.Now.AddMinutes(10));
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cacheKey"></param>
        /// <param name="expireTime"></param>
        public void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class
        {
            //CacheClient.Store(StoreMode.Set, cacheKey, value, expireTime);

            CacheClient.Store(Exists(cacheKey) ? StoreMode.Replace : StoreMode.Set, cacheKey, value, expireTime);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        public void RemoveCache(string cacheKey)
        {
            CacheClient.Remove(cacheKey);
        }

        /// <summary>
        /// 移除所有缓存
        /// </summary>
        public void RemoveCache()
        {
            CacheClient.FlushAll();
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static bool Exists(string key)
        {
            return CacheClient.Get(key) != null;
        }
    }
}