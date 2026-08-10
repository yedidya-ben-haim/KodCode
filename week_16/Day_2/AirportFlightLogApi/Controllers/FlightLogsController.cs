using AirportFlightLogApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirportFlightLogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightLogsController : ControllerBase
    {
        private static readonly List<FlightLog> _flightLogs = new()
        {
            new FlightLog
            {
                Id = 1,
                FlightNumber = "AA101",
                Airline = "American Airlines",
                Destination = "New York JFK",
                PassengerCount = 180,
                ScheduledDeparture = DateTime.UtcNow.AddHours(2),
                Status = "Scheduled"
            },

            new FlightLog
            {
                Id = 2,
                FlightNumber = "BA202",
                Airline = "British Airways",
                Destination = "London Heathrow",
                PassengerCount = 250,
                ScheduledDeparture = DateTime.UtcNow.AddHours(4),
                ActualDeparture = DateTime.UtcNow.AddHours(4).AddMinutes(15),
                Status = "Departed",
                Remarks = "Delayed due to weather"
            },

            new FlightLog
            {
                Id = 3,
                FlightNumber = "LH303",
                Airline = "Lufthansa",
                Destination = "Frankfurt",
                PassengerCount = 200,
                ScheduledDeparture = DateTime.UtcNow.AddHours(6),
                Status = "Scheduled"
            }
        };

        private static int _nextId = 4;

        // GET: api/flightlogs
        [HttpGet]
        public ActionResult<IEnumerable<FlightLog>> GetAllFlightLogs()
        {
            return Ok(_flightLogs);
        }

        // GET: api/flightlogs/2
        [HttpGet("{id}")]
        public ActionResult<FlightLog> GetFlightLogById(int id)
        {
            var log = _flightLogs.FirstOrDefault(f => f.Id == id);
            
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }

        // POST: api/flightlogs
        [HttpPost]
        public ActionResult<FlightLog> CreateFlightLog(FlightLog flightLog)
        {
            _nextId++;

            flightLog.Id = _nextId;

            _flightLogs.Add(flightLog);

            return CreatedAtAction(nameof(GetFlightLogById),
                                    new { id = flightLog.Id }, flightLog);
        }

        // PUT: api/flightlogs/2
        [HttpPut("{id}")]
        public IActionResult UpdateFlightLog(int id, FlightLog updatedLog)
        {
            var existingLog = _flightLogs.FirstOrDefault(f => f.Id == id);


            if (existingLog == null)
            {
                return NotFound();
            }

            existingLog.FlightNumber = updatedLog.FlightNumber;
            existingLog.Airline = updatedLog.Airline;
            existingLog.Destination = updatedLog.Destination;
            existingLog.PassengerCount = updatedLog.PassengerCount;
            existingLog.ScheduledDeparture = updatedLog.ScheduledDeparture;
            existingLog.ActualDeparture = updatedLog.ActualDeparture;
            existingLog.Remarks = updatedLog.Remarks;
            existingLog.Status = updatedLog.Status;

            var a = string.Equals\
            return NoContent();

        }

        // GET: api/flightlogs/search?airline=American
        




    }
}

