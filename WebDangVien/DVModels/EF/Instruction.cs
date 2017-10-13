namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Instruction")]
    public partial class Instruction
    {
        public int InstructionID { get; set; }

        public int? CFileID { get; set; }

        [Column(TypeName = "ntext")]
        public string InstructionInfo { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? EndDate { get; set; }

        [StringLength(50)]
        public string InstructionNumber { get; set; }

        [Column(TypeName = "image")]
        public byte[] InstructionAttachment { get; set; }

        [Column(TypeName = "ntext")]
        public string InstructionDescription { get; set; }

        public virtual CFile CFile { get; set; }
    }
}
