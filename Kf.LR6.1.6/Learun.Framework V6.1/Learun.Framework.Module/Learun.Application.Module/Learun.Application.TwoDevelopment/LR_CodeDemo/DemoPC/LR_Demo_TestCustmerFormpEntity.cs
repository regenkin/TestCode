using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-09-02 05:35
    /// 描 述：测试主从表
    /// </summary>
    public class LR_Demo_TestCustmerFormpEntity 
    {
        #region 实体成员
        /// <summary>
        /// F_Id
        /// </summary>
        [Column("F_ID")]
        public string F_Id { get; set; }
        /// <summary>
        /// F_Name
        /// </summary>
        [Column("F_NAME")]
        public string F_Name { get; set; }
        /// <summary>
        /// F_Code
        /// </summary>
        [Column("F_CODE")]
        public string F_Code { get; set; }
        /// <summary>
        /// F_Des
        /// </summary>
        [Column("F_DES")]
        public string F_Des { get; set; }
        /// <summary>
        /// F_Begin
        /// </summary>
        [Column("F_BEGIN")]
        public DateTime? F_Begin { get; set; }
        /// <summary>
        /// F_End
        /// </summary>
        [Column("F_END")]
        public DateTime? F_End { get; set; }
        /// <summary>
        /// F_Num
        /// </summary>
        [Column("F_NUM")]
        public int? F_Num { get; set; }
        /// <summary>
        /// F_Kind
        /// </summary>
        [Column("F_KIND")]
        public string F_Kind { get; set; }
        /// <summary>
        /// F_Enable
        /// </summary>
        [Column("F_ENABLE")]
        public string F_Enable { get; set; }
        /// <summary>
        /// F_Classify
        /// </summary>
        [Column("F_CLASSIFY")]
        public string F_Classify { get; set; }
        /// <summary>
        /// F_File
        /// </summary>
        [Column("F_FILE")]
        public string F_File { get; set; }
        /// <summary>
        /// F_UserId
        /// </summary>
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary>
        /// F_CompanyId
        /// </summary>
        [Column("F_COMPANYID")]
        public string F_CompanyId { get; set; }
        /// <summary>
        /// F_DepartmentId
        /// </summary>
        [Column("F_DEPARTMENTID")]
        public string F_DepartmentId { get; set; }
        /// <summary>
        /// F_DateTime
        /// </summary>
        [Column("F_DATETIME")]
        public DateTime? F_DateTime { get; set; }
        /// <summary>
        /// F_UserId2
        /// </summary>
        [Column("F_USERID2")]
        public string F_UserId2 { get; set; }
        /// <summary>
        /// F_CompanyId2
        /// </summary>
        [Column("F_COMPANYID2")]
        public string F_CompanyId2 { get; set; }
        /// <summary>
        /// F_DepartmentId2
        /// </summary>
        [Column("F_DEPARTMENTID2")]
        public string F_DepartmentId2 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.F_Id = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

