using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Models.DTO.SecurityAnswerDTO;
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
    public class AnswersController : BaseAPIController<SecurityAnswers,
        SecurityAnswersDTO, SecurityAnswersDTO,
        AddSecurityAnswersDTO,
        UpdateSecurityAnswersDTO>
    {
        private readonly ISecurityAnswersRepo ansRepo;
        public AnswersController(ISecurityAnswersRepo ansRepo,IMapper mapper):base(mapper, ansRepo)
        {
            this.ansRepo = ansRepo;
        }
    }
}
