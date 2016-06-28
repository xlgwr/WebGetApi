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
    /// 特许秘书表
    /// http://www.sb.gov.hk/sc/links/sgsia/tall.htm
    /// </summary>
    [Table("i_Secretaries")]
    public class i_Secretaries : entityItems
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
