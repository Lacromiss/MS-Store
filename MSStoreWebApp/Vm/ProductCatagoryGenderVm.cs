using MSStoreWebApp.Models;
using System.Collections.Generic;

namespace MSStoreWebApp.Vm
{
    public class ProductCatagoryGenderVm
    {
        public List<Product> Products { get; set; }
        public List<Gender> Genders { get; set; }
        public List<Catagory> Catagories { get; set; }
        public List<ColorProduct> ColorProducts { get; set; }
    }
}
