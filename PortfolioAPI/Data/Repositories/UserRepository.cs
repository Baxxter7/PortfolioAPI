using PortfolioAPI.Data.Entities;

namespace PortfolioAPI.Data.Repositories;

public class UserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public User? Authenticate(string username, string password)
    {
        if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Campos vacíos");
        }
        
        User? userToAuthenticate = _context.Users
            .FirstOrDefault(u => u.Username == username && u.Password == password);
        
        return userToAuthenticate;
    }
}
