namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChangeHistory")]
    public partial class ChangeHistory
    {
        [Key]
        public int ChangeID { get; set; }

        public int? CFileID { get; set; }

        [Column(TypeName = "ntext")]
        public string ChangeContent { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ChangeDate { get; set; }

        [StringLength(50)]
        public string ChangeField { get; set; }

        public bool? Approved { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ApprovedDate { get; set; }

        [Column(TypeName = "ntext")]
        public string ChangeDescription { get; set; }

        public virtual CFile CFile { get; set; }
    }
}
