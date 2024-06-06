using FriendlyGeekGameServerManager.Enums;
using FriendlyGeekGameServerManager.GamePlugins;

namespace NecesseServer;

public class NecesseServerPlugin : IGamePluginBase
{
    public string GameName => "Necesse";

    public string? SteamAppId => "1169040";

    public GameServerActionResult LoadPlugin()
    {
        Console.WriteLine("Loaded Necesse Dedicated Server Plugin!");
        return GameServerActionResult.Success;
    }

    public GameServerActionResult CreateServer()
    {
        throw new NotImplementedException();
    }

    public GameServerActionResult StartServer()
    {
        throw new NotImplementedException();
    }

    public GameServerActionResult ShutdownServer()
    {
        throw new NotImplementedException();
    }

    public GameServerActionResult KillServer()
    {
        throw new NotImplementedException();
    }

    public GameServerActionResult DeleteServer()
    {
        throw new NotImplementedException();
    }

    public GameServerActionResult UpdateServer()
    {
        throw new NotImplementedException();
    }

    public GameServerActionResult BackupServer()
    {
        throw new NotImplementedException();
    }
}