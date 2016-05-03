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
    /// <summary>
    /// 公共主表
    /// </summary>
    [Table("entityCommMain")]
    public class entityCommMain : entityTID
    {
        public long tLang { get; set; }

        [StringLength(200)]
        public string tname { get; set; }


        [StringLength(200)]
        public string ttype { get; set; }


        [Column(TypeName = "text")]
        public string thtml { get; set; }

        public entityCommMain()
        {
            this.gwd_Barristers_items = new List<gwd_Barristers_items>();

            this.gwd_Lawyers_items = new List<gwd_Lawyers_items>();

            this.gwd_GovernmentPhonebook_items = new List<gwd_GovernmentPhonebook_items>();
        }
        public ICollection<gwd_Barristers_items> gwd_Barristers_items { get; set; }
        public ICollection<gwd_Lawyers_items> gwd_Lawyers_items { get; set; }
        public ICollection<gwd_GovernmentPhonebook_items> gwd_GovernmentPhonebook_items { get; set; }

    }
}
