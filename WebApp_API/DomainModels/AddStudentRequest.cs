namespace WebApp_API.DomainModels
{
    public class AddStudentRequest
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //attention ici, on recupere un string de la part d'angular vers l'api
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }

        //navicgation properties
        public Guid GenderId { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
    }
}
