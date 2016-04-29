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
    public class gwd_Judiciary_main : entityMain
    {
        public gwd_Judiciary_main()
        {
            this.gwd_Judiciary_items = new List<gwd_Judiciary_items>();
        }
        public ICollection<gwd_Judiciary_items> gwd_Judiciary_items { get; set; }

    }

    [Table("gwd_Judiciary_items")]
    public class gwd_Judiciary_items : entityItems
    {
        [Index]
        [ForeignKey("gwd_Judiciary_main")]
        public long htmlID { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int SerialNo { get; set; }

        /// <summary>
        /// 法院ID
        /// </summary>
        [Column(TypeName = "text")]
        public string CourtID { get; set; }


        /// <summary>
        /// 法官
        /// </summary>
        [Column(TypeName = "text")]
        public string Judge { get; set; }


        /// <summary>
        /// 案件年份
        /// </summary>
        [Column(TypeName = "text")]
        public string CYear { get; set; }


        /// <summary>
        /// 开庭日期
        /// </summary>
        [Column(TypeName = "text")]
        public string CourtDay { get; set; }


        /// <summary>
        /// 聆讯
        /// </summary>
        [Column(TypeName = "text")]
        public string Hearing { get; set; }


        /// <summary>
        /// 案件编号
        /// </summary>
        [Column(TypeName = "text")]
        public string CaseNo { get; set; }

        /// <summary>
        /// 案件类别
        /// </summary>
        [Column(TypeName = "text")]
        public string CaseType { get; set; }

        /// <summary>
        /// 原告
        /// </summary>
        [Column(TypeName = "text")]
        public string PlainTiff { get; set; }


        /// <summary>
        /// 被告
        /// </summary>
        [Column(TypeName = "text")]
        public string Defendant { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        [Column(TypeName = "text")]
        public string Cause { get; set; }

        /// <summary>
        /// 性质
        /// </summary>
        [Column(TypeName = "text")]
        public string Nature { get; set; }



        /// <summary>
        /// 应讯代表
        /// </summary>
        [Column(TypeName = "text")]
        public string Representation { get; set; }

        [JsonIgnore]
        public gwd_Judiciary_main gwd_Judiciary_main { get; set; }
    }
}
