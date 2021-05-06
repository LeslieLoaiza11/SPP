using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DomainDocument
    {
        private string name;
        private string path;
        private string weight;
        private string uploadDate;

        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        public string Weight { get => weight; set => weight = value; }
        public string UploadDate { get => uploadDate; set => uploadDate = value; }
    }
}
