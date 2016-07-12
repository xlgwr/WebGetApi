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

    [Table("m_Case_main")]
    public class m_Case_main : entityMain
    {
        public m_Case_main()
        {
            this.m_Case_items = new List<m_Case_items>();
        }
        public ICollection<m_Case_items> m_Case_items { get; set; }

    }

    [Table("m_Case_items")]
    public class m_Case_items : entityItems
    {
        [Index]
        [ForeignKey("m_Case_main")]
        public long htmlID { get; set; }


        /// <summary>
        /// 案件编号
        /// </summary>
       // [Column(TypeName = "text")]
        public string CaseNo { get; set; }

        /// <summary>
        /// 法院ID
        /// </summary>
       // [Column(TypeName = "text")]
        public string CourtID { get; set; }


        /// <summary>
        /// 案件类别
        /// </summary>
        // [Column(TypeName = "text")]
        [Column("CaseTypeID")]
        public string CaseType { get; set; }

        /// <summary>
        /// 案件年份
        /// </summary>
        // [Column(TypeName = "text")]
        [Column("Year")]
        public string CYear { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int SerialNo { get; set; }


        /// <summary>
        /// 开庭日期
        /// </summary>
       // [Column(TypeName = "text")]
        public string CourtDay { get; set; }




        /// <summary>
        /// 原告 Old
        /// </summary>
       // [Column(TypeName = "text")]
        public string Parties { get; set; }
        /// <summary>
        /// 原告
        /// </summary>
       // [Column(TypeName = "text")]
        public string PlainTiff { get; set; }


        /// <summary>
        /// 被告
        /// </summary>
       // [Column(TypeName = "text")]
        public string Defendant { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        // [Column(TypeName = "text")]
        //public string Cause { get; set; }

        /// <summary>
        /// 性质
        /// </summary>
        // [Column(TypeName = "text")]
        public string Nature { get; set; }

        /// <summary>
        /// 法官
        /// </summary>
       // [Column(TypeName = "text")]
        public string Judge { get; set; }

        /// <summary>
        /// 应讯代表
        /// </summary>
       // [Column(TypeName = "text")]
        public string Representation { get; set; }

        /// <summary>
        /// 聆讯
        /// </summary>
       // [Column(TypeName = "text")]
        public string Hearing { get; set; }

        /// <summary>
        /// 计划行动日期
        /// </summary>
        //public string Actiondate { get; set; }

        /// <summary>
        /// 币别
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// 检验区
        /// </summary>
        //public string CheckField { get; set; }

        public string P_Address { get; set; }
        public string D_Address { get; set; }
        public string Other { get; set; }
        public string Other1 { get; set; }


        [JsonIgnore]
        public m_Case_main m_Case_main { get; set; }
    }
}
