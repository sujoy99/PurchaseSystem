using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PurchaseSystem.Common;
using PurchaseSystem.Models;

namespace PurchaseSystem.Controllers
{
    public class ProductTypeController : Controller
    {
        ApplicationDbContext _db;
        public ProductTypeController()
        {
            _db = new ApplicationDbContext();
        }
        // GET: ProductType
        public ActionResult Create()
        {
            return View("CreateUpdateForm");
        }

        [HttpPost]
        public ActionResult Create(ProductTypeMst PT)
        {
            _db.ProductTypeMsts.Add(PT);
            _db.SaveChanges();
            return View();
        }

        public ActionResult ProductTypeList()
        {
            var prodList = _db.ProductTypeMsts.ToList();
            return View(prodList);
        }

        public ActionResult Edit(int id)
        {
            var productType = _db.ProductTypeMsts.FirstOrDefault(x => x.Pk_ProdTypeId == id);
            return View("CreateUpdateForm",productType);
        }
    }
}