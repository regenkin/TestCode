using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;

namespace Kf.Mongodb
{
    public class MongoConfig
    {
        public static MongoServerSettings config = null;
        private static string _conStr="mongodb://localhost:27017";//mongodb://username:password@myserver:port/databaseName
        private static string FileRedisConfig = System.AppDomain.CurrentDomain.BaseDirectory + "Config\\Mongodb.kcg";
        private static string _mongoDB = "mydb";
        private static string _mongoDBuser = "";
        private static string _mongoDBpsd = "";
        static MongoConfig()
        {
            //config = MongoServerSettings.FromUrl(MongoUrl.Create(conStr));
            ////最大连接池
            //config.MaxConnectionPoolSize = 500;
            ////最大闲置时间
            //config.MaxConnectionIdleTime = TimeSpan.FromSeconds(30);
            ////最大存活时间
            //config.MaxConnectionLifeTime = TimeSpan.FromSeconds(60);
            ////链接时间
            //config.ConnectTimeout = TimeSpan.FromSeconds(10);
            ////等待队列大小
            //config.WaitQueueSize = 50;
            ////socket超时时间
            //config.SocketTimeout = TimeSpan.FromSeconds(10);
            ////队列等待时间
            //config.WaitQueueTimeout = TimeSpan.FromSeconds(60);
            //////操作时间
            ////config.OperationTimeout = TimeSpan.FromSeconds(60);

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            if (System.IO.File.Exists(FileRedisConfig))
                doc.Load(FileRedisConfig);
            else
                doc.LoadXml(string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?><config>
    <txtUrl>{0}</txtUrl>
    <numPort>{1}</numPort>
    <numMaxConnectionPoolSize>{2}</numMaxConnectionPoolSize>
    <numMaxConnectionIdleTime>{3}</numMaxConnectionIdleTime>
    <numMaxConnectionLifeTime>{4}</numMaxConnectionLifeTime>
    <numConnectTimeout>{5}</numConnectTimeout>
    <numWaitQueueSize>{6}</numWaitQueueSize>
    <numSocketTimeout>{7}</numSocketTimeout>
    <numWaitQueueTimeout>{8}</numWaitQueueTimeout>
    <txtDBName>{9}</txtDBName>
    <txtUser>{10}</txtUser>
    <txtPsd>{11}</txtPsd>
</config>", "mongodb://127.0.0.1", "27017", 500, 30, 60, 10, 50, 10, 60, "test", "", ""));
            var txtUrl = doc.SelectSingleNode("config/txtUrl") == null ? "" : doc.SelectSingleNode("config/txtUrl").InnerText;
            var numPort = doc.SelectSingleNode("config/numPort") == null ? "" : doc.SelectSingleNode("config/numPort").InnerText;
            var numMaxConnectionPoolSize = Convert.ToInt32(doc.SelectSingleNode("config/numMaxConnectionPoolSize") == null ? "" : doc.SelectSingleNode("config/numMaxConnectionPoolSize").InnerText);
            var numMaxConnectionIdleTime = Convert.ToInt32(doc.SelectSingleNode("config/numMaxConnectionIdleTime") == null ? "" : doc.SelectSingleNode("config/numMaxConnectionIdleTime").InnerText);
            var numMaxConnectionLifeTime = Convert.ToInt32(doc.SelectSingleNode("config/numMaxConnectionLifeTime") == null ? "" : doc.SelectSingleNode("config/numMaxConnectionLifeTime").InnerText);
            var numConnectTimeout = Convert.ToInt32(doc.SelectSingleNode("config/numConnectTimeout") == null ? "" : doc.SelectSingleNode("config/numConnectTimeout").InnerText);
            var numWaitQueueSize = Convert.ToInt32(doc.SelectSingleNode("config/numWaitQueueSize") == null ? "" : doc.SelectSingleNode("config/numWaitQueueSize").InnerText);
            var numSocketTimeout = Convert.ToInt32(doc.SelectSingleNode("config/numSocketTimeout") == null ? "" : doc.SelectSingleNode("config/numSocketTimeout").InnerText);
            var numWaitQueueTimeout = Convert.ToInt32(doc.SelectSingleNode("config/numWaitQueueTimeout") == null ? "" : doc.SelectSingleNode("config/numWaitQueueTimeout").InnerText);
            var txtDBName = doc.SelectSingleNode("config/txtDBName") == null ? "" : doc.SelectSingleNode("config/txtDBName").InnerText;
            var txtUser = doc.SelectSingleNode("config/txtUser") == null ? "" : doc.SelectSingleNode("config/txtUser").InnerText;
            var txtPsd = doc.SelectSingleNode("config/txtPsd") == null ? "" : doc.SelectSingleNode("config/txtPsd").InnerText;

            if(string.IsNullOrWhiteSpace(txtUser))
                _conStr = string.Format("mongodb://{0}:{1}", txtUrl, numPort);
            else
                _conStr = string.Format("mongodb://{0}:{1}@{2}:{3}", txtUser, txtPsd, txtUrl, numPort);

            config = MongoServerSettings.FromUrl(MongoUrl.Create(_conStr));
            //最大连接池
            config.MaxConnectionPoolSize = numMaxConnectionPoolSize;
            //最大闲置时间
            config.MaxConnectionIdleTime = TimeSpan.FromSeconds(numMaxConnectionIdleTime);
            //最大存活时间
            config.MaxConnectionLifeTime = TimeSpan.FromSeconds(numMaxConnectionLifeTime);
            //链接时间
            config.ConnectTimeout = TimeSpan.FromSeconds(numConnectTimeout);
            //等待队列大小
            config.WaitQueueSize = numWaitQueueSize;
            //socket超时时间
            config.SocketTimeout = TimeSpan.FromSeconds(numSocketTimeout);
            //队列等待时间
            config.WaitQueueTimeout = TimeSpan.FromSeconds(numWaitQueueTimeout);
            
            _mongoDB=txtDBName;
            _mongoDBuser = txtUser;
            _mongoDBpsd = txtPsd;

        }
        public static string ConStr
        {
            get{return _conStr;}
        }
        public static string MongoDB
        {
            get{return _mongoDB;}
        }

        public static string MongoDBuser
        {
            get { return MongoConfig._mongoDBuser; }
            set { MongoConfig._mongoDBuser = value; }
        }
        public static string MongoDBpsd
        {
            get { return MongoConfig._mongoDBpsd; }
            set { MongoConfig._mongoDBpsd = value; }
        }
    }
}
