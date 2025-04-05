using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HolidayHelper.Controllers;
using HolidayHelper.Models;

namespace HolidayHelperTests
{
    [TestClass]
    public class HolidayControllerTests
    {
        private HolidayController _controller;
        private Mock<IHolidayService> _mockService;

        [TestInitialize]
        public void Setup()
        {
            _mockService = new Mock<IHolidayService>();
            _controller = new HolidayController(_mockService.Object);
        }

        [TestMethod]
        public async Task GetAvailability_ReturnsAvailability()
        {
            // Arrange
            var employeeId = "123";
            var expectedAvailability = new List<VacationRequest>();
            _mockService.Setup(s => s.GetAvailability(employeeId)).ReturnsAsync(expectedAvailability);

            // Act
            var result = await _controller.GetAvailability(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedAvailability, result);
        }

        [TestMethod]
        public async Task SubmitVacationRequest_ReturnsSuccess()
        {
            // Arrange
            var vacationRequest = new VacationRequest
            {
                EmployeeId = "123",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
                FTEPercentage = 1.0
            };
            _mockService.Setup(s => s.SubmitVacationRequest(vacationRequest)).ReturnsAsync(true);

            // Act
            var result = await _controller.SubmitVacationRequest(vacationRequest);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task SubmitVacationRequest_ReturnsFailure()
        {
            // Arrange
            var vacationRequest = new VacationRequest
            {
                EmployeeId = "123",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
                FTEPercentage = 1.0
            };
            _mockService.Setup(s => s.SubmitVacationRequest(vacationRequest)).ReturnsAsync(false);

            // Act
            var result = await _controller.SubmitVacationRequest(vacationRequest);

            // Assert
            Assert.IsFalse(result);
        }
    }
}