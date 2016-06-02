namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_BankAccount
    {
        [Key]
        [StringLength(32)]
        public string BankAccountID { get; set; }

        public long Entityid { get; set; }

        [StringLength(64)]
        public string Bank { get; set; }

        [StringLength(16)]
        public string AccountType { get; set; }

        [StringLength(32)]
        public string AccountName { get; set; }

        [StringLength(32)]
        public string AccountNumber { get; set; }

        public DateTime? DateOpened { get; set; }

        public virtual s_Entity s_Entity { get; set; }
    }
}
