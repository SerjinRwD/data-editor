using DbRepository.Interfaces;
using Models;
using Security;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly SaltedHashingProvider _hashingProvider;

        public UserRepository(string connectionString, IRepositoryContextFactory contextFactory)
            : base(connectionString, contextFactory)
        {
            _hashingProvider = new SaltedHashingProvider();
        }

        public User Authenticate(string login, string password)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var user = context.Users.FirstOrDefault(p => p.Login == (login ?? string.Empty).ToLower());

                if (user == null)
                {
                    return null;
                }

                return _hashingProvider.CheckPassword(password, user.Password, user.Salt)
                    ? user
                    : null;
            }
        }

        public long Create(string login, string password, bool isAdmin)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var result = _hashingProvider.HashPassword(password);

                var user = context.Users.Add(new User
                {
                    Login = login.ToLower(),
                    IsAdmin = isAdmin,
                    Password = result.HashBase64,
                    Salt = result.SaltBase64
                });

                context.SaveChanges();

                return user.Entity.UserId;
            }
        }

        public void Delete(long userId)
        {
            throw new NotImplementedException();
        }

        public User Get(long userId)
        {
            throw new NotImplementedException();
        }

        public void Update(long userId, User user)
        {
            throw new NotImplementedException();
        }
    }
}
