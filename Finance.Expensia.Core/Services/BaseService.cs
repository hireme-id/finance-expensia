using AutoMapper;
using Finance.Expensia.DataAccess;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services
{
    public class BaseService<T>(ApplicationDbContext dbContext, IMapper mapper, ILogger<T> logger)
    {
        protected readonly ApplicationDbContext _dbContext = dbContext;
        protected readonly IMapper _mapper = mapper;
        protected readonly ILogger<T> _logger = logger;
    }
}
