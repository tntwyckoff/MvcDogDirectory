using System;
using System.Collections.Generic;
using System.Text;
using IntApps.Samples.Interfaces.DogDirectory.Models;

namespace IntApps.Samples.Models.DogDirectory
{
    public class DogImage : ModelBase, IAnimalImage
    {
        public string Breed { get; set; }
        public string ImageSource { get; set; }
    }
}
