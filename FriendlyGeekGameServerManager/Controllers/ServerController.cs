using FriendlyGeekGameServerManager.Models;

namespace FriendlyGeekGameServerManager.Controllers
{
    public static class ServerController
    {
        public static async Task<List<Server>?> GetActiveServers()
        {
            await Task.Delay(3000);

            return await Task.Run(() => new List<Server>());
        }
    }
}
