namespace SampSharp.MapObjects.Tests;

public class MapObjectServiceTests
{
    private FakeMapContext _fakeMapContext;
    private Dictionary<string, MapDefinition> _maps;

    [SetUp]
    public void Init()
    {
        _fakeMapContext = new FakeMapContext(
            Substitute.For<IWorldService>(),
            Substitute.For<IOmpEntityProvider>(),
            NullLogger<MapContext>.Instance
        );

        _maps = [];
    }

    [Test]
    public void Load_WhenMapNameIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        MapObjectService mapObjects = new(_fakeMapContext, _maps);

        // Act
        Action act = () => mapObjects.Load(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Load_WhenMapNameIsEmpty_ShouldThrowArgumentException()
    {
        // Arrange
        MapObjectService mapObjects = new(_fakeMapContext, _maps);

        // Act
        Action act = () => mapObjects.Load(string.Empty);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Test]
    public void Load_WhenMapIsNotRegistered_ShouldDoNothing()
    {
        // Arrange
        MapObjectService mapObjects = new(_fakeMapContext, _maps);

        // Act
        Action act = () => mapObjects.Load("Unknown");

        // Assert
        act.Should().NotThrow();
    }

    [Test]
    public void Load_WhenMapIsRegistered_ShouldLoadMap()
    {
        // Arrange
        TestMapDefinition map = new("Map");
        _maps.Add(map.Name, map);

        MapObjectService mapObjects = new(_fakeMapContext, _maps);

        // Act
        mapObjects.Load(map.Name);

        // Assert
        map.WasLoaded.Should().BeTrue();
    }

    [Test]
    public void Load_WhenAnotherMapIsAlreadyLoaded_ShouldThrowInvalidOperationException()
    {
        // Arrange
        TestMapDefinition map1 = new("Map1");
        TestMapDefinition map2 = new("Map2");

        _maps.Add(map1.Name, map1);
        _maps.Add(map2.Name, map2);

        MapObjectService mapObjects = new(_fakeMapContext, _maps);
        mapObjects.Load(map1.Name);

        // Act
        Action act = () => mapObjects.Load(map2.Name);

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void Unload_WhenNoMapIsLoaded_ShouldThrowInvalidOperationException()
    {
        // Arrange
        MapObjectService mapObjects = new(_fakeMapContext, _maps);

        // Act
        Action act = mapObjects.Unload;

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Test]
    public void Unload_WhenMapIsLoaded_ShouldUnloadMap()
    {
        // Arrange
        TestMapDefinition map = new("Map");
        _maps.Add(map.Name, map);

        MapObjectService mapObjects = new(_fakeMapContext, _maps);
        mapObjects.Load(map.Name);

        // Act
        mapObjects.Unload();

        // Assert
        map.WasUnloaded.Should().BeTrue();
        _fakeMapContext.WereObjectsDestroyed.Should().BeTrue();
    }

    [Test]
    public void Unload_WhenMapWasUnloaded_ShouldAllowLoadingAnotherMap()
    {
        // Arrange
        TestMapDefinition map1 = new("Map1");
        TestMapDefinition map2 = new("Map2");

        _maps.Add(map1.Name, map1);
        _maps.Add(map2.Name, map2);

        MapObjectService mapObjects = new(_fakeMapContext, _maps);
        mapObjects.Load(map1.Name);
        mapObjects.Unload();

        // Act
        Action act = () => mapObjects.Load(map2.Name);

        // Assert
        act.Should().NotThrow();
        map2.WasLoaded.Should().BeTrue();
    }

    [Test]
    public void Unload_WhenOnUnloadThrows_ShouldAllowLoadingAnotherMap()
    {
        // Arrange
        TestMapDefinition map1 = new("Map1")
        {
            ThrowOnUnload = true
        };

        TestMapDefinition map2 = new("Map2");

        _maps.Add(map1.Name, map1);
        _maps.Add(map2.Name, map2);

        MapObjectService mapObjects = new(_fakeMapContext, _maps);
        mapObjects.Load(map1.Name);

        // Act
        Action unload = mapObjects.Unload;

        // Assert
        unload.Should().Throw<InvalidOperationException>();

        Action load = () => mapObjects.Load(map2.Name);
        load.Should().NotThrow();
        map2.WasLoaded.Should().BeTrue();
    }
}
