namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CStatu
    {
        public CStatu()
        {
            CFiles = new HashSet<CFile>();
        }

        [Key]
        public int CStatusID { get; set; }

        [StringLength(250)]
        public string CStatusInfo { get; set; }

        public virtual ICollection<CFile> CFiles { get; set; }
    }
}
