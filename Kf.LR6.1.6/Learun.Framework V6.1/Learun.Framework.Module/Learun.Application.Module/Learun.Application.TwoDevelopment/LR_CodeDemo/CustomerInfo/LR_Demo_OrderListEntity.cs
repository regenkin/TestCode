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
    public class LR_Demo_OrderListEntity 
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// U_ID
        /// </summary>
        [Column("U_ID")]
        public string U_ID { get; set; }
        /// <summary>
        /// MeterialId
        /// </summary>
        [Column("METERIALID")]
        public string MeterialId { get; set; }
        /// <summary>
        /// MeterialName
        /// </summary>
        [Column("METERIALNAME")]
        public string MeterialName { get; set; }
        /// <summary>
        /// Qty
        /// </summary>
        [Column("QTY")]
        public int? Qty { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [Column("PRICE")]
        public decimal? Price { get; set; }
        /// <summary>
        /// Amount
        /// </summary>
        [Column("AMOUNT")]
        public decimal? Amount { get; set; }
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
    }
}

