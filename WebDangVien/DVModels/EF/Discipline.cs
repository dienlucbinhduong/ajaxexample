namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Discipline")]
    public partial class Discipline
    {
        public int DisciplineID { get; set; }

        public int? CFileID { get; set; }

        [Column(TypeName = "ntext")]
        public string DisciplineInfo { get; set; }

        [StringLength(50)]
        public string DisciplineNumber { get; set; }

        [Column(TypeName = "image")]
        public byte[] DisciplineAttachment { get; set; }

        [Column(TypeName = "ntext")]
        public string DisciplineDescription { get; set; }

        public virtual CFile CFile { get; set; }
    }
}
