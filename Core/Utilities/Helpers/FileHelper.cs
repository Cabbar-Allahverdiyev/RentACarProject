using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile formFile)
        {
            string sourcePath = Path.GetTempFileName();
            if (formFile.Length>0)
            {
                using (var stream=new FileStream(sourcePath,FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            string destFileName = CreateNewFilePath(formFile);
            File.Move(sourcePath, destFileName);
            return destFileName;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exeption)
            {

                return new ErrorResult(exeption.Message);
            }
            return new SuccessResult();
        }

        public static string Update(string sourcePath, IFormFile formFile)
        {
            string result = CreateNewFilePath(formFile);
            if (sourcePath.Length>0)
            {
                using (var stream=new FileStream(result,FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }








        private static string CreateNewFilePath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            string fileExtension = fileInfo.Extension;

            string path = Environment.CurrentDirectory + @"\Images";
            string newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
