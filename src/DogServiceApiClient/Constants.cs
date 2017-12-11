using System;
using System.Collections.Generic;
using System.Text;

namespace IntApps.Samples.ApiClient.DogServiceApiClient
{
    class Constants
    {
        internal const string ConfigurationSettingsKey = "DogCeoDataProviderOptions";
        internal const string DataProviderDomain = "dog.ceo";
        internal const string DataProviderApiBase = "/api/";
        internal const string DataProviderBreedListPath = "breeds/list/all/";
        internal const string DataProviderBreedImageByKeyPathFormat = "breed/{0}/images/random";
        internal const bool DataProviderUseSSL = true;
    }
}
