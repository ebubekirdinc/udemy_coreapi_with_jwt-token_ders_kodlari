namespace UdemyApiWithToken.Domain.Repositories
{
    public class BaseRepository
    {
        protected readonly UdemyApiWithTokenDBContext context;

        public BaseRepository(UdemyApiWithTokenDBContext context)
        {
            this.context = context;
        }
    }
}