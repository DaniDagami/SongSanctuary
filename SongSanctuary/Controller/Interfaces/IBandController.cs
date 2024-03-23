using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interfaces {
    public interface IBandController {
        List<Band> GetAll();
        Band? Get(int? id);
        void Add(Band band);
        void Update(Band band);
        void Delete(int id);
        void ListAll();
    }
}
