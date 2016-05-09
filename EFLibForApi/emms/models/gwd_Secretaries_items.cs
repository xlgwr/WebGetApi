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
    [Table("gwd_Secretaries_items")]
    public class gwd_Secretaries_items : entityItems
    {
        [Index]
        [ForeignKey("entityCommMain")]
        public long htmlID { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        [Index]
        [StringLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        [StringLength(128)]
        public string Grade { get; set; }


        [JsonIgnore]
        public entityCommMain entityCommMain { get; set; }

    }

}
