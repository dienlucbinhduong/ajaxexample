namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MyUser")]
    public partial class MyUser
    {
        public int MyUserID { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string LogIn { get; set; }

        [StringLength(16)]
        public string Pass { get; set; }

        public int? MyGroupID { get; set; }

        public int? DivisionID { get; set; }

        public virtual Division Division { get; set; }

        public virtual MyGroup MyGroup { get; set; }
    }
}
