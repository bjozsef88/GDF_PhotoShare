using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class ImageManipulation
    {
        private const int THUMBNAILSIZE = 350;
        private Image _photoImage;


        public PhotoFile MakePhotoFileFromStream(Stream stream, string fileName)
        {
            _photoImage = Image.FromStream(stream);

            Image thumbnail = GetThumbnail();

            byte[] photoStreamBytes = GetPhotoBytes(_photoImage);
            byte[] thumbnailBytes = GetPhotoBytes(thumbnail);
            
            return new PhotoFile
            {
                File = photoStreamBytes,
                Thumbnail = thumbnailBytes,
                FileName = fileName
            };
        }

        private ThumnailDimensions GetThumnailDimensions()
        {
            int imageWidht = _photoImage.Width;
            int imageHeight = _photoImage.Height;
            int thumbnailWidht, thumbnailHeight = 0;

            if (imageWidht > imageHeight)
            {
                thumbnailWidht = THUMBNAILSIZE;
                thumbnailHeight = (THUMBNAILSIZE * imageHeight) / imageWidht;
            }
            else
            {
                thumbnailHeight = THUMBNAILSIZE;
                thumbnailWidht = (THUMBNAILSIZE * imageWidht) / imageHeight;
            }

            return new ThumnailDimensions
            {
                Width = thumbnailWidht,
                Height = thumbnailHeight
            };
        }

        private Image GetThumbnail()
        {
            ThumnailDimensions dimensions = GetThumnailDimensions();

            return _photoImage.GetThumbnailImage(dimensions.Width, dimensions.Height, () => false, IntPtr.Zero);
        }

        private byte[] GetPhotoBytes(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, _photoImage.RawFormat);
                return ms.ToArray();
            }
        }
    }

    internal class ThumnailDimensions
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}