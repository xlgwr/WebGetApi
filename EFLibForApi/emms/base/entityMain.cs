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
    public abstract class entityMain : entityTID
    {
        [Column("Language")]
        public long tLang { get; set; }

        [StringLength(500)]
        public string tname { get; set; }


        [StringLength(300)]
        public string ttype { get; set; }


        [Column(TypeName = "text")]
        public string thtml { get; set; }

    }
}
