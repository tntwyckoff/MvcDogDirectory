using System;
using System.Collections.Generic;
using System.Text;

namespace IntApps.Samples.Interfaces.DogDirectory.Models
{
    public interface IAnimalImage : IBreed
    {
        string ImageSource { get; }
    }
}
