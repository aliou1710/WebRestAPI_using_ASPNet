namespace WebAppAPI.DataModels
{
    public class Address
    {
        public Guid Id { get; set; }

        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }

        //navicgation properties
        public Guid StudentId { get; set; }

      
        
    }
}
