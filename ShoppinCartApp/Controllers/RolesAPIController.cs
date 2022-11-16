using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Models.DTO.RoleDTO;
using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Repositories.Repos.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppinCartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesAPIController : BaseAPIController<Roles,
        RoleDTO,RoleDTO,
        AddRoleDTO,
        UpdateRoleDTO>
    {
        private readonly IRoleRepo roleRepo;
        public RolesAPIController(IRoleRepo roleRepo,IMapper mapper):base(mapper,roleRepo)
        {
            this.roleRepo = roleRepo;
        }

        [HttpGet("getactiveroles")]
        public async Task<ActionResult<IList<RoleDTO>>> GetActiveRoles()
        {
            try
            {
                var activeRoles = await roleRepo.GetAllBy(x => (x.IsActive) && (!x.IsDelete));
                return Ok(activeRoles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
