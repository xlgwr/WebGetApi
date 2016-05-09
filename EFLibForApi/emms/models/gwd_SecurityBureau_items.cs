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
    /// 香港特别行政区政府保安局
    /// http://www.sb.gov.hk/sc/links/sgsia/tall.htm
    /// </summary>
    [Table("gwd_SecurityBureau_items")]
    public class gwd_SecurityBureau_items : entityItems
    {
        [Index]
        [ForeignKey("entityCommMain")]
        public long htmlID { get; set; }

        /// <summary>
        /// 牌照编号
        /// </summary>
        [Index]
        [StringLength(128)]
        public string LicenceNo { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Index]
        [StringLength(128)]
        public string CompanyName { get; set; }

        [StringLength(128)]
        public string ChineseName { get; set; }

        /// <summary>
        /// 保安工作类别 
        /// </summary>
        public string WorkType { get; set; }

        public string address { get; set; }

        [StringLength(128)]
        public string TelNo { get; set; }


        [JsonIgnore]
        public entityCommMain entityCommMain { get; set; }

    }

}
