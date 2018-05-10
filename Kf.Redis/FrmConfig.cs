using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kf.RedisConfig
{
    public partial class FrmConfig : Form
    {
        string FileRedisConfig = System.AppDomain.CurrentDomain.BaseDirectory + "Config\\Redis.kcg";
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Dir =System.IO.Path.GetDirectoryName(FileRedisConfig);
            if(!System.IO.Directory.Exists(Dir)) System.IO.Directory.CreateDirectory(Dir);
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            string xmlStr =string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?><config>
    <run>{0}</run>
    <readurl>{1}</readurl>
    <writeurl>{2}</writeurl>
    <maxreadpool>{3}</maxreadpool>
    <maxwritepool>{4}</maxwritepool>
    <Expire>{5}</Expire>
    <password>{6}</password>
    <dbid>{7}</dbid>
</config>", chkRun.Checked ? 1 : 0, txtReadUrl.Text, txtWriteUrl.Text, numReadPool.Value, numWritePool.Value, numExpire.Value, txtpassword.Text.Trim(), numDbid.Value);
            doc.LoadXml(xmlStr);
            doc.Save(FileRedisConfig);
            MessageBox.Show(string.Format("保存配制文件 {0} 成功.", FileRedisConfig),"提示", MessageBoxButtons.OK);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            WriteLog("Redis写入缓存：testkey");
            Kf.Redis.RedisCacheHelper rch = new Kf.Redis.RedisCacheHelper();
            rch.Add("testkey", "Redis测试成功");

            WriteLog("Redis获取缓存：testkey");
            string str3 = rch.Get<string>("testkey");
            if(str3=="Redis测试成功") WriteLog(str3);
            else WriteLog("Redis读写失败");

            WriteLog("清除缓存：testkey");
            rch.Remove("testkey");
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
    <readurl>{0}</readurl>
    <writeurl>{1}</writeurl>
    <maxreadpool>{2}</maxreadpool>
    <maxwritepool>{3}</maxwritepool>
    <Expire>{4}</Expire>
    <password></password>
    <dbid></dbid>
</config>", "127.0.0.1:6379", "127.0.0.1:6379", 3, 1, 180));
            txtWriteUrl.Text = doc.SelectSingleNode("config/writeurl") == null ? "" : doc.SelectSingleNode("config/writeurl").InnerText;
            txtReadUrl.Text = doc.SelectSingleNode("config/readurl") == null ? "" : doc.SelectSingleNode("config/readurl").InnerText;
            numReadPool.Value = Convert.ToInt32(doc.SelectSingleNode("config/maxreadpool") == null ? "" : doc.SelectSingleNode("config/maxreadpool").InnerText);
            numWritePool.Value = Convert.ToInt32(doc.SelectSingleNode("config/maxwritepool") == null ? "" : doc.SelectSingleNode("config/maxwritepool").InnerText);
            numExpire.Value = Convert.ToInt32(doc.SelectSingleNode("config/Expire") == null ? "" : doc.SelectSingleNode("config/Expire").InnerText);
            chkRun.Checked = ((doc.SelectSingleNode("config/run") == null ? "" : doc.SelectSingleNode("config/run").InnerText )== "1");
            txtpassword.Text = doc.SelectSingleNode("config/password") == null ? "" : doc.SelectSingleNode("config/password").InnerText;
            numDbid.Value = Convert.ToInt32(doc.SelectSingleNode("config/dbid") == null ? "0" : doc.SelectSingleNode("config/dbid").InnerText);
        }
    }
}
