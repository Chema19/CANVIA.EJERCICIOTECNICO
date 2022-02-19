using CANVIA.EJERCICIOTECNICO.RETOCANVIERO.Models.Product;
using CANVIA.EJERCICIOTECNICO.RETOCANVIERO.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CANVIA.EJERCICIOTECNICO.RETOCANVIERO.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("productapi")]
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("products/page/{page}")]
        public IHttpActionResult GetListProducts(int page)
        {
            try
            {
                var vm = new ProductViewModel();
                var products = vm.ListProducts(page);
                return Ok(products);
                //return Content(HttpStatusCode.BadRequest, response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("products/{productid}")]
        public IHttpActionResult GetProduct(Int32 productid)
        {
            try
            {
                var vm = new ProductViewModel();
                var product = vm.GetProduct(productid);
                return Ok(product);
                //return Content(HttpStatusCode.BadRequest, response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        [Route("products")]
        public IHttpActionResult AddProduct(ProductModel model)
        {
            try
            {
                var vm = new ProductViewModel();
                vm.AddProduct(model);
                return Ok("Registro Creado Correctamente");
                //return Content(HttpStatusCode.BadRequest, response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpPut]
        [Route("products")]
        public IHttpActionResult EditProduct(ProductModel model)
        {
            try
            {
                var vm = new ProductViewModel();
                vm.UpdateProduct(model);
                return Ok("Registro Actualizado Correctamente");               
               //return Content(HttpStatusCode.BadRequest, response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpDelete]
        [Route("products/deletephisic/{productid}")]
        public IHttpActionResult DeleteProductLogic(Int32 productid)
        {
            try
            {
                var vm = new ProductViewModel();
                vm.DeleteProduct(productid);
                return Ok("Registro Eliminado Correctament");
                //return Content(HttpStatusCode.BadRequest, response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpDelete]
        [Route("products/deletelogic/{productid}")]
        public IHttpActionResult DeleteProduct(Int32 productid)
        {
            try
            {
                    var vm = new ProductViewModel();
                    vm.DeleteProductLogic(productid);
                    return Ok("Registro Eliminado Correctament");
                    //return Content(HttpStatusCode.BadRequest, response);
                }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
    }
}
