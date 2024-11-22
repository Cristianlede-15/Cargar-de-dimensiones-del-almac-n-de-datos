using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDimsDWH.Data.Models
{
    [Table("DimCategories")]
    public class DimCategories
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }
    }

    [Table("DimCustomers")]
    public class DimCustomers
    {
        [Key]
        [Column(TypeName = "nchar(5)")]
        public string? CustomerID { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string? CompanyName { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string? ContactName { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string? ContactTitle { get; set; }

        [Column(TypeName = "nvarchar(60)")]
        public string? Address { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string? City { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string? Region { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string? PostalCode { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string? Country { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public string? Phone { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public string? Fax { get; set; }
    }

    [Table("DimEmployees")]
    public class DimEmployees
    {
        [Key]
        public int EmployeeID { get; set; }
        public string? LastName { get; set; }
        public string?   FirstName { get; set; }
        public string? Title { get; set; }
        public string? TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? HomePhone { get; set; }
        public string? Extension { get; set; }
        public byte[]? Photo { get; set; }
        public string? Notes { get; set; }
        public int ReportsTo { get; set; }
        public string? PhotoPath { get; set; }
    }

    [Table("DimProducts")]
    public class DimProducts
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string? QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }
        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }

    [Table("DimShippers")]
    public class DimShippers
    {
        [Key]
        public int ShipperID { get; set; }
        public string? ShipperName { get; set; }
        public string?       Phone { get; set; }
    }
}
