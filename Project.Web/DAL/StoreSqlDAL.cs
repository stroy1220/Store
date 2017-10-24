using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Project.Web.Models;


namespace Project.Web.DAL
{
    public class StoreSqlDAL : IStoreDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Store"].ConnectionString;
        private const string SQL_GetAllProducts = "Select * From products";
        private const string SQL_GetProductsInCategory = "Select * From products Where category_id = @category_id";
        private const string SQL_GetAProduct = "Select * From products where id = @id";
        List<StoreModel> products = new List<StoreModel>();

        public List<StoreModel> GetProductsInCategory(int categoryId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetProductsInCategory, conn);
                    cmd.Parameters.AddWithValue("@category_id", categoryId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StoreModel s = new StoreModel();
                        s.ProductId = Convert.ToInt32(reader["id"]);
                        s.Product = Convert.ToString(reader["product"]);
                        s.Price = Convert.ToDecimal(reader["price"]);
                        s.Description = Convert.ToString(reader["description"]);
                        s.CategoryId = Convert.ToInt32(reader["category_id"]);
                        s.ImageName = Convert.ToString(reader["image"]);
                        s.Inventory = Convert.ToInt32(reader["inventory"]);
                        products.Add(s);
                    }
                    return products;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public List<StoreModel> GetAllProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllProducts, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        StoreModel s = new StoreModel();
                        
                        s.ProductId = Convert.ToInt32(reader["id"]);
                        s.Product = Convert.ToString(reader["product"]);
                        s.Price = Convert.ToDecimal(reader["price"]);
                        s.Description = Convert.ToString(reader["description"]);
                        s.CategoryId = Convert.ToInt32(reader["category_id"]);
                        s.ImageName = Convert.ToString(reader["image"]);
                        s.Inventory = Convert.ToInt32(reader["inventory"]);
                        products.Add(s);

                    }
                    return products;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public StoreModel GetAProduct(int productId)
        {
            StoreModel s = new StoreModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAProduct, conn);
                    cmd.Parameters.AddWithValue("@id", productId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        s.ProductId = Convert.ToInt32(reader["id"]);
                        s.Product = Convert.ToString(reader["product"]);
                        s.Price = Convert.ToDecimal(reader["price"]);
                        s.Description = Convert.ToString(reader["description"]);
                        s.CategoryId = Convert.ToInt32(reader["category_id"]);
                        s.ImageName = Convert.ToString(reader["image"]);
                        s.Inventory = Convert.ToInt32(reader["inventory"]);
                    } 
                }
                return s;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}