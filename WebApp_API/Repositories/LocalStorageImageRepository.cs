using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApp_API.Repositories
{



    public class LocalStorageImageRepository : IImageRepository
    {
        public async Task<string> Upload(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Ressources\Images", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetServerRelativePath(fileName);
        }


        private  string GetServerRelativePath(string fileName)
        {
            return Path.Combine(@"Ressources\Images", fileName);
        }
    }
}
