using System.Collections.Generic;

namespace DataAccess.Model
{
    using Microsoft.AspNet.Http;

    public class AllUploadedFiles
    {
        public List<FileDescriptionShort> FileShortDescriptions { get; set; }
    }
    public class FileDescriptionShort
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public ICollection<IFormFile> File { get; set; }
    }
}