using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Publishers.Models.Mapping;

namespace Publishers.Models
{
    public partial class PublishersContext : DbContext
    {
        static PublishersContext()
        {
            Database.SetInitializer<PublishersContext>(null);
        }

        public PublishersContext()
            : base("Name=PublishersContext")
        {
        }

        public IDbSet<author> authors { get; set; }
        public IDbSet<discount> discounts { get; set; }
        public IDbSet<employee> employees { get; set; }
        public IDbSet<job> jobs { get; set; }
        public IDbSet<pub_info> pub_info { get; set; }
        public IDbSet<publisher> publishers { get; set; }
        public IDbSet<roysched> royscheds { get; set; }
        public IDbSet<sale> sales { get; set; }
        public IDbSet<store> stores { get; set; }
        public IDbSet<sysdiagram> sysdiagrams { get; set; }
        public IDbSet<titleauthor> titleauthors { get; set; }
        public IDbSet<title> titles { get; set; }
        public IDbSet<titleview> titleviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new authorMap());
            modelBuilder.Configurations.Add(new discountMap());
            modelBuilder.Configurations.Add(new employeeMap());
            modelBuilder.Configurations.Add(new jobMap());
            modelBuilder.Configurations.Add(new pub_infoMap());
            modelBuilder.Configurations.Add(new publisherMap());
            modelBuilder.Configurations.Add(new royschedMap());
            modelBuilder.Configurations.Add(new saleMap());
            modelBuilder.Configurations.Add(new storeMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new titleauthorMap());
            modelBuilder.Configurations.Add(new titleMap());
            modelBuilder.Configurations.Add(new titleviewMap());
        }
    }
}
