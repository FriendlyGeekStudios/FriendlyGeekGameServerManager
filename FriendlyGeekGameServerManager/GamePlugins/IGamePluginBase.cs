namespace FriendlyGeekGameServerManager.GamePlugins;

public interface IGamePluginBase
{
    string GameName { get; }
    string? SteamAppID { get; }

    int CreateServer();
    int StartServer();
    int StopServer();
}