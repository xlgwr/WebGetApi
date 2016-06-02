namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_Word
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Wordkey { get; set; }

        [StringLength(8)]
        public string CN { get; set; }

        [StringLength(8)]
        public string TM { get; set; }

        [StringLength(16)]
        public string CN_Pin { get; set; }

        [StringLength(16)]
        public string GD_Pin { get; set; }

        [StringLength(8)]
        public string WordCode { get; set; }
    }
}
