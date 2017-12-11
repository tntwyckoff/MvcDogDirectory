using System;
using System.Collections.Generic;
using System.Text;
using IntApps.Samples.Interfaces.DogDirectory.Providers;

namespace IntApps.Samples.ApiClient.DogServiceApiClient.Factories
{
    /// <summary>
    /// This is the fallback factory if we can't expect the app to have configured properly via appSettings.json file
    /// </summary>
    class DefaultIAnimalFactory : IAnimalProviderFactory
    {
        public IAnimalDataProvider GetIAnimalProvider ()
        {
            return new DogCeoAnimalProvider
            (
                new DogCeoDataProviderOptions
                {
                    DataProviderDomain = Constants.DataProviderDomain,
                    DataProviderApiBase = Constants.DataProviderApiBase,
                    DataProviderBreedListPath = Constants.DataProviderBreedListPath,
                    DataProviderBreedImageByKeyPathFormat = Constants.DataProviderBreedImageByKeyPathFormat,
                    DataProviderUseSSL = Constants.DataProviderUseSSL
                }
            );
        }
    }
}
