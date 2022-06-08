using APIApp_3.Models;

namespace APIApp_3.Services
{
    public interface IUserService
    {
        LoginRequest Login(LoginRequest model);
        IEnumerable<User> GetAll();
        GetUserDetails GetByEmail(string email);
        void Register(Register model);

    }
}
