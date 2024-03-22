using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Controller {
    public class SongController {
        private ApplicationDbContext _appContext;
        public List<Song> GetAll() {
            using(_appContext = new ApplicationDbContext()) {
                return _appContext.Songs.ToList();
            }
        }

        public Song Get(int id) {
            using(_appContext = new ApplicationDbContext()) {
                return _appContext.Songs.Find(id);
            }
        }

        public void Add(Song song) {
            using(_appContext = new ApplicationDbContext()) {
                _appContext.Songs.Add(song);
                _appContext.SaveChanges();
            }
        }

        public void Update(Song song) {
            using(_appContext = new ApplicationDbContext()) {
                var item = _appContext.Songs.Find(song.Id);
                if(item != null) {
                    _appContext.Entry(item).CurrentValues.SetValues(song);
                    _appContext.SaveChanges();
                }
            }
        }

        public void Delete(int id) {
            using(_appContext = new ApplicationDbContext()) {
                var product = _appContext.Songs.Find(id);
                if(product != null) {
                    _appContext.Songs.Remove(product);
                    _appContext.SaveChanges();
                }
            }
        }
    }
}
