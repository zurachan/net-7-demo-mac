using Microsoft.Extensions.Configuration;

namespace bikestore.Core
{
    public interface ICommonService
    {
        string GetConnectionString();
    }
    public class CommonService : ICommonService
    {
        private readonly IConfiguration _configuration;

        public CommonService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}

