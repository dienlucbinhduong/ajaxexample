namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MyGroup")]
    public partial class MyGroup
    {
        public MyGroup()
        {
            MyUsers = new HashSet<MyUser>();
        }

        public int MyGroupID { get; set; }

        [StringLength(50)]
        public string GroupName { get; set; }

        [StringLength(10)]
        public string GroupRole { get; set; }

        public virtual ICollection<MyUser> MyUsers { get; set; }
    }
}
