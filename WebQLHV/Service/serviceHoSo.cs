using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WebQLHV.Abs;
using WebQLHV.Interface;
using WebQLHV.Models;
using WebQLHV.Unit;

namespace WebQLHV.Service
{
    public class serviceHoSo : IHoSo
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();
        public ResourceResp AddHoSo(string ID, string LOAIHOSO, string HOCVIEN, string GHICHU, string HOSO)
        {
            try
            {
                HoSo HoSo = db.HoSo.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                if (HoSo == null)
                {
                    HoSo taohd = new HoSo();
                    taohd.ID = LOAIHOSO + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
                    taohd.LOAIHOSO = LOAIHOSO;
                    taohd.HOCVIEN = HOCVIEN;
                    taohd.GHICHU = GHICHU;
                    var objFile = JArray.Parse(HOSO);
                    if (objFile.Count > 0)
                    {
                        foreach (JObject rootFile in objFile)
                        {
                            try
                            {
                                if (rootFile["BASE64"].ToString().Substring(5, 15).Equals("application/pdf"))
                                {
                                    byte[] PDF = ConvertUnit.Base64ToFile(Regex.Replace(rootFile["BASE64"].ToString(), @"^data:application\/[a-zA-Z]+;base64,", string.Empty));
                                    if (PDF != null)
                                    {
                                        string[] fileName = rootFile["NAME"].ToString().Split('.');
                                        string name = fileName[0] + "_" + DateTime.Now.ToString("yyyyMMdd-HHmmssfff") + ".pdf";
                                        string physicalPath = System.Web.HttpContext.Current.Server.MapPath("~/Hinh/File/" + name);
                                        using (var ms = new MemoryStream(PDF))
                                        {
                                            using (var fs = new FileStream(physicalPath, FileMode.Create))
                                            {
                                                ms.WriteTo(fs);
                                                if (taohd.HOSO != null && taohd.HOSO != "")
                                                {
                                                    taohd.HOSO += "," + name;
                                                }
                                                else
                                                {
                                                    taohd.HOSO = name;
                                                }
                                            }
                                            ms.Close();
                                        }
                                    }
                                }
                                if (rootFile["BASE64"].ToString().Substring(5, 18).Equals("application/msword"))
                                {
                                    byte[] Word = ConvertUnit.Base64ToFile(Regex.Replace(rootFile["BASE64"].ToString(), @"^data:application\/[a-zA-Z-.]+;base64,", string.Empty));
                                    if (Word != null)
                                    {
                                        string[] fileName = rootFile["NAME"].ToString().Split('.');
                                        string name = fileName[0] + "_" + DateTime.Now.ToString("yyyyMMdd-HHmmssfff") + ".doc";
                                        string physicalPath = System.Web.HttpContext.Current.Server.MapPath("~/Hinh/File/" + name);
                                        using (var ms = new MemoryStream(Word))
                                        {
                                            using (var fs = new FileStream(physicalPath, FileMode.Create))
                                            {
                                                ms.WriteTo(fs);
                                                if (taohd.HOSO != null && taohd.HOSO != "")
                                                {
                                                    taohd.HOSO += "," + name;
                                                }
                                                else
                                                {
                                                    taohd.HOSO = name;
                                                }
                                            }
                                            ms.Close();
                                        }
                                    }
                                }
                                if (rootFile["BASE64"].ToString().Substring(5, 71).Equals("application/vnd.openxmlformats-officedocument.wordprocessingml.document"))
                                {
                                    byte[] Word = ConvertUnit.Base64ToFile(Regex.Replace(rootFile["BASE64"].ToString(), @"^data:application\/[a-zA-Z-.]+;base64,", string.Empty));
                                    if (Word != null)
                                    {
                                        string[] fileName = rootFile["NAME"].ToString().Split('.');
                                        string name = fileName[0] + "_" + DateTime.Now.ToString("yyyyMMdd-HHmmssfff") + ".doc";
                                        string physicalPath = System.Web.HttpContext.Current.Server.MapPath("~/Hinh/File/" + name);
                                        using (var ms = new MemoryStream(Word))
                                        {
                                            using (var fs = new FileStream(physicalPath, FileMode.Create))
                                            {
                                                ms.WriteTo(fs);
                                                if (taohd.HOSO != null && taohd.HOSO != "")
                                                {
                                                    taohd.HOSO += "," + name;
                                                }
                                                else
                                                {
                                                    taohd.HOSO = name;
                                                }
                                            }
                                            ms.Close();
                                        }
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                return new ResourceResp(false, ex.Message);
                            }
                        }
                    }

                    taohd.CREATEDATE = DateTime.Now;
                    taohd.UPDATEDATE = DateTime.Now;
                    db.HoSo.AddOrUpdate(taohd);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return new ResourceResp(true, "Đã lưu hồ sơ thành công");
                    }
                    return new ResourceResp(false, "Tạo không thành công");
                }
                return new ResourceResp(false, "Tạo không thành công");
            }
            catch (Exception ex)
            {
                return new ResourceResp(false, ex.Message);
            }
        }

        public ResourceResp DeleteHoSo(string ID)
        {
            try
            {
                HoSo taohd = db.HoSo.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                db.HoSo.Remove(taohd);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return new ResourceResp(true, "Đã xóa thành công");
                }
                return new ResourceResp(false, "Xóa không thành công");
            }
            catch (Exception ex)
            {
                return new ResourceResp(false, ex.Message);
            }
        }
    }
}