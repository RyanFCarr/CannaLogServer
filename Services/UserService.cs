using Microsoft.IdentityModel.Tokens;
using Server.Models;
using Server.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace Server.Services
{
    public interface IUserService : IService<User> {
        User? GetOne(string email);
        string GenerateToken(User user);
    }


    public class UserService : IUserService {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;
        public UserService(IUserRepository repo, IConfiguration config) {
            _repo = repo;
            _config = config;
        }
        public User Create(User item) => _repo.Create(item);

        public void Delete(int id) => _repo.Delete(id);

        public IEnumerable<User> GetAll() => _repo.GetAll();

        public IEnumerable<User> GetAll(Expression<Func<User, bool>> filter) => _repo.GetAll(filter);

        public User? GetOne(int id) => _repo.GetOne(id);
        public User? GetOne(string email) => _repo.GetOne(email);

        public User Update(User item) => _repo.Update(item);

        public string GenerateToken(User user) {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
