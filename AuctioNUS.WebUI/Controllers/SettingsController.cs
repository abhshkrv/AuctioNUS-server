using AuctioNUS.Domain.Abstract;
using AuctioNUS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctioNUS.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        ISettingRepository _settingRepo;
      public SettingsController(ISettingRepository repo)
        {
            _settingRepo = repo;
        }
        //
        // GET: /Settings/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getSetting(int userID)
        {
            Setting setting = _settingRepo.Settings.FirstOrDefault(s => s.UserID == userID);

            var result = new Dictionary<string, object>();
            result.Add("status", "success");
            result.Add("setting", setting);

            return Json(result, JsonRequestBehavior.AllowGet);
        }



    }
}
