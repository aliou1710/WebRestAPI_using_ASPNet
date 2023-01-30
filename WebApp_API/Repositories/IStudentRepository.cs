using WebAppAPI.DataModels;

namespace WebApp_API.Repositories
{
    public interface IStudentRepository
    {
        //on declare les methodes
        List<Student> GetStudents();
        //List<Address> GetAddresses();
    }
}
