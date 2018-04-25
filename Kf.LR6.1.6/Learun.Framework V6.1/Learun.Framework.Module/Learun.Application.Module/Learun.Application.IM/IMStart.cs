using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Configuration;
using System.Reflection;
namespace Learun.Application.IM
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.01
    /// 描 述：im服务
    /// </summary>
    public class IMStart
    {
        /// <summary>
        /// 开启服务
        /// </summary>
        public static void Start()
        {
            string serverUrl = ConfigurationManager.AppSettings["IMUrl"].ToString();
            try
            {
                try
                {
                    using (WebApp.Start(serverUrl, builder =>
                    {
                        builder.Map("/signalr", map =>
                        {
                            // Setup the cors middleware to run before SignalR.
                            // By default this will allow all origins. You can 
                            // configure the set of origins and/or http verbs by
                            // providing a cors options with a different policy.
                            map.UseCors(CorsOptions.AllowAll);
                            var hubConfiguration = new HubConfiguration
                            {
                                // You can enable JSONP by uncommenting line below.
                                // JSONP requests are insecure but some older browsers (and some
                                // versions of IE) require JSONP to work cross domain
                                EnableJSONP = true
                            };
                            // Run the SignalR pipeline. We're not using MapSignalR
                            // since this branch is already runs under the "/signalr"
                            // path.
                            map.RunSignalR(hubConfiguration);
                        });
                        builder.MapSignalR();

                    }))
                    {
                        ConsoleEx.WriteLine(string.Format("服务开启成功,运行在{0}", serverUrl));
                    }
                }
                catch (TargetInvocationException)
                {
                    ConsoleEx.WriteLine(string.Format("服务开启失败. 已经有一个服务运行在{0}", serverUrl));
                }
            }
            catch (Exception)
            {
                ConsoleEx.WriteLine(string.Format("服务开启异常,服务地址{0}", serverUrl));
            }
            finally
            {
                Console.ReadLine();
            }

        }
    }
}
