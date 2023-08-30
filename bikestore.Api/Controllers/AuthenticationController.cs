using AutoMapper;
using bikestore.Core.Entity;
using bikestore.Entity;
using bikestore.Entity.Auth;
using bikestore.Model.Model;
using bikestore.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bikestore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AuthenticationController(AppDbContext context, IAccountService accountService, IMapper mapper)
        {
            _context = context;
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Account>> GetAllAccount()
        {
            return await _context.Accounts.Include(x => x.User).ToListAsync();
        }

        [HttpPost]
        public ResponseData Create(AccountModel model)
        {
            try
            {
                Account entity = _mapper.Map<Account>(model);
                var result = _accountService.Create(entity);
                return new ResponseData { Success = true, Data = result };
            }
            catch (Exception ex)
            {
                return new ResponseData { Success = false, Message = ex.Message };
            }
        }

        [HttpPut]
        public ResponseData Update(AccountModel model)
        {
            try
            {
                Account entity = _mapper.Map<Account>(model);
                var result = _accountService.Update(entity);
                return new ResponseData { Success = true, Data = result };
            }
            catch (Exception ex)
            {
                return new ResponseData { Success = false, Message = ex.Message };
            }
        }
    }
}
