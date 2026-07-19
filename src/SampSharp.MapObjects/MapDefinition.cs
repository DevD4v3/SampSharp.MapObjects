namespace SampSharp.MapObjects;

internal abstract class MapDefinition
{
    private MapContext _mapContext;

    public abstract string Name { get; }

    protected abstract void OnLoad();
    protected virtual void OnUnload() { }

    internal void Load(MapContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        _mapContext = context;
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
            _mapContext = default;
        }
    }

    protected GlobalObject CreateObject(
        int modelId,
        Vector3 position,
        Vector3 rotation,
        float drawDistance = 300.0f,
        EntityId parent = default)
    {
        if (_mapContext is null)
            throw new InvalidOperationException($"Map '{Name}' is not currently loaded.");

        return _mapContext.CreateObject(
            modelId,
            position,
            rotation,
            drawDistance,
            parent
        );
    }
}
