using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class PhotoRepository : IDisposable
    {
        private PhotoShareEntities _db;
        private bool disposedValue = false;

        public PhotoRepository()
        {
            _db = new PhotoShareEntities();
        }

        public void Add(Photo photo)
        {
            _db.Photos.Add(photo);
            _db.SaveChanges();
        }

        public byte[] GetPhoto(int id, PhotoType type)
        {
            switch (type)
            {
                case PhotoType.Thumbnail:
                    return _db.Photos.Find(id).PhotoFile.Thumbnail;
                default:
                    return _db.Photos.Find(id).PhotoFile.File;
            }
        }

        public IEnumerable<Photo> List()
        {
            return _db.Photos.OrderByDescending(photo => photo.UploadedAt);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}