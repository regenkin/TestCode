using Learun.Application.Base.OrganizationModule;
using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.Util;
using System;
using System.Collections.Generic;
namespace Learun.Application.Base.SystemModule
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.04.17
    /// 描 述：编号规则
    /// </summary>
    public class CodeRuleBLL : CodeRuleIBLL
    {
        #region 属性
        private CodeRuleService codeRuleService = new CodeRuleService();

        // 组织单位
        DepartmentIBLL departmentIBLL = new DepartmentBLL();
        CompanyIBLL companyIBLL = new CompanyBLL();
        #endregion

        #region 缓存定义
        /*缓存*/
        private ICache cache = CacheFactory.CaChe();
        private string cacheKey = "learun_adms_cuderule_";//+规则编码
        private string cacheKeySeed = "learun_adms_cuderule_seed_";//+规则主键
        #endregion

        #region 获取数据
        /// <summary>
        /// 规则列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="keyword">查询参数</param>
        /// <returns></returns>
        public IEnumerable<CodeRuleEntity> GetPageList(Pagination pagination, string keyword)
        {
            try
            {
                return codeRuleService.GetPageList(pagination, keyword);
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
        /// 规则列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CodeRuleEntity> GetList()
        {
            try
            {
                return codeRuleService.GetList();
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
        /// 规则实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public CodeRuleEntity GetEntity(string keyValue)
        {
            try
            {
                return codeRuleService.GetEntity(keyValue); ;
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
        /// 规则实体
        /// </summary>
        /// <param name="enCode">规则编码</param>
        /// <returns></returns>
        public CodeRuleEntity GetEntityByCode(string enCode)
        {
            try
            {
                CodeRuleEntity codeRuleEntity = cache.Read<CodeRuleEntity>(cacheKey + enCode, CacheId.codeRule);
                if (codeRuleEntity == null) {
                    codeRuleEntity = codeRuleService.GetEntityByCode(enCode);
                    cache.Write<CodeRuleEntity>(cacheKey + enCode, codeRuleEntity, CacheId.codeRule);
                }
                return codeRuleEntity;
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
        /// 删除规则
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void VirtualDelete(string keyValue)
        {
            try
            {
                CodeRuleEntity entity = codeRuleService.GetEntity(keyValue);
                cache.Remove(cacheKey + entity.F_EnCode, CacheId.codeRule);
                codeRuleService.VirtualDelete(keyValue);
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
        /// 保存规则表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="codeRuleEntity">规则实体</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, CodeRuleEntity codeRuleEntity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    CodeRuleEntity entity = codeRuleService.GetEntity(keyValue);
                    cache.Remove(cacheKey + entity.F_EnCode, CacheId.codeRule);
                }
                codeRuleService.SaveEntity(keyValue, codeRuleEntity);
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

        #region 验证数据
        /// <summary>
        /// 规则编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            try
            {
                return codeRuleService.ExistEnCode(enCode, keyValue);
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
        /// 规则名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            try
            {
                return codeRuleService.ExistFullName(fullName, keyValue);
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

        #region 单据编码处理
        /// <summary>
        /// 获取当前编号规则种子列表
        /// </summary>
        /// <param name="ruleId">编号规则主键</param>
        /// <returns></returns>
        public List<CodeRuleSeedEntity> GetSeedList(string ruleId)
        {
            try
            {
                List<CodeRuleSeedEntity> codeRuleSeedList = cache.Read<List<CodeRuleSeedEntity>>(cacheKeySeed + ruleId, CacheId.codeRule);
                if (codeRuleSeedList == null) {
                    codeRuleSeedList = codeRuleService.GetSeedList(ruleId);
                    cache.Write<List<CodeRuleSeedEntity>>(cacheKeySeed + ruleId, codeRuleSeedList, CacheId.codeRule);
                }
                return codeRuleSeedList;
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
        /// 保存单据编号规则种子
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="codeRuleSeedEntity">种子实体</param>
        public void SaveSeed(string keyValue, CodeRuleSeedEntity codeRuleSeedEntity)
        {
            try
            {
                codeRuleService.SaveSeed(keyValue, codeRuleSeedEntity);
                cache.Remove(cacheKeySeed + codeRuleSeedEntity.F_RuleId, CacheId.codeRule);
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
        /// 获得指定模块或者编号的单据号
        /// </summary>
        /// <param name="enCode">编码</param>
        /// <returns>单据号</returns>
        public string GetBillCode(string enCode)
        {
            try
            {
                string billCode = "";    //单据号
                string nextBillCode = "";//单据号
                bool isOutTime = false;  //是否已过期


                CodeRuleEntity coderuleentity = GetEntityByCode(enCode);
                if (coderuleentity != null)
                {
                    UserInfo userInfo = LoginUserInfo.Get();
                    int nowSerious = 0;
                    List<CodeRuleFormatModel> codeRuleFormatList = coderuleentity.F_RuleFormatJson.ToList<CodeRuleFormatModel>();
                    string dateFormatStr = "";
                    foreach (CodeRuleFormatModel codeRuleFormatEntity in codeRuleFormatList)
                    {
                        switch (codeRuleFormatEntity.itemType.ToString())
                        {
                            //自定义项
                            case "0":
                                billCode = billCode + codeRuleFormatEntity.formatStr;
                                nextBillCode = nextBillCode + codeRuleFormatEntity.formatStr;
                                break;
                            //日期
                            case "1":
                                //日期字符串类型
                                dateFormatStr = codeRuleFormatEntity.formatStr;
                                billCode = billCode + DateTime.Now.ToString(codeRuleFormatEntity.formatStr.Replace("m", "M"));
                                nextBillCode = nextBillCode + DateTime.Now.ToString(codeRuleFormatEntity.formatStr.Replace("m", "M"));
                                break;
                            //流水号
                            case "2":
                                CodeRuleSeedEntity maxSeed = null;
                                CodeRuleSeedEntity codeRuleSeedEntity = null;
                                List<CodeRuleSeedEntity> seedList = GetSeedList(coderuleentity.F_RuleId);
                                maxSeed = seedList.Find(t => t.F_UserId.IsEmpty());
                                #region 处理流水号归0
                                // 首先确定最大种子是否未归0的
                                if (dateFormatStr.Contains("dd"))
                                {
                                    if ((maxSeed.F_ModifyDate).ToDateString() != DateTime.Now.ToString("yyyy-MM-dd"))
                                    {
                                        isOutTime = true;
                                        nowSerious = 1;
                                        maxSeed.F_SeedValue = 2;
                                        maxSeed.F_ModifyDate = DateTime.Now;
                                    }
                                }
                                else if (dateFormatStr.Contains("mm"))
                                {
                                    if (((DateTime)maxSeed.F_ModifyDate).ToString("yyyy-MM") != DateTime.Now.ToString("yyyy-MM"))
                                    {
                                        isOutTime = true;
                                        nowSerious = 1;
                                        maxSeed.F_SeedValue = 2;
                                        maxSeed.F_ModifyDate = DateTime.Now;
                                    }
                                }
                                else if (dateFormatStr.Contains("yy"))
                                {
                                    if (((DateTime)maxSeed.F_ModifyDate).ToString("yyyy") != DateTime.Now.ToString("yyyy"))
                                    {
                                        isOutTime = true;
                                        nowSerious = 1;
                                        maxSeed.F_SeedValue = 2;
                                        maxSeed.F_ModifyDate = DateTime.Now;
                                    }
                                }
                                #endregion
                                // 查找当前用户是否已有之前未用掉的种子做更新
                                codeRuleSeedEntity = seedList.Find(t => t.F_UserId == userInfo.userId && t.F_RuleId == coderuleentity.F_RuleId);
                                string keyvalue = codeRuleSeedEntity == null ? "" : codeRuleSeedEntity.F_RuleSeedId;
                                if (isOutTime)
                                {
                                    SaveSeed(maxSeed.F_RuleSeedId, maxSeed);
                                }
                                else if (codeRuleSeedEntity == null)
                                {
                                    nowSerious = (int)maxSeed.F_SeedValue;
                                    maxSeed.F_SeedValue += 1;
                                    maxSeed.Modify(maxSeed.F_RuleSeedId);
                                    SaveSeed(maxSeed.F_RuleSeedId, maxSeed);
                                }
                                else
                                {
                                    nowSerious = (int)codeRuleSeedEntity.F_SeedValue;
                                }

                                codeRuleSeedEntity = new CodeRuleSeedEntity();
                                codeRuleSeedEntity.Create();
                                codeRuleSeedEntity.F_SeedValue = nowSerious;
                                codeRuleSeedEntity.F_UserId = userInfo.userId;
                                codeRuleSeedEntity.F_RuleId = coderuleentity.F_RuleId;
                                SaveSeed(keyvalue, codeRuleSeedEntity);
                                // 最大种子已经过期
                                string seriousStr = new string('0', (int)(codeRuleFormatEntity.formatStr.Length - nowSerious.ToString().Length)) + nowSerious.ToString();
                                string NextSeriousStr = new string('0', (int)(codeRuleFormatEntity.formatStr.Length - nowSerious.ToString().Length)) + maxSeed.F_SeedValue.ToString();
                                billCode = billCode + seriousStr;
                                nextBillCode = nextBillCode + NextSeriousStr;
                                break;
                            //部门
                            case "3":
                                DepartmentEntity departmentEntity = departmentIBLL.GetEntity(userInfo.companyId, userInfo.departmentId);
                                if (codeRuleFormatEntity.formatStr == "code")
                                {
                                    billCode = billCode + departmentEntity.F_EnCode;
                                    nextBillCode = nextBillCode + departmentEntity.F_EnCode;
                                }
                                else
                                {
                                    billCode = billCode + departmentEntity.F_FullName;
                                    nextBillCode = nextBillCode + departmentEntity.F_FullName;

                                }
                                break;
                            //公司
                            case "4":
                                CompanyEntity companyEntity = companyIBLL.GetEntity(userInfo.companyId);
                                if (codeRuleFormatEntity.formatStr == "code")
                                {
                                    billCode = billCode + companyEntity.F_EnCode;
                                    nextBillCode = nextBillCode + companyEntity.F_EnCode;
                                }
                                else
                                {
                                    billCode = billCode + companyEntity.F_FullName;
                                    nextBillCode = nextBillCode + companyEntity.F_FullName;
                                }
                                break;
                            //用户
                            case "5":
                                if (codeRuleFormatEntity.formatStr == "code")
                                {
                                    billCode = billCode + userInfo.enCode;
                                    nextBillCode = nextBillCode + userInfo.enCode;
                                }
                                else
                                {
                                    billCode = billCode + userInfo.account;
                                    nextBillCode = nextBillCode + userInfo.account;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    coderuleentity.F_CurrentNumber = nextBillCode;
                    SaveEntity(coderuleentity.F_RuleId, coderuleentity);
                }
                return billCode;
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
        /// 占用单据号
        /// </summary>
        /// <param name="enCode">单据编码</param>
        /// <returns>true/false</returns>
        public void UseRuleSeed(string enCode)
        {
            try
            {
                CodeRuleEntity codeRuleSeedEntity = GetEntityByCode(enCode);
                if (codeRuleSeedEntity != null)
                {
                    UserInfo userInfo = LoginUserInfo.Get();
                    //删除用户已经用掉的种子
                    codeRuleService.DeleteSeed(userInfo.userId, codeRuleSeedEntity.F_RuleId);
                    cache.Remove(cacheKeySeed + codeRuleSeedEntity.F_RuleId, CacheId.codeRule);
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
        #endregion
    }
}
