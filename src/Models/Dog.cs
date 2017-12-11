using IntApps.Samples.Interfaces.DogDirectory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntApps.Samples.Models.DogDirectory
{
    public class Dog : ModelBase, IAnimal
    {
        public string Breed { get; set; }
        public string [] SubBreeds { get; set; }
    }
}
