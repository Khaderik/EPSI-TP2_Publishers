using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Publishers.Models.Mapping
{
    public class discountMap : EntityTypeConfiguration<discount>
    {
        public discountMap()
        {
            // Primary Key
            this.HasKey(t => new { t.discounttype, t.discount1 });

            // Properties
            this.Property(t => t.discounttype)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.stor_id)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.discount1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("discounts");
            this.Property(t => t.discounttype).HasColumnName("discounttype");
            this.Property(t => t.stor_id).HasColumnName("stor_id");
            this.Property(t => t.lowqty).HasColumnName("lowqty");
            this.Property(t => t.highqty).HasColumnName("highqty");
            this.Property(t => t.discount1).HasColumnName("discount");

            // Relationships
            this.HasOptional(t => t.store)
                .WithMany(t => t.discounts)
                .HasForeignKey(d => d.stor_id);

        }
    }
}
