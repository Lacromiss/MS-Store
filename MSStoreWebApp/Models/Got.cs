using System.Collections.Generic;

namespace MSStoreWebApp.Models
{
    public class Got
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SikGot> Siks { get; set; }

    }
}
