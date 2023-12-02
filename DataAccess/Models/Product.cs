using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Product : IProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        public int AvailableCount { get; set; }

        public string GetBasicInfo()
        {
            string Finalster = Name + "\nAuthor : " + Author + "/nPrice : " + Price + "$ \nAvailableCount  : " + AvailableCount;
            return Finalster;
        }
    }
}
