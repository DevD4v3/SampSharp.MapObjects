namespace SampSharp.MapObjects;

internal abstract class MapDefinition
{
    private bool _isLoaded;
    private MapContext _mapContext;

    public abstract string Name { get; }

    protected abstract void OnLoad();
    protected virtual void OnUnload() { }

    internal void Load(MapContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (_isLoaded)
            throw new InvalidOperationException($"Map '{Name}' is already loaded.");

        _mapContext = context;
        _isLoaded = true;

        OnLoad();
    }

    internal void Unload()
    {
        if (!_isLoaded)
            throw new InvalidOperationException($"Map '{Name}' is not loaded.");

        try
        {
            OnUnload();
        }
        finally
        {
            _mapContext.DestroyAllObjects();
            _mapContext = default;
            _isLoaded = false;
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
