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
    public abstract class entityMainComm : entityTID
    {
        public long tLang { get; set; }

        [StringLength(200)]
        public string tname { get; set; }


        [StringLength(200)]
        public string ttype { get; set; }


        [Column(TypeName = "text")]
        public string thtml { get; set; }

    }
}
