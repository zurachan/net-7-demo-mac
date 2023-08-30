using bikestore.Entity;
using bikestore.Entity.Auth;
using bikestore.Service.Interface;

namespace bikestore.Service.Service
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;
        public RoleService(AppDbContext context)
        {
            _context = context;
        }
        public Role Create(Role model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new Exception("RoleName không được để trống");

            model.CreatedDate = DateTime.Now;
            _context.Roles.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool Delete(int id)
        {
            var existRole = _context.Roles.FirstOrDefault(x => x.Id == id && !x.IsDeleted) ?? throw new Exception("Role không tồn tại");
            existRole.IsDeleted = true;
            _context.Roles.Update(existRole);
            _context.SaveChanges();
            return true;
        }

        public List<Role> GetAll()
        {
            return _context.Roles.Where(x => !x.IsDeleted).ToList();
        }

        public Role GetById(int id)
        {
            return _context.Roles.FirstOrDefault(x => x.Id == id && !x.IsDeleted) ?? throw new Exception("Role không tồn tại");
        }

        public Role Update(Role model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new Exception("RoleName không được để trống");

            var existRole = _context.Roles.FirstOrDefault(x => x.Id == model.Id && !x.IsDeleted) ?? throw new Exception("Role không tồn tại");
            existRole.UpdatedDate = DateTime.Now;
            existRole.Name = model.Name;

            _context.Roles.Update(existRole);
            _context.SaveChanges();
            return model;
        }
    }
}
