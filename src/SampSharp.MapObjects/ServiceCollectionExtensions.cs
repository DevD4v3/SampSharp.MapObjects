namespace SampSharp.MapObjects;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the services required to manage object maps, including all registered map definitions.
    /// </summary>
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> to add the object map services to.
    /// </param>
    /// <returns>
    /// The same <see cref="IServiceCollection"/> instance so that additional calls can be chained.
    /// </returns>
    public static IServiceCollection AddMapObjects(this IServiceCollection services)
    {
        services.AddTransient<MapContext>();

        services
            .AddSingleton<MapDefinition, Aim_Headshot>()
            .AddSingleton<MapDefinition, Aim_Headshot2>()
            .AddSingleton<MapDefinition, Area51>()
            .AddSingleton<MapDefinition, Area66>()
            .AddSingleton<MapDefinition, Compound>()
            .AddSingleton<MapDefinition, CrackFactory>()
            .AddSingleton<MapDefinition, cs_assault>()
            .AddSingleton<MapDefinition, cs_deagle5>()
            .AddSingleton<MapDefinition, cs_opposition>()
            .AddSingleton<MapDefinition, cs_rockwar>()
            .AddSingleton<MapDefinition, cs_train>()
            .AddSingleton<MapDefinition, DesertGlory>()
            .AddSingleton<MapDefinition, de_aztec>()
            .AddSingleton<MapDefinition, de_dust2>()
            .AddSingleton<MapDefinition, de_dust2x1>()
            .AddSingleton<MapDefinition, de_dust2x2>()
            .AddSingleton<MapDefinition, de_dust2x3>()
            .AddSingleton<MapDefinition, de_dust2x4>()
            .AddSingleton<MapDefinition, de_dust2x5>()
            .AddSingleton<MapDefinition, de_dust2_small>()
            .AddSingleton<MapDefinition, de_dust5>()
            .AddSingleton<MapDefinition, fy_iceworld>()
            .AddSingleton<MapDefinition, fy_iceworld2>()
            .AddSingleton<MapDefinition, fy_snow>()
            .AddSingleton<MapDefinition, fy_snow2>()
            .AddSingleton<MapDefinition, GateToHell>()
            .AddSingleton<MapDefinition, mp_island>()
            .AddSingleton<MapDefinition, mp_jetdoor>()
            .AddSingleton<MapDefinition, PleasureDomes>()
            .AddSingleton<MapDefinition, RC_Battlefield>()
            .AddSingleton<MapDefinition, RC_Battlefield2>()
            .AddSingleton<MapDefinition, SA_Hill>()
            .AddSingleton<MapDefinition, Simpson>()
            .AddSingleton<MapDefinition, TheBunker>()
            .AddSingleton<MapDefinition, TheConstruction>()
            .AddSingleton<MapDefinition, TheWild>()
            .AddSingleton<MapDefinition, WarZone>()
            .AddSingleton<MapDefinition, WarZone2>()
            .AddSingleton<MapDefinition, ZM_Italy>()
            .AddSingleton<MapDefinition, zone_paintball>();

        services
            .AddSingleton(sp =>
            {
                IEnumerable<MapDefinition> maps = sp.GetRequiredService<IEnumerable<MapDefinition>>();
                return maps.ToDictionary(map => map.Name);
            })
            .AddSingleton<IMapObjectService, MapObjectService>()
            .AddSystem<DefaultObjectRemovalSystem>();

        return services;
    }
}
