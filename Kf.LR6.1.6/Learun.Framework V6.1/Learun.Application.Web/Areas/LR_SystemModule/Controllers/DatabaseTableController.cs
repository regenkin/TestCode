using Learun.Application.Base.SystemModule;
using Learun.Util;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.LR_SystemModule.Controllers
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.01
    /// 描 述：数据表管理
    /// </summary>
    public class DatabaseTableController : MvcControllerBase
    {
        private DatabaseTableIBLL databaseTableIBLL = new DatabaseTableBLL();


        #region 获取视图
        /// <summary>
        /// 主页面管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单页面管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form() {
            return View();
        }
        /// <summary>
        /// 表数据查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TableIndex() {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取数据表数据
        /// </summary>
        /// <param name="databaseLinkId">连接串Id</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList(string databaseLinkId,string tableName)
        {
            var data = databaseTableIBLL.GetTableList(databaseLinkId, tableName);
            return Success(data);
        }
        /// <summary>
        /// 获取表的字段数据
        /// </summary>
        /// <param name="databaseLinkId">连接串Id</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFieldList(string databaseLinkId, string tableName) {
            var data = databaseTableIBLL.GetTableFiledList(databaseLinkId, tableName);
            return Success(data);
        }
        /// <summary>
        /// 获取表数据
        /// </summary>
        /// <param name="databaseLinkId">连接串ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="field">字段名</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTableDataList(string databaseLinkId, string tableName, string field, string logic, string keyword, string pagination)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = databaseTableIBLL.GetTableDataList(databaseLinkId, tableName, field, logic, keyword, paginationobj);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records,
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取表数据(树形数据)
        /// </summary>
        /// <param name="parentId">连接串主键</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTreeList(string parentId)
        {
            var data = databaseTableIBLL.GetTreeList(parentId);
            return Success(data);
        }
        /// <summary>
        /// 获取表字段树形数据
        /// </summary>
        /// <param name="databaseLinkId">连接串主键</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public ActionResult GetFieldTreeList(string databaseLinkId, string tableName)
        {
            var data = databaseTableIBLL.GetFiledTreeList(databaseLinkId, tableName);
            return Success(data);
        }
        #endregion

        #region 提交数据

        #endregion
    }
}