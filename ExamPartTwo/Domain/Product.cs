using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPartTwo.Domain
{
    public class Product
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public Guid SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int RecorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

    public class ProductConfiguration: EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(p => p.ProductID);

            Property(p => p.ProductID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(p => p.Supplier)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.SupplierID);

            HasRequired(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryID);

            Property(p => p.ProductName)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.QuantityPerUnit)
                .IsRequired();

            Property(p => p.UnitPrice)
                .IsRequired();

            Property(p => p.UnitsInStock)
                .IsRequired();

            Property(p => p.UnitsOnOrder)
                .IsRequired();

            Property(p => p.RecorderLevel)
                .IsRequired();

            Property(p => p.Discontinued)
                .IsRequired();
        }
    }
}
