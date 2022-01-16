using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YabousNews.Helper
{
    public class ImageHelper
    {
        public static async Task<string> SaveImage(IFormFile img, IHostingEnvironment environment,string FolderName)
        {
            String fileName = "DefaultUser.png";
            if (img != null && img.Length > 0)
            {
                var uploads = Path.Combine(environment.WebRootPath, FolderName);
                if (img.Length > 0)
                {
                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(img.FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await img.CopyToAsync(fileStream);
                    }
                }
            }
            return fileName;
        }
 
    }
}
