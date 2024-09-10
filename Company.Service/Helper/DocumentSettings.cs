using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helper
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file,string folderName)
        {
            var folderPath =Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files", folderName);
            var fileName = $"{Guid.NewGuid()}-{file.FileName}";
            var filePath = Path.Combine(folderPath, fileName);
            using var fileSream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileSream);
            return fileName;
        }
    }
}
