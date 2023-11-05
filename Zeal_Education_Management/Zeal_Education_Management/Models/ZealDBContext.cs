using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Zeal_Education_Management.Models
{
	public class ZealDBContext:DbContext
	{
		public ZealDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseApplicationModel>()
                .Property(c => c.CoursePrice)
                .HasColumnType("decimal(18, 2)"); // Set the appropriate precision and scale
        }
        public DbSet<UserModel> Users { get; set; }

        public DbSet<AdminModel> tbl_Admin_us { get; set; }

		public DbSet<JobModel> Jobs { get; set; }
		public DbSet<JobApplicationModel> JobApplication { get; set; }
		public DbSet<CourseModel> Courses { get; set; }

		public DbSet<CourseApplicationModel> tbl_CourseApplications { get; set; }

	}
}
