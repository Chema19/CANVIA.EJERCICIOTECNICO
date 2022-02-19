using CANVIA.EJERCICIOTECNICO.RETOCANVIERO.Models.Product;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CANVIA.EJERCICIOTECNICO.RETOCANVIERO.ViewModels.Product
{
    public class ProductViewModel
    {
        public int page { set; get; }
        public List<ProductModel> ListProducts(int? p)
        {
            this.page = p ?? 1;
            var listProducto = new List<ProductModel>();
            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.AppSettings["CADENA_CONEXION"].ToString()))
            {
                sqlConn.Open();
                
                string sql = @"exec ListProducts";

                SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(sql, sqlConn);
                SqlDataReader list;

                list = command.ExecuteReader();
                while (list.Read())
                {
                    Console.WriteLine(list[0] + ": " + list[1]);
                    listProducto.Add(new ProductModel()
                    {
                        ProductId = Convert.ToInt32(list[0]),
                        Name = list[1].ToString(),
                        Brand = list[2].ToString(),
                        CreateDate = Convert.ToDateTime(list[3]),
                        UpdateDate = Convert.ToDateTime(list[4]),
                        Status = list[5].ToString(),
                        Price = Convert.ToDecimal(list[6]),
                    });
                }
                sqlConn.Close();

            }
            return listProducto.Skip((page - 1) * 2).Take(2).ToList();
        }

        public ProductModel GetProduct(int? id)
        {
            var product = new ProductModel();
            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.AppSettings["CADENA_CONEXION"].ToString()))
            {
                sqlConn.Open();

                string sql = @"exec GetProduct " + id.ToString();

                SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(sql, sqlConn);
                SqlDataReader list;

                list = command.ExecuteReader();
                while (list.Read())
                {
                    Console.WriteLine(list[0] + ": " + list[1]);
                    product = new ProductModel()
                    {
                        ProductId = Convert.ToInt32(list[0]),
                        Name = list[1].ToString(),
                        Brand = list[2].ToString(),
                        CreateDate = Convert.ToDateTime(list[3]),
                        UpdateDate = Convert.ToDateTime(list[4]),
                        Status = list[5].ToString(),
                        Price = Convert.ToDecimal(list[6]),
                    };
                }
                sqlConn.Close();

            }
            return product;
        }
        public ProductModel AddProduct(ProductModel model)
        {
            var product = new ProductModel();
            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.AppSettings["CADENA_CONEXION"].ToString()))
            {
                sqlConn.Open();

                string sql = @"exec AddProduct '" + model.Name + "', '" + model.Brand + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + model.Price;

                SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(sql, sqlConn);

                sqlAdapter.InsertCommand = command;

                command.ExecuteNonQuery();
                sqlConn.Close();

            }
            return product;
        }

        public ProductModel UpdateProduct(ProductModel model)
        {
            var product = new ProductModel();
            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.AppSettings["CADENA_CONEXION"].ToString()))
            {
                sqlConn.Open();

                string sql = @"exec UpdateProduct " + model.ProductId + ", '" + model.Name + "', '" + model.Brand + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + model.Price;

                SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(sql, sqlConn);

                sqlAdapter.UpdateCommand = command;

                command.ExecuteNonQuery();
                sqlConn.Close();

            }
            return product;
        }

        public ProductModel DeleteProduct(int? id)
        {
            var product = new ProductModel();
            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.AppSettings["CADENA_CONEXION"].ToString()))
            {
                sqlConn.Open();

                string sql = @"exec DeleteProduct " + id.ToString();

                SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(sql, sqlConn);

                sqlAdapter.DeleteCommand = command;

                command.ExecuteNonQuery();
                sqlConn.Close();

            }
            return product;
        }
        public ProductModel DeleteProductLogic(int? id)
        {
            var product = new ProductModel();
            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.AppSettings["CADENA_CONEXION"].ToString()))
            {
                sqlConn.Open();

                string sql = @"exec DeleteProductLogic " + id.ToString();

                SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(sql, sqlConn);

                sqlAdapter.DeleteCommand = command;

                command.ExecuteNonQuery();
                sqlConn.Close();

            }
            return product;
        }
    }
}