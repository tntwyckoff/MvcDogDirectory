using System;
using System.Collections.Generic;
using System.Text;

namespace IntApps.Samples.ApiClient.DogServiceApiClient.Models
{
    class DogCeoResponse
    {
        public string Status { get; set; }
        
        // because of the format of their list response (dictionary rather than an array)
        //  this must be an object so we can trap the full object contents, call "ToString" 
        //  on it, and parse that through newtownsoft as a dictionary
        
        // happily, this works well enough for the simpler Uri to get a random image as well
        public object Message { get; set; }
    }
}
