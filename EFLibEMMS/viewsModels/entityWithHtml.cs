using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFLibEMMS.EMMS;

namespace EFLibEMMS.viewsModels
{
    public abstract class entityWithHtml
    {
        public s_Entity s_Entity { get; set; }
        public t_HtmlPageCom s_Company_html { get; set; }
    }
}
