using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmallShopAPI.Models;
using System.Data.SqlClient;

namespace SmallShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmallShopController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SmallShopController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllProduct")]
        public Response GetAllProduct()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("smallShopDBCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetAllProduct(con);
            return response;
        }

        [HttpGet]
        [Route("GetProductByID/{id}")]
        public Response GetProductByID(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("smallShopDBCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetProductByID(con, id);
            return response;
        }

        [HttpGet]
        [Route("GetProductByName/{name}")]
        public Response GetProductByName(string name)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("smallShopDBCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetProductByName(con, name);
            return response;
        }

        [HttpPost]
        [Route("AddProduct")]
        public Response AddProduct(Product product)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("smallShopDBCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.AddProduct(con, product);
            return response;
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public Response UpdatePeople(Product product)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("smallShopDBCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.UpdateProduct(con, product);
            return response;
        }

        [HttpPut]
        [Route("CheckoutProduct")]
        public Response CheckoutProduct(List<Product> productList)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("smallShopDBCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.CheckoutProduct(con, productList);
            return response;
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public Response DeletePeople(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("smallShopDBCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.DeleteProduct(con, id);
            return response;
        }
    }
}
