using DutyLogAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DutyLogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DutyLogController : ControllerBase
    {
        private static readonly List<DutyLog> _dutyLogs = new()
        {
            new DutyLog
            {
                Id = 1,
                DutyPersonName = "yedidya",
                StationName = "alpha",
                ShiftStart = DateTime.Now,
                ShiftEnd = DateTime.Now.AddHours(1),
                StationNumber = 1
            }
        };

        private static int _nextlogId = 2;

        // GET api/dutyLogs
        [HttpGet]
        public ActionResult<IEnumerable<DutyLog>> GetAllDutyLog()
        {
            return Ok(_dutyLogs);
        }


        // GET api/dutyLogs/{id}
        [HttpGet("{id}")]
        public ActionResult<DutyLog> GetById(int id)
        {
            var log = _dutyLogs.FirstOrDefault(l => l.Id == id);

            if (log == null)
            {
                return NotFound();
            }

            return Ok(log);
        }


        // POST api/dutyLogs
        [HttpPost]
        public ActionResult<DutyLog> PostNewDutyLog(DutyLog dutyLog)
        {
            if (dutyLog.ShiftEnd <= dutyLog.ShiftStart)
            {
                return BadRequest("ShiftEnd must be later than ShiftStart.");
            }

            dutyLog.Id = _nextlogId;

            _nextlogId++;

            _dutyLogs.Add(dutyLog);

            return CreatedAtAction(nameof(GetById), new { id = dutyLog.Id }, dutyLog);
        }


        // PUT api/dutyLogs/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id,DutyLog updateDutyLog)
        {
            var log = _dutyLogs.FirstOrDefault(l => l.Id == id);

            if (log == null)
            {
                return NotFound();
            }

            if (updateDutyLog.ShiftEnd <= updateDutyLog.ShiftStart)
            {
                return BadRequest("ShiftEnd must be later than ShiftStart.");
            }

            log.DutyPersonName = updateDutyLog.DutyPersonName;
            log.StationNumber = updateDutyLog.StationNumber;
            log.StationName = updateDutyLog.StationName;
            log.ShiftStart = updateDutyLog.ShiftStart;
            log.ShiftEnd = updateDutyLog.ShiftEnd;
            log.Remarks = updateDutyLog.Remarks;

            return NoContent();
        }


        // DELETE api/dutyLogs/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var log = _dutyLogs.FirstOrDefault(l => l.Id == id);

            if (log == null)
            {
                return NotFound();
            }

            _dutyLogs.Remove(log);

            return NoContent();

        }






    }




}
