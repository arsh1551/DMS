using CoreEntites.Helper;
using CoreEntites.ViewModel;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace DMS.Areas.FirmArea.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FirmArea/FileUpload
        IClientService _ClientService = null;
        public FileUploadController(IClientService ClientService)
        {
            _ClientService = ClientService;
        }
        FilesHelper filesHelper;
        String tempPath = "~/Files/";
        String serverMapPath = "~/UploadFiles/Files/";
        private string StorageRoot
        {
            get { return Path.Combine(HostingEnvironment.MapPath(serverMapPath)); }
        }
        private string UrlBase = "/UploadFiles/Files/";
        String DeleteURL = "/FileUpload/DeleteFile/?file=";
        String DeleteType = "GET";
        public FileUploadController()
        {
            filesHelper = new FilesHelper(DeleteURL, DeleteType, StorageRoot, UrlBase, tempPath, serverMapPath);
        }
        /// <summary>
        /// CreatedDate:28-Nov-2017
        /// Desc:To Upload the files
        /// </summary>
        /// <returns></returns>
        public ActionResult FileUpload()
        {
            FileUploadViewModel fileUploadViewModel = new FileUploadViewModel();
            var _Clientlist = _ClientService.GetClientList();
            fileUploadViewModel.AccountingFirmId = _Clientlist.FirstOrDefault().AccountingFirmId;
            ViewBag.lstClients = _Clientlist;
            return View(fileUploadViewModel);
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show()
        {
            JsonFiles ListOfFiles = filesHelper.GetFileList();
            var model = new FilesViewModel()
            {
                Files = ListOfFiles.files
            };

            return View(model);
        }

        public ActionResult Edit()
        {
            return View();
        }
        /// <summary>
        /// CreatedDate:29-NOv-2017
        /// Desc:Post method to upload the documents
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Upload(string id)
        {
            try
            {
                var resultList = new List<FileUploadViewModel>();
                var CurrentContext = HttpContext;
                filesHelper = new FilesHelper(DeleteURL, DeleteType, StorageRoot + '_' + id, UrlBase + '_' + id, tempPath + '_' + id, serverMapPath + '_' + id);
                filesHelper.UploadAndShowResults(CurrentContext, resultList);
                JsonFiles files = new JsonFiles(resultList);
                bool isEmpty = !resultList.Any();
                if (isEmpty)
                {
                    return Json("Error ");
                }
                else
                {
                    return Json(files);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public JsonResult GetFileList()
        {
            try
            {
                filesHelper = new FilesHelper(DeleteURL, DeleteType, StorageRoot, UrlBase, tempPath, serverMapPath);
                var list = filesHelper.GetFileList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        public JsonResult DeleteFile(string file)
        {
            filesHelper = new FilesHelper(DeleteURL, DeleteType, StorageRoot, UrlBase, tempPath, serverMapPath);
            filesHelper.DeleteFile(file);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
    }
}