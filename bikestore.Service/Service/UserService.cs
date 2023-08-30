using bikestore.Entity;
using bikestore.Entity.Auth;
using bikestore.Service.Interface;

namespace bikestore.Service.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public User Create(User model)
        {
            if (string.IsNullOrEmpty(model.FullName))
                throw new Exception("FullName không được để trống");

            model.CreatedDate = DateTime.Now;
            _context.Users.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool Delete(int id)
        {
            var existUser = _context.Users.FirstOrDefault(x => x.Id == id && !x.IsDeleted) ?? throw new Exception("Người dùng không tồn tại");
            existUser.IsDeleted = true;
            _context.Users.Update(existUser);
            _context.SaveChanges();
            return true;
        }

        public List<User> GetAll()
        {
            return _context.Users.Where(x => !x.IsDeleted).ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id && !x.IsDeleted) ?? throw new Exception("Người dùng không tồn tại");
        }

        public User Update(User model)
        {
            if (string.IsNullOrEmpty(model.FullName))
                throw new Exception("FullName không được để trống");

            var existUser = _context.Users.FirstOrDefault(x => x.Id == model.Id && !x.IsDeleted) ?? throw new Exception("Người dùng không tồn tại");
            existUser.UpdatedDate = DateTime.Now;
            existUser.FullName = model.FullName;
            existUser.Address = model.Address;

            _context.Users.Update(existUser);
            _context.SaveChanges();
            return model;
        }
    }
}