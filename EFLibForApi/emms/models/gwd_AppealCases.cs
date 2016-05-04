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

    [Table("gwd_RatioDecidendis")]
    public class gwd_RatioDecidendis : entityMain
    {
        [Index]
        [StringLength(128)]
        public string caseNo { get; set; }

        [Index]
        [StringLength(128)]
        public string caseDate { get; set; }

        [Index]
        public long TDis { get; set; }

        [Index]
        public long TGetDis { get; set; }

    }
    [Table("gwd_AppealCases")]
    public class gwd_AppealCases : entityItems
    {

        [Index]
        [StringLength(128)]
        public string caseNo { get; set; }

        [StringLength(128)]
        public string caseDate { get; set; }

        [Index]
        public long TDis { get; set; }

        [Index]
        public long TGetDis { get; set; }

        public string ReportedIn { get; set; }
    }


}
