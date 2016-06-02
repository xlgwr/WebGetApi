namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Payment
    {
        [Key]
        [StringLength(32)]
        public string PaymentID { get; set; }

        [Required]
        [StringLength(32)]
        public string MemberID { get; set; }

        [StringLength(32)]
        public string OrderID { get; set; }

        [StringLength(32)]
        public string InvoiceID { get; set; }

        public int? PayType { get; set; }

        public int? PaymentWay { get; set; }

        [StringLength(64)]
        public string PayInterfaceID { get; set; }

        public double? SubTotal { get; set; }

        public double? RemainingSum { get; set; }

        public int? Success { get; set; }

        public DateTime? PayDate { get; set; }

        [StringLength(32)]
        public string EmailID { get; set; }

        public virtual m_Member m_Member { get; set; }

        public virtual t_Invoice t_Invoice { get; set; }

        public virtual t_Order t_Order { get; set; }
    }
}
