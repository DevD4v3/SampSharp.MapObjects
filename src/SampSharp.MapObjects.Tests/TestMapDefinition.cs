namespace SampSharp.MapObjects.Tests;

public class TestMapDefinition(string name) : MapDefinition
{
    public override string Name { get; } = name;

    public bool WasLoaded { get; private set; }

    public bool WasUnloaded { get; private set; }

    public bool ThrowOnUnload { get; set; }

    protected override void OnLoad()
    {
        WasLoaded = true;
    }

    protected override void OnUnload()
    {
        WasUnloaded = true;

        if (ThrowOnUnload)
            throw new InvalidOperationException("Test exception.");
    }
}
