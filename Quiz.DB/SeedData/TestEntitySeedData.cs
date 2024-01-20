using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Models.DataModels;

namespace Quiz.DB.SeedData
{
    public class TestEntitySeedData : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasData(
                    new Test
                    {
                        id = 1,
                        name = "C# Beginers Test",
                        creationDate = DateTime.Now,
                    }
                );
        }
    }
}
