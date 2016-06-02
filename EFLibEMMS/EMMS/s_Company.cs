namespace EFLibEMMS.EMMS
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class s_Company
    {
        public s_Company()
        {
            Language = 0;
            Show = 2;
        }
        [Key]
        [Column(Order = 0)]
        [StringLength(16)]
        public string CRNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("s_Entity")]
        public long Entityid { get; set; }

        public long HtmlPageID { get; set; }

        /// <summary>
        /// 0:Ӣ�� 1:���� 2:����
        /// </summary>
        public int Language { get; set; }


        /// <summary>
        /// ����EN
        /// </summary>
        /// 
        [StringLength(128)]
        public string FullName_En { get; set; }

        /// <summary>
        /// ����CN
        /// </summary>
        [StringLength(128)]
        public string FullName_Cn { get; set; }

        /// <summary>
        /// ��˾����
        /// </summary>
        [StringLength(32)]
        public string CountryID { get; set; }

        /// <summary>
        /// ��˾��� 0:���޹�˾ 1:���޹�˾ 2:�ɷݹ�˾
        /// </summary>
        [StringLength(64)]
        public string CompanyType { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [StringLength(32)]
        public string IncorporationDate { get; set; }

        /// <summary>
        /// ע���ʱ�
        /// </summary>
        [StringLength(16)]
        public string AuthorizedCapital { get; set; }

        /// <summary>
        /// ���� 0:���� 1:���� 2:����
        /// </summary>
        public int? Areas { get; set; }

        /// <summary>
        /// ע���ַ
        /// </summary>
        [StringLength(128)]
        public string PlaceRegistration { get; set; }

        /// <summary>
        /// �Ƿ�����(0:δ���� 1:������)
        /// </summary>
        public int? Listed { get; set; }

        /// <summary>
        /// �ѷ��й�Ʊ(0:δ���� 1:�ѷ���)
        /// </summary>
        public int? IssuedShares { get; set; }

        /// <summary>
        /// ��״(��˾ע�ᴦ������)
        /// </summary>
        [StringLength(256)]
        public string ActiveStatus { get; set; }

        /// <summary>
        /// ����ģʽ
        /// </summary>
        [StringLength(64)]
        public string WindingUpMode { get; set; }

        /// <summary>
        /// �Ѹ��ɢ����
        /// </summary>
        [StringLength(32)]
        public string DissolutionDate { get; set; }

        /// <summary>
        /// Ѻ�ǵǼǲ�
        /// </summary>
        [StringLength(64)]
        public string RegisterOfCharges { get; set; }

        /// <summary>
        /// ��Ҫ����
        /// </summary>
        [StringLength(256)]
        public string ImportantNote { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        [StringLength(256)]
        public string Remarks { get; set; }

        /// <summary>
        /// 1�����¿ɼ���δ�� 2:���Ͽɼ�������(��˾�Դ�Ϊ׼)
        /// </summary>
        public int? Show { get; set; }

        /// <summary>
        /// ���ݼ���
        /// </summary>
        [StringLength(32)]
        public string DataGradeID { get; set; }

        [JsonIgnore]
        public s_Entity s_Entity { get; set; }
    }
}
