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
    [Table("gwd_ICRIS_main")]
    public class gwd_ICRIS_main : entityGetWebDatas
    {
        public gwd_ICRIS_main()
        {
            this.gwd_ICRIS_items = new gwd_ICRIS_items();
        }
        public gwd_ICRIS_items gwd_ICRIS_items { get; set; }
    }


    [Table("gwd_ICRIS_items")]
    public class gwd_ICRIS_items : entity
    {
        [Key]
        public string Tid { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>

        /// <summary>
        /// 公司名称
        /// </summary>
        // [StringLength(200)]
        public string tcomp { get; set; }


        /// <summary>
        /// 公司类别
        /// </summary>
        // [StringLength(100)]
        public string tclass { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        // [StringLength(100)]
        public string tStartDate { get; set; }

        /// <summary>
        /// 名称生效日期
        /// </summary>
        // [StringLength(100)]
        public string tCompStartDate { get; set; }

        /// <summary>
        /// 使用名称
        /// </summary>
        // [StringLength(200)]
        public string tCompStart { get; set; }

        /// <summary>
        /// 公司现况
        /// </summary>
        // [StringLength(100)]
        public string tNows { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        // [StringLength(200)]
        public string tRemarkNow { get; set; }


        /// <summary>
        /// 清盘模式
        /// </summary>
        // [StringLength(100)]
        public string tModel { get; set; }

        /// <summary>
        /// 已告解散日期
        /// </summary>
        // [StringLength(100)]
        public string tCloseDate { get; set; }

        /// <summary>
        /// 押记登记册
        /// </summary>
        // [StringLength(50)]
        public string tSaveBook { get; set; }


        /// <summary>
        /// 重要事项
        /// </summary>
        // [StringLength(100)]
        public string tImEvens { get; set; }

        /// <summary>
        /// 董事资料 可供查阅
        /// </summary>
        //[Column(TypeName = "text")]
        // [StringLength(100)]
        public string tSearchRes { get; set; }

        [JsonIgnore]
        public gwd_ICRIS_main gwd_ICRIS_main { get; set; }
    }


    [Table("gwd_ICRIS_DisOrders")]
    public class gwd_ICRIS_DisOrders : entity
    {
        [Key]
        public string RecordID { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public long ItemNo { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public string CampanyNo { get; set; }
        /// <summary>
        /// 被取消资格人士姓名/法团名称
        /// </summary>
        public string CorporateName { get; set; }
        /// <summary>
        /// 中文姓名/名称
        /// </summary>
        public string ChineseName { get; set; }
        /// <summary>
        /// 香港身份证号码/公司编号
        /// </summary>
        public string IDCard { get; set; }
        /// <summary>
        /// 海外护照号码
        /// </summary>
        public string OverseasPassportID { get; set; }
        /// <summary>
        /// 护照签发国家
        /// </summary>
        public string PassportCountry { get; set; }
        /// <summary>
        /// 相同项目编号
        /// </summary>
        public string SameNo { get; set; }
    }
}
