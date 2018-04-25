using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-09-04 16:04
    /// 描 述：会员信息
    /// </summary>
    public class CustomerInfoService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<LR_Demo_UserEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.ID,
                t.Name,
                t.Sex,
                t.Age,
                t.Address
                ");
                strSql.Append("  FROM LR_Demo_User t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["Name"].IsEmpty())
                {
                    dp.Add("Name", "%" + queryParam["Name"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.Name Like @Name ");
                }
                if (!queryParam["Sex"].IsEmpty())
                {
                    dp.Add("Sex",queryParam["Sex"].ToString(), DbType.String);
                    strSql.Append(" AND t.Sex = @Sex ");
                }
                if (!queryParam["Age"].IsEmpty())
                {
                    dp.Add("Age", "%" + queryParam["Age"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.Age Like @Age ");
                }
                return this.BaseRepository().FindList<LR_Demo_UserEntity>(strSql.ToString(),dp, pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取LR_Demo_OrderList表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<LR_Demo_OrderListEntity> GetLR_Demo_OrderListList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<LR_Demo_OrderListEntity>(t=>t.U_ID == keyValue );
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取LR_Demo_User表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public LR_Demo_UserEntity GetLR_Demo_UserEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<LR_Demo_UserEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取LR_Demo_OrderList表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public LR_Demo_OrderListEntity GetLR_Demo_OrderListEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<LR_Demo_OrderListEntity>(t=>t.U_ID == keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                var lR_Demo_UserEntity = GetLR_Demo_UserEntity(keyValue); 
                db.Delete<LR_Demo_UserEntity>(t=>t.ID == keyValue);
                db.Delete<LR_Demo_OrderListEntity>(t=>t.U_ID == lR_Demo_UserEntity.ID);
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, LR_Demo_UserEntity entity,List<LR_Demo_OrderListEntity> lR_Demo_OrderListList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var lR_Demo_UserEntityTmp = GetLR_Demo_UserEntity(keyValue); 
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<LR_Demo_OrderListEntity>(t=>t.U_ID == lR_Demo_UserEntityTmp.ID);
                    foreach (LR_Demo_OrderListEntity item in lR_Demo_OrderListList)
                    {
                        item.Create();
                        item.U_ID = lR_Demo_UserEntityTmp.ID;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    foreach (LR_Demo_OrderListEntity item in lR_Demo_OrderListList)
                    {
                        item.Create();
                        item.U_ID = entity.ID;
                        db.Insert(item);
                    }
                }
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

    }
}
