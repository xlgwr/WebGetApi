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
    public abstract class entityItems : entityTID
    {
        [Key]
        [Column("Language",Order = 1)]
        public long tLang { get; set; }

        [Key]
        [Column(Order = 2)]
        public string tkeyNo { get; set; }

        [Key]
        [Column(Order = 3)]
        public long tIndex { get; set; }

        //[StringLength(500)]
        public string tname { get; set; }


        [StringLength(300)]
        public string ttype { get; set; }


    }
}
