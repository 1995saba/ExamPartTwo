using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPartTwo.Domain
{
    public class Territory
    {
        public Guid TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public Guid RegionID { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<EmployeeTerritory> Employees { get; set; }
    }

    public class TerritoryConfiguration: EntityTypeConfiguration<Territory>
    {
        public TerritoryConfiguration()
        {
            HasKey(p => p.TerritoryID);

            Property(p => p.TerritoryID)
                .IsRequired();

            Property(p => p.TerritoryDescription)
                .HasMaxLength(50)
                .IsRequired();

            HasRequired(p => p.Region)
                .WithMany(p => p.Territories)
                .HasForeignKey(p => p.RegionID);
        }
    }
}
