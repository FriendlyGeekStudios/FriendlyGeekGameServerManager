using FriendlyGeekGameServerManager.Interfaces;

namespace FriendlyGeekGameServerManager.Data
{
    public class Settings : ISettings
    {
        public bool IsDarkMode { get; set; } = true;
    }
}
