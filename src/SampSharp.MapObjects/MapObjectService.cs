namespace SampSharp.MapObjects;

internal sealed class MapObjectService(
    IServiceProvider serviceProvider,
    Dictionary<string, MapDefinition> maps) : IMapObjectService
{
    public void Load(string mapName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(mapName);

        if (!maps.TryGetValue(mapName, out MapDefinition map))
            throw new InvalidOperationException($"Map '{mapName}' is not registered.");

        MapContext context = serviceProvider.GetRequiredService<MapContext>();
        map.Load(context);
    }

    public void Unload(string mapName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(mapName);

        if (!maps.TryGetValue(mapName, out MapDefinition map))
            throw new InvalidOperationException($"Map '{mapName}' is not registered.");

        map.Unload();
    }
}
