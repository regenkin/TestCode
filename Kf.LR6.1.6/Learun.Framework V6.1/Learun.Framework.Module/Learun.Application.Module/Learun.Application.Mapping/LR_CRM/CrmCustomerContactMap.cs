using Learun.Application.CRM;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// �� �� Learun-ADMS V6.1.6.0 �������ݿ������
    /// Copyright (c) 2013-2017 �Ϻ�������Ϣ�������޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2017-07-11 09:58
    /// �� �����ͻ���ϵ��
    /// </summary>
    public class CrmCustomerContactMap : EntityTypeConfiguration<CrmCustomerContactEntity>
    {
        public CrmCustomerContactMap()
        {
            #region ������
            //��
            this.ToTable("LR_CRM_CUSTOMERCONTACT");
            //����
            this.HasKey(t => t.F_CustomerContactId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}

