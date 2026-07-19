namespace SampSharp.MapObjects.Abstractions;

/// <summary>
/// Represents a service for loading and unloading object maps in the game world.
/// </summary>
public interface IMapObjectService
{
    /// <summary>
    /// Loads the specified map into the game world.
    /// </summary>
    /// <remarks>
    /// If the specified map is not found, this method does nothing.
    /// Only one map can be loaded at a time.
    /// </remarks>
    /// <param name="mapName">
    /// The unique name of the map to load.
    /// </param>
    /// <exception cref="ArgumentException">
    /// <paramref name="mapName"/> is <see langword="null"/>, empty, or consists only of white-space characters.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Another map is already loaded.
    /// </exception>
    void Load(string mapName);

    /// <summary>
    /// Unloads the currently loaded map and destroys all objects created for it.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// No map is currently loaded.
    /// </exception>
    void Unload();
}
