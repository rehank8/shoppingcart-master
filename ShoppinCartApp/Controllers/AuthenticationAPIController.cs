using Amazon.AspNetCore.Identity.Cognito;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingCartApp.Models.DTO.RegisreUser;
using ShoppingCartApp.Models.DTO.UserDTO;
using ShoppingCartApp.Models.Utility;
using ShoppingCartApp.Repositories.Repos;
using ShoppingCartApp.Repositories.Repos.Role;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinCartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationAPIController : ControllerBase
    {
        readonly IConfiguration configuration;
        private IUserRepo userRepo;
        private IRoleRepo roleRepo;
        private ISecurityAnswersRepo ansRepo;
        private readonly SignInManager<CognitoUser> _signInManager;

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public AuthenticationAPIController(IUserRepo user, IRoleRepo roleRepo, ISecurityAnswersRepo ansRepo, IConfiguration _configuration, SignInManager<CognitoUser> signInManager)
        {
            this.userRepo = user;
            this.roleRepo = roleRepo;
            this.ansRepo = ansRepo;
            _signInManager = signInManager;
            configuration = _configuration;
        }

        [BindProperty]
        public RegisterUserDTO Input { get; set; }

        [HttpPost("Login")]
        public async Task<ActionResult> Authenticate([FromBody] UserDTO user)
        {
            try
            {
                string ip = "";
                IPHostEntry Host = default(IPHostEntry);
                string Hostname = null;
                Hostname = System.Environment.MachineName;
                Host = Dns.GetHostEntry(Hostname);
                foreach (IPAddress IP in Host.AddressList)
                {
                    if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        ip = Convert.ToString(IP);
                    }
                }
                //var ip = Request.HttpContext.GetServerVariable);["HTTP_X_FORWARDED_FOR"]; // Request.HttpContext.Connection.RemoteIpAddress.ToString();
                LoginSucessDTO loginSucess = new LoginSucessDTO();
                var dbUser = await userRepo.GetBy(x => x.Username == user.Username && x.Password == user.Password);
                if (string.IsNullOrEmpty(dbUser.IPAddress))
                {
                    dbUser.IPAddress = ip;
                    await userRepo.Update(dbUser);
                }
                if (!string.IsNullOrEmpty(dbUser.IPAddress))
                {
                    if (dbUser.IPAddress != ip)
                    {
                        dbUser.IsSecurityQuestions = true;
                        loginSucess.IsSecurityQuestions = true;
                        await userRepo.Update(dbUser);
                        var answers = ansRepo.GetAll();
                    }
                }

                var tokenhandler = new JwtSecurityTokenHandler();
                var securitykey = configuration.GetSection("JwtHelper");
                var appSettings = securitykey.Get<JwtHelper>();
                var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

                string role = (dbUser.FKRoleId == 1) ? "Admin" : "User";

                List<Claim> claims = new List<Claim>()
                        {
                            new Claim("id", dbUser.Id.ToString()),
                            new Claim("name", dbUser.Username),
                            new Claim("email", dbUser.EmailId),
                            new Claim("role", role),
                        };

                DateTime tokenExpiresIn = DateTime.UtcNow.AddDays(10);


                JwtSecurityToken tokenOptions = new JwtSecurityToken(
                        claims: claims,
                        expires: tokenExpiresIn,
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                    );

                string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                loginSucess.Token = tokenString;
                loginSucess.TokenExpiration = tokenExpiresIn;

                return Ok(loginSucess);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [HttpPost("CognitoLogin")]
        public async Task<ActionResult> CognitoLogin([FromBody] RegisterUserDTO user, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return Ok(result);
                    //_logger.LogInformation("User logged in.");
                    // return LocalRedirect(returnUrl);
                }
                //else if (result.RequiresTwoFactor)
                //{
                //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                //}
                //else if (result.IsCognitoSignInResult())
                //{
                //    if (result is CognitoSignInResult cognitoResult)
                //    {
                //        if (cognitoResult.RequiresPasswordChange)
                //        {
                //            //_logger.LogWarning("User password needs to be changed");
                //            //return RedirectToPage("./ChangePassword");
                //        }
                //        else if (cognitoResult.RequiresPasswordReset)
                //        {
                //            //_logger.LogWarning("User password needs to be reset");
                //            return RedirectToPage("./ResetPassword");
                //        }
                //    }

                //}

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return NotFound();
            }

            // If we got this far, something failed, redisplay form
            return BadRequest();
        }
    }
}
