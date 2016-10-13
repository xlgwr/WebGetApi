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

    [Table("m_RatioDecidendis")]
    public class m_RatioDecidendis : entityMain
    {
        private string _caseNo = "";
        [Index]
        [StringLength(128)]
        public string caseNo
        {
            get { return _caseNo; }
            set
            {
                _caseNo = value;
                if (value != null)
                {
                    if (value.IndexOf("/") > -1)
                    {
                        var arrList = value.Split('/');
                        var tmp1 = arrList[1].Trim();
                        if (tmp1.Length == 2)
                        {
                            tmp1 += "20" + tmp1;
                        }
                        _caseNo = arrList[0].Trim() + "/" + tmp1;
                    }
                }


            }
        }


        [Index]
        [StringLength(128)]
        public string caseDate { get; set; }

        [Index]
        public long TDis { get; set; }

        [Index]
        public long TGetDis { get; set; }

    }
    [Table("m_AppealCases")]
    public class m_AppealCases : entityItems
    {
        private string _caseNo = "";
        [Index]
        [StringLength(128)]
        public string caseNo
        {
            get { return _caseNo; }
            set
            {
                _caseNo = value;
                if (value != null)
                {
                    if (value.IndexOf("/") > -1)
                    {
                        var arrList = value.Split('/');
                        var tmp1 = arrList[1].Trim();
                        if (tmp1.Length == 2)
                        {
                            tmp1 += "20" + tmp1;
                        }
                        _caseNo = arrList[0].Trim() + "/" + tmp1;
                    }
                }
            }
        }

        [StringLength(128)]
        public string caseDate { get; set; }

        [Index]
        public long TDis { get; set; }

        [Index]
        public long TGetDis { get; set; }

        public string ReportedIn { get; set; }
    }


}
