using System.Collections.Generic;
using System.Threading.Tasks;
using HolidayHelper.Models;
using HolidayHelper.Services;
using Microsoft.AspNetCore.Mvc;

namespace HolidayHelper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayService;

        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        [HttpGet("availability/{employeeId}")]
        public async Task<ActionResult<List<VacationRequest>>> GetAvailability(string employeeId)
        {
            var result = await _holidayService.GetAvailability(employeeId);
            return Ok(result);
        }

        [HttpPost("submit")]
        public async Task<ActionResult<bool>> SubmitVacationRequest([FromBody] VacationRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid vacation request.");
            }

            var result = await _holidayService.SubmitVacationRequest(request);
            return Ok(result);
        }
    }
}

namespace HolidayHelper.Core.Services
{
    public interface IHolidayService
    {
        Task<List<VacationRequest>> GetAvailability(string employeeId);
        Task<bool> SubmitVacationRequest(VacationRequest request);
    }
}