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
    [Table("gwd_Lawyers_main")]
    public class gwd_Lawyers_main : entityMainComm
    {
        public gwd_Lawyers_main()
        {
            this.gwd_Lawyers_items = new List<gwd_Lawyers_items>();
        }
        public ICollection<gwd_Lawyers_items> gwd_Lawyers_items { get; set; }
    }


    [Table("gwd_Lawyers_items")]
    public class gwd_Lawyers_items : entityItems
    {
        [Index]
        [ForeignKey("gwd_Lawyers_main")]
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
        /// 前称（中文）
        /// </summary>
        public string BeforeName { get; set; }

        /// <summary>
        /// 在香港认许日期
        /// </summary>
        public string ApproveDate { get; set; }

        /// <summary>
        /// 其他认许国家
        /// </summary>
        public string ApproveCountry { get; set; }

        /// <summary>
        /// 其他国家认许日期
        /// </summary>
        public string OtherDate { get; set; }

        /// <summary>
        /// 邮件地址
        /// </summary>
        public string LawyerEmail { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 律师行/公司（英文）
        /// </summary>
        public string LawyerCompany { get; set; }

        /// <summary>
        /// 律师行/公司（中文）
        /// </summary>
        public string ChineseCompany { get; set; }

        /// <summary>
        /// 地址（英文）
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 地址（中文）
        /// </summary>
        public string ChineseAddress { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Companytel { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string CompanyFax { get; set; }

        /// <summary>
        /// DX号码
        /// </summary>
        public string Dxnumber { get; set; }
        /// <summary>
        /// 律师行邮箱
        /// </summary>
        public string CompanyEmail { get; set; }

        [JsonIgnore]
        public gwd_Lawyers_main gwd_Lawyers_main { get; set; }
    }

}
