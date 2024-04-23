using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using StudentManagement.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business.Implementations
{
    public class UtilityBL : IUtilityBL
    {
        private IWebHostEnvironment _env;
        private IHttpContextAccessor _contextAccessor;

        public UtilityBL(IWebHostEnvironment env,
            IHttpContextAccessor contextAccessor)
        {
            _env = env;
            _contextAccessor = contextAccessor;
        }

        public Task DeleteImage(string FolderName, string dbPath)
        {
            if (string.IsNullOrEmpty(dbPath))
            {
                return Task.CompletedTask;
            }
            var filename = Path.GetFileName(dbPath);
            var completePath = Path.Combine(_env.WebRootPath, FolderName, filename);
            if (File.Exists(completePath))
            {
                File.Delete(completePath);
            }
            return Task.CompletedTask;
        }

        public async Task<string> SaveImage(string FolderName, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var filename = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_env.WebRootPath, FolderName);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath = Path.Combine(folder, filename);

            using (var memoryStreem = new MemoryStream())
            {
                await file.CopyToAsync(memoryStreem);
                var content = memoryStreem.ToArray();
                await File.WriteAllBytesAsync(filePath, content);

            }
            var basePath = $"{_contextAccessor.HttpContext!.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";

            var completePath = Path.Combine(basePath, FolderName, filename).Replace("\\", "/");

            return completePath;
        }

        public async Task<string> UpadateImage(string FolderName, IFormFile file, string dbPath)
        {
            await DeleteImage(FolderName, dbPath);
            return await SaveImage(FolderName, file);
        }
    }
}

