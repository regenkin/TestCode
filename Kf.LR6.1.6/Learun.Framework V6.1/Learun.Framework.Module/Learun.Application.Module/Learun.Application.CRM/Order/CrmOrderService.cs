﻿using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learun.Application.CRM
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.03.09
    /// 描 述：订单管理
    /// </summary>
    public class CrmOrderService :RepositoryFactory
    {
        private string fieldSql;
        public CrmOrderService()
        {
            fieldSql = @" 
                    t.F_OrderId,
                    t.F_CustomerId,
                    t.F_SellerId,
                    t.F_OrderDate,
                    t.F_OrderCode,
                    t.F_DiscountSum,
                    t.F_Accounts,
                    t.F_ReceivedAmount,
                    t.F_PaymentDate,
                    t.F_PaymentMode,
                    t.F_PaymentState,
                    t.F_SaleCost,
                    t.F_AbstractInfo,
                    t.F_ContractCode,
                    t.F_ContractFile,
                    t.F_SortCode,
                    t.F_DeleteMark,
                    t.F_EnabledMark,
                    t.F_Description,
                    t.F_CreateDate,
                    t.F_CreateUserId,
                    t.F_CreateUserName,
                    t.F_ModifyDate,
                    t.F_ModifyUserId,
                    t.F_ModifyUserName
                    ";
        }
        #region 获取数据
        /// <summary>
        /// 订单列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CrmOrderEntity> GetPageList(Pagination pagination, string queryJson, string custmerQuerySql)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT " + fieldSql + " FROM LR_CRM_Order t WHERE 1=1  ");

                var queryParam = queryJson.ToJObject();
                DateTime startTime = new DateTime(), endTime = new DateTime();
                //单据日期
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    startTime = queryParam["StartTime"].ToDate();
                    endTime = queryParam["EndTime"].ToDate().AddDays(1);


                    strSql.Append(" AND ( t.F_OrderDate >= @startTime AND t.F_OrderDate <= @endTime ) ");
                }

                if (!string.IsNullOrEmpty(custmerQuerySql))
                {
                    strSql.Append(" AND " + custmerQuerySql);
                }

                return this.BaseRepository().FindList<CrmOrderEntity>(strSql.ToString(), new { startTime = startTime, endTime = endTime });
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
        /// 获取订单信息主键
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public CrmOrderEntity GetCrmOrderEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<CrmOrderEntity>(keyValue);
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
        /// 获取订单产品明细数据
        /// </summary>
        /// <param name="orderId">订单主键</param>
        /// <returns></returns>
        public IEnumerable<CrmOrderProductEntity> GetCrmOrderProductEntity(string orderId)
        {
            try
            {
                return this.BaseRepository().FindList<CrmOrderProductEntity>(t => t.F_OrderId == orderId);
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
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void DeleteEntity(string keyValue)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                db.Delete<CrmOrderEntity>(t => t.F_OrderId.Equals(keyValue));
                db.Delete<CrmOrderProductEntity>(t => t.F_OrderId.Equals(keyValue));
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
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="crmOrderEntity">实体对象</param>
        /// <param name="CrmOrderProductEntity">明细实体对象</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, CrmOrderEntity crmOrderEntity, List<CrmOrderProductEntity> crmOrderProductList)
        {
            IRepository db = new RepositoryFactory().BaseRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //主表
                    crmOrderEntity.Modify(keyValue);
                    db.Update(crmOrderEntity);
                    //明细
                    db.Delete<CrmOrderProductEntity>(t => t.F_OrderId.Equals(keyValue));
                    foreach (CrmOrderProductEntity crmOrderProductEntity in crmOrderProductList)
                    {
                        crmOrderProductEntity.F_OrderId = crmOrderEntity.F_OrderId;
                        db.Insert(crmOrderProductEntity);
                    }
                }
                else
                {
                    //主表
                    crmOrderEntity.Create();
                    db.Insert(crmOrderEntity);
                    //coderuleService.UseRuleSeed(orderEntity.F_CreateUserId, "", ((int)CodeRuleEnum.Customer_OrderCode).ToString(), db);//占用单据号
                    //明细
                    foreach (CrmOrderProductEntity crmOrderProductEntity in crmOrderProductList)
                    {
                        crmOrderProductEntity.Create();
                        crmOrderProductEntity.F_OrderId = crmOrderEntity.F_OrderId;
                        db.Insert(crmOrderProductEntity);
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
