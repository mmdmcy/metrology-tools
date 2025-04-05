using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolidayHelper.Services
{
    public interface IHolidayService
    {
        Task<List<VacationRequest>> GetAvailability(string employeeId);
        Task<bool> SubmitVacationRequest(VacationRequest request);
    }

    public class HolidayService : IHolidayService
    {
        private readonly List<VacationRequest> _vacationRequests = new();

        public Task<List<VacationRequest>> GetAvailability(string employeeId)
        {
            var result = _vacationRequests.FindAll(r => r.EmployeeId == employeeId);
            return Task.FromResult(result);
        }

        public Task<bool> SubmitVacationRequest(VacationRequest request)
        {
            _vacationRequests.Add(request);
            return Task.FromResult(true);
        }
    }
}

public class VacationRequest
{
    public string EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double FTEPercentage { get; set; }
    public string CompetencyArea { get; set; }
}