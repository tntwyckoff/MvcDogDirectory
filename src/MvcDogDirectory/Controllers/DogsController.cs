using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntApps.Samples.Interfaces.DogDirectory.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MvcDogDirectory.Controllers
{
    public class DogsController : Controller
    {
        IAnimalDataProvider _dataProvider;


        public DogsController (IAnimalDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }


        // GET: Dogs
        public async Task<ActionResult> Index ()
        {
            var allDogs = await _dataProvider.ListBreedsAsync ();
            return View (allDogs);
        }

        // GET: Dogs/SampleImage/{key}
        public async Task<ActionResult> SampleImage (string key)
        {
            var imageSrc = await _dataProvider.GetRandomBreedImageAsync (key);
            return View (imageSrc);
        }

        // GET: Dogs/Rex
        public ActionResult Rex ()
        {
            var rand = (DateTime.Now.Millisecond / 100);
            ViewBag.ImageSource = string.Format ("/images/rex{0}.jpg", rand);
            return View ();
        }


        //// GET: Dogs/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Dogs/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Dogs/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Dogs/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Dogs/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Dogs/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Dogs/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}