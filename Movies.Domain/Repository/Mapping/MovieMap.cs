using Movies.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Movies.Domain.Repository.Mapping
{
    public class MovieMap : EntityTypeConfiguration<Movie>
    {
        public MovieMap()
        {
            // Primary Key
            this.HasKey(t => t.MovieId);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Genre)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Movie");
            this.Property(t => t.MovieId).HasColumnName("MovieId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Genre).HasColumnName("Genre");
            this.Property(t => t.ReleaseDate).HasColumnName("ReleaseDate");
            this.Property(t => t.Rating).HasColumnName("Rating");
        }
    }
}
