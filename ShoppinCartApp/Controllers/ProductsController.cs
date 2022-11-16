using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Models.DTO.ProductDTO;
using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Repositories.Repos.ProductsRepos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShoppinCartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseAPIController<Products,
        ProductsDTO, ProductsDTO,
        AddProductsDTO,
        UpdateProductsDTO>
    {

        private readonly IProductsRepo productsRepo;
        private IHostingEnvironment _env;
        public ProductsController(IProductsRepo productsRepo, IHostingEnvironment _env, IMapper mapper) : base(mapper, productsRepo)
        {
            this.productsRepo = productsRepo;
            this._env = _env;
        }

        [HttpGet("getallproducts")]
        public async Task<ActionResult<IList<ProductsDTO>>> GetAllproducts()
        {
            try
            {
                var products = await productsRepo.GetAllBy(x => (x.IsActive) && (!x.IsDelete));
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getproductbyid/{id}")]
        public async Task<ActionResult<IList<ProductsDTO>>> GetProductById(string id)
        {
            try
            {
                var product = await productsRepo.GetBy(x=>x.Id==id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addproducts")]
        public async Task<ActionResult> AddUsers([FromBody] AddProductsDTO product)
        {
            try
            {
                var userid = Guid.NewGuid().ToString();
                var pagedUsers = await productsRepo.Add(product.ConvertToModel(), userid);
                return Ok(pagedUsers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Route("UploadProductImage/{id}")]
        public async Task<IActionResult> UploadProductImage(string id)
        {
            string imagePath = string.Empty;
            try
            {
                IFormFile file = Request.Form.Files[0];

                if (file.Length > 0)
                {
                    string fName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string extension = fName.Split('.')[1];
                    string fileName = Guid.NewGuid().ToString();
                    string fullPath = Path.Combine(_env.WebRootPath, "Images\\ProductImages", fileName + "." + extension);
                    imagePath = "Images//ProductImages//" + fileName + "." + extension;
                    using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var prod = productsRepo.GetBy(x => x.Id == id).Result;
                    prod.Image = "https://localhost:44373/" + imagePath;
                    await productsRepo.Update(prod);
                    return Ok(prod); ;
                }
                return Ok();

            }
            catch (Exception ex)
            {
                return Ok(new { path = string.Empty });
            }
        }
    }
}
