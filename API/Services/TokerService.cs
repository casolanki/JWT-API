
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using API.Interface;
using API.DTO;
using API.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace API.Services 
{
    public class TokenService : ITokenService
    {
        public readonly SymmetricSecurityKey _key;
        //private readonly UserManager<UserDto> _userManager;
        public TokenService(IConfiguration config)        
        {
           // _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));  
        }

        public async Task<string> CreateToken(AppUser user)
        {
            var claims = new List<Claim>
           {
              // new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),             
               new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
           }; 

        //    var roles = await _userManager.GetRolesAsync(user);
        //    claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

           var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

           var tokenDiscription = new SecurityTokenDescriptor
           {
               Subject = new ClaimsIdentity(claims),
               Expires = DateTime.Now.AddMinutes(1),
               SigningCredentials = creds
           };  


           var tokenHandler = new JwtSecurityTokenHandler();

           var token = tokenHandler.CreateToken(tokenDiscription);

           return tokenHandler.WriteToken(token); 
            
        }
    }
}