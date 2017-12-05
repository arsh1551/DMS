using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntites.ViewModel
{
    public class FileUploadViewModel
    {
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string deleteUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string deleteType { get; set; }
        public long? AccountingFirmId { get; set; }
        public long? ClientId { get; set; }
        public long? EmployeeId { get; set; }
        public List<ClientViewModel> lstClients { get; set; }
        //public Lis> MyProperty { get; set; }
    }
    public class JsonFiles
    {
        public FileUploadViewModel[] files;
        public string TempFolder { get; set; }
        public JsonFiles(List<FileUploadViewModel> filesList)
        {
            files = new FileUploadViewModel[filesList.Count];
            for (int i = 0; i < filesList.Count; i++)
            {
                files[i] = filesList.ElementAt(i);
            }
        }
    }
    public class FilesViewModel
    {
        public FileUploadViewModel[] Files { get; set; }
    }
}
