using AutoMapper;
using ecom.DTOs;
using ecom.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecom.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        ecomEntities db = new ecomEntities();

        static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public ActionResult Index()
        {
            var data = db.Products.ToList();
            var products = GetMapper().Map<List<ProductDTO>>(data);
           
            return View(products);
        }
        public ActionResult Addtocart(int id)
        {
            var pd = db.Products.Find(id);
             var p= GetMapper().Map<ProductDTO>(pd);
            p.Qty = 1;
           List<ProductDTO> cart=null;
            if (Session["cart"] == null)
            {
                 cart = new List<ProductDTO>();

            }
            else
            {
                cart = (List<ProductDTO>)Session["cart"];

            }
            cart.Add(p);
            Session["cart"] = cart;
            TempData["msg"] = "Product added to cart successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Cart()
        {
            if (Session["cart"] == null)
            {
                return View(new List<ProductDTO>());
            }
            else
            {
                var cart = (List<ProductDTO>)Session["cart"];
                return View(cart);
            }
        }
    }
}