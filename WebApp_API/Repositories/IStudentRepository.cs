using WebAppAPI.DataModels;

namespace WebApp_API.Repositories
{
    public interface IStudentRepository
    {
        //on declare les methodes
        Task<List<Student>> GetStudentsAsync();
        //List<Address> GetAddresses();
    }
}
