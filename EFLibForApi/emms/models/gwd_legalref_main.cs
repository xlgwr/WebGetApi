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

    [Table("gwd_legalref_main")]
    public class gwd_legalref_main : entityGetWebDatas
    {

        public gwd_legalref_main()
        {
            this.gwd_legalref_items = new List<gwd_legalref_items>();
        }
        [Key]
        [Column(Order = 1)]
        public string Tdate { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public long TDis { get; set; }

        [Required]
        [Index]
        public long TGetDis { get; set; }

        public string ReportedIn { get; set; }

        public ICollection<gwd_legalref_items> gwd_legalref_items { get; set; }

    }

    [Table("gwd_legalref_items")]
    public class gwd_legalref_items : entity
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("gwd_legalref_main")]
        public string Tid { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("gwd_legalref_main")]
        public string Tdate { get; set; }


        [Key]
        [Column(Order = 2)]
        public int TIndex { get; set; }

        /// <summary>
        ///语言 en:英文 zh:中文
        /// </summary>
        public string tlang { get; set; }

        /// <summary>
        /// 1:Press Summary, 0: 主页
        /// </summary>
        public int isPressSummary { get; set; }


        [Column(TypeName = "text")]
        public string thtml { get; set; }

        [JsonIgnore]
        public gwd_legalref_main gwd_legalref_main { get; set; }
    }
}
