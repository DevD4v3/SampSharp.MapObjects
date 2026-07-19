namespace SampSharp.MapObjects.Abstractions;

/// <summary>
/// Represents a service for loading and unloading object maps in the game world.
/// </summary>
public interface IMapObjectService
{
    /// <summary>
    /// Loads the specified map into the game world.
    /// </summary>
    /// <param name="mapName">
    /// The unique name of the map to load.
    /// </param>
    /// <exception cref="ArgumentException">
    /// <paramref name="mapName"/> is <see langword="null"/>, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// The specified map is not registered, or the map has already been loaded.
    /// </exception>
    void Load(string mapName);

    /// <summary>
    /// Unloads the specified map and destroys all objects created for it.
    /// </summary>
    /// <param name="mapName">
    /// The unique name of the map to unload.
    /// </param>
    /// <exception cref="ArgumentException">
    /// <paramref name="mapName"/> is <see langword="null"/>, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// The specified map is not registered, or the map is not currently loaded.
    /// </exception>
    void Unload(string mapName);
}
