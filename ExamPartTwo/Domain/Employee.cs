using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPartTwo.Domain
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public string Photo { get; set; }
        public string Notes { get; set; }
        public Guid ReportsTo { get; set; }
        public string PhotoPath { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Employee Boss { get; set; }
        public virtual ICollection<Employee> Slaves { get; set; }
        public virtual ICollection<EmployeeTerritory> Territories { get; set; }
    }

    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(p => p.EmployeeID);

            HasMany(p => p.Slaves)
                .WithOptional(p => p.Boss)
                .HasForeignKey(p => p.ReportsTo);
        }
    }
}
