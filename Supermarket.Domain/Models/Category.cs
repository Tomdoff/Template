using System.Collections.Generic;

namespace Supermarket.Domain.Models{

    public class Category{
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }

}