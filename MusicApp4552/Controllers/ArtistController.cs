using MusicApp4552.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicApp4552.Controllers
{
    public class ArtistController : Controller
    {
        private static List<Artist> _artists = new List<Artist>();

        public ActionResult Index()
        {
            return View(_artists);
        }

        public ActionResult Details(int id)
        {
            var artist = _artists.FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                artist.Id = _artists.Count + 1;
                _artists.Add(artist);
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        public ActionResult Edit(int id)
        {
            var artist = _artists.FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Artist artist)
        {
            if (id != artist.Id)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                var artistToUpdate = _artists.FirstOrDefault(a => a.Id == id);
                artistToUpdate.Name = artist.Name;
                artistToUpdate.Photo = artist.Photo;
                artistToUpdate.Age = artist.Age;
                artistToUpdate.TopListPosition = artist.TopListPosition;

                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        public ActionResult Delete(int id)
        {
            var artist = _artists.FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var artist = _artists.FirstOrDefault(a => a.Id == id);
            _artists.Remove(artist);
            return RedirectToAction(nameof(Index));
        }


    }
}