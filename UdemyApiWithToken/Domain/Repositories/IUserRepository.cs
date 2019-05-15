using System.Threading.Tasks;

namespace UdemyApiWithToken.Domain.Repositories
{
    internal interface IUserRepository
    {
        Task AddUser(User user);

        User FindById(int userId);

        User FindByEmailandPassword(string email, string password);

        void SaveRefreshToken(int userId, string refreshToken);

        User GetUserWithRefreshToken(string refreshToken);

        void RemoveRefreshToken(User user);
    }
}