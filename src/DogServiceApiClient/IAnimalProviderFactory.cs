using System;
using System.Collections.Generic;
using System.Text;
using IntApps.Samples.Interfaces.DogDirectory.Providers;

namespace IntApps.Samples.ApiClient.DogServiceApiClient
{
    interface IAnimalProviderFactory
    {
        IAnimalDataProvider GetIAnimalProvider ();
    }
}
