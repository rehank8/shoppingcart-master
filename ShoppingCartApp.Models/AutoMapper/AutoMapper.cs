using AutoMapper;
using ShoppingCartApp.Models.DTO.CartItemDTO;
using ShoppingCartApp.Models.DTO.Common;
using ShoppingCartApp.Models.DTO.ProductDTO;
using ShoppingCartApp.Models.DTO.RoleDTO;
using ShoppingCartApp.Models.DTO.SecurityAnswerDTO;
using ShoppingCartApp.Models.DTO.SecurityQuestionDTO;
using ShoppingCartApp.Models.DTO.UserDTO;
using ShoppingCartApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApp.Models.AutoMapper
{
    public class CustomAutoMapper : Profile
    {
        public CustomAutoMapper()
        {
            CreateMap<Roles, RoleDTO>().ReverseMap();
            CreateMap<Roles, AddRoleDTO>().ReverseMap();
            CreateMap<Roles, UpdateRoleDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<PaginationEntityDto<User>, PaginationEntityDto<UserDTO>>().ReverseMap();
            CreateMap<User, AddUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();

            CreateMap<CartItems, CartItemsDTO>().ReverseMap();
            CreateMap<CartItems, AddCartItemsDTO>().ReverseMap();
            CreateMap<CartItems, UpdateCartItemsDTO>().ReverseMap();

            CreateMap<Products, ProductsDTO>().ReverseMap();
            CreateMap<Products, AddProductsDTO>().ReverseMap();
            CreateMap<Products, UpdateProductsDTO>().ReverseMap();

            CreateMap<SecurityQuestions, SecurityQuestionsDTO>().ReverseMap();
            CreateMap<SecurityQuestions, AddSecurityQuestionsDTO>().ReverseMap();
            CreateMap<SecurityQuestions, UpdateSecurityQuestionsDTO>().ReverseMap();


            CreateMap<SecurityAnswers, SecurityAnswersDTO>().ReverseMap();
            CreateMap<SecurityAnswers, AddSecurityAnswersDTO>().ReverseMap();
            CreateMap<SecurityAnswers, UpdateSecurityQuestionsDTO>().ReverseMap();
        }

    }
}
