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
    public abstract class entityGetWebDatas : entity
    {
        [Key]
        [Column(Order = 0)]
        public string Tid { get; set; }

        [StringLength(50)]
        public string tname { get; set; }


        [StringLength(50)]
        public string ttype { get; set; }


        [StringLength(100)]
        public string tcontent { get; set; }


        [Column(TypeName = "text")]
        public string tGetTable { get; set; }

        [Column(TypeName = "text")]
        public string thtml { get; set; }

    }
}
