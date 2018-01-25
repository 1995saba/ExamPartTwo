using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPartTwo.Domain
{
    public class Region
    {
        public Guid RegionID { get; set; }
        public string RegionDescription { get; set; }
        public virtual ICollection<Territory> Territories { get; set; }
    }

    public class RegionConfiguration : EntityTypeConfiguration<Region>
    {
        public RegionConfiguration()
        {
            HasKey(p => p.RegionID);

            Property(p => p.RegionID)
                .IsRequired();

            Property(p => p.RegionDescription)
                .HasMaxLength(50)
                .IsRequired();
        }
    } 
}
