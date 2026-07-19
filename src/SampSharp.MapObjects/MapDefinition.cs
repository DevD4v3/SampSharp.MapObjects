namespace SampSharp.MapObjects;

internal abstract class MapDefinition
{
    private MapContext _mapContext;

    public abstract string Name { get; }

    protected abstract void OnLoad();
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
