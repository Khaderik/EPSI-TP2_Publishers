using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Publishers.Models.Mapping
{
    public class pub_infoMap : EntityTypeConfiguration<pub_info>
    {
        public pub_infoMap()
        {
            // Primary Key
            this.HasKey(t => t.pub_id);

            // Properties
            this.Property(t => t.pub_id)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("pub_info");
            this.Property(t => t.pub_id).HasColumnName("pub_id");
            this.Property(t => t.logo).HasColumnName("logo");
            this.Property(t => t.pr_info).HasColumnName("pr_info");

            // Relationships
            this.HasRequired(t => t.publisher)
                .WithOptional(t => t.pub_info);

        }
    }
}
