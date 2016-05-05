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
    /// 注册药剂师名单
    /// http://www.ppbhk.org.hk/eng/list_pharmacists/list.php
    /// </summary>
    [Table("gwd_RegisteredPharmacists_items")]
    public class gwd_RegisteredPharmacists_items : entityItems
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
        [StringLength(128)]
        public string RegName { get; set; }

        [StringLength(128)]
        public string RegNameZH { get; set; }

        /// <summary>
        /// 资格
        /// </summary>
        public string Qualifications { get; set; }

        /// <summary>
        /// 注册日期
        /// </summary>
        [StringLength(128)]
        public string RegDate { get; set; }

        [JsonIgnore]
        public entityCommMain entityCommMain { get; set; }

    }

}
