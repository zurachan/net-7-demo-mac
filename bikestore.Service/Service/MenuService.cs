using bikestore.Entity;
using bikestore.Entity.Auth;
using bikestore.Service.Interface;

namespace bikestore.Service.Service
{
    public class MenuService : IMenuService
    {
        private readonly AppDbContext _context;
        public MenuService(AppDbContext context)
        {
            _context = context;
        }
        public Menu Create(Menu model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new Exception("MenuName không được để trống");

            model.CreatedDate = DateTime.Now;
            _context.Menus.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool Delete(int id)
        {
            var existMenu = _context.Menus.FirstOrDefault(x => x.Id == id && !x.IsDeleted) ?? throw new Exception("Menu không tồn tại");
            existMenu.IsDeleted = true;
            _context.Menus.Update(existMenu);
            _context.SaveChanges();
            return true;
        }

        public List<Menu> GetAll()
        {
            return _context.Menus.Where(x => !x.IsDeleted).ToList();
        }

        public Menu GetById(int id)
        {
            return _context.Menus.FirstOrDefault(x => x.Id == id && !x.IsDeleted) ?? throw new Exception("Menu không tồn tại");
        }

        public Menu Update(Menu model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new Exception("MenuName không được để trống");

            var existMenu = _context.Menus.FirstOrDefault(x => x.Id == model.Id && !x.IsDeleted) ?? throw new Exception("Menu không tồn tại");
            existMenu.UpdatedDate = DateTime.Now;
            existMenu.Name = model.Name;

            _context.Menus.Update(existMenu);
            _context.SaveChanges();
            return model;
        }
    }
}
