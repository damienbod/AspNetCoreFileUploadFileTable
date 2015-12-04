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
        private static readonly string ServerUploadFolder = "\\\\N275\\mssqlserver2014\\WebApiFileTable\\WebApiUploads_Dir"; //Path.GetTempPath();

        public FileUploadController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        /// <summary>
        /// IFormFile  has to be used
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [Route("files")]
        [HttpPost]
        [ServiceFilter(typeof(ValidateMimeMultipartContentFilter))]   
        public async Task<IActionResult> UploadFiles(FileDescriptionShort files)
        {         
            //var streamProvider = new MultipartFormDataStreamProvider(ServerUploadFolder);
            //await Request.Content.ReadAsMultipartAsync(streamProvider);


            //var files = new FileResult
            //{
            //    FileNames = streamProvider.FileData.Select(entry => entry.LocalFileName.Replace(ServerUploadFolder + "\\", "")).ToList(),
            //    Names = streamProvider.FileData.Select(entry => entry.Headers.ContentDisposition.FileName).ToList(),
            //    ContentTypes = streamProvider.FileData.Select(entry => entry.Headers.ContentType.MediaType).ToList(),
            //    Description = streamProvider.FormData["description"],
            //    CreatedTimestamp = DateTime.UtcNow,
            //    UpdatedTimestamp = DateTime.UtcNow,
            //};

            // tests code
            return null; 

            //return _fileRepository.AddFileDescriptions(files);
        }

        //[Route("download/{id}")]
        //[HttpGet]
        //public HttpResponseMessage Download(int id)
        //{
        //    var fileDescription = _fileRepository.GetFileDescription(id);

        //    var path = ServerUploadFolder + "\\" + fileDescription.FileName;
        //    var result = new HttpResponseMessage(HttpStatusCode.OK);
        //    var stream = new FileStream(path, FileMode.Open);
        //    result.Content = new StreamContent(stream);
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue(fileDescription.ContentType);
        //    return result;
        //}

        [Route("all")]
        [HttpGet]
        public IEnumerable<FileDescriptionShort> GetAllFiles()
        {
            return _fileRepository.GetAllFiles();
        }
    }
}

