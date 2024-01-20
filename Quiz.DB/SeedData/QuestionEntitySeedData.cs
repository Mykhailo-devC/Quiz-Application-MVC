using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Models.DataModels;

namespace Quiz.DB.SeedData
{
    public class QuestionEntitySeedData : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasData(
                    new Question
                    {
                        id = 1,
                        value = "What access modifier make component available only within it's class of struct?",
                        correctAnswer = "Private",
                        testId = 1,
                    },
                    new Question
                    {
                        id = 2,
                        value = "What of these types is Referense type?",
                        correctAnswer = "Class",
                        testId = 1,
                    },
                    new Question
                    {
                        id = 3,
                        value = "What modifier can pass parameters by reference?",
                        correctAnswer = "ref",
                        testId = 1,
                    }
                );
        }
    }
}
