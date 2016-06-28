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
    /// 香港特别行政区政府及有关机构电话薄表
    /// </summary>
    [Table("i_GovPhonebook")]
    public class i_GovPhonebook : entityItems
    {
        [Index]
        [ForeignKey("entityCommMain")]
        public long htmlID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public long GovId { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string GovName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string PostTitle { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string OfficePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        [JsonIgnore]
        public entityCommMain entityCommMain { get; set; }

    }

}
