using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLibEMMS.EMMS
{

    [Table("t_HtmlPageCom")]
    public class t_HtmlPageCom
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long HtmlID { get; set; }

        public int Language { get; set; }


        [StringLength(64)]
        public string Title { get; set; }


        [StringLength(512)]
        public string HtmlURL { get; set; }

        [Column(TypeName = "text")]
        public string HtmlPage { get; set; }


        [StringLength(256)]
        public string Remark { get; set; }
        
        public DateTime addDate { get; set; }
    }
}
