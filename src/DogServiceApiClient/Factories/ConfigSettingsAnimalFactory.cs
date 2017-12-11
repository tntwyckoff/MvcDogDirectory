using System;
using System.Collections.Generic;
using System.Text;
using IntApps.Samples.Interfaces.DogDirectory.Providers;
using Microsoft.Extensions.Options;

namespace IntApps.Samples.ApiClient.DogServiceApiClient.Factories
{
    /// <summary>
    /// This factory expects the app to have configured the appSettings.json file with the correct node where options are read
    /// </summary>
    class ConfigSettingsAnimalFactory : IAnimalProviderFactory
    {
        DogCeoDataProviderOptions _options;

        public ConfigSettingsAnimalFactory (IOptions<DogCeoDataProviderOptions> options)
        {
            _options = options.Value;
        }

        public IAnimalDataProvider GetIAnimalProvider ()
        {
            return new DogCeoAnimalProvider (_options);
        }
    }
}
