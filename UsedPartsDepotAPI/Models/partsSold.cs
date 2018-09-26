namespace UsedPartsDepotAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("partsSold")]
    public partial class partsSold
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pSID { get; set; }

        [StringLength(50)]
        public string pSTitle { get; set; }

        [StringLength(200)]
        public string pSDescription { get; set; }

        public int? carID { get; set; }

        public virtual car car { get; set; }
    }
}
