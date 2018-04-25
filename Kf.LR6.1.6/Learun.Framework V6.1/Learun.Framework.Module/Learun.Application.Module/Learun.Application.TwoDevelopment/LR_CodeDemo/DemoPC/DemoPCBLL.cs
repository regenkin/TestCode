using Learun.Util;
using System;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-09-02 05:35
    /// 描 述：测试主从表
    /// </summary>
    public class DemoPCBLL : DemoPCIBLL
    {
        private DemoPCService demoPCService = new DemoPCService();

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
                return demoPCService.GetPageList(pagination, queryJson);
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
        /// 获取LR_Demo_TestCustmerFormc表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<LR_Demo_TestCustmerFormcEntity> GetLR_Demo_TestCustmerFormcList(string keyValue)
        {
            try
            {
                return demoPCService.GetLR_Demo_TestCustmerFormcList(keyValue);
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
        /// 获取LR_Demo_TestCustmerFormp表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public LR_Demo_TestCustmerFormpEntity GetLR_Demo_TestCustmerFormpEntity(string keyValue)
        {
            try
            {
                return demoPCService.GetLR_Demo_TestCustmerFormpEntity(keyValue);
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
        /// 获取LR_Demo_TestCustmerFormc表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public LR_Demo_TestCustmerFormcEntity GetLR_Demo_TestCustmerFormcEntity(string keyValue)
        {
            try
            {
                return demoPCService.GetLR_Demo_TestCustmerFormcEntity(keyValue);
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
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                demoPCService.DeleteEntity(keyValue);
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
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, LR_Demo_TestCustmerFormpEntity entity,List<LR_Demo_TestCustmerFormcEntity> lR_Demo_TestCustmerFormcList)
        {
            try
            {
                demoPCService.SaveEntity(keyValue, entity,lR_Demo_TestCustmerFormcList);
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
