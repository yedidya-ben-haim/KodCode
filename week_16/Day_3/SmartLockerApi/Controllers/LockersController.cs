using Microsoft.AspNetCore.Mvc;
using SmartLockerApi.Model;
using SmartLockerApi.Models;
using SmartLockerApi.Repositories;

namespace SmartLockerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LockersController : ControllerBase
{
    private readonly ILockerRepository _repository;

    public LockersController(ILockerRepository repository)
    {
        _repository = repository;
    }

    // GET: api/lockers
    [HttpGet]
    public ActionResult<IEnumerable<Locker>> GetAll()
    {
        var lockers = _repository.GetAll();

        return Ok(lockers);
    }

    // GET: api/lockers/3
    [HttpGet("{id}")]
    public ActionResult<Locker> GetById(int id)
    {
        var locker = _repository.GetById(id);

        if (locker == null)
        {
            return NotFound();
        }

        return Ok(locker);
    }

    // GET: api/lockers/number/102
    [HttpGet("number/{lockerNumber}")]
    public ActionResult<Locker> GetByLockerNumber(int lockerNumber)
    {
        var locker = _repository.GetByLockerNumber(lockerNumber);

        if (locker == null)
        {
            return NotFound();
        }

        return Ok(locker);
    }

    // GET: api/lockers/status/Available
    [HttpGet("status/{status}")]
    public ActionResult<IEnumerable<Locker>> GetByStatus(string status)
    {
        var lockers = _repository.GetByStatus(status);

        return Ok(lockers);
    }

    // POST: api/lockers
    [HttpPost]
    public ActionResult<Locker> Create(Locker locker)
    {
        var created = _repository.Create(locker);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }

    // PUT: api/lockers/3
    [HttpPut("{id}")]
    public IActionResult Update(int id, Locker locker)
    {
        var updated = _repository.Update(id, locker);

        if (updated == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/lockers/3
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var success = _repository.Delete(id);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}