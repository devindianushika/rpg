using System.Net.Cache;
using System.Threading.Tasks;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthRepository _AuthRepository;
        public AuthController(IAuthRepository AuthRepository)
        {
            _AuthRepository = AuthRepository;
        }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(UserRegisterDto request){
    ServiceResponse<int> response = await  _AuthRepository.Register(new User{
            Username = request.Username},request.Password);
            if(!response.Success) {

            return BadRequest(response);
            }

            return Ok(response);
        }
      
        
    }
    
}