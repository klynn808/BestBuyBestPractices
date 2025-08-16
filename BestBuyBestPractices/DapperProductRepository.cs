using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public DapperProductRepository(IDbConnection conn)
        {  
            _conn = conn;           
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID) " +
                          "VALUES (@name, @price, @categoryID);"
                          , new { name = name, price = price, categoryID = categoryID });
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id;", 
                new { id });
        }

        public void UpdateProductName(int productID, string updatedName)
        {
            _conn.Execute("UPDATE products SET Name = @updatedName WHERE ProductID = @productID;",
                new { updatedName = updatedName, productID = productID });
        }   

        public void DeleteProduct(int id)
        {
            _conn.Execute("DELETE FROM sales WHERE ProductID = @id;", new { id = id });
            _conn.Execute("DELETE FROM reviews WHERE ProductID = @id;", new { id = id });
            _conn.Execute("DELETE FROM products WHERE ProductID = @id;", new { id = id });
        }
    }
}
