using System.Collections.Generic;

namespace MSStoreWebApp.Models
{
    public class Steller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
