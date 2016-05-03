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
    [Table("m_parameter")]
    public class m_parameter : entity
    {

        [Key]
        [StringLength(128)]
        public string paramkey { get; set; }


        [StringLength(128)]
        public string paramvalue { get; set; }


        [StringLength(128)]
        public string paramtype { get; set; }

    }
}
