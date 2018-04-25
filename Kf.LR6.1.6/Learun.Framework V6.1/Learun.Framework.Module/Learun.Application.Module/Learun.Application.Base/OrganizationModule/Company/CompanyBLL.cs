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
    /// 描 述：公司管理
    /// </summary>
    public class CompanyBLL : CompanyIBLL
    {
        #region 属性
        private CompanyService companyService = new CompanyService();        
        #endregion

        #region 缓存定义
        private ICache cache = CacheFactory.CaChe();
        private string cacheKey = "learun_adms_company";
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取公司列表数据
        /// </summary>
        /// <returns></returns>
        public List<CompanyEntity> GetList()
        {
            try
            {
                List<CompanyEntity> list = cache.Read<List<CompanyEntity>>(cacheKey, CacheId.company);
                if (list == null)
                {
                    list = (List<CompanyEntity>)companyService.GetList();
                    cache.Write<List<CompanyEntity>>(cacheKey, list, CacheId.company);
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
        /// 获取公司列表数据
        /// </summary>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        public List<CompanyEntity> GetList(string keyWord)
        {
            try
            {
                List<CompanyEntity> list = GetList();
                if (!string.IsNullOrEmpty(keyWord)) {
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
        /// 获取公司信息实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public CompanyEntity GetEntity(string keyValue)
        {
            try
            {
                List<CompanyEntity> list = GetList();
                CompanyEntity entity = list.Find(t => t.F_CompanyId.Equals(keyValue));
                return entity;
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
        /// <param name="parentId">父级id</param>
        /// <returns></returns>
        public List<TreeModel> GetTree(string parentId) {
            try
            {
                List<CompanyEntity> list = GetList();
                if (string.IsNullOrEmpty(parentId)) {
                    list = list.FindAll(t => t.F_ParentId.Equals(parentId));
                }
                List<TreeModel> treeList = new List<TreeModel>();
                foreach (var item in list) {
                    TreeModel node = new TreeModel();
                    node.id = item.F_CompanyId;
                    node.text = item.F_FullName;
                    node.value = item.F_CompanyId;
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
        #endregion

        #region 提交数据
        /// <summary>
        /// 虚拟删除公司信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void VirtualDelete(string keyValue)
        {
            try
            {
                cache.Remove(cacheKey, CacheId.company);
                companyService.VirtualDelete(keyValue);
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
        /// 保存公司信息（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="companyEntity">公司实体</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, CompanyEntity companyEntity)
        {
            try
            {
                cache.Remove(cacheKey, CacheId.company);
                companyService.SaveEntity(keyValue, companyEntity);
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
