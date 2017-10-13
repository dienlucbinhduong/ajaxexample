namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Unit")]
    public partial class Unit
    {
        public Unit()
        {
            CFiles = new HashSet<CFile>();
        }

        public int UnitID { get; set; }

        [StringLength(50)]
        public string UnitName { get; set; }

        public int? DivisionID { get; set; }

        public virtual ICollection<CFile> CFiles { get; set; }

        public virtual Division Division { get; set; }
    }
}
