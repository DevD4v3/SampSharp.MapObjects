namespace SampSharp.MapObjects.Definitions;

internal sealed class Area51 : MapDefinition
{
    public override string Name => "Area51";

    protected override void OnLoad()
    {
        CreateObject(modelId: 19535, position: new Vector3(268.05020f, 1884.39893f, 6.97360f), rotation: new Vector3(0.00000f, 0.00000f, 0.00000f));
        CreateObject(modelId: 19535, position: new Vector3(268.05020f, 1884.39893f, 16.69360f), rotation: new Vector3(0.00000f, 0.00000f, 0.00000f));
        CreateObject(modelId: 975, position: new Vector3(214.37840f, 1875.68408f, 13.81230f), rotation: new Vector3(0.02000f, 0.00000f, 0.00000f));
    }
}
