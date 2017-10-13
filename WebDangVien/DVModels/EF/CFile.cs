namespace DVModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CFile")]
    public partial class CFile
    {
        public CFile()
        {
            CFeeDetails = new HashSet<CFeeDetail>();
            ChangeHistories = new HashSet<ChangeHistory>();
            Disciplines = new HashSet<Discipline>();
            GoAbroads = new HashSet<GoAbroad>();
            Instructions = new HashSet<Instruction>();
            Rewards = new HashSet<Reward>();
        }

        public int CFileID { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Birthday { get; set; }

        public bool? Sex { get; set; }

        [StringLength(50)]
        public string JobTitle { get; set; }

        [StringLength(50)]
        public string CRole { get; set; }

        [StringLength(50)]
        public string Qualification { get; set; }

        public int? PoliticalID { get; set; }

        [StringLength(250)]
        public string Native { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? AdmittedDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? OfficialDate { get; set; }

        [StringLength(9)]
        public string CardNumber { get; set; }

        [StringLength(50)]
        public string BioNumber { get; set; }

        [Column(TypeName = "ntext")]
        public string Foreigners { get; set; }

        [Column(TypeName = "ntext")]
        public string InternalInfo { get; set; }

        public int? UnitID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ModifiedDate { get; set; }

        public int? CStatusID { get; set; }

        [Column(TypeName = "ntext")]
        public string CFileDescription { get; set; }

        public bool? Locked { get; set; }

        [Column(TypeName = "image")]
        public byte[] CPicture { get; set; }

        public virtual ICollection<CFeeDetail> CFeeDetails { get; set; }

        public virtual CStatu CStatu { get; set; }

        public virtual Political Political { get; set; }

        public virtual Unit Unit { get; set; }

        public virtual ICollection<ChangeHistory> ChangeHistories { get; set; }

        public virtual ICollection<Discipline> Disciplines { get; set; }

        public virtual ICollection<GoAbroad> GoAbroads { get; set; }

        public virtual ICollection<Instruction> Instructions { get; set; }

        public virtual ICollection<Reward> Rewards { get; set; }
    }
}
