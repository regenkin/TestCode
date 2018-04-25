using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kf.MongodbConfig
{
    public partial class FrmConfig : Form
    {
        string FileRedisConfig = System.AppDomain.CurrentDomain.BaseDirectory + "Config\\Mongodb.kcg";
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            string xmlStr =string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?><config>
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
</config>", txtUrl.Text,numPort.Text
          ,numMaxConnectionPoolSize.Value,numMaxConnectionIdleTime.Value
          , numMaxConnectionLifeTime.Value, numConnectTimeout.Value
          , numWaitQueueSize.Value, numSocketTimeout.Value
          , numWaitQueueTimeout.Value
          , txtDBName.Text
          ,txtUser.Text,txtPsd.Text);
            doc.LoadXml(xmlStr);
            doc.Save(FileRedisConfig);
            MessageBox.Show(string.Format("保存配制文件 {0} 成功.", FileRedisConfig),"提示", MessageBoxButtons.OK);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                WriteLog("写入集合：users");
                bool b = Kf.Mongodb.MongodbHelper.Insert<CTest>("users", new CTest() { Number = "kinfar", Name = "君飞", Desc = "君飞工作室" });
                WriteLog("写入集合：users " + (b ? "成功" : "失败"));
                WriteLog("查询集合：users");
                MongoDB.Driver.IMongoQuery query = null;
                query = MongoDB.Driver.Builders.Query.And(
                    MongoDB.Driver.Builders.Query.EQ("Number", "kinfar")
                    );
                CTest t = Kf.Mongodb.MongodbHelper.GetModel<CTest>("users", query);
                WriteLog("查询结果：" + t ?? "".ToString());

                WriteLog("清空集合：users");
                Kf.Mongodb.MongodbHelper.RemoveAll("users");
                WriteLog("查询集合：users");
                t = Kf.Mongodb.MongodbHelper.GetModel<CTest>("users", query);
                WriteLog("查询结果：" + t ?? "".ToString());
            }
            catch (Exception exp)
            {
                WriteLog(exp.Message+"【"+exp.StackTrace+"】");
            }
        }

        void WriteLog(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(txtLog.Text);
            sb.AppendLine(msg);
            txtLog.Text = sb.ToString();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
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
</config>", "mongodb://127.0.0.1", "27017", 500, 30, 60,10,50,10,60,"test","",""));
            txtUrl.Text = doc.SelectSingleNode("config/txtUrl") == null ? "" : doc.SelectSingleNode("config/txtUrl").InnerText;
            numPort.Text = doc.SelectSingleNode("config/numPort") == null ? "" : doc.SelectSingleNode("config/numPort").InnerText;
            numMaxConnectionPoolSize.Value = Convert.ToInt32(doc.SelectSingleNode("config/numMaxConnectionPoolSize") == null ? "" : doc.SelectSingleNode("config/numMaxConnectionPoolSize").InnerText);
            numMaxConnectionIdleTime.Value = Convert.ToInt32(doc.SelectSingleNode("config/numMaxConnectionIdleTime") == null ? "" : doc.SelectSingleNode("config/numMaxConnectionIdleTime").InnerText);
            numMaxConnectionLifeTime.Value = Convert.ToInt32(doc.SelectSingleNode("config/numMaxConnectionLifeTime") == null ? "" : doc.SelectSingleNode("config/numMaxConnectionLifeTime").InnerText);
            numConnectTimeout.Value = Convert.ToInt32(doc.SelectSingleNode("config/numConnectTimeout") == null ? "" : doc.SelectSingleNode("config/numConnectTimeout").InnerText);
            numWaitQueueSize.Value = Convert.ToInt32(doc.SelectSingleNode("config/numWaitQueueSize") == null ? "" : doc.SelectSingleNode("config/numWaitQueueSize").InnerText);
            numSocketTimeout.Value = Convert.ToInt32(doc.SelectSingleNode("config/numSocketTimeout") == null ? "" : doc.SelectSingleNode("config/numSocketTimeout").InnerText);
            numWaitQueueTimeout.Value = Convert.ToInt32(doc.SelectSingleNode("config/numWaitQueueTimeout") == null ? "" : doc.SelectSingleNode("config/numWaitQueueTimeout").InnerText);
            txtDBName.Text = doc.SelectSingleNode("config/txtDBName") == null ? "" : doc.SelectSingleNode("config/txtDBName").InnerText;
            txtUser.Text = doc.SelectSingleNode("config/txtUser") == null ? "" : doc.SelectSingleNode("config/txtUser").InnerText;
            txtPsd.Text = doc.SelectSingleNode("config/txtPsd") == null ? "" : doc.SelectSingleNode("config/txtPsd").InnerText;
        }
    }

    [MongoDB.Bson.Serialization.Attributes.BsonIgnoreExtraElements]
    public class CTest
    {
        //public MongoDB.Bson.ObjectId  _id{ set; get; }
        public string Number { set; get; }
        public string Name { set; get; }
        public string Desc { set; get; }
        public override string ToString()
        {
            return string.Format("{{'Number':'{0}','Name':'{1}','Desc':'{2}'}}",Number, Name, Desc);
        }
    }
}
