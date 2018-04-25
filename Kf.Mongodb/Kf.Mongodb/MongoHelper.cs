using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace Kf.Mongodb
{
    public class MongodbHelper
    {
        private static MongoDatabase mdb = MongoCon.mongo;
        #region 新增
        /// <summary>  
        /// 新增  
        /// </summary>   
        public static Boolean Insert(String collectionName, BsonDocument document)
        {
            MongoCollection<BsonDocument> collection = mdb.GetCollection<BsonDocument>(collectionName);
            try
            {
                collection.Insert(document);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>  
        /// 新增  
        /// </summary>   
        public static Boolean Insert<T>(String collectionName, T t)
        {
            var collection = mdb.GetCollection<T>(collectionName);
            try
            {
                collection.Insert(t);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>  
        /// 批量新增  
        /// </summary>
        public static WriteConcernResult Insert<T>(String collectionName, List<T> list)
        {
            var collection = mdb.GetCollection<T>(collectionName);
            try
            {
                return collection.Insert(list);
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region 查询
        /// <summary>  
        /// 查询单个对象  
        /// </summary>    
        public static T GetModel<T>(String collectionName, IMongoQuery query)
        {

            MongoCollection<T> collection = mdb.GetCollection<T>(collectionName);
            try
            {
                return collection.FindOneAs<T>(query);
            }
            catch
            {
                return default(T);
            }
        }
        /// <summary>
        /// 查询对象集合
        /// </summary>
        public static List<T> GetList<T>(String collectionName, IMongoQuery query)
        {
            MongoCollection<T> collection = mdb.GetCollection<T>(collectionName);
            try
            {
                return collection.FindAs<T>(query).ToList();
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 查询对象集合
        /// </summary>
        public static List<T> GetList<T>(String collectionName, IMongoQuery query, int top)
        {
            MongoCollection<T> collection = mdb.GetCollection<T>(collectionName);
            try
            {
                return collection.FindAs<T>(query).SetLimit(top).ToList();
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 查询对象集合
        /// </summary>
        public static List<T> GetList<T>(String collectionName, IMongoQuery query, string sort, bool isDesc)
        {
            MongoCollection<T> collection = mdb.GetCollection<T>(collectionName);
            try
            {
                if (isDesc)
                {
                    return collection.FindAs<T>(query).SetSortOrder(SortBy.Descending(sort)).ToList();
                }
                else
                {
                    return collection.FindAs<T>(query).SetSortOrder(SortBy.Ascending(sort)).ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 查询对象集合
        /// </summary>
        public static List<T> GetList<T>(String collectionName, IMongoQuery query, string[] sort, bool isDesc)
        {
            MongoCollection<T> collection = mdb.GetCollection<T>(collectionName);
            try
            {
                if (isDesc)
                {
                    return collection.FindAs<T>(query).SetSortOrder(SortBy.Descending(sort)).ToList();
                }
                else
                {
                    return collection.FindAs<T>(query).SetSortOrder(SortBy.Ascending(sort)).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 查询对象集合
        /// </summary>
        public static List<T> GetList<T>(String collectionName, IMongoQuery query, string sort, bool isDesc, int top)
        {
            MongoCollection<T> collection = mdb.GetCollection<T>(collectionName);
            try
            {
                if (isDesc)
                {
                    return collection.FindAs<T>(query).SetSortOrder(SortBy.Descending(sort)).SetLimit(top).ToList();
                }
                else
                {
                    return collection.FindAs<T>(query).SetSortOrder(SortBy.Ascending(sort)).SetLimit(top).ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 查询对象集合
        /// </summary>
        public static List<T> GetList<T>(String collectionName, IMongoQuery query, string[] sort, bool isDesc, int top)
        {
            MongoCollection<T> collection = mdb.GetCollection<T>(collectionName);
            try
            {
                if (isDesc)
                {
                    return collection.FindAs<T>(query).SetSortOrder(SortBy.Descending(sort)).SetLimit(top).ToList();
                }
                else
                {
                    return collection.FindAs<T>(query).SetSortOrder(SortBy.Ascending(sort)).SetLimit(top).ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 分页查询
        /// </summary>       
        public static List<T> GetPageList<T>(String collectionName, IMongoQuery query, string sort, bool isDesc, int index, int pageSize, out long rows)
        {
            MongoCollection<T> collection = mdb.GetCollection<T>(collectionName);
            try
            {
                rows = collection.FindAs<T>(query).Count();
                if (isDesc)
                {
                    return collection.FindAs<T>(query).SetSortOrder(SortBy.Descending(sort)).SetSkip(index).SetLimit(pageSize).ToList();
                }
                else
                {
                    return collection.FindAs<T>(query).SetSortOrder(SortBy.Ascending(sort)).SetSkip(index).SetLimit(pageSize).ToList();
                }
            }
            catch
            {
                rows = 0;
                return null;
            }
        }
        /// <summary>
        /// 分页查询
        /// </summary>       
        public static List<T> GetPageList<T>(String collectionName, IMongoQuery query, string[] sort, bool isDesc, int index, int pageSize, out long rows)
        {
            MongoCollection<T> collection = mdb.GetCollection<T>(collectionName);
            try
            {
                rows = collection.FindAs<T>(query).Count();
                if (isDesc)
                {
                    return collection.FindAs<T>(query).SetSortOrder(SortBy.Descending(sort)).SetSkip(index).SetLimit(pageSize).ToList();
                }
                else
                {
                    return collection.FindAs<T>(query).SetSortOrder(SortBy.Ascending(sort)).SetSkip(index).SetLimit(pageSize).ToList();
                }
            }
            catch
            {
                rows = 0;
                return null;
            }
        }
        #endregion
        #region 修改
        /// <summary>  
        /// 修改  
        /// </summary>    
        public static WriteConcernResult Update(String collectionName, IMongoQuery query, QueryDocument update)
        {
            MongoCollection<BsonDocument> collection = mdb.GetCollection<BsonDocument>(collectionName);
            try
            {
                var new_doc = new UpdateDocument() { { "$set", update } };
                //UpdateFlags设置为Multi时，可批量修改
                var result = collection.Update(query, new_doc, UpdateFlags.Multi);
                return result;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region 移除
        /// <summary>  
        /// 移除匹配的集合
        /// </summary>  
        public static Boolean Remove(String collectionName, IMongoQuery query)
        {

            MongoCollection<BsonDocument> collection = mdb.GetCollection<BsonDocument>(collectionName);
            try
            {
                collection.Remove(query);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>  
        /// 移除所有集合  
        /// </summary>  
        public static Boolean RemoveAll(String collectionName)
        {

            MongoCollection<BsonDocument> collection = mdb.GetCollection<BsonDocument>(collectionName);
            try
            {
                collection.RemoveAll();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region 其它
        /// <summary>
        /// 是否存在
        /// </summary>      
        public static bool IsExist(string collectionName)
        {
            MongoCollection<BsonDocument> collection = mdb.GetCollection<BsonDocument>(collectionName);
            try
            {
                return collection.Exists();
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 总数
        /// </summary>      
        public static long Count(string collectionName)
        {
            MongoCollection<BsonDocument> collection = mdb.GetCollection<BsonDocument>(collectionName);
            try
            {
                return collection.Count();
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 总数
        /// </summary>    
        public static long Count(string collectionName, IMongoQuery query)
        {
            MongoCollection<BsonDocument> collection = mdb.GetCollection<BsonDocument>(collectionName);
            try
            {
                return collection.Count(query);
            }
            catch
            {
                return 0;
            }
        }
        #endregion
    }
}