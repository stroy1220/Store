using Project.Web.DAL;
using Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    public class StoreController : Controller
       
    {
        private IStoreDAL dal;
       
        // GET: Store
        public StoreController(IStoreDAL StoreDAL)
        {
            this.dal = StoreDAL;
           
        }
        public ActionResult Index()
        {
            return View();
        }
     
        public ActionResult DetailView(int id)
        {
            StoreModel store = dal.GetAProduct(id);
            return View("DetailView", store);
        }
        public ActionResult ListView()
        {
            List<StoreModel>model = dal.GetAllProducts(); 
            return View("ListView", model);
        }
        public ActionResult CategoryView(int categoryId)
        {
            List<StoreModel> cats = dal.GetProductsInCategory(categoryId);
            return View("CategoryView", cats);
        }
     

    }
}