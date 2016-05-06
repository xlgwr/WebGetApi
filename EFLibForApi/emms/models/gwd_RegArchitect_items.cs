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
    /// 注册建筑师（个人）表
    /// https://mwerdr.bd.gov.hk/REGISTER/RegistrationSearch.do
    /// </summary>
    [Table("gwd_RegArchitect_items")]
    public class gwd_RegArchitect_items : entityItems
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
        public string ArchitectsName { get; set; }

        [StringLength(128)]
        public string ArchitectsNameZH { get; set; }

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

        [JsonIgnore]
        public entityCommMain entityCommMain { get; set; }

    }

}
