using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kf.Redis
{
    /// <summary>
    /// 操作Redis数据类型List
    /// </summary>
    public class DoRedisList : RedisBase
    {
        #region 赋值
        /// <summary>
        /// 从左侧向list中添加值
        /// </summary>
        public void LPush(string key, string value)
        {
            RedisBase.Core.PushItemToList(key, value);
        }
        /// <summary>
        /// 从左侧向list中添加值，并设置过期时间
        /// </summary>
        public void LPush(string key, string value, DateTime dt)
        {
            RedisBase.Core.PushItemToList(key, value);
            RedisBase.Core.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// 从左侧向list中添加值，设置过期时间
        /// </summary>
        public void LPush(string key, string value, TimeSpan sp)
        {
            RedisBase.Core.PushItemToList(key, value);
            RedisBase.Core.ExpireEntryIn(key, sp);
        }
        /// <summary>
        /// 从左侧向list中添加值
        /// </summary>
        public void RPush(string key, string value)
        {
            RedisBase.Core.PrependItemToList(key, value);
        }
        /// <summary>
        /// 从右侧向list中添加值，并设置过期时间
        /// </summary>    
        public void RPush(string key, string value, DateTime dt)
        {
            RedisBase.Core.PrependItemToList(key, value);
            RedisBase.Core.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// 从右侧向list中添加值，并设置过期时间
        /// </summary>        
        public void RPush(string key, string value, TimeSpan sp)
        {
            RedisBase.Core.PrependItemToList(key, value);
            RedisBase.Core.ExpireEntryIn(key, sp);
        }
        /// <summary>
        /// 添加key/value
        /// </summary>     
        public void Add(string key, string value)
        {
            RedisBase.Core.AddItemToList(key, value);
        }
        /// <summary>
        /// 添加key/value ,并设置过期时间
        /// </summary>  
        public void Add(string key, string value, DateTime dt)
        {
            RedisBase.Core.AddItemToList(key, value);
            RedisBase.Core.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// 添加key/value。并添加过期时间
        /// </summary>  
        public void Add(string key, string value, TimeSpan sp)
        {
            RedisBase.Core.AddItemToList(key, value);
            RedisBase.Core.ExpireEntryIn(key, sp);
        }
        /// <summary>
        /// 为key添加多个值
        /// </summary>  
        public void Add(string key, List<string> values)
        {
            RedisBase.Core.AddRangeToList(key, values);
        }
        /// <summary>
        /// 为key添加多个值，并设置过期时间
        /// </summary>  
        public void Add(string key, List<string> values, DateTime dt)
        {
            RedisBase.Core.AddRangeToList(key, values);
            RedisBase.Core.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// 为key添加多个值，并设置过期时间
        /// </summary>  
        public void Add(string key, List<string> values, TimeSpan sp)
        {
            RedisBase.Core.AddRangeToList(key, values);
            RedisBase.Core.ExpireEntryIn(key, sp);
        }
        #endregion
        #region 获取值
        /// <summary>
        /// 获取list中key包含的数据数量
        /// </summary>  
        public long Count(string key)
        {
            return RedisBase.Core.GetListCount(key);
        }
        /// <summary>
        /// 获取key包含的所有数据集合
        /// </summary>  
        public List<string> Get(string key)
        {
            return RedisBase.Core.GetAllItemsFromList(key);
        }
        /// <summary>
        /// 获取key中下标为star到end的值集合
        /// </summary>  
        public List<string> Get(string key, int star, int end)
        {
            return RedisBase.Core.GetRangeFromList(key, star, end);
        }
        #endregion
        #region 阻塞命令
        /// <summary>
        ///  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public string BlockingPopItemFromList(string key, TimeSpan? sp)
        {
            return RedisBase.Core.BlockingDequeueItemFromList(key, sp);
        }
        /// <summary>
        ///  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        //public ItemRef BlockingPopItemFromLists(string[] keys, TimeSpan? sp)
        //{
        //    return RedisBase.Core.BlockingPopItemFromLists(keys, sp);
        //}
        /// <summary>
        ///  阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public string BlockingDequeueItemFromList(string key, TimeSpan? sp)
        {
            return RedisBase.Core.BlockingDequeueItemFromList(key, sp);
        }
        /// <summary>
        /// 阻塞命令：从list中keys的尾部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        //public ItemRef BlockingDequeueItemFromLists(string[] keys, TimeSpan? sp)
        //{
        //    return RedisBase.Core.BlockingDequeueItemFromLists(keys, sp);
        //}
        /// <summary>
        /// 阻塞命令：从list中key的头部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        public string BlockingRemoveStartFromList(string keys, TimeSpan? sp)
        {
            return RedisBase.Core.BlockingRemoveStartFromList(keys, sp);
        }
        /// <summary>
        /// 阻塞命令：从list中key的头部移除一个值，并返回移除的值，阻塞时间为sp
        /// </summary>  
        //public ItemRef BlockingRemoveStartFromLists(string[] keys, TimeSpan? sp)
        //{
        //    return RedisBase.Core.BlockingRemoveStartFromLists(keys, sp);
        //}
        /// <summary>
        /// 阻塞命令：从list中一个fromkey的尾部移除一个值，添加到另外一个tokey的头部，并返回移除的值，阻塞时间为sp
        /// </summary>  
        //public string BlockingPopAndPushItemBetweenLists(string fromkey, string tokey, TimeSpan? sp)
        //{
        //    return RedisBase.Core.BlockingPopAndPushItemBetweenLists(fromkey, tokey, sp);
        //}
        #endregion
        #region 删除
        /// <summary>
        /// 从尾部移除数据，返回移除的数据
        /// </summary>  
        public string PopItemFromList(string key)
        {
            return RedisBase.Core.PopItemFromList(key);
        }
        /// <summary>
        /// 移除list中，key/value,与参数相同的值，并返回移除的数量
        /// </summary>  
        public long RemoveItemFromList(string key, string value)
        {
            return RedisBase.Core.RemoveItemFromList(key, value);
        }
        /// <summary>
        /// 从list的尾部移除一个数据，返回移除的数据
        /// </summary>  
        public string RemoveEndFromList(string key)
        {
            return RedisBase.Core.RemoveEndFromList(key);
        }
        /// <summary>
        /// 从list的头部移除一个数据，返回移除的值
        /// </summary>  
        public string RemoveStartFromList(string key)
        {
            return RedisBase.Core.RemoveStartFromList(key);
        }
        #endregion
        #region 其它
        /// <summary>
        /// 从一个list的尾部移除一个数据，添加到另外一个list的头部，并返回移动的值
        /// </summary>  
        public string PopAndPushItemBetweenLists(string fromKey, string toKey)
        {
            return RedisBase.Core.PopAndPushItemBetweenLists(fromKey, toKey);
        }
        #endregion
    }
}

/*
 * 展现List的阻塞功能，类似一个简单的消息队列功能
static void Main(string[] args)
        {
            string key = "zlh";
            //清空数据库
            DoRedisBase.Core.FlushAll();
            //给list赋值
            DoRedisBase.Core.PushItemToList(key, "1");
            DoRedisBase.Core.PushItemToList(key, "2");
            DoRedisBase.Core.AddItemToList(key, "3");
            DoRedisBase.Core.PrependItemToList(key, "0");
            DoRedisBase.Core.AddRangeToList(key, new List<string>() { "4", "5", "6" });
            #region 阻塞
            //启用一个线程来处理阻塞的数据集合
            new Thread(new ThreadStart(RunBlock)).Start();
            #endregion
            Console.ReadKey();
        }
        public static void RunBlock()
        {
            while (true)
            {               
               //如果key为zlh的list集合中有数据，则读出，如果没有则等待2个小时，2个小时中只要有数据进入这里就可以给打印出来，类似一个简易的消息队列功能。
               Console.WriteLine(DoRedisBase.Core.BlockingPopItemFromList("zlh", TimeSpan.FromHours(2)));
            }
        }
*/