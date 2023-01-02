using MSStoreWebApp.Models;
using System.Collections.Generic;

namespace MSStoreWebApp.Vm
{
    public class ProductColorVm
    {
        public List<Product> Products { get; set; }
        public List<Color> Colors { get; set; }
    }
}
