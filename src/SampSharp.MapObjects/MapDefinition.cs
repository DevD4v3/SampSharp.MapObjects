namespace SampSharp.MapObjects;

/// <summary>
/// Represents a map that can be loaded and unloaded through
/// <see cref="IMapObjectService"/>.
/// </summary>
public abstract class MapDefinition
{
    private MapContext _mapContext;

    /// <summary>
    /// Gets the unique name of the map.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Called when the map is loaded.
    /// </summary>
    /// <remarks>
    /// Override this method to create the objects that belong to the map.
    /// </remarks>
    protected abstract void OnLoad();

    /// <summary>
    /// Called before the map is unloaded.
    /// </summary>
    /// <remarks>
    /// Override this method to perform custom cleanup before all map objects
    /// are automatically destroyed.
    /// </remarks>
    protected virtual void OnUnload() { }

    internal void Load(MapContext mapContext)
    {
        ArgumentNullException.ThrowIfNull(mapContext);
        _mapContext = mapContext;
        OnLoad();
    }

    internal void Unload()
    {
        try
        {
            OnUnload();
        }
        finally
        {
            _mapContext.DestroyAllObjects();
        }
    }

    /// <summary>
    /// Creates a global object that will be automatically destroyed when the
    /// map is unloaded.
    /// </summary>
    /// <param name="modelId">
    /// The object model identifier.
    /// </param>
    /// <param name="position">
    /// The world position of the object.
    /// </param>
    /// <param name="rotation">
    /// The world rotation of the object.
    /// </param>
    /// <param name="drawDistance">
    /// The maximum distance at which the object will be visible.
    /// </param>
    /// <param name="parent">
    /// The parent object, if any.
    /// </param>
    /// <returns>
    /// The created <see cref="GlobalObject"/>.
    /// </returns>
    protected GlobalObject CreateObject(
        int modelId,
        Vector3 position,
        Vector3 rotation,
        float drawDistance = 300.0f,
        EntityId parent = default)
    {
        return _mapContext.CreateObject(
            modelId,
            position,
            rotation,
            drawDistance,
            parent
        );
    }
}
