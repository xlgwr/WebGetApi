namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("s_Entity")]
    public partial class s_Entity
    {
        public s_Entity()
        {

            s_Company = new HashSet<s_Company>();
            t_CompanyChange = new HashSet<t_CompanyChange>();
            //t_Disqualification = new HashSet<t_Disqualification>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Entityid { get; set; }

        /// <summary>
        /// ���1:P 2:C 3:U(unknown)
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// ���1:��ͥ 2:��˾ 3:���� 4:�Ŵ� 5:����
        /// </summary>
        public int Flag { get; set; }

        /// <summary>
        /// ����(��flag=1ʱ ���ｫ����0:ԭ��,1:���� 2:���� 3:ԭ����ʦ 4:������ʦ��)
        /// </summary>
        public int? Param1 { get; set; }

        //public int? Show { get; set; }

        public ICollection<s_Company> s_Company { get; set; }
        public ICollection<t_CompanyChange> t_CompanyChange { get; set; }
        //public ICollection<t_Disqualification> t_Disqualification { get; set; }
    }
}
