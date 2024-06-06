using FriendlyGeekGameServerManager.Enums;

namespace FriendlyGeekGameServerManager.GamePlugins;

public interface IGamePluginBase
{
    string GameName { get; }
    string? SteamAppId { get; }


    GameServerActionResult LoadPlugin();

    GameServerActionResult CreateServer();
    GameServerActionResult StartServer();

    /// <summary>
    /// Gracefully shut down the server
    /// </summary>
    /// <returns></returns>
    GameServerActionResult ShutdownServer();

    /// <summary>
    /// Forcefully Kill the server
    /// </summary>
    /// <returns></returns>
    GameServerActionResult KillServer();

    GameServerActionResult DeleteServer();
    GameServerActionResult UpdateServer();
    GameServerActionResult BackupServer();
}