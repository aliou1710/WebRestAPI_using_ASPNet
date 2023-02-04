using WebAppAPI.DataModels;

namespace WebApp_API.Repositories
{
    public interface IStudentRepository
    {
        //on declare les methodes
        Task<List<Student>> GetStudentsAsync();
        //List<Address> GetAddresses();

        Task<Student> GetOneStudentAsync(Guid studentId);

        //Gender is from datamodels
        Task<List<Gender>> GetGendersAsync();

        Task<bool> Exists(Guid studentId);
        //Student from datamodels
        Task<Student> UpdateStudent(Guid studentId, Student request);
    }
}
