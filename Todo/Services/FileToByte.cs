using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Services
{
    public static class FileToByte
    {
        public static byte[] ReadImageFile(this string imageLocation)
        {
            byte[] imageData = null;
            var fileInfo = new FileInfo(imageLocation);
            var imageFileLength = fileInfo.Length;
            var fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            var br = new BinaryReader(fs);
            imageData = br.ReadBytes((int) imageFileLength);
            return imageData;
        }
    }
}
