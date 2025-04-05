using System;

namespace MetrologyTools.RDTestMode
{
    public class TestController
    {
        private readonly UnrestrictedModeService _unrestrictedModeService;

        public TestController(UnrestrictedModeService unrestrictedModeService)
        {
            _unrestrictedModeService = unrestrictedModeService;
        }

        public void EnableTestMode()
        {
            _unrestrictedModeService.Enable();
            Console.WriteLine("Unrestricted test mode enabled.");
        }

        public void DisableTestMode()
        {
            _unrestrictedModeService.Disable();
            Console.WriteLine("Unrestricted test mode disabled.");
        }

        public bool IsTestModeEnabled()
        {
            return _unrestrictedModeService.IsEnabled();
        }
    }
}