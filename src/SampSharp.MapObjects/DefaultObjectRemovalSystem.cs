namespace SampSharp.MapObjects;

internal sealed class DefaultObjectRemovalSystem : ISystem
{
    [Event]
    public void OnPlayerConnect(Player player)
    {
        // Remove objects from Area51 map.
        player.RemoveDefaultObjects(modelId: 16664, position: new Vector3(268.6641f, 1885.4297f, 7.8828f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 3399, position: new Vector3(268.7031f, 1889.5234f, 4.8438f), radius: 0.25f);

        // Remove objects from CrackFactory map.
        player.RemoveDefaultObjects(modelId: 1440, position: new Vector3(2538.2969f, -1299.1875f, 1030.9453f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1441, position: new Vector3(2544.0000f, -1300.6875f, 1031.0859f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1464, position: new Vector3(2545.3281f, -1300.6797f, 1031.5781f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2681, position: new Vector3(2548.9375f, -1298.2734f, 1059.9844f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 937, position: new Vector3(2551.3438f, -1297.7422f, 1060.5313f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 937, position: new Vector3(2552.9844f, -1298.0469f, 1060.5313f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2681, position: new Vector3(2548.9375f, -1297.4531f, 1059.9844f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1421, position: new Vector3(2553.0313f, -1297.4141f, 1031.1875f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1431, position: new Vector3(2552.1875f, -1297.2500f, 1030.9766f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1421, position: new Vector3(2539.3516f, -1296.3828f, 1031.1875f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1431, position: new Vector3(2551.5000f, -1296.4922f, 1030.9766f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 937, position: new Vector3(2552.9844f, -1296.8047f, 1060.5313f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1421, position: new Vector3(2539.3516f, -1294.6094f, 1031.1875f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1431, position: new Vector3(2537.8203f, -1295.5000f, 1030.9766f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1431, position: new Vector3(2538.5078f, -1295.2422f, 1030.9766f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1421, position: new Vector3(2553.0313f, -1295.6406f, 1031.1875f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 923, position: new Vector3(2553.3984f, -1295.2578f, 1061.1719f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 14449, position: new Vector3(2567.6172f, -1294.6328f, 1061.2500f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 944, position: new Vector3(2533.1172f, -1293.2578f, 1030.7891f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 944, position: new Vector3(2533.1172f, -1290.2500f, 1031.3047f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1431, position: new Vector3(2544.7422f, -1291.9688f, 1030.9766f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1431, position: new Vector3(2545.4297f, -1292.3750f, 1030.9766f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1421, position: new Vector3(2546.2734f, -1292.4766f, 1031.1875f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1421, position: new Vector3(2546.2734f, -1290.7031f, 1031.1875f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2681, position: new Vector3(2546.7031f, -1289.9063f, 1060.0000f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 923, position: new Vector3(2553.3984f, -1293.2969f, 1061.1719f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1450, position: new Vector3(2538.1172f, -1287.5313f, 1031.0156f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2606, position: new Vector3(2546.1563f, -1286.0469f, 1062.1953f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2606, position: new Vector3(2546.1563f, -1286.0469f, 1061.7266f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2606, position: new Vector3(2546.1563f, -1286.0469f, 1061.2656f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2606, position: new Vector3(2546.1563f, -1286.0469f, 1060.8047f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1829, position: new Vector3(2546.7813f, -1280.6719f, 1060.4609f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1788, position: new Vector3(2546.3359f, -1282.8984f, 1060.2266f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1788, position: new Vector3(2546.3359f, -1282.8984f, 1060.0625f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1703, position: new Vector3(2550.1406f, -1286.6016f, 1059.9766f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2028, position: new Vector3(2549.0938f, -1283.2188f, 1060.1094f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2104, position: new Vector3(2549.4375f, -1279.8438f, 1060.0156f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2229, position: new Vector3(2548.0156f, -1279.8750f, 1060.0156f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2229, position: new Vector3(2551.0156f, -1280.1250f, 1060.0156f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1703, position: new Vector3(2551.2813f, -1283.6875f, 1059.9766f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1704, position: new Vector3(2551.5000f, -1280.3984f, 1059.9766f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 14446, position: new Vector3(2573.1641f, -1281.7031f, 1064.9609f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1775, position: new Vector3(2576.7031f, -1284.4297f, 1061.0938f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2525, position: new Vector3(2579.5391f, -1286.6484f, 1064.3750f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2527, position: new Vector3(2581.1172f, -1283.1563f, 1064.3672f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2524, position: new Vector3(2582.9922f, -1284.1172f, 1064.3750f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 2526, position: new Vector3(2581.7656f, -1286.6797f, 1064.3594f), radius: 0.25f);

        // Remove objects from RC Battlefield map.
        player.RemoveDefaultObjects(modelId: 3940, position: new Vector3(-974.4453f, 1041.5391f, 1347.1484f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 3941, position: new Vector3(-1132.1094f, 1077.7422f, 1347.9063f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1596, position: new Vector3(-1132.6953f, 1073.9922f, 1354.7500f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 1596, position: new Vector3(-973.5625f, 1046.0703f, 1353.9688f), radius: 0.25f);

        // Remove objects from WarZone map.
        player.RemoveDefaultObjects(modelId: 11447, position: new Vector3(-1309.6016f, 2492.4766f, 86.0078f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 11440, position: new Vector3(-1321.2109f, 2503.3438f, 85.4609f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 11441, position: new Vector3(-1310.7734f, 2514.0078f, 86.1641f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 11445, position: new Vector3(-1289.3672f, 2513.6094f, 86.6172f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 11444, position: new Vector3(-1325.6719f, 2527.7031f, 86.1250f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 11446, position: new Vector3(-1334.3828f, 2524.6016f, 86.1641f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 11442, position: new Vector3(-1314.8359f, 2526.4688f, 86.3984f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 11458, position: new Vector3(-1316.8516f, 2542.6719f, 86.8281f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 11443, position: new Vector3(-1301.7188f, 2527.4922f, 86.6172f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 11459, position: new Vector3(-1292.7969f, 2529.0000f, 86.5313f), radius: 0.25f);
        player.RemoveDefaultObjects(modelId: 11457, position: new Vector3(-1303.7734f, 2550.2344f, 86.2266f), radius: 0.25f);
    }
}
