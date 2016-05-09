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
    /// 建筑师
    /// http://www.hkia.net/en/LookingForConstructionCompanys/LookingForConstructionCompanys_02.htm
    /// http://218.188.25.84/corporate_member/contact.php?search=A
    /// </summary>
    [Table("gwd_ConstructionCompany_items")]
    public class gwd_ConstructionCompany_items : entityItems
    {
        [Index]
        [ForeignKey("entityCommMain")]
        public long htmlID { get; set; }

        /// <summary>
        /// 注册编号
        /// </summary>
        [Index]
        [StringLength(128)]
        public string ConstructionCyID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Index]
        [StringLength(128)]
        public string CompanyName { get; set; }

        [StringLength(128)]
        public string ChineseName { get; set; }

        /// <summary>
        /// 公司简介
        /// </summary>
        public string Summary { get; set; }
        
        public string address { get; set; }
        public string addressZH { get; set; }

        [StringLength(128)]
        public string Tel { get; set; }

        [StringLength(128)]
        public string Fax { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(128)]
        public string webUrl { get; set; }
        

        [JsonIgnore]
        public entityCommMain entityCommMain { get; set; }

    }

}
