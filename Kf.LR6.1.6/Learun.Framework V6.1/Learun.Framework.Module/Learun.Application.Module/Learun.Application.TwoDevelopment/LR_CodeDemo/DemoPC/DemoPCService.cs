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
    /// 日 期：2017-09-02 05:35
    /// 描 述：测试主从表
    /// </summary>
    public class DemoPCService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<LR_Demo_TestCustmerFormpEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_Id,
                t.F_Name,
                t.F_Begin,
                t.F_End,
                t.F_Kind,
                t.F_File,
                t.F_Des
                ");
                strSql.Append("  FROM LR_Demo_TestCustmerFormp t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_Begin >= @startTime AND t.F_Begin <= @endTime ) ");
                }
                if (!queryParam["F_Name"].IsEmpty())
                {
                    dp.Add("F_Name", "%" + queryParam["F_Name"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Name Like @F_Name ");
                }
                if (!queryParam["F_Kind"].IsEmpty())
                {
                    dp.Add("F_Kind",queryParam["F_Kind"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Kind = @F_Kind ");
                }
                return this.BaseRepository().FindList<LR_Demo_TestCustmerFormpEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取LR_Demo_TestCustmerFormc表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<LR_Demo_TestCustmerFormcEntity> GetLR_Demo_TestCustmerFormcList(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindList<LR_Demo_TestCustmerFormcEntity>(t=>t.F_ParentId == keyValue );
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
        /// 获取LR_Demo_TestCustmerFormp表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public LR_Demo_TestCustmerFormpEntity GetLR_Demo_TestCustmerFormpEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<LR_Demo_TestCustmerFormpEntity>(keyValue);
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
        /// 获取LR_Demo_TestCustmerFormc表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public LR_Demo_TestCustmerFormcEntity GetLR_Demo_TestCustmerFormcEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<LR_Demo_TestCustmerFormcEntity>(t=>t.F_ParentId == keyValue);
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
                var lR_Demo_TestCustmerFormpEntity = GetLR_Demo_TestCustmerFormpEntity(keyValue); 
                db.Delete<LR_Demo_TestCustmerFormpEntity>(t=>t.F_Id == keyValue);
                db.Delete<LR_Demo_TestCustmerFormcEntity>(t=>t.F_ParentId == lR_Demo_TestCustmerFormpEntity.F_Id);
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
        public void SaveEntity(string keyValue, LR_Demo_TestCustmerFormpEntity entity,List<LR_Demo_TestCustmerFormcEntity> lR_Demo_TestCustmerFormcList)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    var lR_Demo_TestCustmerFormpEntityTmp = GetLR_Demo_TestCustmerFormpEntity(keyValue); 
                    entity.Modify(keyValue);
                    db.Update(entity);
                    db.Delete<LR_Demo_TestCustmerFormcEntity>(t=>t.F_ParentId == lR_Demo_TestCustmerFormpEntityTmp.F_Id);
                    foreach (LR_Demo_TestCustmerFormcEntity item in lR_Demo_TestCustmerFormcList)
                    {
                        item.Create();
                        item.F_ParentId = lR_Demo_TestCustmerFormpEntityTmp.F_Id;
                        db.Insert(item);
                    }
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                    foreach (LR_Demo_TestCustmerFormcEntity item in lR_Demo_TestCustmerFormcList)
                    {
                        item.Create();
                        item.F_ParentId = entity.F_Id;
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
