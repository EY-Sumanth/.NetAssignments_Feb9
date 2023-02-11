using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleCRUDWebApi_Feb9.Models;

namespace VehicleCRUDWebApi_Feb9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        public readonly VehicleContext _context;
            public VehicleController(VehicleContext context) { 
        _context= context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDetail>>> GetVehicleDetail()
        {
            return await _context.VehicleDetails.ToListAsync();
        }
    }
}
