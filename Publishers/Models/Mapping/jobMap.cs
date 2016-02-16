using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Publishers.Models.Mapping
{
    public class jobMap : EntityTypeConfiguration<job>
    {
        public jobMap()
        {
            // Primary Key
            this.HasKey(t => t.job_id);

            // Properties
            this.Property(t => t.job_desc)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("jobs");
            this.Property(t => t.job_id).HasColumnName("job_id");
            this.Property(t => t.job_desc).HasColumnName("job_desc");
            this.Property(t => t.min_lvl).HasColumnName("min_lvl");
            this.Property(t => t.max_lvl).HasColumnName("max_lvl");
        }
    }
}
