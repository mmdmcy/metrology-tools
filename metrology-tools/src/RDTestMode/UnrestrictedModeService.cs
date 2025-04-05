using System;

namespace MetrologyTools.RDTestMode
{
    public class UnrestrictedModeService
    {
        private bool isUnrestrictedModeEnabled;

        public UnrestrictedModeService()
        {
            isUnrestrictedModeEnabled = false;
        }

        public void EnableUnrestrictedMode()
        {
            isUnrestrictedModeEnabled = true;
            // Additional logic for enabling unrestricted mode
        }

        public void DisableUnrestrictedMode()
        {
            isUnrestrictedModeEnabled = false;
            // Additional logic for disabling unrestricted mode
        }

        public bool IsUnrestrictedModeActive()
        {
            return isUnrestrictedModeEnabled;
        }

        // Additional methods for managing access and security can be added here
    }
}