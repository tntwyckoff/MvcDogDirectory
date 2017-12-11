using IntApps.Samples.Interfaces.DogDirectory.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntApps.Samples.Interfaces.DogDirectory.Providers
{
    public interface IAnimalDataProvider
    {
        Task<ICollection<IAnimal>> ListBreedsAsync ();
        Task<IAnimalImage> GetRandomBreedImageAsync(string key);
        ICollection<IAnimal> ListBreeds ();
        IAnimalImage GetRandomBreedImage (string key);
    }
}
