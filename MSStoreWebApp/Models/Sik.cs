using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSStoreWebApp.Models
{
    public class Sik
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SikGot> Gots { get; set; }
    }
}
