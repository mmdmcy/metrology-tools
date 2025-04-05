using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RDTestMode;

namespace RDTestModeTests
{
    [TestClass]
    public class UnrestrictedModeTests
    {
        private UnrestrictedModeService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new UnrestrictedModeService();
        }

        [TestMethod]
        public void TestEnableUnrestrictedMode()
        {
            // Arrange
            bool expected = true;

            // Act
            bool result = _service.EnableUnrestrictedMode();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestDisableUnrestrictedMode()
        {
            // Arrange
            _service.EnableUnrestrictedMode();
            bool expected = false;

            // Act
            bool result = _service.DisableUnrestrictedMode();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAccessControlWhenEnabled()
        {
            // Arrange
            _service.EnableUnrestrictedMode();
            bool expected = true;

            // Act
            bool result = _service.HasAccess();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAccessControlWhenDisabled()
        {
            // Arrange
            _service.DisableUnrestrictedMode();
            bool expected = false;

            // Act
            bool result = _service.HasAccess();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}