using System;

namespace HolidayHelper.Models
{
    public class VacationRequest
    {
        public string EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double FTEPercentage { get; set; }
    }
}