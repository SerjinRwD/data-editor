using Models;

namespace DbRepository.Interfaces
{
    public interface IUserRepository
    {
        long Create(string login, string password);
        void Update(long userId, User user);
        void Delete(long userId);
        User Get(long userId);
        User Authenticate(string login, string password, bool isAdmin);
    }
}
