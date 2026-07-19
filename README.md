# SampSharp.MapObjects

A .NET library for [SampSharp](https://github.com/ikkentim/SampSharp) that implements object maps as regular C# classes instead of Pawn filterscripts.

It is designed for [open.mp](https://github.com/openmultiplayer/open.mp) (Open Multiplayer, a multiplayer mod for GTA San Andreas) game modes where a single map is active at a time, allowing maps to be loaded and unloaded directly from code without relying on RCON commands.

## Why this library exists

This library was originally developed for the [Capture the Flag](https://github.com/DevD4v3/Capture-The-Flag) game mode for open.mp, where maps are loaded and unloaded dynamically throughout the match.

For many years, every map was implemented as an [individual Pawn filterscript](https://github.com/DevD4v3/Capture-The-Flag/blob/006831edeb8736045492eafd08507b324499514b/filterscripts/Aim_Headshot.pwn). The game mode itself was written in C# using [SampSharp](https://github.com/ikkentim/SampSharp), but every time the active map changed it had to ask [open.mp](https://github.com/openmultiplayer/open.mp) to load or unload a filterscript through an RCON command.

The object maps looked like this:

```pawn
#include <open.mp>
#define FILTER_SCRIPT_NAME "Aim_Headshot"
#include "objects"

public OnFilterScriptInit()
{
    new objectId;

    CreateObject(6989, -166.94000, 138.17999, -79.50000, 0.00000, 0.00000, -17.46000);
    CreateObject(6989, -272.32999, 67.31000, -79.50000, 0.00000, 0.00000, 72.72000);
    CreateObject(6989, -320.23999, -86.67000, -79.50000, 0.00000, 0.00000, 72.72000);

    objectId = CreateObject(3885, -152.15030, 52.53920, 2.75850, 0.00000, 0.00000, 146.00000);
    SetObjectMaterial(objectId, 0, 10357, "tvtower_sfs", "ws_transmit_red", 0xFFFFFFFF);

    return 1;
}
```

Whenever the map rotation changed, the C# game mode, built with [SampSharp](https://github.com/ikkentim/SampSharp), still had to communicate with [open.mp](https://github.com/openmultiplayer/open.mp) through RCON commands in order to load or unload Pawn filterscripts:

```csharp
serverService.SendRconCommand($"loadfs {nextMap.Name}");
```

or

```csharp
serverService.SendRconCommand($"unloadfs {currentMap.Name}");
```

This approach is very common in [open.mp](https://github.com/openmultiplayer/open.mp) game modes where only one map is active at a time, and it worked reliably for years.

Eventually, however, it became clear that there was no reason to keep object maps in Pawn. The game mode was already written in C#, yet it still depended on Pawn filterscripts and RCON commands just to create and destroy objects.

## The solution

This library replaces Pawn filterscripts with native C# map definitions.

Instead of compiling and loading filterscripts, maps are implemented as regular C# classes and registered in an [IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection) using the standard Microsoft dependency injection container. They can then be loaded and unloaded directly from code without relying on `loadfs`, `unloadfs`, or `SendRconCommand`.

This provides several advantages:

* Eliminates the dependency on Pawn for object maps.
* Removes the need to communicate with [open.mp](https://github.com/openmultiplayer/open.mp) through RCON commands.
* Keeps map definitions in the same language and ecosystem as the rest of the game mode.
* Makes the same map definitions reusable across multiple [SampSharp](https://github.com/ikkentim/SampSharp) game modes.

Although this library was originally developed for the [Capture the Flag](https://github.com/DevD4v3/Capture-The-Flag) game mode built with SampSharp for open.mp, it can be reused by any SampSharp game mode that loads and unloads maps dynamically, including:

* Gun Game
* Counter-Strike Team Deathmatch
* Capture the Flag
* Any game mode that activates one map at a time

The library is intentionally designed around this use case: a single active map that can be loaded and unloaded on demand.

## Installation

Install the required packages:

```bash
dotnet add package SampSharp.MapObjects.Abstractions
dotnet add package SampSharp.MapObjects
```

## Registering services

Register the object map services during application startup:

```csharp
services.AddMapObjects();
```

This registers the infrastructure required to manage object maps, including the `IMapObjectService` implementation and all built-in map definitions.

The library currently includes 40 built-in map definitions, including:

- Aim_Headshot
- Area51
- de_dust2
- fy_iceworld
- WarZone
- ZM_Italy
- ...and many more.

Custom map definitions can be registered alongside the built-in maps:

```csharp
services
    .AddMapObjects()
    .AddMapDefinition<MyMap>();
```

## Creating a map

If you already have existing Pawn map filterscripts, such as [this one](https://github.com/DevD4v3/Capture-The-Flag/blob/006831edeb8736045492eafd08507b324499514b/filterscripts/Aim_Headshot.pwn), you don't need to rewrite them manually.

[PawnMapTranslator](https://github.com/DevD4v3/SampSharp.MapObjects/tree/master/tools/PawnMapTranslator) can automatically convert supported object creation code into C# `MapDefinition` classes, like the one shown in the example below. The translator currently supports `CreateObject` and `SetObjectMaterial`.

The following class was generated from the [Aim_Headshot](https://github.com/DevD4v3/Capture-The-Flag/blob/006831edeb8736045492eafd08507b324499514b/filterscripts/Aim_Headshot.pwn) Pawn filterscript and can be further customized using regular C# code:

```csharp
public class Aim_Headshot : MapDefinition
{
    public override string Name => "Aim_Headshot";

    protected override void OnLoad()
    {
        CreateObject(modelId: 6989, position: new Vector3(-166.94000f, 138.17999f, -79.50000f), rotation: new Vector3(0.00000f, 0.00000f, -17.46000f));
        CreateObject(modelId: 6989, position: new Vector3(-272.32999f, 67.31000f, -79.50000f), rotation: new Vector3(0.00000f, 0.00000f, 72.72000f));
        CreateObject(modelId: 6989, position: new Vector3(-320.23999f, -86.67000f, -79.50000f), rotation: new Vector3(0.00000f, 0.00000f, 72.72000f));
        CreateObject(modelId: 6989, position: new Vector3(-236.36000f, -150.46001f, -79.50000f), rotation: new Vector3(0.00000f, 0.00000f, 162.78000f));
        CreateObject(modelId: 6989, position: new Vector3(-110.30000f, 21.05000f, -79.50000f), rotation: new Vector3(0.00000f, 0.00000f, 249.66000f));
        CreateObject(modelId: 6989, position: new Vector3(-166.24001f, -130.03999f, -79.52000f), rotation: new Vector3(0.00000f, 0.00000f, 249.66000f));
        CreateObject(modelId: 6388, position: new Vector3(-246.37000f, -69.28000f, -11.84000f), rotation: new Vector3(0.00000f, 0.00000f, -17.70000f));
        CreateObject(modelId: 6388, position: new Vector3(-160.59000f, 67.49000f, -11.84000f), rotation: new Vector3(0.00000f, 0.00000f, 162.00000f));
        CreateObject(modelId: 2934, position: new Vector3(-201.84000f, 75.71000f, 3.24000f), rotation: new Vector3(0.00000f, 0.00000f, 75.66000f));
        CreateObject(modelId: 2934, position: new Vector3(-210.97000f, 78.84000f, 3.25000f), rotation: new Vector3(0.00000f, 0.00000f, 64.56000f));
        CreateObject(modelId: 2934, position: new Vector3(-218.19000f, 81.28000f, 2.73000f), rotation: new Vector3(0.00000f, 0.00000f, 65.58000f));
        CreateObject(modelId: 2934, position: new Vector3(-235.96001f, 83.86000f, 2.49000f), rotation: new Vector3(0.00000f, 0.00000f, 119.22000f));
        CreateObject(modelId: 2934, position: new Vector3(-207.37000f, 75.83000f, 6.14000f), rotation: new Vector3(0.00000f, 0.00000f, 69.24000f));
        CreateObject(modelId: 2932, position: new Vector3(-205.71001f, -77.41000f, 3.43000f), rotation: new Vector3(0.00000f, 0.00000f, -104.76000f));
        CreateObject(modelId: 2932, position: new Vector3(-197.41000f, -80.80000f, 3.44000f), rotation: new Vector3(0.00000f, 0.00000f, -121.14000f));
        CreateObject(modelId: 2932, position: new Vector3(-190.30000f, -84.02000f, 3.44000f), rotation: new Vector3(0.00000f, 0.00000f, -109.02000f));
        CreateObject(modelId: 2932, position: new Vector3(-177.84000f, -84.31000f, 3.44000f), rotation: new Vector3(0.00000f, 0.00000f, -52.02000f));
        CreateObject(modelId: 2932, position: new Vector3(-200.48000f, -77.53000f, 6.33000f), rotation: new Vector3(0.00000f, 0.00000f, -112.50000f));
        CreateObject(modelId: 2934, position: new Vector3(-165.21001f, 90.02000f, 3.50000f), rotation: new Vector3(0.00000f, 0.00000f, 72.24000f));
        CreateObject(modelId: 2932, position: new Vector3(-241.75000f, -91.92000f, 3.40000f), rotation: new Vector3(0.00000f, 0.00000f, 72.18000f));
        CreateObject(modelId: 2935, position: new Vector3(-205.25000f, -1.99000f, 3.49000f), rotation: new Vector3(0.00000f, 0.00000f, 71.70000f));
        CreateObject(modelId: 16061, position: new Vector3(-239.14999f, -119.39000f, 1.88000f), rotation: new Vector3(0.00000f, 0.00000f, 73.32000f));
        CreateObject(modelId: 16061, position: new Vector3(-219.09000f, 106.20000f, -9.92000f), rotation: new Vector3(0.00000f, 0.00000f, 240.24001f));
        CreateObject(modelId: 16061, position: new Vector3(-188.72000f, -101.70000f, -9.92000f), rotation: new Vector3(0.00000f, 0.00000f, 85.74000f));
        CreateObject(modelId: 16061, position: new Vector3(-175.15781f, 113.35090f, 1.95000f), rotation: new Vector3(0.00000f, 0.00000f, 250.56000f));
        CreateObject(modelId: 16061, position: new Vector3(-148.36000f, -10.28000f, 2.59000f), rotation: new Vector3(0.00000f, 0.00000f, 156.84000f));
        CreateObject(modelId: 16061, position: new Vector3(-258.48001f, 27.26000f, 1.40000f), rotation: new Vector3(0.00000f, 0.00000f, 340.01999f));
        GlobalObject object0 = CreateObject(modelId: 3885, position: new Vector3(-152.15030f, 52.53920f, 2.75850f), rotation: new Vector3(0.00000f, 0.00000f, 146.00000f));
        object0.SetMaterial(materialIndex: 0, modelId: 10357, txdName: "tvtower_sfs", textureName: "ws_transmit_red", materialColor: new Color(0xFFFFFFFF));
        GlobalObject object1 = CreateObject(modelId: 3885, position: new Vector3(-247.57410f, -55.88480f, 2.77900f), rotation: new Vector3(0.00000f, 0.00000f, -38.00000f));
        object1.SetMaterial(materialIndex: 0, modelId: 6328, txdName: "sunset04_law2", textureName: "LAbluewall", materialColor: new Color(0xFFFFFFFF));
        CreateObject(modelId: 18257, position: new Vector3(-142.27528f, 54.97489f, 6.50410f), rotation: new Vector3(0.00000f, 0.00000f, -18.00000f));
        CreateObject(modelId: 18257, position: new Vector3(-156.45602f, 59.57191f, 6.50410f), rotation: new Vector3(0.00000f, 0.00000f, -18.00000f));
        CreateObject(modelId: 18257, position: new Vector3(-168.30475f, 63.68726f, 6.50410f), rotation: new Vector3(0.00000f, 0.00000f, -18.00000f));
        CreateObject(modelId: 2991, position: new Vector3(-180.94998f, 68.02634f, 7.09530f), rotation: new Vector3(0.00000f, 0.00000f, -18.00000f));
        CreateObject(modelId: 2991, position: new Vector3(-180.95000f, 68.02630f, 8.27530f), rotation: new Vector3(0.00000f, 0.00000f, -18.00000f));
        CreateObject(modelId: 18257, position: new Vector3(-225.18930f, -72.35310f, 6.50580f), rotation: new Vector3(0.00000f, 0.00000f, -20.00000f));
        CreateObject(modelId: 18257, position: new Vector3(-237.63338f, -68.80544f, 6.50580f), rotation: new Vector3(0.00000f, 0.00000f, -20.00000f));
        CreateObject(modelId: 18257, position: new Vector3(-250.39244f, -64.32850f, 6.50580f), rotation: new Vector3(0.00000f, 0.00000f, -20.00000f));
        CreateObject(modelId: 2991, position: new Vector3(-262.21289f, -58.01108f, 7.07080f), rotation: new Vector3(0.00000f, 0.00000f, -18.00000f));
        CreateObject(modelId: 2991, position: new Vector3(-262.21289f, -58.01110f, 8.25080f), rotation: new Vector3(0.00000f, 0.00000f, -18.00000f));
    }
}

```

## Loading maps

Inject `IMapObjectService` into the service responsible for your game mode's map rotation:

```csharp
public class MapRotationService(IMapObjectService mapObjects)
{
    // ...
}
```

Load a map by its registered name:

```csharp
mapObjects.Load("Aim_Headshot");
```

or, if your game mode already keeps track of the current rotation:

```csharp
mapObjects.Load(nextMap.Name);
```

If the specified map name is not registered, the call is ignored.

## Unloading maps

When the current map is no longer needed, unload it:

```csharp
mapObjects.Unload();
```

All objects created through `CreateObject` are automatically destroyed when the map is unloaded.

## Design constraints

`SampSharp.MapObjects` is designed around game modes where **only one object map can be active at a time**.

Because of this, `IMapObjectService` enforces the following constraints:

- Calling `Load` while another map is already loaded throws an `InvalidOperationException`.
- Calling `Unload` when no map is currently loaded throws an `InvalidOperationException`.
- Calling `Load` with an unregistered map name is ignored.
- All objects created through `CreateObject` are automatically destroyed when the current map is unloaded.

This design matches game modes where maps rotate sequentially, such as Capture the Flag, Gun Game, Counter-Strike Team Deathmatch, or any mode that activates a single map at a time.