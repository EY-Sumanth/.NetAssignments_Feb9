using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleApiCrud__Feb9.Models;

namespace VehicleApiCrud__Feb9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VehicleController : ControllerBase
    {
        private readonly VehicleContext _vehicleContext;

        public VehicleController(VehicleContext vehicleContext)
        {
            _vehicleContext = vehicleContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<VehicleDetail>>> getVehicles()
        {
            if (_vehicleContext.VehicleDetails == null)
            {
                return NotFound();
            }
            return Ok( _vehicleContext.VehicleDetails.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDetail>> getVehicles(int VehicleId)
        {
            if (_vehicleContext.VehicleDetails == null)
            {
                return NotFound();
            }
            var vehicledetail = await _vehicleContext.VehicleDetails.FindAsync(VehicleId);
            if (vehicledetail == null)
            {
                return NotFound();

            }
            return vehicledetail;

        }

        [HttpPost]
        public async Task<ActionResult<VehicleDetail>> PostVehicle(VehicleDetail vehicledetail)
        {
            _vehicleContext.VehicleDetails.Add(vehicledetail);
            await _vehicleContext.SaveChangesAsync();

            return CreatedAtAction(nameof(getVehicles), new { VehicleId = vehicledetail.VehicleId }, vehicledetail);
        }

        [HttpPut]
        public async Task<IActionResult> PutVehicle(int id, VehicleDetail vehicledetail)
        {
            if (id != vehicledetail.VehicleId)
            {
                return BadRequest();
            }
            _vehicleContext.Entry(vehicledetail).State = EntityState.Modified;

            try
            {
                await _vehicleContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleModel(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
        private bool VehicleModel(int id)
        {
            return (_vehicleContext.VehicleDetails?.Any(x => x.VehicleId == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleDetail(int id)
        {
            if (_vehicleContext.VehicleDetails == null)
            {
                return BadRequest();
            }

            var vehicledetails = await _vehicleContext.VehicleDetails.FindAsync(id);
            if (vehicledetails == null)
            {
                return NotFound();
            }

            _vehicleContext.VehicleDetails.Remove(vehicledetails);
            await _vehicleContext.SaveChangesAsync();
            return Ok();

        }



    }
}
