using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var result = newPath(file);
            try
            {
                var sourcePath = Path.GetTempFileName();
                if (file.Length > 0)
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                        file.CopyTo(stream);
                File.Move(sourcePath, result.newPath);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result.Path2;
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result.newPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Delete(sourcePath);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result.Path2;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static (string newPath, string Path2) newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var newPath = Guid.NewGuid() + fileExtension;


            string path = Environment.CurrentDirectory + @"\wwwroot\Images";

            string result = $@"{path}\{newPath}";

            return (result, $"\\Images\\{newPath}");
        }
    }
}
















































//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.IO;
//using Microsoft.AspNetCore.Http;

//namespace Core.Utilities.Helpers
//{
//    public class FileHelper
//    {
//        public static string Add(IFormFile formFile)
//        {
//            string sourcePath = Path.GetTempFileName();
//            if (formFile.Length>0)
//            {
//                using (var stream=new FileStream(sourcePath,FileMode.Create))
//                {
//                    formFile.CopyTo(stream);
//                }
//            }
//            string destFileName = CreateNewFilePath(formFile);
//            File.Move(sourcePath, destFileName);
//            return destFileName;
//        }

//        public static IResult Delete(string path)
//        {
//            try
//            {
//                File.Delete(path);
//            }
//            catch (Exception exeption)
//            {

//                return new ErrorResult(exeption.Message);
//            }
//            return new SuccessResult();
//        }

//        public static string Update(string sourcePath, IFormFile formFile)
//        {
//            string result = CreateNewFilePath(formFile);
//            if (sourcePath.Length>0)
//            {
//                using (var stream=new FileStream(result,FileMode.Create))
//                {
//                    formFile.CopyTo(stream);
//                }
//            }
//            File.Delete(sourcePath);
//            return result;
//        }








//        private static string CreateNewFilePath(IFormFile formFile)
//        {
//            FileInfo fileInfo = new FileInfo(formFile.FileName);
//            string fileExtension = fileInfo.Extension;

//            string path = Environment.CurrentDirectory + @"\Wwwroot\Images";
//            string newPath = Guid.NewGuid().ToString() + fileExtension;

//            string result = $@"{path}\{newPath}";
//            return result;
//        }
//    }
//}
