using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppinCartApp.Helper;
using ShoppingCartApp.Models.DTO.Common;
using ShoppingCartApp.Models.DTO.UserDTO;
using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppinCartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAPIController : BaseAPIController<User,
        UserDTO, UserDTO,
        AddUserDTO,
        UpdateUserDTO>
    {
        private readonly IUserRepo userRepo;
        public UsersAPIController(IUserRepo userRepo, IMapper mapper) : base(mapper, userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpGet("getactiveusers")]
        public async Task<ActionResult<IList<UserDTO>>> GetActiveUsers()
        {
            try
            {
                var activeUsers = await userRepo.GetAllBy(x => (x.IsActive) && (!x.IsDelete) && x.FKRoleId == 3);
                return Ok(activeUsers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("getallusers/{pagenumber:int}/{pagesize:int}")]
        public async Task<ActionResult<PaginationEntityDto<UserDTO>>> GetPaged([FromRoute] int pagenumber, [FromRoute] int pagesize, [FromBody] FilterAttributes filterArray = null)
        {
            try
            {
                var pagedUsers = await userRepo.GetPagedUsers(filterArray, pagenumber, pagesize, x => !x.IsDelete, x => x.Username);
                return Ok(pagedUsers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("addusers")]
        public async Task<ActionResult> AddUsers([FromBody] AddUserDTO user)
        {
            try
            {
                var userid = Guid.NewGuid().ToString();
                var pagedUsers = await userRepo.Add(user.ConvertToModel(),userid);
                return Ok(pagedUsers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
