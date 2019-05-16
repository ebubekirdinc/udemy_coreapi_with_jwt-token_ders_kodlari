using System;
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
            UserResponse userResponse = userService.GetUserWithRefreshToken(refreshToken);

            if (userResponse.Success)
            {
                if (userResponse.user.RefreshTokenEndDate < DateTime.Now)
                {
                    AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.user);

                    return new AccessTokenResponse(accessToken);
                }
                else
                {
                    return new AccessTokenResponse("refreshtoken süresi dolmuş");
                }
            }
            else
            {
                return new AccessTokenResponse("refreshtoken bulunamadı");
            }
        }

        public AccessTokenResponse RevokeRefreshToken(string refreshToken)
        {
            UserResponse userResponse = userService.GetUserWithRefreshToken(refreshToken);

            if (userResponse.Success)
            {
                userService.RemoveRefreshToken(userResponse.user);

                return new AccessTokenResponse(new AccessToken());
            }
            else
            {
                return new AccessTokenResponse("refreshtoken bulunamadı.");
            }
        }
    }
}