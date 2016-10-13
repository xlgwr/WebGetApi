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
        /// 类别1:P 2:C 3:U(unknown)
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 标记1:法庭 2:公司 3:土地 4:信贷 5:公共
        /// </summary>
        public int Flag { get; set; }

        /// <summary>
        /// 参数(当flag=1时 这里将保存0:原告,1:被告 2:法官 3:原告律师 4:被告律师等)
        /// </summary>
        public int? Param1 { get; set; }

        //public int? Show { get; set; }

        public ICollection<s_Company> s_Company { get; set; }
        public ICollection<t_CompanyChange> t_CompanyChange { get; set; }
        //public ICollection<t_Disqualification> t_Disqualification { get; set; }
    }
}
