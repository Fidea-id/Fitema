using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace FitemaAPI.Utils.Helpers
{
    public static class ImageHelper
    {
        public static string ResizeAndSave(IFormFile image, int maxWidth, int maxHeight, string folderDirection, string folderRootDirection = "wwwroot")
        {
            string filename = image.FileName;
            string fileExtension = Path.GetExtension(filename);
            string uniqueFilename = $"{Guid.NewGuid()}_{DateTime.Now.Ticks}{fileExtension}";
            string imagePath = $"{folderDirection}/{uniqueFilename}";
            string imageFullpath = Path.Combine(Directory.GetCurrentDirectory(), $"{folderRootDirection}/{folderDirection}/", uniqueFilename);
            int newHeight, newWidth;
            using (var imageStream = Image.Load(image.OpenReadStream()))
            {
                if (imageStream.Width > maxWidth || imageStream.Height > maxHeight)
                {
                    double widthRatio = imageStream.Width / (double)maxWidth;
                    double heightRatio = imageStream.Height / (double)maxHeight;
                    double ratio = Math.Max(widthRatio, heightRatio);
                    newWidth = (int)(imageStream.Width / ratio);
                    newHeight = (int)(imageStream.Height / ratio);
                }
                else
                {
                    newHeight = imageStream.Height;
                    newWidth = imageStream.Width;
                }
                imageStream.Mutate(x => x.Resize(newWidth, newHeight));
                imageStream.Save(imageFullpath);
            }
            return imagePath;

        }
    }
}

