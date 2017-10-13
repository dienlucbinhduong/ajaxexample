namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Political")]
    public partial class Political
    {
        public Political()
        {
            CFiles = new HashSet<CFile>();
        }

        public int PoliticalID { get; set; }

        [StringLength(50)]
        public string PoliticalLevel { get; set; }

        public virtual ICollection<CFile> CFiles { get; set; }
    }
}
