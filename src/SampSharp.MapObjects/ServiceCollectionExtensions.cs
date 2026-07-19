namespace SampSharp.MapObjects;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the services required to manage object maps, including all built-in map definitions.
    /// </summary>
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> to add the object map services to.
    /// </param>
    /// <returns>
    /// The same <see cref="IServiceCollection"/> instance so that additional calls can be chained.
    /// </returns>
    public static IServiceCollection AddMapObjects(this IServiceCollection services)
    {
        services
            .AddMapDefinition<Aim_Headshot>()
            .AddMapDefinition<Aim_Headshot2>()
            .AddMapDefinition<Area51>()
            .AddMapDefinition<Area66>()
            .AddMapDefinition<Compound>()
            .AddMapDefinition<CrackFactory>()
            .AddMapDefinition<cs_assault>()
            .AddMapDefinition<cs_deagle5>()
            .AddMapDefinition<cs_opposition>()
            .AddMapDefinition<cs_rockwar>()
            .AddMapDefinition<cs_train>()
            .AddMapDefinition<DesertGlory>()
            .AddMapDefinition<de_aztec>()
            .AddMapDefinition<de_dust2>()
            .AddMapDefinition<de_dust2x1>()
            .AddMapDefinition<de_dust2x2>()
            .AddMapDefinition<de_dust2x3>()
            .AddMapDefinition<de_dust2x4>()
            .AddMapDefinition<de_dust2x5>()
            .AddMapDefinition<de_dust2_small>()
            .AddMapDefinition<de_dust5>()
            .AddMapDefinition<fy_iceworld>()
            .AddMapDefinition<fy_iceworld2>()
            .AddMapDefinition<fy_snow>()
            .AddMapDefinition<fy_snow2>()
            .AddMapDefinition<GateToHell>()
            .AddMapDefinition<mp_island>()
            .AddMapDefinition<mp_jetdoor>()
            .AddMapDefinition<PleasureDomes>()
            .AddMapDefinition<RC_Battlefield>()
            .AddMapDefinition<RC_Battlefield2>()
            .AddMapDefinition<SA_Hill>()
            .AddMapDefinition<Simpson>()
            .AddMapDefinition<TheBunker>()
            .AddMapDefinition<TheConstruction>()
            .AddMapDefinition<TheWild>()
            .AddMapDefinition<WarZone>()
            .AddMapDefinition<WarZone2>()
            .AddMapDefinition<ZM_Italy>()
            .AddMapDefinition<zone_paintball>();

        services
            .AddSingleton(sp =>
            {
                IEnumerable<MapDefinition> maps = sp.GetRequiredService<IEnumerable<MapDefinition>>();
                return maps.ToDictionary(map => map.Name);
            })
            .AddSingleton<IMapObjectService, MapObjectService>()
            .AddSingleton<MapContext>()
            .AddSystem<DefaultObjectRemovalSystem>();

        return services;
    }

    /// <summary>
    /// Registers a custom map definition.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the map definition to register.
    /// </typeparam>
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> to add the map definition to.
    /// </param>
    /// <returns>
    /// The same <see cref="IServiceCollection"/> instance so that additional calls can be chained.
    /// </returns>
    public static IServiceCollection AddMapDefinition<T>(this IServiceCollection services)
        where T : MapDefinition
    {
        services.AddSingleton<MapDefinition, T>();
        return services;
    }
}
