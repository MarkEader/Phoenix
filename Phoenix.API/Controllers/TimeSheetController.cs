using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Models;

namespace Phoenix.API.Controllers
{
    [Route("api/[controller]")]
    public class TimeSheetController : Controller
    {
        private readonly PhoenixDbContext _context;
        private readonly IMapper _mapper;

        public TimeSheetController(PhoenixDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}