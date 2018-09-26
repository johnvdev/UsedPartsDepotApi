namespace UsedPartsDepotAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("car")]
    public partial class car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public car()
        {
            partsForSales = new HashSet<partsForSale>();
            partsSolds = new HashSet<partsSold>();
            depotUsers = new HashSet<depotUser>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? cYear { get; set; }

        [StringLength(30)]
        public string cMake { get; set; }

        [StringLength(30)]
        public string cModel { get; set; }

        [StringLength(30)]
        public string cVin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<partsForSale> partsForSales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<partsSold> partsSolds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<depotUser> depotUsers { get; set; }
    }
}
