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
    [Table("m_CompaniesRegistry_main")]
    public class m_CompaniesRegistry_main : entityMain
    {
        public m_CompaniesRegistry_main()
        {
            this.m_CompaniesRegistry_items = new List<m_CompaniesRegistry_items>();
            this.m_CompaniesRegistry_itemsChange = new List<m_CompaniesRegistry_itemsChange>();
        }
        public ICollection<m_CompaniesRegistry_items> m_CompaniesRegistry_items { get; set; }
        public ICollection<m_CompaniesRegistry_itemsChange> m_CompaniesRegistry_itemsChange { get; set; }
    }


    [Table("m_CompaniesRegistry_items")]
    public class m_CompaniesRegistry_items : entityItems
    {
        [Index]
        [ForeignKey("m_CompaniesRegistry_main")]
        public long htmlID { get; set; }

        /// <summary>
        /// 公司名称 英文
        /// </summary>
        // [StringLength(200)]
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司名称 中文
        /// </summary>
        public string CompanyNameZH { get; set; }


        /// <summary>
        /// 公司类别
        /// </summary>
        // [StringLength(100)]
        public string CompanyType { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        // [StringLength(100)]
        public string FoundDate { get; set; }

        /// <summary>
        /// 公司现况
        /// </summary>
        // [StringLength(100)]
        public string CurrentState { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        // [StringLength(200)]
        public string tRemarkNow { get; set; }


        /// <summary>
        /// 清盘模式
        /// </summary>
        // [StringLength(100)]
        public string LiquidationMode { get; set; }

        /// <summary>
        /// 已告解散日期
        /// </summary>
        // [StringLength(100)]
        public string DisbandDate { get; set; }

        /// <summary>
        /// 押记登记册
        /// </summary>
        // [StringLength(50)]
        public string ChargeState { get; set; }


        /// <summary>
        /// 重要事项
        /// </summary>
        // [StringLength(100)]
        public string Important { get; set; }

        /// <summary>
        /// 董事资料 可供查阅
        /// </summary>
        //[Column(TypeName = "text")]
        // [StringLength(100)]
        public string tSearchRes { get; set; }

        [JsonIgnore]
        public m_CompaniesRegistry_main m_CompaniesRegistry_main { get; set; }
    }


    [Table("m_CompaniesRegistry_itemsChange")]
    public class m_CompaniesRegistry_itemsChange : entityItems
    {
        [Index]
        [ForeignKey("m_CompaniesRegistry_main")]
        public long htmlID { get; set; }

        /// <summary>
        /// 公司名称 英文
        /// </summary>
        // [StringLength(200)]
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司名称 中文
        /// </summary>
        public string CompanyNameZH { get; set; }
        /// <summary>
        /// 名称生效日期
        /// </summary>
        public string EffectiveDate { get; set; }

        [JsonIgnore]
        public m_CompaniesRegistry_main m_CompaniesRegistry_main { get; set; }

    }
    [Table("m_CompaniesRegistry_DisOrders")]
    public class m_CompaniesRegistry_DisOrders : entity
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

        [Column(TypeName = "text")]
        public string thtml { get; set; }
    }
}
