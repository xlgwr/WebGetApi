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

    [Table("gwd_Judiciary_main")]
    public class gwd_Judiciary_main : entityGetWebDatas
    {
        public gwd_Judiciary_main()
        {
            this.gwd_Judiciary_items = new List<gwd_Judiciary_items>();
        }
        public ICollection<gwd_Judiciary_items> gwd_Judiciary_items { get; set; }

    }

    [Table("gwd_Judiciary_items")]
    public class gwd_Judiciary_items : entity
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("gwd_Judiciary_main")]
        public string Tid { get; set; }

        [Key]
        [Column(Order = 1)]
        public int Tindex { get; set; }


        /// <summary>
        /// 序号
        /// </summary>
        public int SerialNo { get; set; }

        /// <summary>
        /// 法院ID
        /// </summary>
        [StringLength(100)]
        public string CourtID { get; set; }


        /// <summary>
        /// 法官
        /// </summary>
        [StringLength(200)]
        public string Judge { get; set; }


        /// <summary>
        /// 案件年份
        /// </summary>
        [StringLength(100)]
        public string CYear { get; set; }


        /// <summary>
        /// 开庭日期
        /// </summary>
        [StringLength(100)]
        public string CourtDay { get; set; }


        /// <summary>
        /// 聆讯
        /// </summary>
        [StringLength(100)]
        public string Hearing { get; set; }


        /// <summary>
        /// 案件编号
        /// </summary>
        [StringLength(100)]
        public string CaseNo { get; set; }

        /// <summary>
        /// 案件类别
        /// </summary>
        [StringLength(100)]
        public string CaseType { get; set; }

        /// <summary>
        /// 原告
        /// </summary>
        [StringLength(200)]
        public string PlainTiff { get; set; }


        /// <summary>
        /// 被告
        /// </summary>
        [StringLength(200)]
        public string Defendant { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        [StringLength(500)]
        public string Cause { get; set; }

        /// <summary>
        /// 性质
        /// </summary>
        [StringLength(100)]
        public string Nature { get; set; }



        /// <summary>
        /// 应讯代表
        /// </summary>
        [StringLength(100)]
        public string Representation { get; set; }

        [JsonIgnore]
        public gwd_Judiciary_main gwd_Judiciary_main { get; set; }
    }
}
