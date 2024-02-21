using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Models.DataModels;

namespace Quiz.DB.SeedData
{
    public class QuizEntitySeedData : IEntityTypeConfiguration<Models.DataModels.Quiz>
    {
        public void Configure(EntityTypeBuilder<Models.DataModels.Quiz> builder)
        {
            builder.HasData(
                    new Models.DataModels.Quiz
                    {
                        id = 1,
                        name = "C# Beginers Test",
                        creationDate = DateTime.Now,
                    }
                );
        }
    }
}
