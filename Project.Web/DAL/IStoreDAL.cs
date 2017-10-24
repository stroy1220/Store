using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Project.Web.Models;

namespace Project.Web.DAL
{
    public interface IStoreDAL
    {
        List<StoreModel> GetAllProducts();
        List<StoreModel> GetProductsInCategory(int categoryId);
        StoreModel GetAProduct(int productId);
    }
}