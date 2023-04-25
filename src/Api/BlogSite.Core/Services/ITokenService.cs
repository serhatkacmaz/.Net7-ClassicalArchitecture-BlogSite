using BlogSite.Common.Configurations;
using BlogSite.Common.DTOs.JWT;
using BlogSite.Core.Entities.UserBase;

namespace BlogSite.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(User user);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}
