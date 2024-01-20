using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Models.DataModels;

namespace Quiz.DB.SeedData
{
    public class AnswerEntitySeedData : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasData(
                    //Question 1
                    new Answer
                    {
                        id = 101,
                        value = "Private",
                        questionId = 1
                    },
                    new Answer
                    {
                        id = 102,
                        value = "Private Protected",
                        questionId = 1
                    },
                    new Answer
                    {
                        id = 103,
                        value = "Protected",
                        questionId = 1
                    },
                    new Answer
                    {
                        id = 104,
                        value = "Internal",
                        questionId = 1
                    },
                    new Answer
                    {
                        id = 105,
                        value = "Public",
                        questionId = 1
                    },
                    //Question 2
                    new Answer
                    {
                        id = 106,
                        value = "Bool",
                        questionId = 2
                    },
                    new Answer
                    {
                        id = 107,
                        value = "Integer",
                        questionId = 2
                    },
                    new Answer
                    {
                        id = 108,
                        value = "Class",
                        questionId = 2
                    },
                    new Answer
                    {
                        id = 109,
                        value = "Structure",
                        questionId = 2
                    },
                    new Answer
                    {
                        id = 110,
                        value = "Char",
                        questionId = 2
                    },
                    //Question 3
                    new Answer
                    {
                        id = 111,
                        value = "null",
                        questionId = 3
                    },
                    new Answer
                    {
                        id = 112,
                        value = "ref",
                        questionId = 3
                    },
                    new Answer
                    {
                        id = 113,
                        value = "public",
                        questionId = 3
                    },
                    new Answer
                    {
                        id = 114,
                        value = "static",
                        questionId = 3
                    },
                    new Answer
                    {
                        id = 115,
                        value = "<T>",
                        questionId = 3
                    }

                );
        }
    }
}
