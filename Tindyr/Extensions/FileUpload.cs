using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Tindyr.Extensions
{
    public class FileUpload
    {
        private static List<bool> GetHash(Bitmap bmpSource)
        {
            List<bool> lResult = new List<bool>();
            //create new image with a smaller size to compare faster
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    //reduce colors to true / false                
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }
            return lResult;
        }
        private static int CompareImgSimilarityvalue(String filename1, Stream filestream)
        {
            var bmp1 = new Bitmap(filename1);
            var bmp2 = new Bitmap(filestream);

            List<bool> iHash1 = GetHash(bmp1);
            List<bool> iHash2 = GetHash(bmp2);
            
            //determine the number of equal pixel (x of 256) 256 is a perfect match
            int equalElements = iHash1.Zip(iHash2, (i, j) => i == j).Count(eq => eq);
            //2h of errors :( bitmaps lock the content if not disposed after usage since they seem to continuously refer to a path
            bmp1.Dispose();
            bmp2.Dispose();
            
            return equalElements;
        }
        public static bool Upload(IFormFile image, string newName)
        {
            var filePath = Path.Combine("wwwroot/userimages", newName);
            using (var uploadingImgStream = image.OpenReadStream())
            {
                //check for dupes 
                foreach (var imgInServer in Directory.EnumerateFiles("wwwroot/userimages", "*", SearchOption.AllDirectories))
                {
                    var c = CompareImgSimilarityvalue(imgInServer, uploadingImgStream);
                    if (c > 253.44)
                    {
                        return false;
                    }
                }
            }

            //write file
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                image.CopyTo(fileStream);
            }
            return true;
        }
    }
}