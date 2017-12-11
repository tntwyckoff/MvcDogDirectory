using System;
using System.Collections.Generic;
using System.Text;

namespace IntApps.Samples.Interfaces.DogDirectory.Models
{
    public interface IAnimal : IBreed
    {
        string [] SubBreeds { get; set; }
    }
}
