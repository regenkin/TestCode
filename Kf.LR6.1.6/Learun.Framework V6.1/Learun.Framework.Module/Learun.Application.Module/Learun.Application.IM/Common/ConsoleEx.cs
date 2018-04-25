using System;
namespace Learun.Application.IM
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.01
    /// 描 述：日志打印函数
    /// </summary>
    public class ConsoleEx
    {
        /// <summary>
        /// 控制台屏幕输出
        /// </summary>
        /// <param name="msg">消息</param>
        public static void WriteLine(string msg)
        {
            try
            {
                Console.WriteLine("【{0}】{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg);
            }
            catch
            {
            }
        }
    }
}
