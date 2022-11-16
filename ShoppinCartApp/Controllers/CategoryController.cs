using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Models.DTO.CategoryDTO;
using ShoppingCartApp.Models.DTO.SubCategoryDTO;
using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Repositories.Repos.CategoryRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppinCartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseAPIController<ProductCategory,
        ProductCategoryDTO, ProductCategoryDTO,
        AddProductCategoryDTO,
        UpdateProductCategoryDTO>
    {
        private readonly ICategoryRepo categoryRepo;
        public CategoryController(ICategoryRepo categoryRepo, IMapper mapper) : base(mapper, categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        [HttpGet("getallcategories")]
        public async Task<ActionResult<IList<ProductCategoryDTO>>> GetAllCategories()
        {
            try
            {
                var cat = await categoryRepo.GetAllCategoriesandSubCat();
                var subcat = await categoryRepo.GetAllSubCategories();
                List<ProductCategoryDTO> categoryDTOs = new List<ProductCategoryDTO>();
                List<ProductSubCategoryDTO> subcategoryDTOs = new List<ProductSubCategoryDTO>();
                foreach (var item1 in subcat)
                {
                    subcategoryDTOs.Add(new ProductSubCategoryDTO()
                    {
                        Id=item1.Id,
                        SubCategoryName=item1.SubCategoryName,
                        FKCategoryId=item1.FKCategoryId,
                        IsActive=item1.IsActive,
                        IsDelete=item1.IsDelete
                    });
                }
                foreach (var item in cat)
                {
                    categoryDTOs.Add(new ProductCategoryDTO()
                    {
                        Id = item.Id,
                        CategoryName = item.CategoryName,
                        SubCategories = subcategoryDTOs.Where(x => x.FKCategoryId == item.Id).ToList()
                    }); ;

                }

                return Ok(categoryDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
