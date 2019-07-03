using System;

namespace UdemyApiWithToken.Domain.Responses
{
    public class UserResponse : BaseResponse
    {
        public User user { get; set; }

        private UserResponse(Boolean success, string message, User user) : base(success, message)//base ile miras aldigi classin ctoruna gidip set ediyor
        {
            this.user = user;
        }

        //success

        public UserResponse(User user) : this(true, String.Empty, user) //this ile yukaridaki ctora gidip set ediyor
        {
        }

        //fail

        public UserResponse(string message) : this(false, message, null) //this ile yukaridaki ctora gidip set ediyor
        {
        }
    }
}
