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
    /// 建筑公司表
    /// http://www.hkia.net/en/LookingForConstructionCompanys/LookingForConstructionCompanys_02.htm
    /// http://218.188.25.84/corporate_member/contact.php?search=A
    /// </summary>
    [Table("i_BuildingCom")]
    public class i_BuildingCom : entityItems
    {
        [Index]
        [ForeignKey("entityCommMain")]
        public long htmlID { get; set; }

        /// <summary>
        /// 注册编号
        /// </summary>
        [Index]
        [StringLength(128)]
        public string BuildingComID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Index]
        [StringLength(128)]
        public string CompanyNameEn { get; set; }

        [StringLength(128)]
        public string CompanyNameCn { get; set; }

        /// <summary>
        /// 公司简介
        /// </summary>
        public string Summary { get; set; }
        
        public string AddressEn { get; set; }
        public string AddressCn { get; set; }

        [StringLength(128)]
        public string Tel { get; set; }

        [StringLength(128)]
        public string Fax { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(128)]
        public string WebSite { get; set; }
        

        [JsonIgnore]
        public entityCommMain entityCommMain { get; set; }

    }

}
