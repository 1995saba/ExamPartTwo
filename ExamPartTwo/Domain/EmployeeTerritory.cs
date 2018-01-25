using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPartTwo.Domain
{
    public class EmployeeTerritory
    {
        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public Guid TerritoryID { get; set; }
        public Territory Territory { get; set; }
    }

    public class EmployeeTerritoryConfiguration : EntityTypeConfiguration<EmployeeTerritory>
    {
        public EmployeeTerritoryConfiguration()
        {
            HasKey(p => new { p.EmployeeID, p.TerritoryID });

            HasRequired(p => p.Territory)
                .WithMany(p => p.Employees)
                .HasForeignKey(p => p.TerritoryID);

            HasRequired(p => p.Employee)
                .WithMany(p => p.Territories)
                .HasForeignKey(p => p.EmployeeID);
        }
    }
}
