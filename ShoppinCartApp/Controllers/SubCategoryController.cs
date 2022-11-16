using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Models.DTO.SubCategoryDTO;
using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Repositories.Repos.SubCategoryRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppinCartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : BaseAPIController<ProductSubCategory,
        ProductSubCategoryDTO, ProductSubCategoryDTO,
        AddProductSubCategoryDTO,
        UpdateProductSubCategoryDTO>
    {
        private readonly ISubCategoryRepo categoryRepo;
        public SubCategoryController(ISubCategoryRepo categoryRepo, IMapper mapper) : base(mapper, categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        [HttpGet("getallsubcategories")]
        public async Task<ActionResult<IList<ProductSubCategoryDTO>>> GetAllSubCategories()
        {
            try
            {
                var cat = await categoryRepo.GetAllBy(x => (x.IsActive) && (!x.IsDelete));
                return Ok(cat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getallsubcategoriesbyid/{id}")]
        public async Task<ActionResult<IList<ProductSubCategoryDTO>>> GetAllSubCategoriesById(string id)
        {
            try
            {
                var cat = await categoryRepo.GetAllSubCategoriesById(id);
                return Ok(cat.Where(x => (x.IsActive) && (!x.IsDelete)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
