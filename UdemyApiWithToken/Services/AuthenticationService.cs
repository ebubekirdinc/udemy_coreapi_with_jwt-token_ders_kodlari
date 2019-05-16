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
            UserResponse userResponse = userService.FindEmailAndPassword(email, password);

            if (userResponse.Success)
            {
                AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.user);

                return new AccessTokenResponse(accessToken);
            }
            else
            {
                return new AccessTokenResponse(userResponse.Message);
            }
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