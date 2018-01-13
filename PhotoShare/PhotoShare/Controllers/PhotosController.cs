using PhotoShare.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace PhotoShare.Controllers
{
    public class PhotosController : Controller
    {
        private PhotoShareEntities _db = new PhotoShareEntities();

        public ActionResult Index()
        {
            return View(_db.Photos.ToList());
        }

        public ViewResult UploadPhoto()
        {
            IpAddress ip = new IpAddress();
            Photo newPhoto = new Photo();
            newPhoto.IpAddress = ip.GetCurrent();

            return View(newPhoto);
        }

        [HttpPost]
        public ActionResult UploadPhoto(Photo model)
        {
            ImageManipulation imageManipulation = new ImageManipulation();

            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        model.PhotoFile = imageManipulation.MakePhotoFileFromStream(file.InputStream, file.FileName);

                        _db.Photos.Add(model);
                        _db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }


        public ActionResult GetPhoto(int id)
        {
            byte[] imageData = null;
            imageData = _db.Photos.Find(id).PhotoFile.File;

            return File(imageData, "image/jpg");
        }

        public ActionResult GetThumbnail(int id)
        {
            byte[] imageData = null;
            imageData = _db.Photos.Find(id).PhotoFile.Thumbnail;

            return File(imageData, "image/jpg");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();

            base.Dispose(disposing);
        }
    }
}