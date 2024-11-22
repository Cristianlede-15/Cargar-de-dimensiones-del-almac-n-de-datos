using LoadDimsDWH.Data.Context;
using LoadDimsDWH.Data.Interfaces;
using LoadDimsDWH.Data.Models;
using LoadDimsDWH.Data.Results;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadDimsDWH.Data.Services
{
    public class DataServiceDwOrders : IDataServiceDwOrders
    {
        private readonly DbOrdersContext _dbOrdersContext;
        private readonly NorthwindContext _northwindContext;

        public DataServiceDwOrders(DbOrdersContext dbOrdersContext, NorthwindContext northwindContext)
        {
            _dbOrdersContext = dbOrdersContext;
            _northwindContext = northwindContext;
        }

        public async Task<OperactionResult> LoadDwh()
        {
            OperactionResult result = new OperactionResult();
            try
            {
                await LoadCategory();
                await LoadCustomer();
                await LoadEmployee();
                await LoadProduct();
                await LoadShipper();

                result.Success = true;
                result.Message = "All dimensions loaded successfully.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error loading dimensions: {ex.Message}";
            }
            return result;
        }

        private async Task<OperactionResult> LoadCategory()
        {
            OperactionResult operation = new OperactionResult();
            try
            {
                var categories = await _northwindContext.Categories.Select(cat => new DimCategories
                {
                    CategoryID = cat.CategoryId,
                    CategoryName = cat.CategoryName,
                    Description = cat.Description
                }).AsNoTracking().ToListAsync();

                int[] categoryIds = categories.Select(c => c.CategoryID).ToArray();

                await _dbOrdersContext.DimCategories.Where(c => categoryIds.Contains(c.CategoryID))
                                                    .AsNoTracking()
                                                    .ExecuteDeleteAsync();

                await _dbOrdersContext.DimCategories.AddRangeAsync(categories);
                await _dbOrdersContext.SaveChangesAsync();

                operation.Success = true;
            }
            catch (Exception ex)
            {
                operation.Success = false;
                operation.Message = $"Error loading Categories dimension: {ex.Message}";
            }
            return operation;
        }

        private async Task<OperactionResult> LoadCustomer()
        {
            OperactionResult operation = new OperactionResult();
            try
            {
                var customers = await _northwindContext.Customers.Select(cust => new DimCustomers
                {
                    CustomerID = cust.CustomerId,
                    CompanyName = cust.CompanyName,
                    ContactName = cust.ContactName,
                    ContactTitle = cust.ContactTitle,
                    Address = cust.Address,
                    City = cust.City,
                    Region = cust.Region,
                    PostalCode = cust.PostalCode,
                    Country = cust.Country,
                    Phone = cust.Phone,
                    Fax = cust.Fax
                }).AsNoTracking().ToListAsync();

                string[] customerIds = customers.Select(c => c.CustomerID).ToArray();

                await _dbOrdersContext.DimCustomers.Where(c => customerIds.Contains(c.CustomerID))
                                                   .AsNoTracking()
                                                   .ExecuteDeleteAsync();

                await _dbOrdersContext.DimCustomers.AddRangeAsync(customers);
                await _dbOrdersContext.SaveChangesAsync();

                operation.Success = true;
            }
            catch (Exception ex)
            {
                operation.Success = false;
                operation.Message = $"Error loading Customers dimension: {ex.Message}";
            }
            return operation;
        }

        private async Task<OperactionResult> LoadEmployee()
        {
            OperactionResult operation = new OperactionResult();
            try
            {
                var employees = await _northwindContext.Employees.Select(emp => new DimEmployees
                {
                    EmployeeID = emp.EmployeeId,
                    LastName = emp.LastName,
                    FirstName = emp.FirstName,
                    Title = emp.Title,
                    TitleOfCourtesy = emp.TitleOfCourtesy,
                    BirthDate = emp.BirthDate,
                    HireDate = emp.HireDate,
                    Address = emp.Address
                }).AsNoTracking().ToListAsync();

                int[] employeeIds = employees.Select(e => e.EmployeeID).ToArray();

                await _dbOrdersContext.DimEmployees.Where(e => employeeIds.Contains(e.EmployeeID))
                                                   .AsNoTracking()
                                                   .ExecuteDeleteAsync();

                await _dbOrdersContext.DimEmployees.AddRangeAsync(employees);
                await _dbOrdersContext.SaveChangesAsync();

                operation.Success = true;
            }
            catch (Exception ex)
            {
                operation.Success = false;
                operation.Message = $"Error loading Employee dimension: {ex.Message}";
            }
            return operation;
        }

        private async Task<OperactionResult> LoadProduct()
        {
            OperactionResult operation = new OperactionResult();
            try
            {
                var products = await _northwindContext.Products.Select(prod => new DimProducts
                {
                    ProductID = prod.ProductId,
                    ProductName = prod.ProductName,
                    SupplierID = (int)prod.SupplierId,
                    CategoryID = (int)prod.CategoryId,
                    QuantityPerUnit = prod.QuantityPerUnit
                }).AsNoTracking().ToListAsync();

                int[] productIds = products.Select(p => p.ProductID).ToArray();

                await _dbOrdersContext.DimProducts.Where(p => productIds.Contains(p.ProductID))
                                                  .AsNoTracking()
                                                  .ExecuteDeleteAsync();

                await _dbOrdersContext.DimProducts.AddRangeAsync(products);
                await _dbOrdersContext.SaveChangesAsync();

                operation.Success = true;
            }
            catch (Exception ex)
            {
                operation.Success = false;
                operation.Message = $"Error loading Products dimension: {ex.Message}";
            }
            return operation;
        }

        private async Task<OperactionResult> LoadShipper()
        {
            OperactionResult operation = new OperactionResult();
            try
            {
                var shippers = await _northwindContext.Shippers.Select(ship => new DimShippers
                {
                    ShipperID = ship.ShipperID,
                    ShipperName = ship.CompanyName,
                    Phone = ship.Phone
                }).AsNoTracking().ToListAsync();

                int[] shipperIds = shippers.Select(s => s.ShipperID).ToArray();

                await _dbOrdersContext.DimShippers.Where(s => shipperIds.Contains(s.ShipperID))
                                                  .AsNoTracking()
                                                  .ExecuteDeleteAsync();

                await _dbOrdersContext.DimShippers.AddRangeAsync(shippers);
                await _dbOrdersContext.SaveChangesAsync();

                operation.Success = true;
            }
            catch (Exception ex)
            {
                operation.Success = false;
                operation.Message = $"Error loading Shippers dimension: {ex.Message}";
            }
            return operation;
        }
    }
}

