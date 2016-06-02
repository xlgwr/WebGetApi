namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_Country
    {
        [Key]
        [StringLength(32)]
        public string Countryid { get; set; }

        [StringLength(64)]
        public string CountryName { get; set; }

        [StringLength(32)]
        public string LanguageCode { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }
    }
}
