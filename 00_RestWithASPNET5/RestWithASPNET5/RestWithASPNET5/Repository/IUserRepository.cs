using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Models;

namespace RestWithASPNET5.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string username);
        bool RevokeToken(string username);

        public User RefreshUserInfo(User user);
    }
}
