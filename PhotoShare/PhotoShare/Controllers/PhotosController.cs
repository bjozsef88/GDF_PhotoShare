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
        private PhotoRepository _repository;

        public PhotosController()
        {
            _repository = new PhotoRepository();
        }

        public ActionResult Index()
        {
            return View(_repository.List());
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

                        _repository.Add(model);
                    }
                }
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }


        public ActionResult GetPhoto(int id)
        {
            byte[] imageData = _repository.GetPhoto(id, PhotoType.Full);

            return File(imageData, "image/jpg");
        }

        public ActionResult GetThumbnail(int id)
        {
            byte[] imageData = _repository.GetPhoto(id, PhotoType.Thumbnail);

            return File(imageData, "image/jpg");
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}