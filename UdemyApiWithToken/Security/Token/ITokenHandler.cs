using UdemyApiWithToken.Domain;

namespace UdemyApiWithToken.Security.Token
{
    internal interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);

        void RevokeRefreshToken(User user);
    }
}