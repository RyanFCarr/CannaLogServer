using Server.Models;
using Server.Repositories;
using System.Linq.Expressions;

namespace Server.Services
{
    public interface IUserService : IService<User> {}

    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo) {
            _repo = repo;
        }
        public User Create(User item) => _repo.Create(item);

        public void Delete(int id) => _repo.Delete(id);

        public IEnumerable<User> GetAll() => _repo.GetAll();

        public IEnumerable<User> GetAll(Expression<Func<User, bool>> filter) => _repo.GetAll(filter);

        public User? GetOne(int id) => _repo.GetOne(id);

        public User Update(User item) => _repo.Update(item);
    }
}
