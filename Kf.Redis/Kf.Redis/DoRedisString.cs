﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kf.Redis
{
    /// <summary>
    /// 操作Redis数据类型String
    /// </summary>
    public class DoRedisString : RedisBase
    {
        #region 赋值
        /// <summary>
        /// 设置key的value
        /// </summary>
        public bool Set(string key, string value)
        {
            return RedisBase.Core.Set<string>(key, value);
        }
        /// <summary>
        /// 设置key的value并设置过期时间
        /// </summary>
        public bool Set(string key, string value, DateTime dt)
        {
            return RedisBase.Core.Set<string>(key, value, dt);
        }
        /// <summary>
        /// 设置key的value并设置过期时间
        /// </summary>
        public bool Set(string key, string value, TimeSpan sp)
        {
            return RedisBase.Core.Set<string>(key, value, sp);
        }
        /// <summary>
        /// 设置多个key/value
        /// </summary>
        public void Set(Dictionary<string, string> dic)
        {
            RedisBase.Core.SetAll(dic);
        }

        #endregion
        #region 追加
        /// <summary>
        /// 在原有key的value值之后追加value
        /// </summary>
        public long Append(string key, string value)
        {
            return RedisBase.Core.AppendToValue(key, value);
        }
        #endregion
        #region 获取值
        /// <summary>
        /// 获取key的value值
        /// </summary>
        public string Get(string key)
        {
            return RedisBase.Core.GetValue(key);
        }
        /// <summary>
        /// 获取多个key的value值
        /// </summary>
        public List<string> Get(List<string> keys)
        {
            return RedisBase.Core.GetValues(keys);
        }
        /// <summary>
        /// 获取多个key的value值
        /// </summary>
        public List<T> Get<T>(List<string> keys)
        {
            return RedisBase.Core.GetValues<T>(keys);
        }
        #endregion
        #region 获取旧值赋上新值
        /// <summary>
        /// 获取旧值赋上新值
        /// </summary>
        public string GetAndSetValue(string key, string value)
        {
            return RedisBase.Core.GetAndSetEntry(key, value);
        }
        #endregion
        #region 辅助方法
        /// <summary>
        /// 获取值的长度
        /// </summary>
        public long GetCount(string key)
        {
            return RedisBase.Core.GetSetCount(key);
        }
        /// <summary>
        /// 自增1，返回自增后的值
        /// </summary>
        public long Incr(string key)
        {
            return RedisBase.Core.IncrementValue(key);
        }
        /// <summary>
        /// 自增count，返回自增后的值
        /// </summary>
        public long IncrBy(string key, int count)
        {
            return RedisBase.Core.IncrementValueBy(key, count);
        }
        /// <summary>
        /// 自减1，返回自减后的值
        /// </summary>
        public long Decr(string key)
        {
            return RedisBase.Core.DecrementValue(key);
        }
        /// <summary>
        /// 自减count ，返回自减后的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public long DecrBy(string key, int count)
        {
            return RedisBase.Core.DecrementValueBy(key, count);
        }
        #endregion
    }
}
