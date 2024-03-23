using Controller.Controller;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSanctuary.View {
    public class AlbumDisplay : Display {
        private AlbumController _albumController = new AlbumController();

        public AlbumDisplay() {
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
                        AlbumController.ListAll();
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
            Album album = new Album();
            Console.WriteLine("Enter name: ");
            album.Name = Console.ReadLine();
            Console.WriteLine("Enter release year: ");
            album.ReleaseYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter song count: ");
            album.SongCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Do you want to add a BandId? Y for yes/ N for no: ");
            string answer = Console.ReadLine();
            if(answer.ToUpper() == "Y") {
                album.BandId = int.Parse(Console.ReadLine());
            }
            _albumController.Add(album);
        }

        private void Update() {
            AlbumController.ListAll(); // show all available albums
            Console.WriteLine("Enter ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                Console.WriteLine("Invalid input. Input should be integer."); // TODO: ArgumentException
            }

            Album album = _albumController.Get(id);
            if (album == null)
                Console.WriteLine("Album not found!"); // TODO: ArgumentException

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "Current values for this album are: ");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(album.ToString());
            Console.WriteLine(new string('-', 40));
            
            Console.WriteLine("Enter name: ");
            album.Name = Console.ReadLine();
            Console.WriteLine("Enter release year: ");
            album.ReleaseYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter genre: ");
            album.SongCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Do you want to associate the album with an existing band (Y/N): ");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "Y") {
                BandController bandController = new BandController();
                BandController.ListAll(); // TODO: Need the method | lists all bands so you can choose
                Console.WriteLine("Enter band ID: ");
                if (!int.TryParse(Console.ReadLine(), out int bandId))
                    Console.WriteLine("Invalid input. Album will not be associated with any band.");

                Band band = bandController.Get(bandId);
                if (band == null)
                    Console.WriteLine("Band not found. Album will not be associated with any band.");

                album.BandId = bandId;
            }
            _albumController.Update(album);
        }

        private void Fetch() {
            Console.WriteLine("Enter ID to fetch:");
            BandController bandController = new BandController();

            if (int.TryParse(Console.ReadLine(), out int id)) {
                Album? album = _albumController.Get(id);

                if (album == null)
                    Console.WriteLine("Album not found!"); // TODO: ArgumentException

                Console.WriteLine(new string('-', 40));
                Console.WriteLine(new string(' ', 16) + $"Album");
                Console.WriteLine(new string('-', 40));
                
                List<Song> albumSongs = SongController.GetAll().Where(x => x.AlbumId == id).ToList();


                foreach (var song in albumSongs) {
                    Console.WriteLine(song.ToString() + $", {album.Name}");
                }

                Console.WriteLine(new string('-', 60));
            } else {
                Console.WriteLine("Invalid input. Input should be integer."); // TODO: ArgumentException
            }
        }

        private void Delete() {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Album Album = _albumController.Get(id);
            if(Album == null)
                Console.WriteLine("Album was not found!");

            _albumController.Delete(id);
            Console.WriteLine("This Album has been deleted!");
        }
    }
}
