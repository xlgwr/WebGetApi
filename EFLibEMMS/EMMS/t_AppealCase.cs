namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("t_AppealCase")]
    public partial class t_AppealCase
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AppealID { get; set; }

        private string _caseNo = "";
        public string CaseNo
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

        public string OldCaseNo { get; set; }

        public DateTime? OldDate { get; set; }

        public string Remark { get; set; }


        public string adduser { get; set; }

        public System.DateTime? addtime { get; set; }

        public string upduser { get; set; }

        public System.DateTime? updtime { get; set; }

        #region add new by xlg
        public string WebURL { get; set; }
        /// <summary>
        /// 网上主ID
        /// </summary>
        public long TDis { get; set; }
        /// <summary>
        /// 网上获取ID
        /// </summary>

        public long TGetDis { get; set; }

        public string ReportedIn { get; set; }
        #endregion
    }
}
