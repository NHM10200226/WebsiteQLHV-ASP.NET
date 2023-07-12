using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace WebQLHV.Unit
{
    public class ConvertUnit
    {
        public static byte[] Base64ToImage(string base64String)
        {
            try
            {
                // Convert base 64 string to byte[]
                string base64Image = base64String.Replace("\"", "").Split(',')[1];
                byte[] imageBytes = Convert.FromBase64String(base64Image);
                // Convert byte[] to Image
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    Image image = Image.FromStream(ms, true);
                    return ms.ToArray();
                }
            }
            catch
            {
                return null;
            }
        }

        public static byte[] Base64ToFile(string base64String)
        {
            try
            {
                // Convert base 64 string to byte[]
                byte[] fileBytes = Convert.FromBase64String(base64String);
                // Convert byte[] to File
                using (var ms = new MemoryStream(fileBytes, 0, fileBytes.Length))
                {
                    return ms.ToArray();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}