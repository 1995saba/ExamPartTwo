using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPartTwo.Domain
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public Guid ShipVia { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Shipper Shipper { get; set; }
    }

    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            HasKey(p => p.OrderID);

            Property(p => p.OrderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(p => p.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.CustomerID);

            HasRequired(p => p.Shipper)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.ShipVia);

            HasRequired(p => p.Employee)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.EmployeeID);

            Property(p => p.CustomerID)
                .IsRequired();

            Property(p => p.EmployeeID)
                .IsRequired();

            Property(p => p.OrderDate)
                .IsRequired();

            Property(p => p.RequiredDate)
                .IsRequired();

            Property(p => p.ShippedDate)
                .IsRequired();

            Property(p => p.ShipVia)
                .IsRequired();

            Property(p => p.Freight)
                .IsRequired();

            Property(p => p.ShipName)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.ShipAddress)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.ShipCity)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.ShipRegion)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.ShipPostalCode)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.ShipCountry)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
