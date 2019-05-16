using UdemyApiWithToken.Domain.Responses;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Security.Token;

namespace UdemyApiWithToken.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService userService;

        private readonly ITokenHandler tokenHandler;

        public AuthenticationService(IUserService userService, ITokenHandler tokenHandler)
        {
            this.userService = userService;
            this.tokenHandler = tokenHandler;
        }

        public AccessTokenResponse CreateAccessToken(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public AccessTokenResponse CreateAccessTokenByRefreshToken(string refreshToken)
        {
            throw new System.NotImplementedException();
        }

        public AccessTokenResponse RevokeRefreshToken(string refreshToken)
        {
            throw new System.NotImplementedException();
        }
    }
}