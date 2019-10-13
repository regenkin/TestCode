using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CsharpHttpHelper;
using System.Net;
using CsharpHttpHelper.Enum;
using CsharpHttpHelper.Item;
using System.IO;

namespace CsharpHttpHelper_Demo
{
    public partial class HttpPostFile_Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var url = "http://localhost:9100/document/fileupload/kinfar";
            var log1 = @"D:\kinfar_logo.png";
            var formDatas = new List<FormItemModel>();
            //添加文件
            formDatas.Add(new FormItemModel()
            {
                Key = "file1",
                Value = "",
                FileName = $"kinfar_logo.png",
                FileContent = File.OpenRead(log1)
            }
            //formDatas.Add(new FormItemModel()
            //{
            //    Key = "log2",
            //    Value = "",
            //    FileName = "log2.txt",
            //    FileContent = File.OpenRead(log2)
            //});
            ////添加文本
            //formDatas.Add(new FormItemModel()
            //{
            //    Key = "id",
            //    Value = "id-test-id-test-id-test-id-test-id-test-"
            //});
            //formDatas.Add(new FormItemModel()
            //{
            //    Key = "name",
            //    Value = "name-test-name-test-name-test-name-test-name-test-"
            //}
            );
            //提交表单
            var result = CsharpHttpHelper.PostFileFormData.PostForm(url, formDatas);
            this.Response.Write(result);
        }
    }
}