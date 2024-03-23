using Data.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Interfaces;

namespace Controller.Controller {
    public class ArtistController : Controller, IArtistController {
        public List<Artist> GetAll() {
            using (_appContext = new ApplicationDbContext()) {
                return _appContext.Artists.ToList();
            }
        }

        public Artist Get(int id) {
            using (_appContext = new ApplicationDbContext()) {
                return _appContext.Artists.Find(id);
            }
        }

        public void Add(Artist Artist) {
            using (_appContext = new ApplicationDbContext()) {
                _appContext.Artists.Add(Artist);
                _appContext.SaveChanges();
            }
        }

        public void Update(Artist Artist) {
            using (_appContext = new ApplicationDbContext()) {
                var item = _appContext.Artists.Find(Artist.Id);
                if (item != null) {
                    _appContext.Entry(item).CurrentValues.SetValues(Artist);
                    _appContext.SaveChanges();
                }
            }
        }

        public void Delete(int id) {
            using (_appContext = new ApplicationDbContext()) {
                var product = _appContext.Artists.Find(id);
                if (product != null) {
                    _appContext.Artists.Remove(product);
                    _appContext.SaveChanges();
                }
            }
        }

        public void ListAll() {
            using (_appContext = new ApplicationDbContext()) {
                BandController bandController = new BandController();
                string type = "Artists";
                List<Artist> artists = GetAll();
                List<string> artistInfos = artists.Select(a => GetArtistInfo(a, bandController)).ToList();

                // print info relative to the longest artist info string
                int maxInfoCharacterLength = artistInfos.Max(a => a.Length);
                Console.WriteLine(new string('-', maxInfoCharacterLength));
                Console.WriteLine(new string(' ', (maxInfoCharacterLength - type.Length) / 2) + type);
                Console.WriteLine(new string('-', maxInfoCharacterLength));

                artistInfos.ForEach(x => Console.WriteLine(x));// TODO: make a ToString()

                Console.WriteLine(new string('-', maxInfoCharacterLength));
            }
        }

        private static string GetArtistInfo(Artist artist, BandController bandController) {
            Band? band = bandController.Get(artist.BandId);
            string info = artist.ToString();
            info += band == null ? $", Band Name: N/A" : $", Band Name: {band.Name}";
            return info;
        }
    }
}
