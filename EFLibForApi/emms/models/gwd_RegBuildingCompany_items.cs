using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace EFLibForApi.emms.models
{
    /// <summary>
    /// 注册建筑师（公司）表
    /// https://mwerdr.bd.gov.hk/REGISTER/RegistrationSearch.do
    /// </summary>
    [Table("gwd_RegBuildingCompany_items")]
    public class gwd_RegBuildingCompany_items : entityItems
    {
        [Index]
        [ForeignKey("entityCommMain")]
        public long htmlID { get; set; }

        /// <summary>
        /// 注册编号
        /// </summary>
        [Index]
        [StringLength(128)]
        public string RegNo { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Index]
        [StringLength(128)]
        public string CompanyName { get; set; }

        [StringLength(128)]
        public string CompanyNameZH { get; set; }


        [StringLength(128)]
        public string AuthorizedSignatory { get; set; }
        public string classType { get; set; }

        /// <summary>
        /// 服务于楼宇安全
        /// </summary>
        public string BuildingSafety { get; set; }

        /// <summary>
        /// 到期日
        /// </summary>
        [StringLength(128)]
        public string ExpiryDate { get; set; }

        [StringLength(128)]
        public string PhoneNo { get; set; }
        public string Districtarea { get; set; }
        public string Emailaddress { get; set; }
        public string Faxno { get; set; }

        [JsonIgnore]
        public entityCommMain entityCommMain { get; set; }

    }

}
