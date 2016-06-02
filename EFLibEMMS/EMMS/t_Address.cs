namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_Address
    {
        [Key]
        [StringLength(32)]
        public string AddressID { get; set; }

        public long Entityid { get; set; }

        [StringLength(16)]
        public string AddressType { get; set; }

        [StringLength(128)]
        public string Address { get; set; }

        [StringLength(8)]
        public string RoomNO { get; set; }

        [StringLength(8)]
        public string Floor { get; set; }

        [StringLength(64)]
        public string Street { get; set; }

        [StringLength(8)]
        public string StreetNumber { get; set; }

        [StringLength(16)]
        public string POBox { get; set; }

        [StringLength(16)]
        public string PostalCode { get; set; }

        [StringLength(16)]
        public string City { get; set; }

        [StringLength(16)]
        public string Province { get; set; }

        [StringLength(16)]
        public string Country { get; set; }

        [StringLength(32)]
        public string LenghtTime { get; set; }

        public int? OwnerShip { get; set; }

        public virtual s_Entity s_Entity { get; set; }
    }
}
