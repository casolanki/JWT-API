
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace API.controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {

        private readonly IMapper _mapper;

        private readonly DataContext _context;
        public UserController(DataContext context,IMapper mapper){ 
            _context = context;
             _mapper = mapper;
        }

        [HttpGet]
         public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            var _user = await _context.Users.ToListAsync();
            return Ok(_user);            
        }
        
        [HttpGet("{id}")]
         public async Task<ActionResult<AppUser>> GetUsers(int id){
           return await _context.Users.FindAsync(id);
        }
    }
}