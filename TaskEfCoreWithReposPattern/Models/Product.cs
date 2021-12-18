using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEfCoreWithReposPattern.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigational Property 
        public Category Category { get; set; }
    }
}
