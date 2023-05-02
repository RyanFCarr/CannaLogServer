using Server.Contexts;
using Server.Models;
using System.Linq.Expressions;

namespace Server.Repositories
{
    public interface IUserRepository : IRepository<User> {
        User? GetOne(string email);
    }


    public class UserRepository : IUserRepository {

        private readonly CannaLogContext _context;

        public UserRepository(CannaLogContext context) {
            _context = context;
        }

        public User Create(User user) {
            var entity = _context.Add(user);
            _context.SaveChanges();

            return entity.Entity;
        }

        public void Delete(int id) {
            var user = GetOne(id) ?? throw new ArgumentException("User not found");
            user.IsDeleted = true;

            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll() => _context.Users;
        public IEnumerable<User> GetAll(Expression<Func<User, bool>> filter) => _context.Users.Where(filter);

        public User? GetOne(int id) => _context.Users.Find(id);
        public User? GetOne(string email) => _context.Users.FirstOrDefault(user => user.Email == email);

        public User Update(User user) {
            _context.Update(user);
            _context.SaveChanges();

#pragma warning disable CS8603 // Possible null reference return.
            return GetOne(user.Id);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
