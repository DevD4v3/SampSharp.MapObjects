namespace SampSharp.MapObjects.Tests;

internal class FakeMapContext(
    IWorldService worldService, 
    IOmpEntityProvider ompEntityProvider, 
    ILogger<MapContext> logger) : MapContext(worldService, ompEntityProvider, logger)
{
    public bool WereObjectsDestroyed { get; private set; }

    public override GlobalObject CreateObject(
        int modelId, 
        Vector3 position, 
        Vector3 rotation, 
        float drawDistance = 300, 
        EntityId parent = default)
    {
        return Substitute.For<GlobalObject>();
    }

    public override void DestroyAllObjects()
    {
        WereObjectsDestroyed = true;
    }
}
