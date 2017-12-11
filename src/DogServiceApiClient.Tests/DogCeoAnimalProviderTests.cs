using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntApps.Samples.ApiClient.DogServiceApiClient;
using IntApps.Samples.ApiClient.DogServiceApiClient.Models;
using IntApps.Samples.Models.DogDirectory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DogServiceApiClient.Tests
{
    [TestClass]
    public class DogCeoAnimalProviderTests
    {
        [TestMethod]
        public void ProtocolIsHttpsWhenUseSSLIsTrue ()
        {
            var opts = new DogCeoDataProviderOptions
            {
                DataProviderUseSSL = true
            };

            var ceoDogProvider = new DogCeoAnimalProvider (opts);

            Assert.AreEqual ("https", ceoDogProvider.GetProtocol ().ToLower ());
        }

        [TestMethod]
        public void ProtocolIsHttpWhenUseSSLIsFalse ()
        {
            var opts = new DogCeoDataProviderOptions
            {
                DataProviderUseSSL = false
            };

            var ceoDogProvider = new DogCeoAnimalProvider (opts);

            Assert.AreEqual ("http", ceoDogProvider.GetProtocol ().ToLower ());
        }

        [TestMethod]
        public void ParseSampleJson ()
        {
            var ceoDogProvider = new DogCeoAnimalProvider (new DogCeoDataProviderOptions ());

            var testString = "{\"affenpinscher\": [],\"african\": [], \"bulldog\": [\"boston\", \"french\"]}";

            var testList = new List<Dog>
            {
                new Dog
                {
                    Breed = "affenpinscher"
                },
                new Dog
                {
                    Breed = "african"
                },
                new Dog
                {
                    Breed = "bulldog",
                    SubBreeds = new [] { "boston", "french" }
                }
            };

            var dogs = ceoDogProvider.ParseBreedList (testString);

            if (testList.Count != dogs.Length)
                Assert.Fail ("Wrong number of elements returned from parsed string.");

            for (var i = 0; i < testList.Count; i++)
            {
                if (testList [i].Breed != dogs [i].Breed)
                    Assert.Fail ("Element #{0} returned wrong breed name.", i);

                if (null != testList [i].SubBreeds)
                {
                    if (null == dogs [i].SubBreeds)
                        Assert.Fail ("Element #{0} failed to populate sub-breeds.", i);

                    if (testList [i].SubBreeds.Length != dogs [i].SubBreeds.Length)
                        Assert.Fail ("Element #{0} failed to populate the correct number of sub-breeds.", i);

                    for (var ii = 0; ii < testList [i].SubBreeds.Length; ii++)
                    {
                        var testName = testList [i].SubBreeds [ii];
                        var valName = dogs [i].SubBreeds [ii];

                        if (!string.Equals (testName, valName))
                            Assert.Fail ("Element #{0}, sub-breed {1} yielded incorrect sub-breed name.", i);
                    }
                }
            }
        }

        [TestMethod]
        public void BuildValidUriGetAllDogs ()
        {
            var ceoDogProvider = new DogCeoAnimalProvider (getLiveProviderOptions ());

            var allDogsUri = new Uri ("https://dog.ceo/api/breeds/list/all");

            var val = ceoDogProvider.GetUriForPath (Constants.DataProviderBreedListPath);

            Assert.AreEqual (allDogsUri, val);
        }

        // i find it odd that they don't handle a traling '/' char (maybe i'm wrong) so this test documents that 
        //  we should **not** allow trailing slashes
        [TestMethod]
        public void DoesNotBuildInvalidUriGetAllDogs ()
        {
            var ceoDogProvider = new DogCeoAnimalProvider (getLiveProviderOptions ());

            var allDogsUri = new Uri ("https://dog.ceo/api/breeds/list/all/");

            var val = ceoDogProvider.GetUriForPath (Constants.DataProviderBreedListPath);

            Assert.AreNotEqual (allDogsUri, val);
        }

        [TestMethod]
        public async Task TestOverallApiPullAllDogs ()
        {
            var ceoDogProvider = new DogCeoAnimalProvider (getLiveProviderOptions ());

            var list = await ceoDogProvider.ListBreedsAsync ();

            Assert.IsTrue (0 < list.Count);
        }

        [TestMethod]
        public async Task TestOverallApiPullImageBassetHound ()
        {
            var ceoDogProvider = new DogCeoAnimalProvider (getLiveProviderOptions ());

            var imageSrc = await ceoDogProvider.GetRandomBreedImageAsync ("hound");

            Assert.IsNotNull (imageSrc);
        }

        [TestMethod]
        public async Task TestOverallApiPullImageBluetick ()
        {
            var ceoDogProvider = new DogCeoAnimalProvider (getLiveProviderOptions ());

            var imageSrc = await ceoDogProvider.GetRandomBreedImageAsync ("bluetick");

            Assert.IsNotNull (imageSrc);
        }


        DogCeoDataProviderOptions getLiveProviderOptions ()
        {
            return new DogCeoDataProviderOptions
            {
                DataProviderDomain = Constants.DataProviderDomain,
                DataProviderApiBase = Constants.DataProviderApiBase,
                DataProviderBreedListPath = Constants.DataProviderBreedListPath,
                DataProviderBreedImageByKeyPathFormat = Constants.DataProviderBreedImageByKeyPathFormat,
                DataProviderUseSSL = Constants.DataProviderUseSSL
            };
        }

    }
}
