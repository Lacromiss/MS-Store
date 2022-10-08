namespace MSStoreWebApp.Models
{
    public class SikGot
    {
        public int Id { get; set; }
        public int SikId { get; set; }
        public int GotId { get; set; }
        public Sik Sik { get; set; }
        public Got Got { get; set; }
    }
}
