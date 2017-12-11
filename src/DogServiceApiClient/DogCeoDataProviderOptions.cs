using System;
using System.Collections.Generic;
using System.Text;

namespace IntApps.Samples.ApiClient.DogServiceApiClient
{
    public class DogCeoDataProviderOptions
    {
        public string DataProviderDomain { get; set; }

        public string DataProviderApiBase { get; set; }

        public string DataProviderBreedListPath { get; set; }

        public string DataProviderBreedImageByKeyPathFormat { get; set; }

        public bool DataProviderUseSSL { get; set; }
    }
}
