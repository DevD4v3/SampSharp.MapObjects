namespace PawnMapTranslator.Tests;

public class PawnTranslatorTests
{
    [Test]
    public void Translate_WhenValidMap_ShouldGenerateExpectedCSharp()
    {
        // Arrange
        const string source =
        """
        #include <open.mp>
        #define FILTER_SCRIPT_NAME "Aim_Headshot"
        #include "objects"

        public OnFilterScriptInit()
        {
            new objectId;

            CreateObject(6989, -166.94000, 138.17999, -79.50000, 0.00000, 0.00000, -17.46000);
            CreateObject(6388, -246.37000, -69.28000, -11.84000, 0.00000, 0.00000, -17.70000);
            CreateObject(2932, -177.84000, -84.31000, 3.44000, 0.00000, 0.00000, -52.02000);

            objectId = CreateObject(3885, -152.15030, 52.53920, 2.75850, 0.00000, 0.00000, 146.00000);
            SetObjectMaterial(objectId, 0, 10357, "tvtower_sfs", "ws_transmit_red", 0xFFFFFFFF);

            objectId = CreateObject(19378, -2268.83500, -1512.10600, 1287.41300, 0.00000, 0.00000, 180.00000);
            SetObjectMaterial(objectId, 0, 4004, "civic07_lan", "badmarb1_LAn", -3149830);

            objectId = CreateObject(19378, -2268.83500, -1521.72600, 1287.41300, 0.00000, 0.00000, 180.00000);
            SetObjectMaterial(objectId, 0, 4004, "civic07_lan", "badmarb1_LAn", 0xFF336699);

            CreateObject(18257, -142.27528, 54.97489, 6.50410, 0.00000, 0.00000, -18.00000);
            CreateObject(2991, -180.94998, 68.02634, 7.09530, 0.00000, 0.00000, -18.00000);

            return 1;
        }
        """;

        const string expected =
        """
        namespace SampSharp.MapObjects.Definitions;

        internal sealed class Aim_Headshot : MapDefinition
        {
            public override string Name => "Aim_Headshot";

            protected override void OnLoad()
            {
                CreateObject(modelId: 6989, position: new Vector3(-166.94000f, 138.17999f, -79.50000f), rotation: new Vector3(0.00000f, 0.00000f, -17.46000f));
                CreateObject(modelId: 6388, position: new Vector3(-246.37000f, -69.28000f, -11.84000f), rotation: new Vector3(0.00000f, 0.00000f, -17.70000f));
                CreateObject(modelId: 2932, position: new Vector3(-177.84000f, -84.31000f, 3.44000f), rotation: new Vector3(0.00000f, 0.00000f, -52.02000f));
                GlobalObject object0 = CreateObject(modelId: 3885, position: new Vector3(-152.15030f, 52.53920f, 2.75850f), rotation: new Vector3(0.00000f, 0.00000f, 146.00000f));
                object0.SetMaterial(materialIndex: 0, modelId: 10357, txdName: "tvtower_sfs", textureName: "ws_transmit_red", materialColor: new Color(0xFFFFFFFF));
                GlobalObject object1 = CreateObject(modelId: 19378, position: new Vector3(-2268.83500f, -1512.10600f, 1287.41300f), rotation: new Vector3(0.00000f, 0.00000f, 180.00000f));
                object1.SetMaterial(materialIndex: 0, modelId: 4004, txdName: "civic07_lan", textureName: "badmarb1_LAn", materialColor: new Color(-3149830));
                GlobalObject object2 = CreateObject(modelId: 19378, position: new Vector3(-2268.83500f, -1521.72600f, 1287.41300f), rotation: new Vector3(0.00000f, 0.00000f, 180.00000f));
                object2.SetMaterial(materialIndex: 0, modelId: 4004, txdName: "civic07_lan", textureName: "badmarb1_LAn", materialColor: new Color(0xFF336699));
                CreateObject(modelId: 18257, position: new Vector3(-142.27528f, 54.97489f, 6.50410f), rotation: new Vector3(0.00000f, 0.00000f, -18.00000f));
                CreateObject(modelId: 2991, position: new Vector3(-180.94998f, 68.02634f, 7.09530f), rotation: new Vector3(0.00000f, 0.00000f, -18.00000f));
            }
        }

        """;

        // Act
        string actual = PawnTranslator.Translate(mapName: "Aim_Headshot", source);

        // Assert
        actual.Should().Be(expected);
    }
}
