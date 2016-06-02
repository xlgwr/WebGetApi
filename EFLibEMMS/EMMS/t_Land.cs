namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Land
    {
        [Key]
        [StringLength(32)]
        public string LandID { get; set; }

        [StringLength(32)]
        public string LandNO { get; set; }

        [StringLength(32)]
        public string SearchTime { get; set; }

        [StringLength(32)]
        public string SearchType { get; set; }

        public DateTime? CutTime { get; set; }

        [StringLength(32)]
        public string LotType { get; set; }

        [StringLength(32)]
        public string LotNo { get; set; }

        [StringLength(32)]
        public string ShareLot { get; set; }

        [StringLength(16)]
        public string Section { get; set; }

        [StringLength(16)]
        public string Subsection { get; set; }

        [StringLength(64)]
        public string BuildName { get; set; }

        [StringLength(8)]
        public string HouseNO { get; set; }

        [StringLength(8)]
        public string RoomNO { get; set; }

        [StringLength(8)]
        public string Floor { get; set; }

        [StringLength(64)]
        public string Street { get; set; }

        [StringLength(8)]
        public string StreetNumber { get; set; }

        [StringLength(16)]
        public string Area { get; set; }

        [StringLength(128)]
        public string Address { get; set; }

        [StringLength(128)]
        public string PathHTML { get; set; }

        [StringLength(128)]
        public string PathExcel { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }

        public int? Show { get; set; }

        [StringLength(32)]
        public string DataGradeID { get; set; }
    }
}
