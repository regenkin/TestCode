using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-09-04 16:04
    /// 描 述：会员信息
    /// </summary>
    public class LR_Demo_UserEntity 
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Column("NAME")]
        public string Name { get; set; }
        /// <summary>
        /// Sex
        /// </summary>
        [Column("SEX")]
        public string Sex { get; set; }
        /// <summary>
        /// Age
        /// </summary>
        [Column("AGE")]
        public string Age { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        [Column("ADDRESS")]
        public string Address { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.ID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.ID = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

