namespace SampSharp.MapObjects;

internal class MapContext(
    IWorldService worldService,
    IOmpEntityProvider ompEntityProvider,
    ILogger<MapContext> logger)
{
    private int _initialObjectId;
    private int _objectCount;

    /// <summary>
    /// Creates a global object and tracks its identifier so it can be
    /// automatically destroyed when the map is unloaded.
    /// </summary>
    public virtual GlobalObject CreateObject(
        int modelId,
        Vector3 position,
        Vector3 rotation,
        float drawDistance = 300.0f,
        EntityId parent = default)
    {
        GlobalObject globalObject = worldService.CreateObject(
            modelId,
            position,
            rotation,
            drawDistance,
            parent
        );

        if (_objectCount == 0)
            _initialObjectId = globalObject.Id;

        _objectCount++;

        return globalObject;
    }

    /// <summary>
    /// Destroys every object created through this context.
    /// </summary>
    public virtual void DestroyAllObjects()
    {
        if (_objectCount == 0)
            return;

        int endExclusive = _initialObjectId + _objectCount;

        for (int objectId = _initialObjectId; objectId < endExclusive; objectId++)
        {
            GlobalObject globalObject = ompEntityProvider.GetObject(objectId);

            if (globalObject is null)
            {
                logger.LogError(
                    "Map object with ID '{ObjectId}' could not be found during unload.",
                    objectId);

                continue;
            }

            globalObject.Destroy();
        }

        _initialObjectId = 0;
        _objectCount = 0;
    }
}
