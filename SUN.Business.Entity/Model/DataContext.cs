namespace SUN.Business.Entity.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Complaint> Complaint { get; set; }
        public virtual DbSet<ComplaintResponse> ComplaintResponse { get; set; }
        public virtual DbSet<ComplaintType> ComplaintType { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<LoginActivity> LoginActivity { get; set; }
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginActivity>()
                .Property(e => e.UserName)
                .IsUnicode(false);
        }
    }
}
