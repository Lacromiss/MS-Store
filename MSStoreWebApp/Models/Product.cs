using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSStoreWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
  
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public double Price { get; set; }
        public double PriceFrom { get; set; }

        public int CatagoryId { get; set; }
        public Catagory Catagory { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public List<ColorProduct> Products { get; set; }
        public int ColorrId { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public int BestId { get; set; }
        public Best Best { get; set; }


    }
}
