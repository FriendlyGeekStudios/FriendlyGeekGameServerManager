using GamePlugin;

namespace FriendlyGeekGameServerManager.Interfaces;

public interface IPluginManager
{
    public void LoadPlugins();

    public IEnumerable<GameInformation> GetAvailablePluginInformation();
}