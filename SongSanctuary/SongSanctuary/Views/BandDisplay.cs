using Controller.Controller;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSanctuary.View {
    public class BandDisplay : Display {
        private BandController _bandController = new BandController();

        public BandDisplay() {
            Input();
        }

        private void Input() {
            var operation = -1;
            do {
                ShowCommands();
                operation = int.Parse(Console.ReadLine());
                Console.Clear();
                switch(operation) {
                    case 1:
                        _bandController.ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;

                }
            } while(operation != closeOperationId);
        }

        private void Add() {
            Band band = new Band();

            Console.WriteLine("Enter name: ");
            band.Name = Console.ReadLine();

            Console.WriteLine("Alive? Y for yes/ N for no: ");
            string answerActive = Console.ReadLine().ToUpper();
            band.Active = answerActive == "Y";


            string memberCount = Console.ReadLine();
            if(!int.TryParse(memberCount, out int members))
                throw new ArgumentException("Invalid length format. The count of members will be set to default (0).");

            band.MemberCount = members;

            _bandController.Add(band);
        }


        private void Update() {
            _bandController.ListAll(); // show all available bands

            Console.WriteLine("Enter ID to update:");
            if(!int.TryParse(Console.ReadLine(), out int id))
                throw new ArgumentException("Invalid number format.");
            Console.Clear();

            Band band = _bandController.Get(id) ?? throw new ArgumentException("Band not found!");

            string info = band.ToString();
            string title = "Current values for this band are:";
            ShowHeader(info.Length, info, title);

            Console.WriteLine("Enter name: ");
            band.Name = Console.ReadLine();

            Console.WriteLine("Active? Y for yes/ N for no: ");
            string answerActive = Console.ReadLine().ToUpper();
            band.Active = answerActive == "Y";

            Console.WriteLine("Enter member count: ");
            string memberCount = Console.ReadLine();
            if(!int.TryParse(memberCount, out int members))
                throw new ArgumentException("Invalid number format. The count of members will be set to default (0).");

            band.MemberCount = members;

            _bandController.Update(band);
        }


        private void Fetch() {
            _bandController.ListAll();
            AlbumController albumController = new AlbumController();

            Console.WriteLine("Enter ID to fetch:");

            if(!int.TryParse(Console.ReadLine(), out int id))
                throw new ArgumentException("Invalid input. Input should be integer.");
            Console.Clear();

            Band? band = _bandController.Get(id) ?? throw new ArgumentException("Band not found!");

            List<string> albums = albumController.GetAll().Where(x=>x.BandId == id).Select(s=>s.ToString()).ToList();
            int maxCharacterLength = albums.Max(x => x.Length);
            StringBuilder info = new StringBuilder();
            foreach(var item in albums) {
                info.AppendLine(item.ToString());
            }
            ShowHeader(maxCharacterLength, info.ToString().Trim(), band.Name);
        }

        private void Delete() {
            _bandController.ListAll();

            Console.WriteLine("Enter ID to delete: ");

            if(!int.TryParse(Console.ReadLine(), out int id))
                throw new ArgumentException("Invalid input. Please enter a valid integer ID.");

            Console.Clear();

            Band band = _bandController.Get(id) ?? throw new ArgumentException("Band not found!");

            _bandController.Delete(id);
            Console.WriteLine("This band has been deleted!");
        }
    }
}
