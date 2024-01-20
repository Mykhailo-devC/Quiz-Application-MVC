using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Quiz.DB.SeedData;
using Quiz.Models.DataModels;
using System.Security.Cryptography.X509Certificates;

namespace Quiz.DB
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var answerEntityConfig = modelBuilder.Entity<Answer>();

            answerEntityConfig.HasKey(x => x.id);
            answerEntityConfig.HasOne(x => x.question)
                    .WithMany(x => x.answers)
                    .HasForeignKey(x => x.questionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            answerEntityConfig.Property(x => x.value).HasMaxLength(100);
            answerEntityConfig.Property(x => x.id).ValueGeneratedOnAdd();

            var questionEntityConfig = modelBuilder.Entity<Question>();

            questionEntityConfig.HasKey(x => x.id);
            questionEntityConfig.HasOne(x => x.test)
                    .WithMany(x => x.questions)
                    .HasForeignKey(x => x.testId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            questionEntityConfig.Property(x => x.value).HasMaxLength(100);
            questionEntityConfig.Property(x => x.correctAnswer).HasMaxLength(100);
            questionEntityConfig.Property(x => x.id).ValueGeneratedOnAdd();

            var testEntityConfig = modelBuilder.Entity<Test>();

            testEntityConfig.HasKey(x => x.id);
            testEntityConfig.Property(x => x.creationDate).HasAnnotation("DefaultValue", DateTime.Now);
            testEntityConfig.Property(x => x.name).HasMaxLength(100);
            testEntityConfig.Property(x => x.id).ValueGeneratedOnAdd();

            modelBuilder.ApplyConfiguration(new TestEntitySeedData());
            modelBuilder.ApplyConfiguration(new QuestionEntitySeedData());
            modelBuilder.ApplyConfiguration(new AnswerEntitySeedData());
        }
    }
}