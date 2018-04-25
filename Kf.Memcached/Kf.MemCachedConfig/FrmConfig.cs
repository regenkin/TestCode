using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kf.MemCachedConfig
{
    public partial class FrmConfig : Form
    {
        string FileRedisConfig = System.AppDomain.CurrentDomain.BaseDirectory + "Config\\Memcached.kcg";
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            string xmlStr =string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?><config>
    <run>{0}</run>
    <url>{1}</url>
    <port>{2}</port>
    <minpool>{3}</minpool>
    <maxpool>{4}</maxpool>
    <expire>{5}</expire>
    <username>{6}</username>
    <password>{7}</password>
</config>", chkRun.Checked?1:0,txtUrl.Text,numPort.Text,numReadPool.Value,numWritePool.Value,numExpire.Value,txtUser.Text,txtPsd.Text);
            doc.LoadXml(xmlStr);
            doc.Save(FileRedisConfig);
            MessageBox.Show(string.Format("保存配制文件 {0} 成功.", FileRedisConfig),"提示", MessageBoxButtons.OK);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            WriteLog("Memcached写入缓存：testkey");
            Kf.Memcached.MemcachedHelper mch = new Kf.Memcached.MemcachedHelper();
            mch.WriteCache<string>("Memcached测试成功", "testkey");

            WriteLog("Memcached获取缓存：testkey");
            string str3 = mch.GetCache<string>("testkey");
            if (str3 == "Memcached测试成功") WriteLog(str3);
            else WriteLog("Memcached读写失败");

            WriteLog("清除缓存：testkey");
            mch.RemoveCache("testkey");
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
    <run>0</run>
    <url>{0}</url>
    <port>{1}</port>
    <minpool>{2}</minpool>
    <maxpool>{3}</maxpool>
    <expire>{4}</expire>
    <username>{5}</username>
    <password>{6}</password>
</config>", "127.0.0.1","11215", 5, 200, 180,"",""));
            numPort.Text = doc.SelectSingleNode("config/port") == null ? "" : doc.SelectSingleNode("config/port").InnerText;
            txtUrl.Text = doc.SelectSingleNode("config/url") == null ? "" : doc.SelectSingleNode("config/url").InnerText;
            numReadPool.Value = Convert.ToInt32(doc.SelectSingleNode("config/minpool") == null ? "" : doc.SelectSingleNode("config/minpool").InnerText);
            numWritePool.Value = Convert.ToInt32(doc.SelectSingleNode("config/maxpool") == null ? "" : doc.SelectSingleNode("config/maxpool").InnerText);
            numExpire.Value = Convert.ToInt32(doc.SelectSingleNode("config/expire") == null ? "" : doc.SelectSingleNode("config/expire").InnerText);
            chkRun.Checked = ((doc.SelectSingleNode("config/run") == null ? "" : doc.SelectSingleNode("config/run").InnerText )== "1");
            txtUser.Text = doc.SelectSingleNode("config/username") == null ? "" : doc.SelectSingleNode("config/username").InnerText;
            txtPsd.Text = doc.SelectSingleNode("config/password") == null ? "" : doc.SelectSingleNode("config/password").InnerText;
        }
    }
}
