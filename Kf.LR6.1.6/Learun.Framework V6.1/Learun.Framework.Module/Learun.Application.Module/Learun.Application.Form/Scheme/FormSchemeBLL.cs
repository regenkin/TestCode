using Learun.Application.Base.SystemModule;
using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.DataBase.Repository;
using Learun.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;

namespace Learun.Application.Form
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.01
    /// 描 述：表单模板
    /// </summary>
    public class FormSchemeBLL : FormSchemeIBLL
    {
        private FormSchemeService formSchemeService = new FormSchemeService();
        private DatabaseLinkIBLL databaseLinkIBLL = new DatabaseLinkBLL();


        #region 缓存定义
        private ICache cache = CacheFactory.CaChe();
        private string cacheKey = "learun_adms_formscheme_";// +模板主键
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取自定义表单列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FormSchemeInfoEntity> GetCustmerSchemeInfoList()
        {
            try
            {
                return formSchemeService.GetCustmerSchemeInfoList();
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
        /// 获取表单分页列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <param name="category">分类</param>
        /// <param name="type">表单类型0自定义表单,1自定义表单（OA），2系统表单</param>
        /// <returns></returns>
        public IEnumerable<FormSchemeInfoEntity> GetSchemeInfoPageList(Pagination pagination, string keyword, string category, int type)
        {
            try
            {
                return formSchemeService.GetSchemeInfoPageList(pagination, keyword, category, type);
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
        /// 获取表单分页列表(用于系统表单)
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键字</param>
        /// <param name="category">分类</param>
        /// <returns></returns>
        public IEnumerable<FormSchemeInfoEntity> GetSchemeInfoPageList(Pagination pagination, string keyword, string category)
        {
            try
            {
                return formSchemeService.GetSchemeInfoPageList(pagination, keyword, category);
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
        /// 获取模板列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="schemeInfoId">模板信息主键</param>
        /// <returns></returns>
        public IEnumerable<FormSchemeEntity> GetSchemePageList(Pagination pagination, string schemeInfoId)
        {
            try
            {
                return formSchemeService.GetSchemePageList(pagination, schemeInfoId);
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
        /// 获取模板基础信息的实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public FormSchemeInfoEntity GetSchemeInfoEntity(string keyValue)
        {
            try
            {

                FormSchemeInfoEntity schemeInfoEntity = cache.Read<FormSchemeInfoEntity>(cacheKey + keyValue, CacheId.formscheme);
                if (schemeInfoEntity == null)
                {
                    schemeInfoEntity = formSchemeService.GetSchemeInfoEntity(keyValue);
                    cache.Write<FormSchemeInfoEntity>(cacheKey + keyValue, schemeInfoEntity, CacheId.formscheme);
                }
                return schemeInfoEntity;
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
        /// 获取模板的实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public FormSchemeEntity GetSchemeEntity(string keyValue)
        {
            try
            {
                FormSchemeEntity schemeEntity = cache.Read<FormSchemeEntity>(cacheKey + keyValue, CacheId.formscheme);
                if (schemeEntity == null)
                {
                    schemeEntity = formSchemeService.GetSchemeEntity(keyValue);
                    cache.Write<FormSchemeEntity>(cacheKey + keyValue, schemeEntity, CacheId.formscheme);
                }
                return schemeEntity;
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
        /// 虚拟删除模板信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void VirtualDelete(string keyValue)
        {
            try
            {
                cache.Remove(cacheKey + keyValue, CacheId.formscheme);
                formSchemeService.VirtualDelete(keyValue);
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
        /// 保存模板信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="schemeInfoEntity">模板基础信息</param>
        /// <param name="schemeEntity">模板信息</param>
        public void SaveEntity(string keyValue, FormSchemeInfoEntity schemeInfoEntity, FormSchemeEntity schemeEntity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    FormSchemeEntity schemeEntityOld = GetSchemeEntity(schemeInfoEntity.F_SchemeId);
                    if (schemeEntityOld.F_Scheme == schemeEntity.F_Scheme && schemeEntityOld.F_Type == schemeEntity.F_Type)
                    {
                        schemeEntity = null;
                    }
                    cache.Remove(cacheKey + keyValue, CacheId.formscheme);
                }
                formSchemeService.SaveEntity(keyValue, schemeInfoEntity, schemeEntity);
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
        /// 保存模板基础信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="schemeInfoEntity">模板基础信息</param>
        public void SaveSchemeInfoEntity(string keyValue, FormSchemeInfoEntity schemeInfoEntity)
        {
            try
            {
                formSchemeService.SaveSchemeInfoEntity(keyValue, schemeInfoEntity);
                cache.Remove(cacheKey + keyValue, CacheId.formscheme);
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
        /// 更新模板
        /// </summary>
        /// <param name="schemeInfoId">模板信息主键</param>
        /// <param name="schemeId">模板主键</param>
        public void UpdateScheme(string schemeInfoId, string schemeId)
        {
            try
            {
                cache.Remove(cacheKey + schemeInfoId, CacheId.formscheme);
                formSchemeService.UpdateScheme(schemeInfoId, schemeId);
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
        /// 更新自定义表单模板状态
        /// </summary>
        /// <param name="schemeInfoId">模板信息主键</param>
        /// <param name="state">状态1启用0禁用</param>
        public void UpdateState(string schemeInfoId, int state)
        {
            try
            {
                cache.Remove(cacheKey + schemeInfoId, CacheId.formscheme);
                formSchemeService.UpdateState(schemeInfoId, state);
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

        #region 扩展方法

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="schemeInfoId">模板信息主键</param>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        public DataTable GetFormPageList(string schemeInfoId, Pagination pagination, string queryJson)
        {
            try
            {
                FormSchemeInfoEntity formSchemeInfoEntity = GetSchemeInfoEntity(schemeInfoId);
                FormSchemeEntity formSchemeEntity = GetSchemeEntity(formSchemeInfoEntity.F_SchemeId);
                FormSchemeModel formSchemeModel = formSchemeEntity.F_Scheme.ToObject<FormSchemeModel>();

                var queryParam = queryJson.ToJObject();

                string querySql = GetQuerySql(formSchemeModel, queryParam);
                return databaseLinkIBLL.FindTable(formSchemeModel.dbId, querySql, queryParam, pagination);
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
        /// 获取分页数据
        /// </summary>
        /// <param name="schemeInfoId">模板信息主键</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        public DataTable GetFormList(string schemeInfoId, string queryJson)
        {
            try
            {
                FormSchemeInfoEntity formSchemeInfoEntity = GetSchemeInfoEntity(schemeInfoId);
                FormSchemeEntity formSchemeEntity = GetSchemeEntity(formSchemeInfoEntity.F_SchemeId);
                FormSchemeModel formSchemeModel = formSchemeEntity.F_Scheme.ToObject<FormSchemeModel>();

                var queryParam = queryJson.ToJObject();

                string querySql = GetQuerySql(formSchemeModel, queryParam);
                return databaseLinkIBLL.FindTable(formSchemeModel.dbId, querySql, queryParam);
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
        /// 获取自定义表单数据
        /// </summary>
        /// <param name="schemeInfoId">模板信息主键</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Dictionary<string, DataTable> GetInstanceForm(string schemeInfoId, string keyValue)
        {
            Dictionary<string, DataTable> res = new Dictionary<string, DataTable>();

            try
            {
                FormSchemeInfoEntity formSchemeInfoEntity = GetSchemeInfoEntity(schemeInfoId);
                FormSchemeEntity formSchemeEntity = GetSchemeEntity(formSchemeInfoEntity.F_SchemeId);
                FormSchemeModel formSchemeModel = formSchemeEntity.F_Scheme.ToObject<FormSchemeModel>();

                // 确定主从表之间的关系
                List<TreeModelEx<FormTableModel>> TableTree = new List<TreeModelEx<FormTableModel>>();// 从表
                foreach (var table in formSchemeModel.dbTable)
                {
                    TreeModelEx<FormTableModel> treeone = new TreeModelEx<FormTableModel>();
                    treeone.data = table;
                    treeone.id = table.name;
                    treeone.parentId = table.relationName;
                    if (string.IsNullOrEmpty(table.relationName))
                    {
                        treeone.parentId = "0";
                    }
                    TableTree.Add(treeone);
                }
                TableTree = TableTree.ToTree();

                // 确定表与组件之间的关系
                Dictionary<string, List<FormCompontModel>> tableComponts = new Dictionary<string, List<FormCompontModel>>();
                foreach (var tab in formSchemeModel.data)
                {
                    foreach (var compont in tab.componts)
                    {
                        if (!string.IsNullOrEmpty(compont.table))
                        {
                            if (!tableComponts.ContainsKey(compont.table))
                            {
                                tableComponts[compont.table] = new List<FormCompontModel>();
                            }
                            tableComponts[compont.table].Add(compont);
                        }
                    }
                }
                GetInstanceTableData(TableTree, tableComponts, formSchemeModel.dbId, keyValue, null, res);
                return res;
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
        /// 获取自定义表单数据
        /// </summary>
        /// <param name="schemeInfoId">模板信息主键</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public Dictionary<string, DataTable> GetInstanceForm(string schemeInfoId, string processIdName, string keyValue)
        {
            Dictionary<string, DataTable> res = new Dictionary<string, DataTable>();

            try
            {
                FormSchemeInfoEntity formSchemeInfoEntity = GetSchemeInfoEntity(schemeInfoId);
                FormSchemeEntity formSchemeEntity = GetSchemeEntity(formSchemeInfoEntity.F_SchemeId);
                FormSchemeModel formSchemeModel = formSchemeEntity.F_Scheme.ToObject<FormSchemeModel>();

                // 确定主从表之间的关系
                List<TreeModelEx<FormTableModel>> TableTree = new List<TreeModelEx<FormTableModel>>();// 从表
                foreach (var table in formSchemeModel.dbTable)
                {
                    TreeModelEx<FormTableModel> treeone = new TreeModelEx<FormTableModel>();
                    treeone.data = table;
                    treeone.id = table.name;
                    treeone.parentId = table.relationName;
                    if (string.IsNullOrEmpty(table.relationName))
                    {
                        treeone.parentId = "0";
                    }
                    TableTree.Add(treeone);
                }
                TableTree = TableTree.ToTree();

                // 确定表与组件之间的关系
                Dictionary<string, List<FormCompontModel>> tableComponts = new Dictionary<string, List<FormCompontModel>>();
                foreach (var tab in formSchemeModel.data)
                {
                    foreach (var compont in tab.componts)
                    {
                        if (!string.IsNullOrEmpty(compont.table))
                        {
                            if (!tableComponts.ContainsKey(compont.table))
                            {
                                tableComponts[compont.table] = new List<FormCompontModel>();
                            }
                            tableComponts[compont.table].Add(compont);
                        }
                    }
                }
                GetInstanceTableData(TableTree, tableComponts, formSchemeModel.dbId, keyValue,processIdName, null, res);
                return res;
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
        /// 保存自定义表单数据
        /// </summary>
        /// <param name="schemeInfoId">表单模板主键</param>
        /// <param name="processIdName">流程关联字段名</param>
        /// <param name="keyValue">数据主键值</param>
        /// <param name="formData">自定义表单数据</param>
        public void SaveInstanceForm(string schemeInfoId, string processIdName, string keyValue, string formData)
        {
            try
            {
                FormSchemeInfoEntity schemeInfoEntity = GetSchemeInfoEntity(schemeInfoId);
                FormSchemeEntity schemeEntity = GetSchemeEntity(schemeInfoEntity.F_SchemeId);
                FormSchemeModel formSchemeModel = schemeEntity.F_Scheme.ToObject<FormSchemeModel>();

                List<FormTableModel> cTableList = new List<FormTableModel>();// 从表
                foreach (var table in formSchemeModel.dbTable)
                {
                    if (string.IsNullOrEmpty(table.relationName))
                    {
                        formSchemeModel.mainTableName = table.name;
                        formSchemeModel.mainTablePkey = table.field;
                    }
                    else
                    {
                        cTableList.Add(table);
                    }
                }

                var formDataJson = formData.ToJObject();
                //var paramter = SqlHelper.JObjectToParameter((JObject)dbParameter);
                // 首先对数据进行以数据表为基准的分类处理
                Dictionary<string, List<FormCompontModel>> tableMap = new Dictionary<string, List<FormCompontModel>>();
                List<FieldValueParam> fieldValueParamlist = new List<FieldValueParam>();

                string processIdFiled = "";
                foreach (var tab in formSchemeModel.data)
                {
                    foreach (var compont in tab.componts)
                    {
                        if (compont.id == processIdName)
                        {
                            processIdFiled = compont.field;
                        }

                        if (!string.IsNullOrEmpty(compont.table))
                        {
                            if (!formDataJson[compont.id].IsEmpty() || (formDataJson[compont.id] != null && formDataJson[compont.id].ToString() == ""))
                            {
                                FieldValueParam fieldValueParam = new FieldValueParam();
                                fieldValueParam.name = "LR" + compont.id.Replace("-", "_");
                                fieldValueParam.value = formDataJson[compont.id].ToString();
                                fieldValueParam.type = (int)DbType.String;
                                if (compont.type == "datetime")
                                {
                                    fieldValueParam.type = (int)DbType.DateTime;
                                }
                                fieldValueParamlist.Add(fieldValueParam);
                                compont.value = formDataJson[compont.id].ToString();
                            }
                            else
                            {
                                compont.value = "";
                            }
                            if (!tableMap.ContainsKey(compont.table))
                            {
                                tableMap[compont.table] = new List<FormCompontModel>();
                            }
                            tableMap[compont.table].Add(compont);
                        }
                    }
                }
                var db = databaseLinkIBLL.BeginTrans(formSchemeModel.dbId);
                try
                {
                    string strSql = "";
                    if (string.IsNullOrEmpty(keyValue))
                    {
                        // 插入主表数据
                        strSql = InsertSql(formSchemeModel.mainTableName, tableMap, formDataJson);
                        databaseLinkIBLL.ExecuteBySqlTrans(strSql, fieldValueParamlist, db);
                        foreach (FormTableModel table in cTableList)
                        {
                            foreach (var compont in tableMap[table.relationName])
                            {
                                if (compont.field == table.relationField)
                                {
                                    FormCompontModel newcompont = new FormCompontModel();
                                    newcompont.id = compont.id;
                                    newcompont.field = table.field;
                                    newcompont.value = "123";
                                    tableMap[table.name].Add(newcompont);
                                    break;
                                }
                            }
                            strSql = InsertSql(table.name, tableMap, formDataJson);
                            if (!string.IsNullOrEmpty(strSql))
                            {
                                databaseLinkIBLL.ExecuteBySqlTrans(strSql, fieldValueParamlist, db);
                            }
                        }
                    }
                    else
                    {
                        // 更新主表数据
                        string mainTablePkey = formSchemeModel.mainTablePkey;
                        if (!string.IsNullOrEmpty(processIdFiled))
                        {
                            mainTablePkey = processIdFiled;
                        }

                        strSql = UpdateSql(formSchemeModel.mainTableName, mainTablePkey, keyValue, tableMap, formDataJson);
                        databaseLinkIBLL.ExecuteBySqlTrans(strSql, fieldValueParamlist, db);
                        foreach (FormTableModel table in cTableList)
                        {
                            foreach (var compont in tableMap[table.relationName])
                            {
                                if (compont.field == table.relationField)
                                {
                                    strSql = UpdateSql(table.name, table.field, compont.value, tableMap, formDataJson);
                                    databaseLinkIBLL.ExecuteBySqlTrans(strSql, fieldValueParamlist, db);
                                }
                            }
                        }
                    }
                    db.Commit();
                }
                catch (Exception)
                {
                    db.Rollback();
                    throw;
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
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 删除自定义表单数据
        /// </summary>
        /// <param name="schemeInfoId">表单模板主键</param>
        /// <param name="keyValue">数据主键值</param>
        public void DeleteInstanceForm(string schemeInfoId, string keyValue)
        {
            try
            {
                FormSchemeInfoEntity formSchemeInfoEntity = GetSchemeInfoEntity(schemeInfoId);
                FormSchemeEntity formSchemeEntity = GetSchemeEntity(formSchemeInfoEntity.F_SchemeId);
                FormSchemeModel formSchemeModel = formSchemeEntity.F_Scheme.ToObject<FormSchemeModel>();

                // 确定主从表之间的关系
                List<TreeModelEx<FormTableModel>> TableTree = new List<TreeModelEx<FormTableModel>>();// 从表
                foreach (var table in formSchemeModel.dbTable)
                {
                    TreeModelEx<FormTableModel> treeone = new TreeModelEx<FormTableModel>();
                    treeone.data = table;
                    treeone.id = table.name;
                    treeone.parentId = table.relationName;
                    if (string.IsNullOrEmpty(table.relationName))
                    {
                        treeone.parentId = "0";
                    }
                    TableTree.Add(treeone);
                }
                TableTree = TableTree.ToTree();

                // 确定表与组件之间的关系
                Dictionary<string, List<FormCompontModel>> tableComponts = new Dictionary<string, List<FormCompontModel>>();
                foreach (var tab in formSchemeModel.data)
                {
                    foreach (var compont in tab.componts)
                    {
                        if (!string.IsNullOrEmpty(compont.table))
                        {
                            if (!tableComponts.ContainsKey(compont.table))
                            {
                                tableComponts[compont.table] = new List<FormCompontModel>();
                            }
                            tableComponts[compont.table].Add(compont);
                        }
                    }
                }
                 var db = databaseLinkIBLL.BeginTrans(formSchemeModel.dbId);
                 try
                 {
                     DeleteInstanceTable(TableTree, tableComponts, formSchemeModel.dbId, keyValue, null, db);
                     db.Commit();
                 }
                 catch (Exception)
                 {
                     db.Rollback();
                     throw;
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
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }


        /// <summary>
        /// 获取查询sql语句
        /// </summary>
        /// <param name="formSchemeModel">表单模板设置信息</param>
        /// <returns></returns>
        private string GetQuerySql(FormSchemeModel formSchemeModel, JObject queryParam)
        {
            try
            {
                string querySql = "";
                string fieldSql = "";
                Dictionary<string, string> girdTable = new Dictionary<string, string>();  // 表格绑定的表
                foreach (var tab in formSchemeModel.data)
                {
                    foreach (var compont in tab.componts)
                    {
                        if (compont.type == "girdtable")
                        {
                            if (!girdTable.ContainsKey(compont.table))
                            {
                                girdTable.Add(compont.table, "1");
                            }
                        }
                        else if (!string.IsNullOrEmpty(compont.field))
                        {
                            fieldSql += compont.table + "tt." + compont.field + " as lr" + compont.id.Replace("-", "_") + ",";
                        }
                    }
                }
                // 确定主表
                List<FormTableModel> cTableList = new List<FormTableModel>();// 从表
                foreach (var table in formSchemeModel.dbTable)
                {
                    if (string.IsNullOrEmpty(table.relationName))
                    {
                        formSchemeModel.mainTableName = table.name;
                        formSchemeModel.mainTablePkey = table.field;
                    }
                    else if (!girdTable.ContainsKey(table.name))
                    {
                        cTableList.Add(table);
                    }
                }
                fieldSql = fieldSql.Remove(fieldSql.Length - 1, 1);
                querySql += " SELECT " + fieldSql + " FROM  " + formSchemeModel.mainTableName + " " + formSchemeModel.mainTableName + "tt ";

                foreach (var ctable in cTableList)
                {
                    querySql += " LEFT JOIN  " + ctable.name + " " + ctable.name + "tt " + "  ON " + ctable.name + "tt." + ctable.field + " = " + ctable.relationName + "tt." + ctable.relationField + " ";
                }
                querySql += "  where 1=1 ";

                if (queryParam != null && !queryParam["lrdateField"].IsEmpty())
                {
                    querySql += " AND (" + formSchemeModel.mainTableName + "tt." + queryParam["lrdateField"].ToString() + " >=@lrbegin AND " + formSchemeModel.mainTableName + "tt." + queryParam["lrdateField"].ToString() + " <=@lrend ) ";
                }

                return querySql;
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
        /// 获取自定义表单实例表的实体数据
        /// </summary>
        /// <param name="tableTree">主从表关系树</param>
        /// <param name="tableComponts">表与组件之间的关系</param>
        /// <param name="dbId">数据库主键</param>
        /// <param name="keyValue">主键值</param>
        /// <param name="pData">父表的数据值</param>
        /// <param name="res">结果数据</param>
        private void GetInstanceTableData(List<TreeModelEx<FormTableModel>> tableTree, Dictionary<string, List<FormCompontModel>> tableComponts, string dbId, string keyValue,Dictionary<string,string> pData, Dictionary<string, DataTable> res)
        {
            try
            {
                foreach (var tableItem in tableTree)
                {
                    string querySql = " SELECT ";
                    if (tableComponts.ContainsKey(tableItem.data.name) && !res.ContainsKey(tableItem.data.name))
                    {
                        foreach (var compont in tableComponts[tableItem.data.name])
                        {
                            querySql += compont.field + " as LR" + compont.id.Replace("-", "_") + " , ";
                        }

                        if (string.IsNullOrEmpty(keyValue))
                        {
                            keyValue = pData[tableItem.data.relationField];
                        }

                        querySql = querySql.Remove(querySql.Length - 2, 2);
                        querySql += " FROM " + tableItem.data.name + " WHERE " + tableItem.data.field + " = @keyValue";

                        DataTable dt = databaseLinkIBLL.FindTable(dbId, querySql, new { keyValue = keyValue });
                        res.Add(tableItem.data.name, dt);

                        // 获取它的从表数据
                        if (tableItem.ChildNodes.Count > 0 && dt.Rows.Count > 0)
                        {
                            Dictionary<string, string> pDatatmp = new Dictionary<string, string>();
                            foreach (var compont in tableComponts[tableItem.data.name])
                            {
                                if (!pDatatmp.ContainsKey(compont.field))
                                {
                                    pDatatmp.Add(compont.field, dt.Rows[0]["LR" + compont.id.Replace("-", "_")].ToString());
                                }
                            }
                            GetInstanceTableData(tableItem.ChildNodes, tableComponts, dbId, "", pDatatmp, res);
                        }

                    }
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
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 获取自定义表单实例表的实体数据
        /// </summary>
        /// <param name="tableTree">主从表关系树</param>
        /// <param name="tableComponts">表与组件之间的关系</param>
        /// <param name="dbId">数据库主键</param>
        /// <param name="keyName">主键字段名字</param>
        /// <param name="keyValue">主键值</param>
        /// <param name="pData">父表的数据值</param>
        /// <param name="res">结果数据</param>
        private void GetInstanceTableData(List<TreeModelEx<FormTableModel>> tableTree, Dictionary<string, List<FormCompontModel>> tableComponts, string dbId, string keyValue,string keyName, Dictionary<string, string> pData, Dictionary<string, DataTable> res)
        {
            try
            {
                foreach (var tableItem in tableTree)
                {
                    string querySql = " SELECT ";
                    if (tableComponts.ContainsKey(tableItem.data.name) && !res.ContainsKey(tableItem.data.name))
                    {
                        string tableName = "";
                        foreach (var compont in tableComponts[tableItem.data.name])
                        {
                            if (keyName == compont.id)
                            {
                                tableName = compont.field;
                            }
                            querySql += compont.field + " as LR" + compont.id.Replace("-", "_") + " , ";
                        }

                        if (string.IsNullOrEmpty(keyValue))
                        {
                            keyValue = pData[tableItem.data.relationField];
                        }

                        querySql = querySql.Remove(querySql.Length - 2, 2);
                        querySql += " FROM " + tableItem.data.name + " WHERE " + tableName + " = @keyValue";

                        DataTable dt = databaseLinkIBLL.FindTable(dbId, querySql, new { keyValue = keyValue });
                        res.Add(tableItem.data.name, dt);

                        // 获取它的从表数据
                        if (tableItem.ChildNodes.Count > 0 && dt.Rows.Count > 0)
                        {
                            Dictionary<string, string> pDatatmp = new Dictionary<string, string>();
                            foreach (var compont in tableComponts[tableItem.data.name])
                            {
                                if (!pDatatmp.ContainsKey(compont.field))
                                {
                                    pDatatmp.Add(compont.field, dt.Rows[0]["LR" + compont.id.Replace("-", "_")].ToString());
                                }
                            }
                            GetInstanceTableData(tableItem.ChildNodes, tableComponts, dbId, "", pDatatmp, res);
                        }

                    }
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
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        
        /// <summary>
        /// 删除自定义表单实例表的实体数据
        /// </summary>
        /// <param name="tableTree">主从表关系树</param>
        /// <param name="tableComponts">表与组件之间的关系</param>
        /// <param name="dbId">数据库主键</param>
        /// <param name="keyValue">主键值</param>
        /// <param name="pData">父表的数据值</param>
        /// <param name="db">数据库连接</param>
        private void DeleteInstanceTable(List<TreeModelEx<FormTableModel>> tableTree, Dictionary<string, List<FormCompontModel>> tableComponts, string dbId, string keyValue, DataTable pData,IRepository db)
        {
            try
            {
                foreach (var tableItem in tableTree)
                {
                    string querySql = "";
                    if (tableComponts.ContainsKey(tableItem.data.name))
                    {
                        if (string.IsNullOrEmpty(keyValue))
                        {
                            keyValue = pData.Rows[0][tableItem.data.relationField].ToString();
                        }

                        // 如果有子表需要先获取数据
                        if (tableItem.ChildNodes.Count > 0)
                        {
                            querySql = " SELECT * FROM " + tableItem.data.name + " WHERE " + tableItem.data.field + " = @keyValue";
                            DataTable dt = databaseLinkIBLL.FindTable(dbId, querySql, new { keyValue = keyValue });
                            DeleteInstanceTable(tableItem.ChildNodes, tableComponts, dbId, "", dt,db);
                        }

                        // 删除数据
                        querySql = " DELETE FROM " + tableItem.data.name + " WHERE " + tableItem.data.field + " = @keyValue";
                        databaseLinkIBLL.ExecuteBySqlTrans(querySql, new { keyValue = keyValue },db);
                    }
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
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 新增数据sql语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="tableMap">表名->组件映射</param>
        /// <returns></returns>
        private string InsertSql(string tableName, Dictionary<string, List<FormCompontModel>> tableMap, JObject formDataJson)
        {
            string strSql = "";
            bool flag = false;
            try
            {
                if (tableMap.ContainsKey(tableName) && tableMap[tableName].Count > 0)
                {
                    strSql = "INSERT " + tableName + "( ";
                    string sqlValue = " ( ";


                    foreach (var item in tableMap[tableName])
                    {
                        if (!string.IsNullOrEmpty(item.field) && !formDataJson[item.id].IsEmpty())
                        {
                            flag = true;
                            strSql += item.field + ",";
                            sqlValue += " @LR" + item.id.Replace("-","_") + ",";
                        }
                    }
                    strSql = strSql.Remove(strSql.Length - 1, 1);
                    sqlValue = sqlValue.Remove(sqlValue.Length - 1, 1);

                    strSql += " ) VALUES " + sqlValue + ")";
                }
                if (!flag)
                {
                    return "";
                }
                return strSql;
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
        /// 更新数据sql语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="pkey">主键字段</param>
        /// <param name="pkeyValue">主键数据</param>
        /// <param name="tableMap">表名->组件映射</param>
        /// <param name="formDataJson">上传的数据</param>
        /// <returns></returns>
        private string UpdateSql(string tableName, string pkey, string pkeyValue, Dictionary<string, List<FormCompontModel>> tableMap, JObject formDataJson)
        {
            string strSql = "";
            try
            {
                if (tableMap.ContainsKey(tableName) && tableMap[tableName].Count > 0)
                {
                    strSql = " UPDATE   " + tableName + " SET  ";
                    foreach (var item in tableMap[tableName])
                    {
                        if (!string.IsNullOrEmpty(item.field) && item.field != pkey && !formDataJson[item.id].IsEmpty())
                        {
                            strSql += item.field + "=@LR" + item.id.Replace("-", "_") + ",";
                        }
                    }
                    strSql = strSql.Remove(strSql.Length - 1, 1);
                    strSql += " WHERE " + pkey + "='" + pkeyValue + "'";
                }
                return strSql;
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
