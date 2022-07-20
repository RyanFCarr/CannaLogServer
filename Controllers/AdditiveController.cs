using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdditiveController : ControllerBase
    {
        private readonly ILogger<AdditiveController> _logger;
        private readonly IAdditiveService _additiveService;
        private readonly IMapper _mapper;

        public AdditiveController(ILogger<AdditiveController> logger, IAdditiveService additiveService, IMapper mapper)
        {
            _logger = logger;
            _additiveService = additiveService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_additiveService.GetAll().Select(a => _mapper.Map<AdditiveDto>(a)));
    }
}
