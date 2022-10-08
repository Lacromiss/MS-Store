using System.Collections.Generic;

namespace MSStoreWebApp.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ColorProduct> Colors { get; set; }

    }
}
