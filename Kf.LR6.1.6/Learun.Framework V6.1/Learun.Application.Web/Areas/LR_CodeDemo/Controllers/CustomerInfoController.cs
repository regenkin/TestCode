using Learun.Util;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-09-04 16:04
    /// 描 述：会员信息
    /// </summary>
    public class CustomerInfoController : MvcControllerBase
    {
        private CustomerInfoIBLL customerInfoIBLL = new CustomerInfoBLL();

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
            var data = customerInfoIBLL.GetPageList(paginationobj, queryJson);
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
            var LR_Demo_UserData = customerInfoIBLL.GetLR_Demo_UserEntity( keyValue );
            var LR_Demo_OrderListData = customerInfoIBLL.GetLR_Demo_OrderListList( LR_Demo_UserData.ID );
            var jsonData = new {
                LR_Demo_UserData = LR_Demo_UserData,
                LR_Demo_OrderListData = LR_Demo_OrderListData,
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
            customerInfoIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue, string strEntity, string strlR_Demo_OrderListList)
        {
            LR_Demo_UserEntity entity = strEntity.ToObject<LR_Demo_UserEntity>();
            List<LR_Demo_OrderListEntity> lR_Demo_OrderListList = strlR_Demo_OrderListList.ToObject<List<LR_Demo_OrderListEntity>>();
            customerInfoIBLL.SaveEntity(keyValue,entity,lR_Demo_OrderListList);
            return Success("保存成功！");
        }
        #endregion

    }
}
