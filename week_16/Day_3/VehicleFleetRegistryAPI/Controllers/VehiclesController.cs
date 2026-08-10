using Microsoft.AspNetCore.Mvc;
using VehicleFleetRegistryAPI.Models;
using VehicleFleetRegistryAPI.Repository;

namespace VehicleFleetRegistryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _repository;

        public VehiclesController(IVehicleRepository repository)
        {
            _repository = repository;
        }


        // GET: api/Vehicles
        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> GetAll()
        {
            var vehicles = _repository.GetAll();
            return Ok(vehicles);
        }

        // GET: api/Vehicles/{id}
        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetById(int id)
        {
            var log = _repository.GetById(id);
            
            if (log == null)
            {
                return NotFound();
            }

            return Ok(log);
        }



    }
}
