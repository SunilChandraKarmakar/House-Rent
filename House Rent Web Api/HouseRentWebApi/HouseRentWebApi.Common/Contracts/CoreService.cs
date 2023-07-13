using AutoMapper;

namespace HouseRentWebApi.Common.Contracts
{
    public class CoreService : ICoreService
    {
        private readonly ICoreDbContext _context;
        private readonly IMapper _mapper;

        public CoreService(ICoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICoreDbContext Context => _context;

        public IMapper Mapper => _mapper;
    }
}