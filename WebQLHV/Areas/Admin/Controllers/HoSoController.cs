using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebQLHV.Models;
using WebQLHV.Interface;
using WebQLHV.Service;

namespace WebQLHV.Areas.Admin.Controllers
{
    public class HoSoController : Controller
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();
        private IHoSo HoSoservice = new serviceHoSo();
        // GET: Admin/HoSo
        public ActionResult Index()
        {
            LoadDATA();
            return View();
        }
        public ActionResult Add()
        {
            LoadDATA();
            return View();
        }
        public JsonResult Delete(string ID)
        {
            var res = HoSoservice.DeleteHoSo(ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Addasync(string ID, string LOAIHOSO, string HOCVIEN, string GHICHU, string HOSO)
        {
            var res = HoSoservice.AddHoSo(ID, LOAIHOSO, HOCVIEN, GHICHU, HOSO);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult XemHoSo(string ID)
        {
            try
            {
                HoSo hoso = db.HoSo.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                if (hoso != null)
                {
                    if (Path.GetExtension(hoso.HOSO).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        var filePath = System.Web.HttpContext.Current.Server.MapPath("~/Hinh/File/" + hoso.HOSO);
                        byte[] pdfBytes = System.IO.File.ReadAllBytes(filePath);
                        return File(pdfBytes, "application/pdf");
                    }
                    if (Path.GetExtension(hoso.HOSO).Equals(".doc", StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            // Generate unique file name for the PDF
                            var wordFilePath = System.Web.HttpContext.Current.Server.MapPath("~/Hinh/File/" + hoso.HOSO);
                            var pdfFilePath = Path.Combine(Server.MapPath("~/Hinh/File/"), Path.GetFileNameWithoutExtension(hoso.HOSO) + ".pdf");

                            // Create a new Microsoft Word application
                            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

                            // Open the source document
                            Document document = app.Documents.Open(wordFilePath);

                            // Convert to PDF
                            document.SaveAs2(pdfFilePath, WdExportFormat.wdExportFormatPDF);

                            // Close the document and Microsoft Word application
                            document.Close();
                            app.Quit();

                            // Show PDF on web page
                            byte[] pdfBytes = System.IO.File.ReadAllBytes(pdfFilePath);
                            return File(pdfBytes, "application/pdf");
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("", "Error converting file to PDF. " + ex.Message);
                        }
                    }
                }
                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        public void LoadDATA()
        {
            List<LoaiHoSo> lstLoaiHoSo = db.LoaiHoSo.Where(s=> s.STATUS == true).ToList();
            List<SelectListItem> litLoaiHoSo = new List<SelectListItem>();
            litLoaiHoSo.Add(new SelectListItem { Text = "--- Chọn ---", Value = "NONE" });
            foreach (var n in lstLoaiHoSo)
            {
                litLoaiHoSo.Add(new SelectListItem { Text = n.NAME, Value = n.ID });
            }
            ViewData["LITLOAIHD"] = litLoaiHoSo;
            //
            List<TTHocVien> lstTThocvien = db.TTHocVien.ToList();
            List<SelectListItem> litTTHocVien = new List<SelectListItem>();
            litTTHocVien.Add(new SelectListItem { Text = "--- Chọn ---", Value = "NONE" });
            foreach (var n in lstTThocvien)
            {
                litTTHocVien.Add(new SelectListItem { Text = n.HOTEN, Value = n.ID });
            }
            ViewData["LITTHV"] = litTTHocVien;
        }
    }
}