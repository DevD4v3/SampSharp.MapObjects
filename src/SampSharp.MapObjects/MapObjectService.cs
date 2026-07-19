namespace SampSharp.MapObjects;

internal sealed class MapObjectService(
    IServiceProvider serviceProvider,
    Dictionary<string, MapDefinition> maps) : IMapObjectService
{
    private MapDefinition _loadedMap;

    public void Load(string mapName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(mapName);

        if (!maps.TryGetValue(mapName, out MapDefinition map))
            return;

        if (_loadedMap is not null)
            throw new InvalidOperationException($"Map '{_loadedMap.Name}' is already loaded.");

        MapContext context = serviceProvider.GetRequiredService<MapContext>();
        _loadedMap = map;
        map.Load(context);
    }

    public void Unload()
    {
        if (_loadedMap is null)
            throw new InvalidOperationException("No map is currently loaded.");

        try
        {
            _loadedMap.Unload();
        }
        finally 
        { 
            _loadedMap = default; 
        }
    }
}
