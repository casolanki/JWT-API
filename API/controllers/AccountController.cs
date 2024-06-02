using API.DTO;
using API.Interface;
using API.Entities;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using API.Data;
using AutoMapper;
namespace API.controllers
{

    public class AccountController : BaseApiController
    {
        
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public AccountController(ITokenService tokenService, UserManager<AppUser> userManager, 
        SignInManager<AppUser> signInManager, IMapper mapper, DataContext context) 
        {
            _tokenService = tokenService;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

         
        [HttpGet("{id}")]
         public async Task<ActionResult<AppUser>> GetUsers(int id){
           return await _context.Users.FindAsync(id);
        }

        [HttpPost("signin")]
        public async Task<ActionResult<UserDto>> Login([FromBody]LoginDto loginDto)
        {
            var user =   _context.Users.SingleOrDefault(x => x.UserName == loginDto.UserName.ToLower()); 

            if (user == null) return Unauthorized("Invalid username");

              var result = await _signInManager
                            .CheckPasswordSignInAsync(user, loginDto.Password, false);

             if(!result.Succeeded) return Unauthorized();

            var token = await _tokenService.CreateToken(user);
            try
            {
                return new UserDto
                {
                    UserName = user.UserName,
                    Token = token                  
                };
            }
            catch (Exception e)
            {
                throw;
            }

        }
         [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody]RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserName))
                return BadRequest("username is taken..!!");

            var user = _mapper.Map<AppUser>(registerDto);
            user.UserName = registerDto.UserName.ToLower();


            var result = await _userManager.CreateAsync(user, registerDto.Password);
                      
             
            if (result.Succeeded)
            {
              //  var roleResult = await _userManager.AddToRoleAsync(user, "Member");

                //if (!roleResult.Succeeded) return BadRequest(result.Errors);

                return new UserDto
                {
                    UserName = user.UserName,
                    Token = await _tokenService.CreateToken(user),                
                };
            }

           return BadRequest(result.Errors); 

        
        }

        private async Task<bool> UserExists(string Username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == Username.ToLower());
        }
       
    }

}
