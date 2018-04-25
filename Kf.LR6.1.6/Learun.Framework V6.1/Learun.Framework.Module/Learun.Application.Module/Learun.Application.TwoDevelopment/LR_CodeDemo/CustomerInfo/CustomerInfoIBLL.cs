using Learun.Util;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-09-04 16:04
    /// 描 述：会员信息
    /// </summary>
    public interface CustomerInfoIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<LR_Demo_UserEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取LR_Demo_OrderList表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<LR_Demo_OrderListEntity> GetLR_Demo_OrderListList(string keyValue);
        /// <summary>
        /// 获取LR_Demo_User表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        LR_Demo_UserEntity GetLR_Demo_UserEntity(string keyValue);
        /// <summary>
        /// 获取LR_Demo_OrderList表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        LR_Demo_OrderListEntity GetLR_Demo_OrderListEntity(string keyValue);
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void SaveEntity(string keyValue, LR_Demo_UserEntity entity,List<LR_Demo_OrderListEntity> lR_Demo_OrderListList);
        #endregion

    }
}
