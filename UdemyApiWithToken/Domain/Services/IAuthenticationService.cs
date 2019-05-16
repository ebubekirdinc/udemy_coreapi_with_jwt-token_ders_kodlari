using UdemyApiWithToken.Domain.Responses;

namespace UdemyApiWithToken.Domain.Services
{
    internal interface IAuthenticationService
    {
        AccessTokenResponse CreateAccessToken(string email, string password);

        AccessTokenResponse CreateAccessTokenByRefreshToken(string refreshToken);

        AccessTokenResponse RevokeRefreshToken(string refreshToken);
    }
}