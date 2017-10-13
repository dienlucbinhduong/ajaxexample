namespace DVModels.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DangVienDBContext : DbContext
    {
        public DangVienDBContext()
            : base("name=DangVienDBContext")
        {
        }

        public virtual DbSet<CFee> CFees { get; set; }
        public virtual DbSet<CFeeDetail> CFeeDetails { get; set; }
        public virtual DbSet<CFile> CFiles { get; set; }
        public virtual DbSet<ChangeHistory> ChangeHistories { get; set; }
        public virtual DbSet<CStatu> CStatus { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<GoAbroad> GoAbroads { get; set; }
        public virtual DbSet<Instruction> Instructions { get; set; }
        public virtual DbSet<MyGroup> MyGroups { get; set; }
        public virtual DbSet<MyUser> MyUsers { get; set; }
        public virtual DbSet<Political> Politicals { get; set; }
        public virtual DbSet<Reward> Rewards { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CFile>()
                .Property(e => e.CardNumber)
                .IsFixedLength();

            modelBuilder.Entity<MyGroup>()
                .Property(e => e.GroupRole)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MyUser>()
                .Property(e => e.LogIn)
                .IsUnicode(false);

            modelBuilder.Entity<MyUser>()
                .Property(e => e.Pass)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
