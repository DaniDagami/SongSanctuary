using Controller.Controller;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSanctuary.View {
    public class ArtistDisplay : Display {

        private ArtistController _artistController = new ArtistController();

        public ArtistDisplay() {
            Input();
        }

        private void Input() {
            var operation = -1;
            do {
                ShowCommands();
                operation = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (operation) {
                    case 1:
                        _artistController.ListAll();
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
            } while (operation != closeOperationId);
        }


        private void Add() {
            Artist artist = new Artist();

            Console.WriteLine("Enter first name: ");
            artist.FirstName = Console.ReadLine();

            Console.WriteLine("Enter last name: ");
            artist.LastName = Console.ReadLine();

            Console.WriteLine("Alive? Y for yes/ N for no: ");
            string answerAlive = Console.ReadLine().ToUpper();
            artist.Alive = answerAlive == "Y";

            Console.WriteLine("Do you want to add a BandId? Y for yes/ N for no: ");
            string answerBandId = Console.ReadLine().ToUpper();
            if (answerBandId == "Y") {
                BandController bandController = new BandController();
                bandController.ListAll(); // lists all bands so you can choose

                Console.WriteLine("Enter band ID: ");
                if (!int.TryParse(Console.ReadLine(), out int bandId))
                    throw new ArgumentException("Invalid input. Artist will not be associated with any band.");

                Band band = bandController.Get(bandId);
                if (band == null)
                    throw new ArgumentException("Band not found. Artist will not be associated with any album.");

                artist.BandId = bandId;
            }
            _artistController.Add(artist);
        }

        private void Update() {
            _artistController.ListAll(); // show all available artists

            Console.WriteLine("Enter ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new ArgumentException("Invalid input. Input should be integer.");
            Console.Clear();
            Artist artist = _artistController.Get(id) ?? throw new ArgumentException("Artist not found!");

            string info = artist.ToString();
            string title = "Current values for this artist are:";
            ShowHeader(info.Length, info, title);

            Console.WriteLine("Enter first name: ");
            artist.FirstName = Console.ReadLine();

            Console.WriteLine("Enter last name: ");
            artist.LastName = Console.ReadLine();

            Console.WriteLine("Alive? Y for yes/ N for no: ");
            string answerAlive = Console.ReadLine().ToUpper();
            artist.Alive = answerAlive == "Y" ? true : false;

            Console.WriteLine("Do you want to add a BandId? Y for yes/ N for no: ");
            string answerBandId = Console.ReadLine().ToUpper();
            if (answerBandId == "Y") {
                BandController bandController = new BandController();
                bandController.ListAll(); // lists all bands so you can choose

                Console.WriteLine("Enter band ID: ");
                if (!int.TryParse(Console.ReadLine(), out int bandId))
                    throw new ArgumentException("Invalid input. Artist will not be associated with any band.");

                Band band = bandController.Get(bandId);
                if (band is null)
                    throw new ArgumentException("Band not found. Artist will not be associated with any album.");

                artist.BandId = bandId;
            }
            _artistController.Update(artist);
        }

        private void Fetch() {
            BandController bandController = new BandController();
            string title = "Artists";

            Console.WriteLine("Enter ID to fetch:");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                throw new ArgumentException("Invalid input. Input should be integer.");
            }
            Console.Clear();
            Artist? artist = _artistController.Get(id);
            if (artist == null)
                throw new ArgumentException("Artist not found!");

            Band? band = bandController.Get(artist.BandId);
            string info = artist.ToString();
            info += band is null ? $", Band Name: N/A" : $", Band Name: {band?.Name}";
            int maxCharacterLength = info.Length;

            ShowHeader(maxCharacterLength, info, title);
        }

        private void Delete() {
            _artistController.ListAll();

            Console.WriteLine("Enter ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new ArgumentException("Invalid input. Please enter a valid integer ID.");
            Console.Clear();
            Artist artist = _artistController.Get(id) ?? throw new ArgumentException("Artist was not found!");

            _artistController.Delete(id);
            Console.WriteLine("This artist has been deleted!");
        }
    }
}

