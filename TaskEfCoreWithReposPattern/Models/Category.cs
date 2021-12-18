using System.Collections.Generic;

namespace TaskEfCoreWithReposPattern.Models
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public string Name { get; set; }

        // Navigational Property 
        public List<Product> Products { get; set; }
    }
}