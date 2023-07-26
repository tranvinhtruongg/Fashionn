using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace Fashion.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        //
        // GET: /Admin/Product/
        public ActionResult Index()
        {
            return View(new ProductDAO().ListProduct());
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDAO().DeleteProduct(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(new ProductDAO().GetByID(id));
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SanPham _product)
        {
            new ProductDAO().EditProduct(_product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            var kichthuoc = new SizeDAO().ListSize();
            var mausac = new ColorDAO().ListColor();
            ViewBag.kichthuoc = new SelectList(kichthuoc, "MaSize", "TenSize");
            ViewBag.mausac = new SelectList(mausac, "MaMau", "TenMau");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SanPham _product,List<int> listMau,List<int> listSize, string img1, string img2, string img3)
        {
            var db = new ProductDAO();
            db.CreateProduct(_product, listMau, listSize, img1, img2, img3);
            return RedirectToAction("Index");
        }

        public void SetViewBag(int? idCate = null,int? idBrand = null, int? idCollection = null)
        {
            var listCate = new CategoryDAO().ListSubCategory();
            ViewBag.MaDanhMucSP = new SelectList(listCate, "MaDanhMucSP", "TenDanhMucSP", idCate);
            var listBrand = new BrandDAO().ListBrand();
            ViewBag.MaHang = new SelectList(listBrand, "MaHang", "TenHang", idBrand);
            var listCollection = new CollectionDAO().ListAllCollection();
            ViewBag.MaBST = new SelectList(listCollection, "MaBST", "TenBST", idCollection);
        }

        public ActionResult Detail(int id)
        {
            ViewBag.ListColor = new ProductDAO().ListColorProduct(id);
            ViewBag.ListSize = new ProductDAO().ListSizeProduct(id);
            ViewBag.Image = new ProductDAO().ImageGetByID(id);
            var entity = new ProductDAO().GetByID(id);
            return View(entity);
        }

	}
}