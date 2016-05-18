using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
using DataAccess.Model;

namespace AspNet5FileUploadFileTable.Controllers
{
    public class FileClientController : Controller
    {
        private readonly IFileRepository _fileRepository;

        public FileClientController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Index Page";

            return View();
        }

        public ActionResult Client()
        {
            ViewBag.Title = "Ex Client";

            return View();
        }

        public ActionResult MultiClient()
        {
            ViewBag.Title = "Ex MultiClient";

            return View();
        }

        /// <summary>
        /// Just a test method to view all files.
        /// </summary>
        public ActionResult ViewAllFiles()
        {
            var model = new AllUploadedFiles {FileShortDescriptions = _fileRepository.GetAllFiles().ToList()};
            return View(model);
        }
    }
}
