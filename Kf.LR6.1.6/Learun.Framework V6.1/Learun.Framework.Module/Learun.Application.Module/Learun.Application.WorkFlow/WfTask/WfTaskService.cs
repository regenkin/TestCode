﻿using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learun.Application.WorkFlow
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.17
    /// 描 述：任务实例
    /// </summary>
    public class WfTaskService : RepositoryFactory
    {
        #region 获取数据
        /// <summary>
        /// 获取未完成的流程实例任务列表
        /// </summary>
        /// <param name="processId">流程实例主键</param>
        /// <returns></returns>
        public IEnumerable<WfTaskEntity> GetList(string processId)
        {
            try
            {
                return this.BaseRepository().FindList<WfTaskEntity>(t => t.F_ProcessId == processId && t.F_IsFinished == 0);
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
        /// 获取当前任务节点主键
        /// </summary>
        /// <param name="processId">流程实例主键</param>
        /// <returns></returns>
        public List<string> GetCurrentNodeIds(string processId)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"SELECT
	                                t.F_NodeId
                                FROM
	                                LR_Workflow_Task t
                                WHERE
	                                t.F_IsFinished = 0 AND t.F_ProcessId = @processId
                                GROUP BY
	                                t.F_ProcessId,
	                                t.F_NodeId      
                ");
                var taskList = this.BaseRepository().FindList<WfTaskEntity>(strSql.ToString(), new { processId = processId });
                List<string> list = new List<string>();
                foreach (var item in taskList)
                {
                    list.Add(item.F_NodeId);
                }
                return list;
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
        /// 获取任务实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public WfTaskEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<WfTaskEntity>(t => t.F_Id == keyValue);
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
        /// 获取任务实体
        /// </summary>
        /// <param name="processId">流程实例主键</param>
        /// <param name="nodeId">节点主键</param>
        /// <returns></returns>
        public WfTaskEntity GetEntityUnFinish(string processId, string nodeId)
        {
            try
            {
                return this.BaseRepository().FindEntity<WfTaskEntity>(t => t.F_ProcessId == processId && t.F_NodeId == nodeId && t.F_IsFinished == 0);
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
        /// 
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public WfTaskEntity GetEntity(string processId, string nodeId)
        {
            try
            {
                return this.BaseRepository().FindEntity<WfTaskEntity>(t => t.F_ProcessId == processId && t.F_NodeId == nodeId);
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
        /// 获取未处理任务列表
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="pagination">翻页信息</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        public IEnumerable<WfProcessInstanceEntity> GetActiveList(UserInfo userInfo, Pagination pagination, string queryJson)
        {
            try
            {
                string userId = userInfo.userId;
                string postIds = "'" + userInfo.postIds.Replace(",", "','") + "'";
                string roleIds = "'" + userInfo.roleIds.Replace(",", "','") + "'";
                string companyId = userInfo.companyId;
                string departmentId = userInfo.departmentId;

                var strSql = new StringBuilder();
                strSql.Append(@"SELECT
	                                a.F_TaskId,
	                                a.F_TaskType,
	                                a.F_TaskName,
	                                p.F_Id,
	                                p.F_SchemeId,
	                                p.F_SchemeCode,
	                                p.F_SchemeName,
	                                p.F_ProcessName,
	                                p.F_ProcessLevel,
	                                p.F_EnabledMark,
	                                p.F_IsFinished,
	                                p.F_IsAgain,
	                                p.F_Description,
	                                p.F_CreateDate,
	                                p.F_CreateUserId,
	                                p.F_CreateUserName,
	                                p.F_CompanyId,
	                                p.F_DepartmentId,
	                                p.F_IsChildFlow,
	                                p.F_ProcessParentId
                                FROM
                                (
                                    SELECT
	                                   MAX (t.F_Id) AS F_TaskId,
			                           MAX (t.F_TaskType) AS F_TaskType,
			                           t.F_ProcessId,
			                           t.F_NodeName AS F_TaskName
                                    FROM
	                                    LR_Workflow_Task t WHERE t.F_IsFinished = 0 ");
                strSql.Append(" AND ( t.F_AuditorId = '1' OR ");
                strSql.Append("  t.F_AuditorId = @userId ");
                if (!string.IsNullOrEmpty(userInfo.postIds))
                {
                    strSql.Append("  OR (t.F_AuditorId in (" + postIds + ") AND t.F_CompanyId = '1' AND t.F_DepartmentId = '1' ) ");
                    strSql.Append("  OR (t.F_AuditorId in (" + postIds + ") AND t.F_CompanyId = @companyId ) ");
                    strSql.Append("  OR (t.F_AuditorId in (" + postIds + ") AND t.F_DepartmentId = @departmentId ) ");
                }
                if (!string.IsNullOrEmpty(userInfo.roleIds))
                {
                    strSql.Append("  OR (t.F_AuditorId in (" + roleIds + ") AND t.F_CompanyId = '1' AND t.F_DepartmentId = '1' ) ");
                    strSql.Append("  OR (t.F_AuditorId in (" + roleIds + ") AND t.F_CompanyId = @companyId ) ");
                    strSql.Append("  OR (t.F_AuditorId in (" + roleIds + ") AND t.F_DepartmentId = @departmentId) ");
                }
                strSql.Append(@" ) GROUP BY
	                                t.F_ProcessId,
	                                t.F_NodeId,
	                                t.F_NodeName )a LEFT JOIN LR_Workflow_ProcessInstance p ON p.F_Id = a.F_ProcessId WHERE 1=1 AND (p.F_IsFinished = 0 OR a.F_TaskType = 3) AND p.F_EnabledMark = 1 ");

                var queryParam = queryJson.ToJObject();
                DateTime startTime = DateTime.Now, endTime = DateTime.Now;

                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    startTime = queryParam["StartTime"].ToDate();
                    endTime = queryParam["EndTime"].ToDate();
                    strSql.Append(" AND ( p.F_CreateDate >= @startTime AND  p.F_CreateDate <= @endTime ) ");
                }
                string keyword = "";
                if (!queryParam["keyword"].IsEmpty())
                {
                    keyword = "%" + queryParam["keyword"].ToString() + "%";
                    strSql.Append(" AND ( p.F_ProcessName like @keyword OR  p.F_SchemeName like @keyword ) ");
                }


                return this.BaseRepository().FindList<WfProcessInstanceEntity>(strSql.ToString(), new { userId = userId, companyId = companyId, departmentId = departmentId, startTime = startTime, endTime = endTime, keyword = keyword }, pagination);
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
        /// 获取已处理任务列表
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="pagination">翻页信息</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        public IEnumerable<WfProcessInstanceEntity> GetHasList(string userId, Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append(@"SELECT
	                                t.F_Id AS F_TaskId,
	                                t.F_TaskType,
	                                t.F_NodeName AS F_TaskName,
	                                p.F_Id,
	                                p.F_SchemeId,
	                                p.F_SchemeCode,
	                                p.F_SchemeName,
	                                p.F_ProcessName,
	                                p.F_ProcessLevel,
	                                p.F_EnabledMark,
	                                p.F_IsFinished,
	                                p.F_IsAgain,
	                                p.F_Description,
	                                p.F_CreateDate,
	                                p.F_CreateUserId,
	                                p.F_CreateUserName,
	                                p.F_CompanyId,
	                                p.F_DepartmentId,
	                                p.F_IsChildFlow,
	                                p.F_ProcessParentId
                                FROM
	                                LR_Workflow_Task t
                                LEFT JOIN LR_Workflow_ProcessInstance p ON t.F_ProcessId = p.F_Id
                                WHERE
	                                t.F_IsFinished = 1 AND t.F_ModifyUserId = @userId
                ");


                var queryParam = queryJson.ToJObject();
                DateTime startTime = DateTime.Now, endTime = DateTime.Now;

                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    startTime = queryParam["StartTime"].ToDate();
                    endTime = queryParam["EndTime"].ToDate();
                    strSql.Append(" AND ( p.F_CreateDate >= @startTime AND  p.F_CreateDate <= @endTime ) ");
                }
                string keyword = "";
                if (!queryParam["keyword"].IsEmpty())
                {
                    keyword = "%" + queryParam["keyword"].ToString() + "%";
                    strSql.Append(" AND ( p.F_ProcessName like @keyword OR  p.F_SchemeName like @keyword ) ");
                }

                return this.BaseRepository().FindList<WfProcessInstanceEntity>(strSql.ToString(), new { userId = userId, startTime = startTime, endTime = endTime, keyword = keyword }, pagination);
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
        /// 保存或更新流程实例任务
        /// </summary>
        /// <param name="entity">实体</param>
        public void SaveEntity(WfTaskEntity entity)
        {
            try
            {
                 entity.Create();
                 this.BaseRepository().Insert(entity);
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
        /// 保存或更新流程实例任务
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="companyId">公司主键</param>
        /// <param name="departmentId">部门主键</param>
        public void SaveEntitys(WfTaskEntity entity, string companyId, string departmentId)
        {
            try
            {
                if (entity.auditors.Count > 0)
                {
                    foreach (var auditor in entity.auditors)
                    {
                        WfTaskEntity wfTaskEntity = new WfTaskEntity();
                        wfTaskEntity.F_ProcessId = entity.F_ProcessId;
                        wfTaskEntity.F_NodeId = entity.F_NodeId;
                        wfTaskEntity.F_NodeName = entity.F_NodeName;
                        wfTaskEntity.F_TaskType = entity.F_TaskType;
                        wfTaskEntity.F_TimeoutAction = entity.F_TimeoutAction;
                        wfTaskEntity.F_TimeoutNotice = entity.F_TimeoutNotice;
                        wfTaskEntity.F_PreviousId = entity.F_PreviousId;
                        wfTaskEntity.F_PreviousName = entity.F_PreviousName;
                        wfTaskEntity.F_CreateUserId = entity.F_CreateUserId;
                        wfTaskEntity.F_CreateUserName = entity.F_CreateUserName;

                        wfTaskEntity.F_AuditorId = auditor.auditorId;
                        wfTaskEntity.F_AuditorName = auditor.auditorName;

                        wfTaskEntity.F_CompanyId = "1";
                        wfTaskEntity.F_DepartmentId = "1";
                        if (auditor.condition == 1)
                        {
                            wfTaskEntity.F_DepartmentId = departmentId;
                        }
                        else if (auditor.condition == 2)
                        {
                            wfTaskEntity.F_CompanyId = companyId;
                        }

                        wfTaskEntity.Create();
                        this.BaseRepository().Insert(wfTaskEntity);
                    }
                }
                else
                {
                    entity.F_AuditorId = "1";
                    entity.Create();
                    this.BaseRepository().Insert(entity);
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
        /// 更新任务状态
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="state">状态 1 完成 2 关闭（会签 </param>
        public void UpdateState(string keyValue, int state)
        {
            try
            {
                WfTaskEntity wfTaskEntity = new WfTaskEntity();
                wfTaskEntity.Modify(keyValue);
                wfTaskEntity.F_IsFinished = state;
                this.BaseRepository().Update(wfTaskEntity);
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
        /// 更新任务完成状态
        /// </summary>
        /// <param name="processId">流程实例主键</param>
        /// <param name="nodeId">节点主键</param>
        /// <param name="userId">用户主键</param>
        /// <param name="userName">用户名称</param>
        public void UpdateStateByNodeId(string processId, string nodeId, string userId, string userName)
        {
            try
            {
                var list = this.BaseRepository().FindList<WfTaskEntity>(t => t.F_ProcessId == processId && t.F_IsFinished == 0 && t.F_NodeId == nodeId);
                foreach (var item in list)
                {
                    WfTaskEntity wfTaskEntity = new WfTaskEntity();
                    wfTaskEntity.Modify(item.F_Id);
                    wfTaskEntity.F_IsFinished = 1;
                    wfTaskEntity.F_ModifyUserId = userId;
                    wfTaskEntity.F_ModifyUserName = userName;
                    this.BaseRepository().Update(wfTaskEntity);
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
        #endregion
    }
}
