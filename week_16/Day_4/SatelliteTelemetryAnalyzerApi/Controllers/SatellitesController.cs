using Microsoft.AspNetCore.Mvc;
using SatelliteTelemetryAnalyzerApi.Models;
using SatelliteTelemetryAnalyzerApi.Repositories;
using SatelliteTelemetryAnalyzerApi.Services;

namespace SatelliteTelemetryAnalyzerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SatellitesController : ControllerBase
    {
        private readonly ISatelliteRepository _satelliteRepository;
        

        public SatellitesController(ISatelliteRepository satelliteRepository)
        {
            _satelliteRepository = satelliteRepository;
        }

        // GET /api/satellites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Satellite>>> GetAllSatellite()
        {
            var satellites = await _satelliteRepository.GetAllAsync();

            return Ok(satellites);
        }

        // GET /api/satellites/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Satellite>> GetById(int id)
        {
            var satellite = await _satelliteRepository.GetByIdAsync(id);

            if (satellite == null)
            {
                return NotFound();
            }

            return Ok(satellite);
        }

        // POST /api/satellites
        [HttpPost]
        public async Task<ActionResult<Satellite>> CreateSatellite(Satellite satellite)
        {
            var createdSatellite = await _satelliteRepository.CreateAsync(satellite);

            return CreatedAtAction(nameof(GetById), new {id = createdSatellite.Id}, satellite);
        }

        // PUT /api/satellites/{id}
        [HttpPut]
        public async Task<IActionResult> UpdateSatellite(int id ,Satellite satellite)
        {
            var updateSatellite = await _satelliteRepository.UpdateAsync(id, satellite);

            if (updateSatellite == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE /api/satellites/{id}
        [HttpDelete]
        public async Task<IActionResult> DeleteSatellite(int id)
        {
            var deletedSatellite = await _satelliteRepository.DeleteAsync(id);

            if (deletedSatellite == false)
            {
                return NotFound();
            }

            return NoContent();
        }






    }
}
