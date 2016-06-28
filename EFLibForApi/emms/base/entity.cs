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
        public string Remark { get; set; }

        public int tStatus { get; set; }

        public string ClientIP { get; set; }

        [StringLength(128)]
        public string adduser { get; set; }

        [StringLength(128)]
        public string upduser { get; set; }

        [Index]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime addtime { get; set; }

        public DateTime updtime { get; set; }

    }
}
