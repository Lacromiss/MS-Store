using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;

namespace MSStoreWebApp.Utilites
{
    public static class ExImgMethods
    {
        public static bool CheckSize(this IFormFile formFile, int mb)
        {
            if (!(formFile.Length / 1024 / 1024 <= mb))
            {
                return false;
            }
            return true;
        }
        public static bool CheckType(this IFormFile formFile, string typee)
        {
            if (!(formFile.ContentType.Contains(typee)))
            {
                return false;

            }
            return true;
        }
        public static async Task<string> SaveFileAsync(this IFormFile formFile, string pathh)
        {
            string Musi = Guid.NewGuid().ToString() + formFile.FileName;
            string path = Path.Combine(pathh, Musi);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
            return Musi;
        }
    
    }
}
