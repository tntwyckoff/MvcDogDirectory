# MvcDogDirectory

This is my first pass at the Dog Directory sample project.

## Tech stack

I built this using .NET Core 2.0. I prefer to work in .NET Core whenever possible, because I feel it's the most elegant, well-rounded platform Microsoft has produced for web projects. I tried to build this as I would if I were starting a project of reasonable size (clearly the amount of code here is more than is warranted by the simple requirements), including:

* Separation of related code into library projects
* Full integration with the dependency injection system (and extension methods to facilitate its use)
* Async methods
* Factory pattern
* Coding against abstractions
* A smattering of unit tests

## In answer to your PDF sample queries
* Re: Elegant way to handle deserializing the JSON - hopefully my code in the `DogCeoAnimalProvider` class [`DogServiceApiClient` project] seems about right. I defined a POCO class that's analogous to the "standard" API response, and simply let the JSON utility classes deserialize the body:
`apiResult.Content.ReadAsAsync<DogCeoResponse> ();`
...I would add here that the designers of the dog.ceo API did us a disservice in returning the payload as a single large, complex object with a key for each breed, as opposed to an array of simpler objects. This seems like a non-standard implementation in my view and added some code requirements to be able to deserialize the dynamic list of breeds in our API client code. 
* Re: status - I guess I would just say that status is a top-level HTTP protocol construct, and so is generally communicated that way via, well-known status codes (200 == OK, 404 == not found, etc.). HTTP responses can also include additional information in the body if appropriate, but unless there's a very good reason status is nearly always handled in the HTTP response layer.

## Notes

* Built using VS 2017 Community
* I typically set my individual projects to build to a common output directory somewhere outside of their project path, but doing so was giving the compiler fits here, so it seems that this is not fully supported by either VS 2017 or .NET Core 2.0
* In a real-world environment I would want to push these libraries out to a local nuget package server and only refer to them via nuget, but for simplicity I just set inter-project references
* I indulged myself and added a page for my dog Rex
