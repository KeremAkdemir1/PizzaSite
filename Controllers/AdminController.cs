using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatanBilgisayar.Models.Repositories;
using VatanBilgisayar.Models.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace VatanBilgisayar.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        CategoryRepository cr = new CategoryRepository();
        ProductRepository pr = new ProductRepository();

        [Authorize]
        public IActionResult producttable()
        {
            return View(pr.TList("Category"));
        }
        [Authorize]
        public IActionResult categorytable()
        {
            return View(cr.TList());
        }
        [Authorize]
        public IActionResult MainPage()
        {
            return View(pr.TList("Category"));
        }
        [Authorize]
        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()

                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()

                                           }

                                          ).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddProduct(Products p)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Admin", "AddProduct");
            }
            pr.TAdd(p);
            return RedirectToAction("MainPage", "Admin");
        }
        [Authorize]
        public IActionResult AddCategory()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Admin", "AddCategory");
            }
            cr.TAdd(c);
            return RedirectToAction("MainPage", "Admin");
        }
    }
}
