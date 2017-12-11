using IntApps.Samples.ApiClient.DogServiceApiClient.Models;
using IntApps.Samples.HttpCore;
using IntApps.Samples.Interfaces.DogDirectory.Models;
using IntApps.Samples.Interfaces.DogDirectory.Providers;
using IntApps.Samples.Models.DogDirectory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntApps.Samples.ApiClient.DogServiceApiClient
{
    public class DogCeoAnimalProvider : IAnimalDataProvider
    {
        DogCeoDataProviderOptions _options;


        public DogCeoAnimalProvider (DogCeoDataProviderOptions options)
        {
            _options = options;
        }


        public ICollection<IAnimal> ListBreeds ()
        {
            var task = ListBreedsAsync ();
            task.Wait ();

            return task.Result;
        }

        public async Task<ICollection<IAnimal>> ListBreedsAsync ()
        {
            using (var apiClient = GetClient ())
            {
                HttpResponseMessage apiResult;

                var request = new HttpRequestMessage ()
                {
                    RequestUri = GetUriForPath (_options.DataProviderBreedListPath),
                    Method = HttpMethod.Get,
                };

                try
                {
                    apiResult = await apiClient.SendAsync (request);

                    if (apiResult.IsSuccessStatusCode)
                    {
                        var result = await apiResult.Content.ReadAsAsync<DogCeoResponse> ();

                        // their response really ought to be an array, but they've returned it in 
                        //  a dictionary-like form; requires some x-formation...

                        return ParseBreedList (result.Message.ToString());
                    }
                }
                catch
                {
                    throw;
                }
            }

            return null;
        }

        public IAnimalImage GetRandomBreedImage (string key)
        {
            var task = GetRandomBreedImageAsync (key);
            task.Wait ();

            return task.Result;
        }

        public async Task<IAnimalImage> GetRandomBreedImageAsync (string key)
        {
            using (var apiClient = GetClient ())
            {
                HttpResponseMessage apiResult;

                var request = new HttpRequestMessage ()
                {
                    RequestUri = GetUriForPath (string.Format (_options.DataProviderBreedImageByKeyPathFormat, key)),
                    Method = HttpMethod.Get,
                };

                try
                {
                    apiResult = await apiClient.SendAsync (request);

                    if (apiResult.IsSuccessStatusCode)
                    {
                        var result = await apiResult.Content.ReadAsAsync<DogCeoResponse> ();

                        return new DogImage
                        {
                            Breed = key,
                            ImageSource = result.Message.ToString ()
                        };
                    }
                }
                catch
                {
                    throw;
                }
            }

            return null;

        }

        public IAnimal [] ParseBreedList (string message)
        {
            var breedList = new List<Dog> ();

            var dict = JsonConvert.DeserializeObject<Dictionary<string, List<string>>> (message);

            foreach (var key in dict.Keys)
            {
                // here we even have to parse the value string as a serialized object
                var value = dict [key];

                breedList.Add
                (
                    new Dog
                    {
                        Breed = key,
                        SubBreeds = value.ToArray ()
                    }
                );
            }

            return breedList.ToArray ();
        }

        public HttpClient GetClient ()
        {
            var result = new HttpClient ()
            {
                BaseAddress = new Uri (string.Format ("{0}://{1}", GetProtocol (), _options.DataProviderDomain))
            };

            return result;
        }

        public string GetProtocol ()
        {
            return string.Format ("http{0}", _options.DataProviderUseSSL ? "s" : "");
        }

        public Uri GetUriForPath (string path)
        {
            var proto = GetProtocol ();
            var domain = _options.DataProviderDomain;
            var apiBase = _options.DataProviderApiBase;

            return new Uri (string.Format ("{0}://{1}{2}{3}", proto, domain, apiBase, path));
        }

    }
}
