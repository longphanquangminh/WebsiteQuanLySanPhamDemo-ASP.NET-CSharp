using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebsiteQuanLySanPham.Models;

namespace WebsiteQuanLySanPham.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            /*QuanLySanPhamDataContext context = new QuanLySanPhamDataContext();
            List<Product> dsProduct = context.Products.ToList();
            return View(dsProduct);*/
            QuanLySanPhamDataContext context = new QuanLySanPhamDataContext();
            List<Product> dsProduct = null;
            if (Request.QueryString.Count == 0)
            {
                dsProduct = context.Products.ToList();
            }
            else
            {
                double min = double.Parse(Request.QueryString["txtMin"]);
                double max = double.Parse(Request.QueryString["txtMax"]);
                dsProduct = context.Products
                    .Where(x => x.UnitPrice >= min && x.UnitPrice <= max)
                    .ToList();
            }
            return View(dsProduct);
        }
        public ActionResult Details(int id)
        {
            QuanLySanPhamDataContext context = new QuanLySanPhamDataContext();
            Product p = context.Products
                               .FirstOrDefault(x => x.Id == id);
            return View(p);
        }
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                QuanLySanPhamDataContext context = new QuanLySanPhamDataContext();
                Product p = new Product();
                List<Product> dsProduct = context.Products.ToList();
                p.Id = dsProduct.Count + 1;
                p.CatalogId = int.Parse(Request.Form["CatalogId"]);
                p.ProductCode = Request.Form["ProductCode"];
                p.ProductName = Request.Form["ProductName"];
                p.UnitPrice = double.Parse(Request.Form["UnitPrice"]);
                HttpPostedFileBase file = Request.Files["Picture"];
                if (file != null)
                {
                    string serverPath = HttpContext.Server.MapPath("~/Hinh");
                    string filePath = serverPath + "/" + file.FileName;
                    file.SaveAs(filePath);
                    p.Picture = file.FileName;
                }
                context.Products.InsertOnSubmit(p);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            QuanLySanPhamDataContext context = new QuanLySanPhamDataContext();
            Product p = context.Products.FirstOrDefault(x => x.Id == id);
            if (Request.Form.Count == 0)
            {
                return View(p);
            }
            p.CatalogId = int.Parse(Request.Form["CatalogId"]);
            p.ProductCode = Request.Form["ProductCode"];
            p.ProductName = Request.Form["ProductName"];
            p.UnitPrice = double.Parse(Request.Form["UnitPrice"]);
            HttpPostedFileBase file = Request.Files["Picture"];
            if (file != null && file.FileName != "")
            {
                string serverPath = HttpContext.Server.MapPath("~/Hinh");
                string filePath = serverPath + "/" + file.FileName;
                file.SaveAs(filePath);
                p.Picture = file.FileName;
            }
            context.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            QuanLySanPhamDataContext context = new QuanLySanPhamDataContext();
            Product p = context.Products.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                context.Products.DeleteOnSubmit(p);
                context.SubmitChanges();
            }
            return RedirectToAction("Index");
        }
    }
}