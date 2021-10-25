using EC4WebApp.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EC4WebApp.Extensions
{
    public static class UserManagerExtensions
    {
        /// <summary>
        /// Find <see cref="UserInfo"/> with provided <paramref name="userName"/>
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="loginId">Login Id</param>
        /// <returns><see cref="Task"/> which reference <see cref="UserInfo>"/></returns>

        public static async Task<User> FindByUserNameAsync(this UserManager<User> userManager, string userName)
        {
            return await userManager.Users.FirstOrDefaultAsync(u => u.UserName.Equals(userName));
        }
    }
}
