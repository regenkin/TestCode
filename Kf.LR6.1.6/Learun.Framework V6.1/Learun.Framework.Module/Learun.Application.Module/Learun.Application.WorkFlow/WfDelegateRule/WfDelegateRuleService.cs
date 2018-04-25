using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;

namespace Learun.Application.WorkFlow
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.17
    /// 描 述：工作流委托规则
    /// </summary>
    public class WfDelegateRuleService : RepositoryFactory
    {
        #region 获取数据
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字(被委托人)</param>
        /// <returns></returns>
        public IEnumerable<WfDelegateRuleEntity> GetPageList(Pagination pagination, string keyword)
        {
            try
            {

                UserInfo userInfo = LoginUserInfo.Get();
                var expression = LinqExtensions.True<WfDelegateRuleEntity>();
                if (!userInfo.isSystem)
                {
                    string userId = userInfo.userId;
                    expression = expression.And(t => t.F_CreateUserId == userId);
                }
                if (string.IsNullOrEmpty(keyword))
                {
                    expression = expression.And(t => t.F_ToUserName.Contains(keyword));
                }
                return this.BaseRepository().FindList<WfDelegateRuleEntity>(expression, pagination);                
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
        /// 获取实体数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WfDelegateRuleEntity> GetList()
        {
            try
            {
                UserInfo userInfo = LoginUserInfo.Get();
                string userId = userInfo.userId;
                return this.BaseRepository().FindList<WfDelegateRuleEntity>(t => t.F_ToUserId == userId);       
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
        /// 删除实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete<WfDelegateRuleEntity>(t => t.F_Id == keyValue);
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
        /// 保存实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="wfDelegateRuleEntity">实体数据</param>
        public void SaveEntity(string keyValue, WfDelegateRuleEntity wfDelegateRuleEntity)
        {
            try
            {
                if (string.IsNullOrEmpty(keyValue))
                {
                    wfDelegateRuleEntity.Create();
                    this.BaseRepository().Insert(wfDelegateRuleEntity);
                }
                else
                {
                    wfDelegateRuleEntity.Modify(keyValue);
                    this.BaseRepository().Update(wfDelegateRuleEntity);
                }
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
        /// 更新委托规则状态信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="state"></param>
        public void UpdateState(string keyValue, int state)
        {
            try
            {
                WfDelegateRuleEntity wfDelegateRuleEntity = new WfDelegateRuleEntity
                {
                    F_Id = keyValue,
                    F_EnabledMark = state
                };
                this.BaseRepository().Update(wfDelegateRuleEntity);
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
    }
}
