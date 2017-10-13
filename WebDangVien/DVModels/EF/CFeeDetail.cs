namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CFeeDetail")]
    public partial class CFeeDetail
    {
        public int CFeeDetailID { get; set; }

        public int? CFeeID { get; set; }

        public int? CFileID { get; set; }

        public long? Salary { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DeliveredDate { get; set; }

        [Column(TypeName = "ntext")]
        public string CFeeDetailDescription { get; set; }

        public virtual CFee CFee { get; set; }

        public virtual CFile CFile { get; set; }
    }
}
