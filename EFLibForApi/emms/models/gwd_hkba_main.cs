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
    [Table("gwd_hkba_main")]
    public class gwd_hkba_main : entityMainComm
    {
        public gwd_hkba_main()
        {
            this.gwd_hkba_items = new List<gwd_hkba_items>();
        }
        public ICollection<gwd_hkba_items> gwd_hkba_items { get; set; }
    }

    [Table("gwd_hkba_items")]
    public class gwd_hkba_items : entityItems
    {
        [Index]
        [ForeignKey("gwd_hkba_main")]
        public long htmlID { get; set; }

        /// <summary>
        /// 姓名（英文）
        /// </summary>
        public string LawyerName { get; set; }

        /// <summary>
        /// 姓名（中文）
        /// </summary>
        public string ChineseName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Telphone { get; set; }

        /// <summary>
        /// 手提电话
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 业务范围
        /// </summary>
        public string PracticeAreas { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 学历/资历
        /// </summary>
        public string Quals { get; set; }
        /// <summary>
        /// 认许年份
        /// </summary>
        public string ApproveYear { get; set; }

        /// <summary>
        /// 是否普通话
        /// </summary>
        public string IsMandarin { get; set; }

        [JsonIgnore]
        public gwd_hkba_main gwd_hkba_main { get; set; }

    }

}
