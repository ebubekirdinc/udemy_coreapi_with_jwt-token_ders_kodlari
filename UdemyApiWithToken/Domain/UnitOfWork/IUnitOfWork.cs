using System.Threading.Tasks;

namespace UdemyApiWithToken.Domain.UnitOfWork
{
    internal interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}