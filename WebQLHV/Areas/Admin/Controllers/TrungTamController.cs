using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLHV.Interface;
using WebQLHV.Models;
using WebQLHV.Service;

namespace WebQLHV.Areas.Admin.Controllers
{
    public class TrungTamController : Controller
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();
        private ITrungTam ttamservice = new serviceTrungTam();
        // GET: Admin/TrungTam
        public ActionResult Index()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit(string ID)
        {
            TrungTam ttam = ttamservice.EditTrungTamById(ID).DataTTam;
            if (ttam == null)
            {
                ttam = new TrungTam();
            }
            return View(ttam);
        }
        public JsonResult Delete(string ID)
        {
            var res = ttamservice.DeleteTrungTam(ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Addasync(string ID, string NAME, string EMAIL, string HOTLINE, string ADDRESS)
        {
            var res = ttamservice.AddTrungTam(ID, NAME, EMAIL, HOTLINE, ADDRESS);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Editasync(string ID, string NAME, string EMAIL, string HOTLINE, string ADDRESS)
        {
            var res = ttamservice.EditTrungTam(ID, NAME, EMAIL, HOTLINE, ADDRESS);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}