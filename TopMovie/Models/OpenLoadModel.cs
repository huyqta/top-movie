using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopMovie.Models.OpenLoadModel
{
    public class Folder
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class File
    {
        public string name { get; set; }
        public object cblock { get; set; }
        public string sha1 { get; set; }
        public string folderid { get; set; }
        public string upload_at { get; set; }
        public string status { get; set; }
        public string size { get; set; }
        public string content_type { get; set; }
        public string download_count { get; set; }
        public string cstatus { get; set; }
        public string link { get; set; }
        public string linkextid { get; set; }
    }

    public class Result
    {
        public List<Folder> folders { get; set; }
        public List<File> files { get; set; }
    }

    public class RootObject
    {
        public int status { get; set; }
        public string msg { get; set; }
        public Result result { get; set; }
    }
}
