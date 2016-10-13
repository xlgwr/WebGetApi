namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("t_Case")]
    public class t_Case
    {
        #region ʵ������
        /// <summary>
        /// Ψһ��ʶ(�Զ�����)
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Caseid { get; set; }


        /// <summary>
        /// �������(����GUID,���Ƿ�Ժ���ı��,�������޸�,ϵͳ�ڲ���ϵ��)
        /// </summary>
        public virtual string CaseNo { get; set; }

        /// <summary>
        /// �������(Ĭ����CaseNo��ͬһ��������������˹�����,��ʾʱ����ʾ������)
        /// </summary>
        public virtual string CaseNoNew { get; set; }

        /// <summary>
        /// �����о���(0:�� 1:��)
        /// </summary>
        public virtual int? Judgement { get; set; }

        ///// <summary>
        ///// ���ķ�ͥ��� ��(�����V�A 001/2014) �ǰ����Ͻ���������
        ///// </summary>
        //public virtual string CaseNo_Cn { get; set; }

        ///// <summary>
        ///// ����[2/4]#
        ///// </summary>
        //public virtual string NumberTimes { get; set; }

        ///// <summary>
        ///// ��Ժid
        ///// </summary>
        //public virtual long CourtID { get; set; }

        ///// <summary>
        ///// �������:�������V/�����V�A/�����V�A/�l�T�a������/���°���/�Ʈa����/�s헰���/С�~�X������̎���V/���B���ٲ��V�A/���з�Ժ���V
        ///// </summary>
        //public virtual long CaseTypeID { get; set; }

        ///// <summary>
        ///// �������2015
        ///// </summary>
        //public virtual string Year { get; set; }

        ///// <summary>
        ///// ���001
        ///// </summary>
        //public virtual string SerialNo { get; set; }

        ///// <summary>
        ///// ��ͥ����
        ///// </summary>
        //public virtual string CourtDay { get; set; }

        ///// <summary>
        ///// �����˸�����ԭ�棬�����ԭʼ��¼)
        ///// </summary>
        //public virtual string Parties { get; set; }

        ///// <summary>
        ///// ԭ��
        ///// </summary>
        //public virtual string Plaintiff { get; set; }

        ///// <summary>
        ///// ԭ���ַ
        ///// </summary>
        //public virtual string P_Address { get; set; }

        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual string Defendant { get; set; }

        ///// <summary>
        ///// �����ַ
        ///// </summary>
        //public virtual string D_Address { get; set; }

        ///// <summary>
        ///// ԭ��/����
        ///// </summary>
        //public virtual string Nature { get; set; }

        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual string Judge { get; set; }

        ///// <summary>
        ///// ӦѶ����
        ///// </summary>
        //public virtual string Representation { get; set; }

        ///// <summary>
        ///// ԭ�����
        ///// </summary>
        //public virtual string Representation_P { get; set; }

        ///// <summary>
        ///// �������
        ///// </summary>
        //public virtual string Representation_D { get; set; }

        ///// <summary>
        ///// ��Ѷ
        ///// </summary>
        //public virtual string Hearing { get; set; }

        ///// <summary>
        ///// �ұ�(excel����)
        ///// </summary>
        //public virtual string Currency { get; set; }

        ///// <summary>
        ///// �ܽ��(excel����)
        ///// </summary>
        //public virtual int Amount { get; set; }

        ///// <summary>
        ///// ����
        ///// </summary>
        //public virtual string Other { get; set; }

        ///// <summary>
        ///// ����1
        ///// </summary>
        //public virtual string Other1 { get; set; }

        ///// <summary>
        ///// �����о���(0:�� 1:��)
        ///// </summary>
        //public virtual int Judgement { get; set; }

        ///// <summary>
        ///// HtmlID
        ///// </summary>
        //public virtual long HtmlID { get; set; }

        ///// <summary>
        ///// 1�����¿ɼ���δ�� 2:���Ͽɼ�������
        ///// </summary>
        //public virtual int Show { get; set; }

        ///// <summary>
        ///// ���ݼ���(0:���� 1:�ڲ���Ա�ɼ� 2:���ܿɼ� 3:�����û��ɼ�)
        ///// </summary>
        //public virtual string DataGradeID { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual string AddUser { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual System.DateTime? AddDatetime { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual string UpdUser { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public virtual System.DateTime? UpdDatetime { get; set; }


        ///// <summary>
        ///// ��ע
        ///// </summary>
        //public virtual string Remark { get; set; }
        ///// <summary>
        ///// 0:���� 1:����
        ///// </summary>
        //public virtual int Enable { get; set; }

        #endregion



    }
}
