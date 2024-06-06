using System.Net;
using System.Reflection;
using FriendlyGeekGameServerManager.Contexts;
using FriendlyGeekGameServerManager.Interfaces;
using GamePlugin;

namespace FriendlyGeekGameServerManager.Data;

public class PluginManager : IPluginManager
{
    private string? _pluginDirectory = null;

    private IEnumerable<IGamePluginBase> _plugins = null!;

    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public PluginManager(IConfiguration configuration, ILogger<PluginManager> logger)
    {
        _configuration = configuration;
        _logger = logger;

        UpdatePluginDirectories();

        LoadPlugins();
    }

    public IEnumerable<GameInformation> GetAvailablePluginInformation()
    {
        return _plugins.Select(plugin => plugin.GetGameInformation()).ToList();
    }

    public void LoadPlugins()
    {
        // TODO: Unload currently loaded plugins or come up with a way to prevent loading the same plugin twice
        if (_pluginDirectory == null)
        {
            _logger.LogWarning("Plugin Directory is invalid. Cannot load plugins");
            return;
        }

        _logger.LogInformation($"Attempting to load plugins from directory: {_pluginDirectory}");

        // Will search Recursively through the plugins folder
        string[] pluginLibraries = Directory.GetFiles(_pluginDirectory, "*.dll", SearchOption.AllDirectories);

        _logger.LogInformation($"Found {pluginLibraries.Length} Potential Shared Libraries");

        _plugins = pluginLibraries.SelectMany(pluginPath =>
        {
            if (string.IsNullOrEmpty(pluginPath)) return null!;
            var pluginAssembly = LoadPlugin(pluginPath);
            return CreateGamePlugins(pluginAssembly);
        }).ToList();

        foreach (var plugin in _plugins)
        {
            plugin.LoadPlugin();
        }
    }

    private Assembly LoadPlugin(string pluginPath)
    {
        string root = Path.GetFullPath(pluginPath);
        var pluginLocation = root.Replace('\\', Path.DirectorySeparatorChar);

        PluginLoadContext loadContext = new PluginLoadContext(pluginLocation);
        return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
    }

    private IEnumerable<IGamePluginBase> CreateGamePlugins(Assembly pluginAssembly)
    {
        int gameCount = 0;

        foreach (Type type in pluginAssembly.GetTypes())
        {
            if (!typeof(IGamePluginBase).IsAssignableFrom(type)) continue;
            if (Activator.CreateInstance(type) is not IGamePluginBase plugin) continue;
            gameCount++;
            yield return plugin;
        }

        Console.WriteLine($"Loaded {gameCount} game plugin(s)");
    }

    private void UpdatePluginDirectories()
    {
        var pluginConfigSection = _configuration["plugin_directory"];
        _pluginDirectory = pluginConfigSection ?? "";
    }
}