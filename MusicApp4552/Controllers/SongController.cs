using MusicApp4552.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace MusicApp4552.Controllers
{
    public class SongController : Controller
    {
        private static List<Song> _songs = new List<Song>();
        private static List<Artist> _artists = new List<Artist>();

        public ActionResult Index(int? artistId)
        {
          

            var artist = _artists.FirstOrDefault(a => a.Id == artistId);
            if (artist == null)
            {
                return HttpNotFound();
            }

            var songs = _songs.Where(s => s.ArtistId == artistId).ToList();
            return View(songs);
        }

    

    public ActionResult Create(int artistId)
    {
        var artist = _artists.FirstOrDefault(a => a.Id == artistId);
        if (artist == null)
        {
            return HttpNotFound();
        }

        var song = new Song
        {
            ArtistId = artistId,
            Artist = artist
        };
        return View(song);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Song song)
    {
        if (ModelState.IsValid)
        {
            song.Id = _songs.Count + 1;
            _songs.Add(song);
            return RedirectToAction(nameof(Index), new { artistId = song.ArtistId });
        }
        return View(song);
    }

    public ActionResult Edit(int id)
    {
        var song = _songs.FirstOrDefault(s => s.Id == id);
        if (song == null)
        {
            return HttpNotFound();
        }
        return View(song);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Song song)
    {
        if (id != song.Id)
        {
            return HttpNotFound();
        }

        if (ModelState.IsValid)
        {
            var songToUpdate = _songs.FirstOrDefault(s => s.Id == id);
            songToUpdate.Name = song.Name;
            songToUpdate.Year = song.Year;
            songToUpdate.DownloadLink = song.DownloadLink;

            return RedirectToAction(nameof(Index), new { artistId = songToUpdate.ArtistId });
        }
        return View(song);
    }

    public ActionResult Delete(int id)
    {
        var song = _songs.FirstOrDefault(s => s.Id == id);
        if (song == null)
        {
            return HttpNotFound();
        }
        return View(song);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var song = _songs.FirstOrDefault(s => s.Id == id);
        var artistId = song.ArtistId;
        _songs.Remove(song);
        return RedirectToAction(nameof(Index), new { artistId = artistId });
    }
  }

}
