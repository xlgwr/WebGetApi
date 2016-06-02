namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_IDDocuments
    {
        [Key]
        [StringLength(32)]
        public string IDDocumentID { get; set; }

        public long? Entityid { get; set; }

        public int? Type { get; set; }

        [StringLength(32)]
        public string Number { get; set; }

        public DateTime? CertificateDate { get; set; }

        public virtual s_Entity s_Entity { get; set; }
    }
}
