namespace EFLibEMMS.EMMS
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class s_Company
    {
        public s_Company()
        {
            Language = 0;
            Show = 2;
        }
        [Key]
        [Column(Order = 0)]
        [StringLength(16)]
        public string CRNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("s_Entity")]
        public long Entityid { get; set; }

        public long HtmlPageID { get; set; }

        /// <summary>
        /// 0:英文 1:简体 2:繁体
        /// </summary>
        public int Language { get; set; }


        /// <summary>
        /// 名称EN
        /// </summary>
        /// 
        [StringLength(128)]
        public string FullName_En { get; set; }

        /// <summary>
        /// 名称CN
        /// </summary>
        [StringLength(128)]
        public string FullName_Cn { get; set; }

        /// <summary>
        /// 公司国别
        /// </summary>
        [StringLength(32)]
        public string CountryID { get; set; }

        /// <summary>
        /// 公司类别 0:有限公司 1:无限公司 2:股份公司
        /// </summary>
        [StringLength(64)]
        public string CompanyType { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        [StringLength(32)]
        public string IncorporationDate { get; set; }

        /// <summary>
        /// 注册资本
        /// </summary>
        [StringLength(16)]
        public string AuthorizedCapital { get; set; }

        /// <summary>
        /// 地域 0:本地 1:国外 2:其他
        /// </summary>
        public int? Areas { get; set; }

        /// <summary>
        /// 注册地址
        /// </summary>
        [StringLength(128)]
        public string PlaceRegistration { get; set; }

        /// <summary>
        /// 是否上市(0:未上市 1:已上市)
        /// </summary>
        public int? Listed { get; set; }

        /// <summary>
        /// 已发行股票(0:未发行 1:已发行)
        /// </summary>
        public int? IssuedShares { get; set; }

        /// <summary>
        /// 现状(公司注册处有这项)
        /// </summary>
        [StringLength(256)]
        public string ActiveStatus { get; set; }

        /// <summary>
        /// 清盘模式
        /// </summary>
        [StringLength(64)]
        public string WindingUpMode { get; set; }

        /// <summary>
        /// 已告解散日期
        /// </summary>
        [StringLength(32)]
        public string DissolutionDate { get; set; }

        /// <summary>
        /// 押记登记册
        /// </summary>
        [StringLength(64)]
        public string RegisterOfCharges { get; set; }

        /// <summary>
        /// 重要事项
        /// </summary>
        [StringLength(256)]
        public string ImportantNote { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(256)]
        public string Remarks { get; set; }

        /// <summary>
        /// 1：线下可见（未审） 2:线上可见（已审）(公司以此为准)
        /// </summary>
        public int? Show { get; set; }

        /// <summary>
        /// 数据级别
        /// </summary>
        [StringLength(32)]
        public string DataGradeID { get; set; }

        [JsonIgnore]
        public s_Entity s_Entity { get; set; }
    }
}
