using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InterviewTexter.Models
{
    public partial class QuestionContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=InterviewQuestions;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.question).IsRequired();
            });

            //modelBuilder.Entity<Question>(entity =>
            //{
            //    entity.HasOne(d => d.question);
            //    entity.HasOne(d => d.category);
            //});
        }

        public virtual DbSet<Question> Question { get; set; }
    }
}