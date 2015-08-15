using SpaSystem.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaSystem.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            using(SpaDbEntities db=new SpaDbEntities())
            {
                ViewBag.Products = db.Products.ToList();
                return View();
            }
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View(new ProductViewModel());
        }
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel model,HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["photo"];
                if(file==null)
                {
                    ViewBag.Message = "Please Select The Image File";
                    return View(model);
                }
                if(file.ContentLength<1000 && file.ContentLength>1024*30)
                {
                    ViewBag.Message = "Please Select Image Size Should Between 1Kb to 30Kb";
                    return View(model);
                }
                if(file.ContentType!="image/jpeg")
                {
                    ViewBag.Message = "Please Select .jpg File";
                    return View(model);
                }
                using (SpaDbEntities db = new SpaDbEntities())
                {
                    var Search = db.Products.Where(x => x.ProductName == model.ProductName).FirstOrDefault();
                    if (Search != null)
                    {
                        ViewBag.Message = "Product Exist";
                    }
                    else
                    {
                        Product product = new Product();
                        product.ProductName = model.ProductName;
                        product.ProductDesc = model.ProductDescription;
                        product.CategoryId = model.CategoryId;
                        product.UnitId = model.UnitId;
                        db.Products.Add(product);
                        db.SaveChanges();
                        var FileName = product.ProductId + ".jpg";
                        var FilePath = Server.MapPath("~/Files/Images/Product/" + FileName);
                        file.SaveAs(FilePath);
                        ViewBag.Message = "Product Added Sucessfully";
                    }
                }
             }
            else
            {
                ViewBag.Message = "Please Enter Required Fields.";
            }
            return View(model);
        }
       [HttpGet]
        public ActionResult EditProduct(int? Id)
        {
            if (Id == null) return RedirectToAction("Index");
            using(SpaDbEntities db=new SpaDbEntities())
            {
                var Search = db.Products.Where(x => x.ProductId == Id.Value).FirstOrDefault();
                if (Search == null) return RedirectToAction("Index");
                return View(new ProductViewModel()
                {
                    ProductId = Search.ProductId,
                    CategoryId = Search.CategoryId.Value,
                    UnitId = Search.UnitId.Value,
                    ProductName = Search.ProductName,
                    ProductDescription = Search.ProductDesc
                });
                
            }
            
        }
       [HttpPost]
        public ActionResult EditProduct(ProductViewModel model,HttpPostedFileBase photo )
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["photo"];
                if(file==null)
                {
                    ViewBag.Message = "Please Select a Valid Image";
                    return View(model);
                }
                if(file.ContentLength<=1000 && file.ContentLength>=1024*30)
                {
                    ViewBag.Message = "Image Size Should between 1Kb to 30Kb";
                    return View(model);
                }
                if(file.ContentType!="image/jpeg")
                {
                    ViewBag.Message = "Select a .jpg Image ";
                }

                using(SpaDbEntities db=new SpaDbEntities())
                {
                    var Search = db.Products.Where(x => x.ProductId == model.ProductId).FirstOrDefault();
                    if(Search==null)
                    {
                        ViewBag.Message = "Product Not Found";
                    }
                        else
                         {
                             var FilePath = Server.MapPath("~/Files/Images/Product/" + Search.ProductId + ".jpg");
                        if(System.IO.File.Exists(FilePath))
                        {
                            System.IO.File.Delete(FilePath);
                        }
                            Search.ProductName = model.ProductName;
                            Search.ProductDesc = model.ProductDescription;
                            Search.CategoryId = model.CategoryId;
                            Search.UnitId = model.UnitId;
                            db.SaveChanges();
                            file.SaveAs(FilePath);
                            ViewBag.Message = "Product Updated";
                         }
  
                }
            } return View(model);
        }
       [HttpGet]
        public ActionResult DeleteProduct(int? Id)
       {
           if (Id == null) return RedirectToAction("Index");
           using(SpaDbEntities db=new SpaDbEntities())
           {
               var Search = db.Products.Where(x => x.ProductId == Id.Value).FirstOrDefault();
              if (Search == null) return RedirectToAction("Index");
              if(Search!=null)
              {
                  ProductViewModel model = new ProductViewModel()
                  {
                      ProductName = Search.ProductName,
                      ProductId = Search.ProductId,
                      ProductDescription = Search.ProductDesc,
                      CategoryId = Search.CategoryId.Value,
                      UnitId = Search.UnitId.Value
                  };
                  View(model);
              }
           }
           return View();
       }
        public ActionResult DeleteProduct(ProductViewModel model)
       {
            using(SpaDbEntities db=new SpaDbEntities())
            {
                var Search = db.Products.Where(x => x.ProductId == model.ProductId).FirstOrDefault();
                if (Search == null) return RedirectToAction("Index");
                else
                {
                    if(System.IO.File.Exists(Server.MapPath("~/Files/Images/Product/"+Search.ProductId+".jpg")))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Files/Images/Product/" + Search.ProductId + ".jpg"));

                    }
                    db.Products.Remove(Search);                    
                    db.SaveChanges();
                   
                  
                }
                return RedirectToAction("Index");
            }
          
       }
    
    }
}