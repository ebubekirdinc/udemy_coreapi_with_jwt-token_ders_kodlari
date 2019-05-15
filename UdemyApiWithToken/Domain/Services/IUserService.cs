using UdemyApiWithToken.Domain.Responses;

namespace UdemyApiWithToken.Domain.Services
{
    internal interface IUserService
    {
        UserResponse AddUser(User user);

        UserResponse FindById(int userId);

        UserResponse FindEmailAndPassword(string email, string password);

        void SaveRefreshToken(int userId, string refreshToken);

        UserResponse GetUserWithRefreshToken(string refreshToken);

        void RemoveRefreshToken(User user);
    }
}