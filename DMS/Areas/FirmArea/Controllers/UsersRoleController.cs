using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Interfaces;

namespace DMS.Areas.FirmArea.Controllers
{
    public class UsersRoleController : Controller
    {
        IUsersRoleService _UsersRoleService = null;
        public UsersRoleController(IUsersRoleService UsersRoleService)
        {
            this._UsersRoleService = UsersRoleService;
        }
        // GET: FirmArea/UsersRole
        public ActionResult Index()
        {
            return View();
        }
    }
}