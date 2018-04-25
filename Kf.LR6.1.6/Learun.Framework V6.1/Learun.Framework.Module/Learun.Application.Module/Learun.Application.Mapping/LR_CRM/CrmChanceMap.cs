using Learun.Application.CRM;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// �� �� Learun-ADMS V6.1.6.0 �������ݿ������
    /// Copyright (c) 2013-2017 �Ϻ�������Ϣ�������޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-07-11 11:30
    /// �� �����̻�����
    /// </summary>
    public class CrmChanceMap : EntityTypeConfiguration<CrmChanceEntity>
    {
        public CrmChanceMap()
        {
            #region ������
            //��
            this.ToTable("LR_CRM_CHANCE");
            //����
            this.HasKey(t => t.F_ChanceId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}

