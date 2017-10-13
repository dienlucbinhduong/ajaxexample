namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CFee")]
    public partial class CFee
    {
        public CFee()
        {
            CFeeDetails = new HashSet<CFeeDetail>();
        }

        public int CFeeID { get; set; }

        public int? DivisionID { get; set; }

        public int? OfMonth { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? PreparedDate { get; set; }

        [StringLength(50)]
        public string PreparedBy { get; set; }

        [StringLength(50)]
        public string ReceiptNumber { get; set; }

        public int? Percentage { get; set; }

        [Column(TypeName = "ntext")]
        public string CFeeDescription { get; set; }

        public virtual Division Division { get; set; }

        public virtual ICollection<CFeeDetail> CFeeDetails { get; set; }
    }
}
