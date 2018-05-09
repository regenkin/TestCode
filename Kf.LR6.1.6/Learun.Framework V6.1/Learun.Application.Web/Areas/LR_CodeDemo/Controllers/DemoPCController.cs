﻿using Learun.Util;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-09-02 05:35
    /// 描 述：测试主从表
    /// </summary>
    public class DemoPCController : MvcControllerBase
    {
        private DemoPCIBLL demoPCIBLL = new DemoPCBLL();

        #region 视图功能

        /// <summary>
        /// 主页面
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
             return View();
        }
        /// <summary>
        /// 表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
             return View();
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = demoPCIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var LR_Demo_TestCustmerFormpData = demoPCIBLL.GetLR_Demo_TestCustmerFormpEntity( keyValue );
            var LR_Demo_TestCustmerFormcData = demoPCIBLL.GetLR_Demo_TestCustmerFormcList( LR_Demo_TestCustmerFormpData.F_Id );
            var jsonData = new {
                LR_Demo_TestCustmerFormpData = LR_Demo_TestCustmerFormpData,
                LR_Demo_TestCustmerFormcData = LR_Demo_TestCustmerFormcData,
            };
            return Success(jsonData);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteForm(string keyValue)
        {
            demoPCIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string strEntity, string strlR_Demo_TestCustmerFormcList)
        {
            LR_Demo_TestCustmerFormpEntity entity = strEntity.ToObject<LR_Demo_TestCustmerFormpEntity>();
            List<LR_Demo_TestCustmerFormcEntity> lR_Demo_TestCustmerFormcList = strlR_Demo_TestCustmerFormcList.ToObject<List<LR_Demo_TestCustmerFormcEntity>>();
            demoPCIBLL.SaveEntity(keyValue,entity,lR_Demo_TestCustmerFormcList);
            return Success("保存成功！");
        }
        #endregion

    }
}