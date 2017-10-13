namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Division")]
    public partial class Division
    {
        public Division()
        {
            CFees = new HashSet<CFee>();
            MyUsers = new HashSet<MyUser>();
            Units = new HashSet<Unit>();
        }

        public int DivisionID { get; set; }

        [StringLength(50)]
        public string DivisionName { get; set; }

        public virtual ICollection<CFee> CFees { get; set; }

        public virtual ICollection<MyUser> MyUsers { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}
