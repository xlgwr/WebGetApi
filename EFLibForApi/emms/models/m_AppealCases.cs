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

    [Table("m_RatioDecidendis")]
    public class m_RatioDecidendis : entityMain
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
    [Table("m_AppealCases")]
    public class m_AppealCases : entityItems
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
