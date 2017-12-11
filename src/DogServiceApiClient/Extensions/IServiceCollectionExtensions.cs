using System;
using System.Collections.Generic;
using System.Text;
using IntApps.Samples.ApiClient.DogServiceApiClient.Factories;
using IntApps.Samples.Interfaces.DogDirectory.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntApps.Samples.ApiClient.DogServiceApiClient.Extensions
{
    public static class IServiceCollectionExtensions
    {
        static bool _useConfigSettings = false;


        public static IServiceCollection UseDogCeoAnimalProvider (this IServiceCollection context)
        {
            // if they've invoked 'UseConfigSettingsAnimalProviderFactory' we can assume there's a valid entry in appSettings
            // if not, we'll fll back on our hard-coded consts file

            if (!_useConfigSettings)
                context.UseDefaultAnimalProviderFactory ();

            return context.AddTransient<IAnimalDataProvider> (svcs => 
            {
                var factory = svcs.GetService<IAnimalProviderFactory> ();

                return factory.GetIAnimalProvider ();
            });
        }

        public static IServiceCollection UseDogCeoAppSettings (this IServiceCollection context, IConfiguration config)
        {
            _useConfigSettings = true;
            context.Configure<DogCeoDataProviderOptions> (config.GetSection (Constants.ConfigurationSettingsKey));
            return context.AddSingleton<IAnimalProviderFactory, ConfigSettingsAnimalFactory> ();
        }

        public static IServiceCollection UseDefaultAnimalProviderFactory (this IServiceCollection context)
        {
            return context.AddSingleton<IAnimalProviderFactory, DefaultIAnimalFactory> ();
        }

    }
}
