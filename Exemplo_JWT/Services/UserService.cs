using Exemplo_JWT.Models;

namespace Exemplo_JWT.Services
{
    public interface IUserService
    {
        User? Authenticate(string username, string password);
        User? GetByUsername(string username);
    }

    public class UserService : IUserService
    {
        // Lista simulada de usuários
        private readonly List<User> _users = new()
        {
            new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin" },
            new User { Id = 2, Username = "usuario", Password = "senha123", Role = "User" }
        };

        public User? Authenticate(string username, string password)
        {
            // Em um cenário real, você usaria hash de senha
            return _users.SingleOrDefault(u =>
                u.Username == username &&
                u.Password == password);
        }

        public User? GetByUsername(string username)
        {
            return _users.SingleOrDefault(u => u.Username == username);
        }
    }
}
