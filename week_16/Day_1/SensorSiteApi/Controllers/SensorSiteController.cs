using Microsoft.AspNetCore.Mvc;
using SensorSiteApi.models;

namespace SensorSiteApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorSiteController : ControllerBase
{
    private static readonly List<SensorSite> Sites =
        [
            new SensorSite
            {
                Id = 1,
                SiteName = "Northern Ridge",
                Zone = "North",
                Status = "Active",
                LastContact = DateTime.Now.AddMinutes(-5)
            },
            new SensorSite
            {
                Id = 2,
                SiteName = "Galilee Forest",
                Zone = "North",
                Status = "Silent",
                LastContact = DateTime.Now.AddHours(-3)
            },
            new SensorSite
            {
                Id = 3,
                SiteName = "Coastal Watch",
                Zone = "West",
                Status = "Active",
                LastContact = DateTime.Now.AddMinutes(-12)
            },
            new SensorSite
            {
                Id = 4,
                SiteName = "Desert Point",
                Zone = "South",
                Status = "Maintenance",
                LastContact = DateTime.Now.AddDays(-1)
            },
            new SensorSite
            {
                Id = 5,
                SiteName = "Eastern Valley",
                Zone = "East",
                Status = "Active",
                LastContact = DateTime.Now.AddMinutes(-30)
            },
            new SensorSite
            {
                Id = 6,
                SiteName = "Southern Border",
                Zone = "South",
                Status = "Silent",
                LastContact = DateTime.Now.AddHours(-8)
            },
            new SensorSite
            {
                Id = 7,
                SiteName = "Mountain Station",
                Zone = "North",
                Status = "Maintenance",
                LastContact = DateTime.Now.AddHours(-2)
            },
            new SensorSite
            {
                Id = 8,
                SiteName = "Central Command",
                Zone = "Center",
                Status = "Active",
                LastContact = DateTime.Now.AddMinutes(-1)
            }
        ];


    // GET: api/sensorsite
    [HttpGet]
    public ActionResult GetAllSensor()
    {
        return Ok(Sites);
    }

    // GET: api/SensorSite/{id}
    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        var site = Sites.FirstOrDefault(s => s.Id == id);
        
        if (site == null)
        {
            return NotFound();
        }

        return Ok(site);
    }

    // GET /api/SensorSite/search?zone=North
    [HttpGet("search")]
    public ActionResult<IEnumerable<SensorSite>> SearchByZone(
        [FromQuery]string? zone)
    {
        var query = Sites.Where(s => string.Equals(s.Zone, zone, StringComparison.OrdinalIgnoreCase));

        return Ok(query.ToList());
    }









}
