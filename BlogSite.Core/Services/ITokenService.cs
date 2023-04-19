using BlogSite.Core.Configurations;
using BlogSite.Core.DTOs.JWT;
using BlogSite.Core.Entities.UserBase;

namespace BlogSite.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(User user);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}
