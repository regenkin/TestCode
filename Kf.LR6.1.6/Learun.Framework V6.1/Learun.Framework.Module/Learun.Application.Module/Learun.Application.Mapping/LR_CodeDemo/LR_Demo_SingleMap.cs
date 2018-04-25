using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V6.1.6.0 力软敏捷开发框架
    /// Copyright (c) 2013-2017 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-09-01 17:36
    /// 描 述：测试单表生成
    /// </summary>
    public class LR_Demo_SingleMap : EntityTypeConfiguration<LR_Demo_SingleEntity>
    {
        public LR_Demo_SingleMap()
        {
            #region 表、主键
            //表
            this.ToTable("LR_DEMO_SINGLE");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

