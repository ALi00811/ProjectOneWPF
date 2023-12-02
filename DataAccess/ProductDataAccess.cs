using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess
{
    public class ProductDataAccess
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public ProductDataAccess()
        { 
            ReadProducts();
        }
        
        private void ReadProducts()
        {
            Product pr1 = new Product()
            {
                Id =1,
                Name = "Animal",
                Author = "Gorje",
                AvailableCount = 12,
                Price = 12
            };

            Product pr2 = new Product()
            {
                Id = 2,
                Name = "Animal 2",
                Author = "Gorje floid",
                AvailableCount = 13,
                Price = 15
            };
            Products.Add(pr1);
            Products.Add(pr2);
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(int id)
        {
            Product temp = Products.First(x => x.Id == id);
            Products.Remove(temp);
        }


        public void EditProduct(Product product)
        {
            Product temp = Products.First(x => x.Id == product.Id);
            int index = Products.IndexOf(temp);
            Products[index] = product;
        }

        public int GetNextId()
        {
            return Products.Any() ? Products.Max(x => x.Id) : 1 ;
        }
    }
}
