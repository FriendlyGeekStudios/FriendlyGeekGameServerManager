using FriendlyGeekGameServerManager.Enums;

namespace GamePlugin;

public interface IGamePluginBase
{
    string GameName { get; }
    string? SteamAppId { get; }
    string IconURL { get; }

    GameServerActionResult LoadPlugin();

    public GameInformation GetGameInformation();

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