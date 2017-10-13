namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reward")]
    public partial class Reward
    {
        public int RewardID { get; set; }

        public int? CFileID { get; set; }

        [Column(TypeName = "ntext")]
        public string RewardInfo { get; set; }

        [StringLength(50)]
        public string RewardNumber { get; set; }

        [Column(TypeName = "image")]
        public byte[] RewardAttachment { get; set; }

        [Column(TypeName = "ntext")]
        public string RewardDescription { get; set; }

        public virtual CFile CFile { get; set; }
    }
}
