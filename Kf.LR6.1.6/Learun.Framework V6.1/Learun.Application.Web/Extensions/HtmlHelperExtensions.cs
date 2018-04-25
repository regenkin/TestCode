using Learun.Application.Base.SystemModule;
using Learun.Util;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Learun.Application.Web
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.03.07
    /// 描 述：对HtmlHelper类进行扩展
    /// </summary>
    public static class HtmlHelperExtensions
    {

        /// <summary>
        ///  加载js文件
        /// </summary>
        /// <param name="htmlHelper">需要扩展对象</param>
        /// <param name="jsFile">文件路径</param>
        /// <returns></returns>
        public static MvcHtmlString RenderJsFile(this HtmlHelper htmlHelper,params string[] jsFiles)
        {
            StringBuilder content = new StringBuilder();
            string executionFilePath = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.Replace("~/", "");
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (!string.IsNullOrEmpty(executionFilePath))
            {
                int startindex = url.LastIndexOf(executionFilePath);
                url = url.Remove(startindex, url.Length - startindex);
            }
            string jsFormat = "<script type=\"text/javascript\" src=\"{0}\"></script>";
            string jsFile = "";
            foreach (string file in jsFiles)
            {
                if (jsFile != "")
                {
                    jsFile += ",";
                }
                jsFile += file;
            }
            content.AppendFormat(jsFormat, url +"Utility/GetJSFile?filePath=" + jsFile);
            return new MvcHtmlString(content.ToString());
        }
        /// <summary>
        /// 往页面中写入js文件
        /// </summary>
        /// <param name="htmlHelper">需要扩展对象</param>
        /// <param name="jsFiles">文件路径</param>
        /// <returns></returns>
        public static MvcHtmlString AppendJsFile(this HtmlHelper htmlHelper, params string[] jsFiles)
        {
            StringBuilder content = new StringBuilder();
            string jsFormat = "<script>{0}</script>";
            string jsStr = JsCssHelper.ReadJSFile(jsFiles);
            content.AppendFormat(jsFormat, jsStr);
            return new MvcHtmlString(content.ToString());
        }

        /// <summary>
        ///  加载css文件
        /// </summary>
        /// <param name="htmlHelper">需要扩展对象</param>
        /// <param name="jsFile">文件路径</param>
        /// <returns></returns>
        public static MvcHtmlString RenderCssFile(this HtmlHelper htmlHelper, params string[] cssFiles)
        {
            StringBuilder content = new StringBuilder();
            string executionFilePath = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.Replace("~/", "");
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (!string.IsNullOrEmpty(executionFilePath))
            {
                int startindex = url.LastIndexOf(executionFilePath);
                url = url.Remove(startindex, url.Length - startindex);
            }
            string cssFile = "";
            foreach (string file in cssFiles)
            {
                if (cssFile != "")
                {
                    cssFile += ",";
                }
                cssFile += file;
            }

            string cssFormat = "<link href=\"{0}\" rel=\"stylesheet\" />";
            content.AppendFormat(cssFormat, url + "Utility/GetCssFile?filePath=" + cssFile);
            return new MvcHtmlString(content.ToString());
        }
        /// <summary>
        /// 往页面中写入css样式
        /// </summary>
        /// <param name="htmlHelper">需要扩展对象</param>
        /// <param name="cssFiles">文件路径</param>
        /// <returns></returns>
        public static MvcHtmlString AppendCssFile(this HtmlHelper htmlHelper, params string[] cssFiles)
        {
            StringBuilder content = new StringBuilder();
            string cssFormat = "<style>{0}</style>";
            string cssStr = JsCssHelper.ReadCssFile(cssFiles);
            content.AppendFormat(cssFormat, cssStr);
            return new MvcHtmlString(content.ToString());
        }

        #region 权限模块
        /// <summary>
        /// 获取当前页面的按钮
        /// </summary>
        /// <returns></returns>
        public static MvcHtmlString GetModuleButtonList(this HtmlHelper htmlHelper)
        {
            string currentUrl = (string)WebHelper.GetHttpItems("currentUrl");

            List<ModuleButtonEntity> buttonList =  new ModuleBLL().GetButtonListByUrl(currentUrl);
            Dictionary<string, string> dicButton = new Dictionary<string, string>();
            foreach (var item in buttonList)
            {
                if (!dicButton.ContainsKey(item.F_EnCode))
                {
                    dicButton.Add(item.F_EnCode, item.F_FullName);
                }
            }
            string strButtonList = dicButton.ToJson();
            return new MvcHtmlString("<script>var lrMouduleButtonList=" + strButtonList + "</script>");
        }
        /// <summary>
        /// 获取当前页面的列表
        /// </summary>
        /// <returns></returns>
        public static MvcHtmlString GetModuleColumnList(this HtmlHelper htmlHelper)
        {
            string currentUrl = (string)WebHelper.GetHttpItems("currentUrl");

            List<ModuleColumnEntity> columnList = new ModuleBLL().GetColumnListByUrl(currentUrl);
            Dictionary<string, string> dicColumn = new Dictionary<string, string>();
            foreach (var item in columnList)
            {
                if (!dicColumn.ContainsKey(item.F_EnCode))
                {
                    dicColumn.Add(item.F_EnCode.ToLower(), item.F_FullName);
                }
            }

            string strColumnList = dicColumn.ToJson();
            return new MvcHtmlString("<script>var lrMouduleColumnList=" + strColumnList + "</script>");
        }
        #endregion
    }
}