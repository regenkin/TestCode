using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.Util;
using System;
using System.Collections.Generic;

namespace Learun.Application.Base.OrganizationModule
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.17
    /// 描 述：部门管理
    /// </summary>
    public class DepartmentBLL : DepartmentIBLL
    {
        #region 属性
        private DepartmentService departmentService = new DepartmentService();
        #endregion

        #region 缓存定义
        private ICache cache = CacheFactory.CaChe();
        private string cacheKey = "learun_adms_department_"; // +加公司主键
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取部门列表信息(根据公司Id)
        /// </summary>
        /// <param name="companyId">公司Id</param>
        /// <returns></returns>
        public List<DepartmentEntity> GetList(string companyId)
        {
            try
            {
                List<DepartmentEntity> list = cache.Read<List<DepartmentEntity>>(cacheKey + companyId, CacheId.department);
                if (list == null)
                {
                    list = (List<DepartmentEntity>)departmentService.GetList(companyId);
                    cache.Write<List<DepartmentEntity>>(cacheKey + companyId, list, CacheId.department);
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
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 获取部门列表信息(根据公司Id)
        /// </summary>
        /// <param name="companyId">公司Id</param>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        public List<DepartmentEntity> GetList(string companyId, string keyWord)
        {
            try
            {
                List<DepartmentEntity> list = GetList(companyId);
                if (!string.IsNullOrEmpty(keyWord))
                {
                    list = list.FindAll(t => t.F_FullName.Contains(keyWord) || t.F_EnCode.Contains(keyWord) || t.F_ShortName.Contains(keyWord));
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
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 获取部门数据实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public DepartmentEntity GetEntity(string keyValue) {
            try
            {
                return departmentService.GetEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 获取部门数据实体
        /// </summary>
        /// <param name="companyId">公司主键</param>
        /// <param name="departmentId">部门主键</param>
        /// <returns></returns>
        public DepartmentEntity GetEntity(string companyId, string departmentId) {
            try
            {
                return GetList(companyId).Find(t => t.F_DepartmentId.Equals(departmentId));
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <param name="companyId">公司id</param>
        /// <param name="parentId">父级id</param>
        /// <returns></returns>
        public List<TreeModel> GetTree(string companyId,string parentId)
        {
            try
            {
                if (string.IsNullOrEmpty(companyId)) {// 如果公司主键没有的话，需要加载公司信息
                    return new List<TreeModel>();
                }

                List<DepartmentEntity> list = GetList(companyId);
                if (!string.IsNullOrEmpty(parentId))
                {
                    list = list.FindAll(t => t.F_ParentId.Equals(parentId));
                }
                List<TreeModel> treeList = new List<TreeModel>();
                foreach (var item in list) {
                    TreeModel node = new TreeModel();
                    node.id = item.F_DepartmentId;
                    node.text = item.F_FullName;
                    node.value = item.F_DepartmentId;
                    node.showcheck = false;
                    node.checkstate = 0;
                    node.isexpand = true;
                    node.parentId = item.F_ParentId;
                    
                    treeList.Add(node);
                }
                return treeList.ToTree();
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <param name="companylist">公司数据列表</param>
        /// <returns></returns>
        public List<TreeModel> GetTree(List<CompanyEntity> companylist)
        {
            try
            {
                List<TreeModel> treeList = new List<TreeModel>();
                foreach (var companyone in companylist)
                {
                    List<TreeModel> departmentTree = GetTree(companyone.F_CompanyId, "");
                    if (departmentTree.Count > 0)
                    {
                        TreeModel node = new TreeModel();
                        node.id = companyone.F_CompanyId;
                        node.text = companyone.F_FullName;
                        node.value = companyone.F_CompanyId;
                        node.showcheck = false;
                        node.checkstate = 0;
                        node.isexpand = true;
                        node.parentId = "0";
                        node.hasChildren = true;
                        node.ChildNodes = departmentTree;
                        node.complete = true;
                        treeList.Add(node);
                    }
                }
                return treeList;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 虚拟删除部门信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void VirtualDelete(string keyValue)
        {
            try
            {
                DepartmentEntity entity = GetEntity(keyValue);
                cache.Remove(cacheKey + entity.F_CompanyId, CacheId.department);
                departmentService.VirtualDelete(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 保存部门信息（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="departmentEntity">部门实体</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, DepartmentEntity departmentEntity)
        {
            try
            {
                cache.Remove(cacheKey + departmentEntity.F_CompanyId, CacheId.department);
                departmentService.SaveEntity(keyValue, departmentEntity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        #endregion
    }
}
