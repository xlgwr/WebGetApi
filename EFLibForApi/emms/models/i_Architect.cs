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
    /// http://www.hkia.net/en/LookingForArchitects/LookingForArchitects_02.htm
    /// http://218.188.25.84/member_list_name.php?keyword=a
    /// </summary>
    [Table("i_Architect")]
    public class i_Architect : entityItems
    {
        [Index]
        [ForeignKey("entityCommMain")]
        public long htmlID { get; set; }

        /// <summary>
        /// 注册编号
        /// </summary>
        [Index]
        [StringLength(128)]
        public string ArchitectId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Index]
        [StringLength(128)]
        public string MembershipEn { get; set; }

        [StringLength(128)]
        public string MembershipCn { get; set; }

        /// <summary>
        /// 会员类别
        /// </summary>
        public string MembershipType { get; set; }

        /// <summary>
        /// 入会年份
        /// </summary>
        [StringLength(128)]
        public string MembershipYear { get; set; }

        [JsonIgnore]
        public entityCommMain entityCommMain { get; set; }

    }

}
