using System;

namespace Learun.Util.Token
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.03.08
    /// 描 述：登录用户票据信息处理类
    /// </summary>
    public static class TokenHelper
    {
        /// <summary>
        /// 将凭证信息转化成字串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToTokenString(this TokenInfo obj)
        {
            string key = "learun_adms_" + DateTime.Now.ToString("yyyyMMdd");
            string str = obj.ToJson();
            string res = DESEncrypt.Encrypt(str, key);
            return res;
        }
        /// <summary>
        /// 将字串转换成凭证信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TokenInfo ToTokenInfo(this string str)
        {
            try
            {
                string key = "learun_adms_" + DateTime.Now.ToString("yyyyMMdd");
                string res = DESEncrypt.Decrypt(str, key);
                return res.ToObject<TokenInfo>();
            }
            catch (System.Exception)
            {
                return null;
            }

        }
    }
}
