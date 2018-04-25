using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.Base.SystemModule
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.03.08
    /// 描 述：数据库表管理
    /// </summary>
    public class DatabaseTableService : RepositoryFactory
    {
        #region 获取数据
        /// <summary>
        /// 数据表列表
        /// </summary>
        /// <param name="databaseLinkEntity">数据库连接信息</param>
        /// <returns></returns>
        public IEnumerable<DatabaseTableModel> GetTableList(DatabaseLinkEntity databaseLinkEntity)
        {
            try
            {
                if (databaseLinkEntity == null)
                {
                    return new List<DatabaseTableModel>();
                }
                return this.BaseRepository(databaseLinkEntity.F_DbConnection, databaseLinkEntity.F_DbType).GetDBTable<DatabaseTableModel>();
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
        /// 数据表字段列表
        /// </summary>
        /// <param name="databaseLinkEntity">数据库连接信息</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public IEnumerable<DatabaseTableFieldModel> GetTableFiledList(DatabaseLinkEntity databaseLinkEntity, string tableName)
        {
            try
            {
                if (databaseLinkEntity == null)
                {
                    return new List<DatabaseTableFieldModel>();
                }
                return this.BaseRepository(databaseLinkEntity.F_DbConnection, databaseLinkEntity.F_DbType).GetDBTableFields<DatabaseTableFieldModel>(tableName);
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
        /// 数据库表数据列表
        /// </summary>
        /// <param name="databaseLinkEntity">库连接信息</param>
        /// <param name="field">表明</param>
        /// <param name="switchWhere">条件</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public DataTable GetTableDataList(DatabaseLinkEntity databaseLinkEntity, string tableName, string field, string logic, string keyword, Pagination pagination)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT * FROM " + tableName + " WHERE 1=1");
                if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(logic) && logic != "Null" && logic != "NotNull")
                {
                    strSql.Append(" AND " + field + " ");
                    switch (logic)
                    {
                        case "Equal":           //等于
                            strSql.Append(" = ");
                            break;
                        case "NotEqual":        //不等于
                            strSql.Append(" <> ");
                            break;
                        case "Greater":         //大于
                            strSql.Append(" > ");
                            break;
                        case "GreaterThan":     //大于等于
                            strSql.Append(" >= ");
                            break;
                        case "Less":            //小于
                            strSql.Append(" < ");
                            break;
                        case "LessThan":        //小于等于
                            strSql.Append(" >= ");
                            break;
                        case "Like":            //包含
                            strSql.Append(" like ");
                            keyword = "%" + keyword + "%";
                            break;
                        default:
                            break;
                    }
                    strSql.Append("@keyword ");
                }
                if (logic == "Null")
                {
                    strSql.Append(" AND " + field + " is null ");
                }
                else if (logic == "NotNull")
                {
                    strSql.Append(" AND " + field + " is not null ");
                }
                return this.BaseRepository(databaseLinkEntity.F_DbConnection, databaseLinkEntity.F_DbType).FindTable(strSql.ToString(), new { keyword = keyword }, pagination);
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

        #endregion
    }
}
