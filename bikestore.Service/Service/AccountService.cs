using bikestore.Entity;
using bikestore.Entity.Auth;
using bikestore.Service.Interface;

namespace bikestore.Service.Service
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;
        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        public Account Create(Account model)
        {
            if (string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.Username))
                throw new Exception("Username và Password không được để trống");
            if (model.UserId == 0)
                throw new Exception("UserId không được để trống");
            var duplicatedUsername = _context.Accounts.FirstOrDefault(x => x.Username == model.Username && !x.IsDeleted);
            if (duplicatedUsername != null)
                throw new Exception("Username đã được sử dụng");
            var duplicatedAccount = _context.Accounts.FirstOrDefault(x => x.UserId == model.UserId && !x.IsDeleted);
            if (duplicatedAccount != null)
                throw new Exception("Người dùng đã có tài khoản");

            model.CreatedDate = DateTime.Now;
            _context.Accounts.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool Delete(int id)
        {
            var existAccount = _context.Accounts.FirstOrDefault(x => x.Id == id && !x.IsDeleted) ?? throw new Exception("Tài khoản không tồn tại");
            existAccount.IsDeleted = true;
            _context.Accounts.Update(existAccount);
            _context.SaveChanges();
            return true;
        }

        public List<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }

        public Account GetById(int id)
        {
            return _context.Accounts.FirstOrDefault(x => x.Id == id && !x.IsDeleted) ?? throw new Exception("Tài khoản không tồn tại");
        }

        public Account Update(Account model)
        {
            if (string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.Username))
                throw new Exception("Username và Password không được để trống");
            if (model.UserId == 0)
                throw new Exception("UserId không được để trống");
            var duplicatedAccount = _context.Accounts.FirstOrDefault(x => x.Id != model.Id && x.Username == model.Username && !x.IsDeleted);
            if (duplicatedAccount != null)
                throw new Exception("Username đã được sử dụng");

            var existAccount = _context.Accounts.FirstOrDefault(x => x.Id == model.Id && !x.IsDeleted) ?? throw new Exception("Tài khoản không tồn tại");
            existAccount.UpdatedDate = DateTime.Now;
            existAccount.Username = model.Username;
            existAccount.Password = model.Password;
            existAccount.UserId = model.UserId;

            _context.Accounts.Update(existAccount);
            _context.SaveChanges();
            return model;
        }
    }
}