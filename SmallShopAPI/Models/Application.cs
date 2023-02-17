using System.Data.SqlClient;
using System.Data;

namespace SmallShopAPI.Models
{
    public class Application
    {
        public Response GetAllProduct(SqlConnection con)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select ProductId, ProductName, Amount, Price from product", con);
            DataTable dt = new DataTable();
            List<Product> listProduct = new List<Product>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Product product = new Product();
                    product.ProductId = (int)dt.Rows[i]["ProductId"];
                    product.ProductName = (string)dt.Rows[i]["ProductName"];
                    product.Amount = (int)dt.Rows[i]["Amount"];
                    product.Price = double.Parse(dt.Rows[i]["Price"].ToString());

                    listProduct.Add(product);
                }
            }
            if (listProduct.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.listProduct = listProduct;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listProduct = null;
            }
            return response;
        }

        public Response GetProductByID(SqlConnection con, int id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select ProductId, ProductName, Amount, Price from product Where ProductId = '" + id + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Product product = new Product();
                product.ProductId = (int)dt.Rows[0]["ProductId"];
                product.ProductName = (string)dt.Rows[0]["ProductName"];
                product.Amount = (int)dt.Rows[0]["Amount"];
                product.Price = double.Parse(dt.Rows[0]["Price"].ToString());

                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.product = product;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listProduct = null;
            }
            return response;
        }

        public Response GetProductByName(SqlConnection con, string name)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select ProductId, ProductName, Amount, Price from product Where ProductName = '" + name + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Product product = new Product();
                product.ProductId = (int)dt.Rows[0]["ProductId"];
                product.ProductName = (string)dt.Rows[0]["ProductName"];
                product.Amount = (int)dt.Rows[0]["Amount"];
                product.Price = double.Parse(dt.Rows[0]["Price"].ToString());

                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.product = product;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listProduct = null;
            }
            return response;
        }

        public Response AddProduct(SqlConnection con, Product product)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Insert into Product(ProductId, ProductName, Amount, Price) Values('" + product.ProductId + "','" + product.ProductName + "', '" + product.Amount + "', '" + product.Price + "') ", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product Added";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Inserted";

            }
            return response;
        }

        public Response UpdateProduct(SqlConnection con, Product product)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Update product set productName='" + product.ProductName + "', Amount='" + product.Amount + "', Price='" + product.Price + "' Where productId='" + product.ProductId + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product Updated";
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Updated";

            }
            return response;
        }

        public Response CheckoutProduct(SqlConnection con, List<Product> productList)
        {
            string updateSqls = new string("");
            for(int i=0; i< productList.Count; i++)
            {
                updateSqls = updateSqls + "update product set Amount = Amount - " + productList[i].Amount + "where ProductName = '" + productList[i].ProductName + "'; ";
            }
            
            Response response = new Response();
            SqlCommand cmd = new SqlCommand(updateSqls, con);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            if (count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Checkout Successful";
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Checkout Fail";

            }
            return response;
        }

        public Response DeleteProduct(SqlConnection con, int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from Product Where ProductId='" + id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Product Deleted";
            }

            return response;
        }

    }
}
