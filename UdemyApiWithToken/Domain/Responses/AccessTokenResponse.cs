using UdemyApiWithToken.Security.Token;

namespace UdemyApiWithToken.Domain.Responses
{
    public class AccessTokenResponse : BaseResponse
    {
        public AccessToken accesstoken { get; set; }

        private AccessTokenResponse(bool success, string message, AccessToken accessToken) : base(success, message)
        {
            this.accesstoken = accessToken;
        }

        //success
        public AccessTokenResponse(AccessToken accessToken) : this(true, string.Empty, accessToken)
        {
        }

        //fail

        public AccessTokenResponse(string message) : this(false, message, null)
        {
        }
    }
}