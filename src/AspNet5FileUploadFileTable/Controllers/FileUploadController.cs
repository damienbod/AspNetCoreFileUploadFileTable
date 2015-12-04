namespace AspNet5FileUploadFileTable.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    using DataAccess;
    using DataAccess.Model;

    using Microsoft.AspNet.Http;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Net.Http.Headers;

    using FileResult = DataAccess.Model.FileResult;

    [Route("api/test")]
    public class FileUploadController : Controller
    {
        private readonly IFileRepository _fileRepository;
        private static readonly string ServerUploadFolder = "\\\\N275\\mssqlserver2014\\WebApiFileTable\\WebApiUploads_Dir";

        public FileUploadController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [Route("files")]
        [HttpPost]
        [ServiceFilter(typeof(ValidateMimeMultipartContentFilter))]
        public async Task<IActionResult> UploadFiles(FileDescriptionShort fileDescriptionShort)
        {
            var names = new List<string>();
            var contentTypes = new List<string>();
            if (ModelState.IsValid)
            {
                // The next lines of code was taken from the following 2 blogs
                // http://www.mikesdotnetting.com/article/288/asp-net-5-uploading-files-with-asp-net-mvc-6
                // http://dotnetthoughts.net/file-upload-in-asp-net-5-and-mvc-6/
                foreach (var file in fileDescriptionShort.File)
                {
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        contentTypes.Add(file.ContentType);
                        names.Add(fileName);

                        await file.SaveAsAsync(Path.Combine(ServerUploadFolder, fileName));
                    }
                }
            }

            var files = new FileResult
                            {
                                FileNames = names,
                                ContentTypes = contentTypes,
                                Description = fileDescriptionShort.Description,
                                CreatedTimestamp = DateTime.UtcNow,
                                UpdatedTimestamp = DateTime.UtcNow,
                            };

            _fileRepository.AddFileDescriptions(files);

            return RedirectToAction("ViewAllFiles", "FileClient");
        }

        [Route("download/{id}")]
        [HttpGet]
        public FileStreamResult Download(int id)
        {
            var fileDescription = _fileRepository.GetFileDescription(id);

            var path = ServerUploadFolder + "\\" + fileDescription.FileName;
            var stream = new FileStream(path, FileMode.Open);
            return  File(stream, fileDescription.ContentType);
        }

        [Route("all")]
        [HttpGet]
        public IEnumerable<FileDescriptionShort> GetAllFiles()
        {
            return _fileRepository.GetAllFiles();
        }
    }
}

