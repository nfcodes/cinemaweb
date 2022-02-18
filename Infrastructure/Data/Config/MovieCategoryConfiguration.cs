using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class MovieCategoryConfiguration : IEntityTypeConfiguration<MovieCategory>
{
    public void Configure(EntityTypeBuilder<MovieCategory> builder)
    {
        builder.HasKey(x => new {x.MovieId, x.CategoryId});
        
        builder.HasOne(x => x.Movie)
            .WithMany(x => x.MovieCategories)
            .HasForeignKey(x => x.MovieId);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.MovieCategories)
            .HasForeignKey(x => x.CategoryId);

        builder.Navigation(x => x.Category)
            .AutoInclude();
    }
}