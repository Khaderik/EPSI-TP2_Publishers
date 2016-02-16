using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Publishers.Models.Mapping
{
    public class titleviewMap : EntityTypeConfiguration<titleview>
    {
        public titleviewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.title, t.au_lname });

            // Properties
            this.Property(t => t.title)
                .IsRequired()
                .HasMaxLength(80);

            this.Property(t => t.au_lname)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.pub_id)
                .IsFixedLength()
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("titleview");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.au_ord).HasColumnName("au_ord");
            this.Property(t => t.au_lname).HasColumnName("au_lname");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.ytd_sales).HasColumnName("ytd_sales");
            this.Property(t => t.pub_id).HasColumnName("pub_id");
        }
    }
}
