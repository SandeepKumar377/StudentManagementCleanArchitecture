using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business.Interfaces
{
    public interface IUtilityBL
    {
        Task<string> SaveImage(string FolderName, IFormFile file);
        Task<string> UpadateImage(string FolderName, IFormFile file, string dbPath);
        Task DeleteImage(string FolderName, string dbPath);
    }
}
