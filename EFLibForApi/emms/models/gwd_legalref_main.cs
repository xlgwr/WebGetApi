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
        [Key]
        [Column(Order = 1)]
        public string Tdate { get; set; }

        [Key]
        [Column(Order = 2)]
        public int TIndex { get; set; }

        [Required]
        [Index(Order = 0)]
        public long TDis { get; set; }

        [Required]
        [Index(Order = 1)]
        public long TGetDis { get; set; }

        public string ReportedIn { get; set; }
    }

}
