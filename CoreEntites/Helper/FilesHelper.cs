using CoreEntites.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
//using System.Web.Helpers;

namespace CoreEntites.Helper
{
    public class FilesHelper
    {

        String DeleteURL = null;
        String DeleteType = null;
        String StorageRoot = null;
        String UrlBase = null;
        String tempPath = null;
        //ex:"~/Files/something/";
        String serverMapPath = null;
        public FilesHelper(String DeleteURL, String DeleteType, String StorageRoot, String UrlBase, String tempPath, String serverMapPath)
        {
            this.DeleteURL = DeleteURL;
            this.DeleteType = DeleteType;
            this.StorageRoot = StorageRoot;
            this.UrlBase = UrlBase;
            this.tempPath = tempPath;
            this.serverMapPath = serverMapPath;
        }

        public void DeleteFiles(String pathToDelete)
        {
            try
            {
                string path = HostingEnvironment.MapPath(pathToDelete);

                System.Diagnostics.Debug.WriteLine(path);
                if (Directory.Exists(path))
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        System.IO.File.Delete(fi.FullName);
                        System.Diagnostics.Debug.WriteLine(fi.Name);
                    }

                    di.Delete(true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public String DeleteFile(String file)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("DeleteFile");
                //    var req = HttpContext.Current;
                System.Diagnostics.Debug.WriteLine(file);

                String fullPath = Path.Combine(StorageRoot, file);
                System.Diagnostics.Debug.WriteLine(fullPath);
                System.Diagnostics.Debug.WriteLine(System.IO.File.Exists(fullPath));
                String thumbPath = "/" + file + "80x80.jpg";
                String partThumb1 = Path.Combine(StorageRoot, "thumbs");
                String partThumb2 = Path.Combine(partThumb1, file + "80x80.jpg");

                System.Diagnostics.Debug.WriteLine(partThumb2);
                System.Diagnostics.Debug.WriteLine(System.IO.File.Exists(partThumb2));
                if (System.IO.File.Exists(fullPath))
                {
                    //delete thumb 
                    if (System.IO.File.Exists(partThumb2))
                    {
                        System.IO.File.Delete(partThumb2);
                    }
                    System.IO.File.Delete(fullPath);
                    String succesMessage = "Ok";
                    return succesMessage;
                }
                String failMessage = "Error Delete";
                return failMessage;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        /// <summary>
        /// Desc:To get all the files
        /// </summary>
        /// <returns></returns>
        public JsonFiles GetFileList()
        {
            try
            {
                var r = new List<FileUploadViewModel>();

                String fullPath = Path.Combine(StorageRoot);
                if (Directory.Exists(fullPath))
                {
                    DirectoryInfo dir = new DirectoryInfo(fullPath);
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        int SizeInt = unchecked((int)file.Length);
                        r.Add(UploadResult(file.Name, SizeInt, file.FullName));
                    }

                }
                JsonFiles files = new JsonFiles(r);

                return files;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UploadAndShowResults(HttpContextBase ContentBase, List<FileUploadViewModel> resultList)
        {
            try
            {
                var httpRequest = ContentBase.Request;
                System.Diagnostics.Debug.WriteLine(Directory.Exists(tempPath));
                String fullPath = Path.Combine(StorageRoot);
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
                // Create new folder for thumbs
                Directory.CreateDirectory(fullPath + "/thumbs/");

                foreach (String inputTagName in httpRequest.Files)
                {

                    var headers = httpRequest.Headers;

                    var file = httpRequest.Files[inputTagName];
                    System.Diagnostics.Debug.WriteLine(file.FileName);

                    if (string.IsNullOrEmpty(headers["X-File-Name"]))
                    {

                        UploadWholeFile(ContentBase, resultList);
                    }
                    else
                    {
                        UploadPartialFile(headers["X-File-Name"], ContentBase, resultList);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void UploadWholeFile(HttpContextBase requestContext, List<FileUploadViewModel> statuses)
        {
            try
            {

                var request = requestContext.Request;
                for (int i = 0; i < request.Files.Count; i++)
                {
                    var file = request.Files[i];
                    String pathOnServer = Path.Combine(StorageRoot);
                    var fullPath = Path.Combine(pathOnServer, Path.GetFileName(file.FileName));
                    file.SaveAs(fullPath);

                    //Create thumb
                    string[] imageArray = file.FileName.Split('.');
                    if (imageArray.Length != 0)
                    {
                        String extansion = imageArray[imageArray.Length - 1].ToLower();
                        if (extansion != "jpg" && extansion != "png" && extansion != "jpeg") //Do not create thumb if file is not an image
                        {

                        }
                        else
                        {
                            var ThumbfullPath = Path.Combine(pathOnServer, "thumbs");
                            //String fileThumb = file.FileName + ".80x80.jpg";
                            String fileThumb = Path.GetFileNameWithoutExtension(file.FileName) + "80x80.jpg";
                            var ThumbfullPath2 = Path.Combine(ThumbfullPath, fileThumb);
                            using (MemoryStream stream = new MemoryStream(System.IO.File.ReadAllBytes(fullPath)))
                            {
                                //var thumbnail = new WebImage(stream).Resize(80, 80);
                                //thumbnail.Save(ThumbfullPath2, "jpg");
                            }

                        }
                    }
                    statuses.Add(UploadResult(file.FileName, file.ContentLength, file.FileName));
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void UploadPartialFile(string fileName, HttpContextBase requestContext, List<FileUploadViewModel> statuses)
        {
            try
            {
                var request = requestContext.Request;
                if (request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
                var file = request.Files[0];
                var inputStream = file.InputStream;
                String patchOnServer = Path.Combine(StorageRoot);
                var fullName = Path.Combine(patchOnServer, Path.GetFileName(file.FileName));
                var ThumbfullPath = Path.Combine(fullName, Path.GetFileName(file.FileName + "80x80.jpg"));
                ImageHandler handler = new ImageHandler();

                var ImageBit = ImageHandler.LoadImage(fullName);
                handler.Save(ImageBit, 80, 80, 10, ThumbfullPath);
                using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
                {
                    var buffer = new byte[1024];

                    var l = inputStream.Read(buffer, 0, 1024);
                    while (l > 0)
                    {
                        fs.Write(buffer, 0, l);
                        l = inputStream.Read(buffer, 0, 1024);
                    }
                    fs.Flush();
                    fs.Close();
                }
                statuses.Add(UploadResult(file.FileName, file.ContentLength, file.FileName));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public FileUploadViewModel UploadResult(String FileName, int fileSize, String FileFullPath)
        {
            String getType = System.Web.MimeMapping.GetMimeMapping(FileFullPath);
            var result = new FileUploadViewModel()
            {
                name = FileName,
                size = fileSize,
                type = getType,
                url = UrlBase + FileName,
                deleteUrl = DeleteURL + FileName,
                thumbnailUrl = CheckThumb(getType, FileName),
                deleteType = DeleteType,
            };
            return result;
        }

        public String CheckThumb(String type, String FileName)
        {
            try
            {
                var splited = type.Split('/');
                if (splited.Length == 2)
                {
                    string extansion = splited[1].ToLower();
                    if (extansion.Equals("jpeg") || extansion.Equals("jpg") || extansion.Equals("png") || extansion.Equals("gif"))
                    {
                        String thumbnailUrl = UrlBase + "thumbs/" + Path.GetFileNameWithoutExtension(FileName) + "80x80.jpg";
                        return thumbnailUrl;
                    }
                    else
                    {
                        if (extansion.Equals("octet-stream")) //Fix for exe files
                        {
                            return "/Content/Free-file-icons/48px/exe.png";

                        }
                        if (extansion.Contains("zip")) //Fix for exe files
                        {
                            return "/Content/Free-file-icons/48px/zip.png";
                        }
                        String thumbnailUrl = "/Content/Free-file-icons/48px/" + extansion + ".png";
                        return thumbnailUrl;
                    }
                }
                else
                {
                    return UrlBase + "/thumbs/" + Path.GetFileNameWithoutExtension(FileName) + "80x80.jpg";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<String> FilesList()
        {
            List<String> Filess = new List<String>();
            string path = HostingEnvironment.MapPath(serverMapPath);
            System.Diagnostics.Debug.WriteLine(path);
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo fi in di.GetFiles())
                {
                    Filess.Add(fi.Name);
                    System.Diagnostics.Debug.WriteLine(fi.Name);
                }

            }
            return Filess;
        }
    }
}
