using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myFirstBackend.DataAcces;
using myFirstBackend.Helpers;
using myFirstBackend.Modelos.DataModels;

namespace myFirstBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        private readonly JWTSettings _jWtSettings;

        public AccountController(UniversityDBContext context,JWTSettings jWtSettings)
        {
            _context = context;
            _jWtSettings = jWtSettings;
          
        }

        //Funcion Login
        private IEnumerable<User> Logins= new List<User>()
        {
            new User() 
            { 
                Id = 1,
                Email="jhonvd08@gmail.com",
                Name="Admin",
                Password="Admin"
            },
            new User()
            {
                Id = 2,
                Email="alex@gmail.com",
                Name="User1",
                Password="alex"
            }
        };

        //Especificar ruta obtener token
        [HttpPost]
        public IActionResult GetToken(UserLogins userLogins)
        {
            try
            {
              var Token = new UserTokens();
              var Valid = Logins.Any(user => user.Name.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                if (Valid)
                {
                    //Encontrar usuario
                    var user= Logins.FirstOrDefault(user => user.Name.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));

                    //Generar Token
                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = user.Name,
                        EmailId = user.Email,
                        Id= user.Id,
                        GuidId=new Guid()
                        
                    }, _jWtSettings);
                }
                else
                {
                    return BadRequest("Credenciales erroneas");
                }

                return Ok(Token);

            }catch(Exception ex) 
            {
                throw new Exception("Error",ex);
            }
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles ="Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }

    }
}
