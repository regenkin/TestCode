using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CsharpHttpHelper;
using System.Net;
using System.Text;
using CsharpHttpHelper.Enum;

namespace CsharpHttpHelper_Demo
{
    public partial class HttpGet_Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////创建Httphelper对象
            //HttpHelper http = new HttpHelper();
            ////创建Httphelper参数对象
            //HttpItem item = new HttpItem()
            //{
            //    URL = "http://www.sufeinet.com",//URL     必需项    
            //    IsReset=true
            //};
            ////开始异步调用
            //http.BeginInvokeGetHtml(item, new ResultHandler(SetHtml));


            //只返回Byte
            HttpHelper http = new HttpHelper();
            //创建Httphelper参数对象
            HttpItem item = new HttpItem()
            {
                URL = "http://www.sufeinet.com",//URL     必需项    
                 ResultType=ResultType.Byte
            };

            HttpResult result = http.GetHtml(item);
            //获取请请求的Html
            string html = result.Html;

            byte[] b = result.ResultByte;


            //只返回Html
             item = new HttpItem()
            {
                URL = "http://www.sufeinet.com",//URL     必需项    
                IsReset = true,
                ResultType = ResultType.String
            };

             result = http.GetHtml(item);
            //获取请请求的Html
             html = result.Html;
             
            b = result.ResultByte;

            //同时返回Html和Byte
            item = new HttpItem()
            {
                URL = "http://www.sufeinet.com",//URL     必需项    
                IsReset = true,
                ResultType = ResultType.StringByte
            };

            result = http.GetHtml(item);
            //获取请请求的Html
            html = result.Html;

            b = result.ResultByte;
          
        }
        /// <summary>
        /// 在异步执行完成后要回调的方法
        /// </summary>
        /// <param name="result"></param>
        public void SetHtml(HttpResult result)
        {
            //获取请请求的Html
            string html = result.Html;
            //获取请求的Cookie
            string cookie = result.Cookie;

            //状态码
            HttpStatusCode code = result.StatusCode;
            //状态描述
            string Des = result.StatusDescription;
            if (code == HttpStatusCode.OK)
            {
                //状态为200
            }
        }
    }
}