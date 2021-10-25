using EC4WebApp.Domains;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace EC4WebApp.Services
{
    public interface IJwtServices
    {
        Task<string> GenerateTokenAsync(User user);
        JwtSecurityToken VerifyToken(string jwt);
    }
}
