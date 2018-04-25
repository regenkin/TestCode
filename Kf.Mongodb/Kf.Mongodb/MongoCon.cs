using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;

namespace Kf.Mongodb
{
    public class MongoCon : IDisposable
    {
        public static MongoServer mongoCon = null;
        public static MongoDatabase mongo { get; private set; }
        private bool disposed = false;
        static MongoCon()
        {
            //创建链接
            mongoCon = new MongoServer(MongoConfig.config);
            //打开链接
            mongoCon.Connect();
            //获取mongodb指定数据库
            mongo = mongoCon.GetDatabase(MongoConfig.MongoDB);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //释放链接
                    mongoCon.Disconnect();
                }
                mongoCon = null;
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
