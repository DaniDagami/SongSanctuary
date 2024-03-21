using Data.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Controller {
    public class BandController {
        private ApplicationDbContext _appContext;
        public List<Band> GetAll() {
            using(_appContext = new ApplicationDbContext()) {
                return _appContext.Bands.ToList();
            }
        }

        public Band Get(int id) {
            using(_appContext = new ApplicationDbContext()) {
                return _appContext.Bands.Find(id);
            }
        }

        public void Add(Band Band) {
            using(_appContext = new ApplicationDbContext()) {
                _appContext.Bands.Add(Band);
                _appContext.SaveChanges();
            }
        }

        public void Update(Band Band) {
            using(_appContext = new ApplicationDbContext()) {
                var item = _appContext.Bands.Find(Band.Id);
                if(item != null) {
                    _appContext.Entry(item).CurrentValues.SetValues(Band);
                    _appContext.SaveChanges();
                }
            }
        }

        public void Delete(int id) {
            using(_appContext = new ApplicationDbContext()) {
                var product = _appContext.Bands.Find(id);
                if(product != null) {
                    _appContext.Bands.Remove(product);
                    _appContext.SaveChanges();
                }
            }
        }
    }
}
