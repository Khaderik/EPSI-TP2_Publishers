using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Publishers.Models.Mapping
{
    public class royschedMap : EntityTypeConfiguration<roysched>
    {
        public royschedMap()
        {
            // Primary Key
            this.HasKey(t => t.title_id);

            // Properties
            this.Property(t => t.title_id)
                .IsRequired()
                .HasMaxLength(6);

            // Table & Column Mappings
            this.ToTable("roysched");
            this.Property(t => t.title_id).HasColumnName("title_id");
            this.Property(t => t.lorange).HasColumnName("lorange");
            this.Property(t => t.hirange).HasColumnName("hirange");
            this.Property(t => t.royalty).HasColumnName("royalty");

            // Relationships
            this.HasRequired(t => t.title)
                .WithOptional(t => t.roysched);

        }
    }
}
