namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("t_Judgment")]
    public partial class t_Judgment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long JudgementID { get; set; }
        public long Language { get; set; }

        /// <summary>
        /// �����е�ID,t_Case
        /// </summary>
        public long? Caseid { get; set; }

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

        public DateTime? ResultDate { get; set; }


        [Column(TypeName = "text")]
        public string Results { get; set; }

        #region add new by xlg
        public string WebURL { get; set; }
        public string Remark { get; set; }
        /// <summary>
        /// ������ID
        /// </summary>
        public long TDis { get; set; }
        /// <summary>
        /// ���ϻ�ȡID
        /// </summary>

        public long TGetDis { get; set; }
        #endregion

    }
}
