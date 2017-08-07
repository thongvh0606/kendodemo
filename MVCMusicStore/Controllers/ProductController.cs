using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStore.JsonpResult;
using MVCMusicStore.Models;

namespace MVCMusicStore.Controllers
{
    public class ProductController : Controller
    {
        List<Album> albums = new List<Album>();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Read()
        {
            
            for (int i = 0; i < 30; i++)
            {
                albums.Add(new Album()
            {
                AlbumId = i,
                Artist = new Artist()
                {
                    ArtistId = i,
                    Name = i+"a"
                },
                ArtistId = i,
                Price = 100+i,
                Title = "Depacito"+i,
            });
            }
            return this.Jsonp(albums);
        }

       


    }
}