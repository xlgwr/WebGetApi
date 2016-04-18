using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLibForApi.emms.models
{
    public abstract class entity
    {
        [Column(TypeName = "text")]
        public string Remark { get; set; }

        public int tStatus { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime addDate { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}
