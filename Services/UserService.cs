using APIApp_3.Models;

namespace APIApp_3.Services
{
    public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public LoginRequest Login(LoginRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

            // validate
            if ((user == null) || (model.Password != user.Password))
                throw new Exception("Email or password is incorrect");

            return new LoginRequest { Email = user.Email, Password = user.Password };

            return null;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public void Register(Register model)
        {
            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new Exception("Email '" + model.Email + "' is already exist");

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNo = model.PhoneNo,
                Email = model.Email,
                Password = model.Password
            };

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private User getUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public GetUserDetails GetByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            if (user == null) throw new KeyNotFoundException("User not found");

            var uModel = new GetUserDetails();

            if (user != null)
            {
                uModel = new GetUserDetails
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNo = user.PhoneNo,
                };
            }
            return uModel;
        }
    }
}