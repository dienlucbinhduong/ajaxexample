namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoAbroad")]
    public partial class GoAbroad
    {
        [Key]
        public int TripID { get; set; }

        public int? CFileID { get; set; }

        [Column(TypeName = "ntext")]
        public string Reasons { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? EndDate { get; set; }

        [Column(TypeName = "ntext")]
        public string Destinations { get; set; }

        [Column(TypeName = "ntext")]
        public string TripDescription { get; set; }

        public virtual CFile CFile { get; set; }
    }
}
