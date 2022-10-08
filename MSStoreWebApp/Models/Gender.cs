using System.Collections.Generic;

namespace MSStoreWebApp.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
