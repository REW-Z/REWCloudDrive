using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class File
    {
        public int FileID { get; set; }
        public int UserID { get; set; }
        public string FileName { get; set; }
        public string UploadTime { get; set; }
        public string FileType { get; set; }
    }
}
