using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        public Product GetProduct(int id);
        public void UpdateProductName(int productID, string updatedName);
        public void DeleteProduct(int id); 
    }
}
