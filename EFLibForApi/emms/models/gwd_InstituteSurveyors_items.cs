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
    /// 香港测量师学会
    /// http://www.hkis.org.hk/zh/company_list2.php?id=47
    /// </summary>
    [Table("gwd_InstituteSurveyors_items")]
    public class gwd_InstituteSurveyors_items : entityItems
    {
        [Index]
        [ForeignKey("entityCommMain")]
        public long htmlID { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [Index]
        [StringLength(128)]
        public string CompanyName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 联络人
        /// </summary>
        public string ContactPerson { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string TelNo { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 網址
        /// </summary>
        public string Website { get; set; }

        [JsonIgnore]
        public entityCommMain entityCommMain { get; set; }

    }

}
