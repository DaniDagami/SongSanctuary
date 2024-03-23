using Data.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Interfaces;

namespace Controller.Controller {
    public class BandController : Controller, IBandController {
        public  List<Band> GetAll() {
            using (_appContext = new ApplicationDbContext()) {
                return _appContext.Bands.ToList();
            }
        }

        public Band? Get(int? id) {
            using (_appContext = new ApplicationDbContext()) {
                return _appContext.Bands.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Add(Band Band) {
            using (_appContext = new ApplicationDbContext()) {
                _appContext.Bands.Add(Band);
                _appContext.SaveChanges();
            }
        }

        public void Update(Band Band) {
            using (_appContext = new ApplicationDbContext()) {
                var item = _appContext.Bands.Find(Band.Id);
                if (item != null) {
                    _appContext.Entry(item).CurrentValues.SetValues(Band);
                    _appContext.SaveChanges();
                }
            }
        }

        public void Delete(int id) {
            using (_appContext = new ApplicationDbContext()) {
                var product = _appContext.Bands.Find(id);
                if (product != null) {
                    _appContext.Bands.Remove(product);
                    _appContext.SaveChanges();
                }
            }
        }

        public void ListAll() {
            using (_appContext = new ApplicationDbContext()) {
                string type = "Bands";
                List<Band> bands = GetAll();
                List<string> bandInfos = bands.Select(a => a.ToString()).ToList();

                // print info relative to the longest band info string
                int maxInfoCharacterLength = bandInfos.Max(a => a.Length);
                Console.WriteLine(new string('-', maxInfoCharacterLength));
                Console.WriteLine(new string(' ', (maxInfoCharacterLength - type.Length) / 2) + type);
                Console.WriteLine(new string('-', maxInfoCharacterLength));

                bandInfos.ForEach(x => Console.WriteLine(x.ToString()));

                Console.WriteLine(new string('-', maxInfoCharacterLength));
            }
        }
    }
}
