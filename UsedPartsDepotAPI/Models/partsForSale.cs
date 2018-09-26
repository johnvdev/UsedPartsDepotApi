namespace UsedPartsDepotAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("partsForSale")]
    public partial class partsForSale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pID { get; set; }

        [StringLength(50)]
        public string pTitle { get; set; }

        [StringLength(200)]
        public string pDescription { get; set; }

        public int? carID { get; set; }

        public virtual car car { get; set; }
    }
}
