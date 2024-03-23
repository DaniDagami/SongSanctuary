using Controller.Controller;
using Controller.Interfaces;
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
                        _albumController.ListAll();
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
            Album album = new Album();

            Console.WriteLine("Enter name: ");
            album.Name = Console.ReadLine();

            Console.WriteLine("Enter release year: ");
            album.ReleaseYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter song count: ");
            album.SongCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Do you want to add a BandId? Y for yes/ N for no: ");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "Y") {
                BandController bandController = new BandController();
                bandController.ListAll();
                Console.WriteLine("Enter band ID: ");
                if (!int.TryParse(Console.ReadLine(), out int bandId))
                    throw new ArgumentException("Invalid input. Album will not be associated with any band.");

                Band band = bandController.Get(bandId);
                if (band == null)
                    throw new ArgumentException("Band not found. Album will not be associated with any band.");

                album.BandId = bandId;
            }
            _albumController.Add(album);
        }

        private void Update() {
            _albumController.ListAll(); // shows all available albums
            Console.WriteLine("Enter ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new ArgumentException("Invalid input. Input should be integer.");
            Console.Clear();

            Album album = _albumController.Get(id) ?? throw new ArgumentException("Album not found!");

            string info = album.ToString();
            string title = "Current values for this album are:";
            ShowHeader(info.Length, info, title);

            Console.WriteLine("Enter name: ");
            album.Name = Console.ReadLine();

            Console.WriteLine("Enter release year: ");
            album.ReleaseYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter song count: ");
            album.SongCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Do you want to associate the album with an existing band (Y/N): ");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "Y") {
                BandController bandController = new BandController();
                bandController.ListAll();
                Console.WriteLine("Enter band ID: ");
                if (!int.TryParse(Console.ReadLine(), out int bandId))
                    throw new ArgumentException("Invalid input. Album will not be associated with any band.");

                Band band = bandController.Get(bandId);
                if (band == null)
                    throw new ArgumentException("Band not found. Album will not be associated with any band.");

                album.BandId = bandId;
            }
            _albumController.Update(album);
        }

        private void Fetch() {
            BandController bandController = new BandController();
            SongController songController = new SongController();
            _albumController.ListAll(); // shows all available albums
            
            Console.WriteLine("Enter ID to fetch:");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new ArgumentException("Invalid input. Input should be integer.");

            Console.Clear();

            Album? album = _albumController.Get(id) ?? throw new ArgumentException("Album not found!");


            List<string> albumSongInfos = songController.GetAll().Where(x => x.AlbumId == id).Select(s => s.ToString()).ToList();
            int maxCharacterLenght = albumSongInfos.Max(x => x.Length);
            StringBuilder info = new StringBuilder();
            foreach (var song in albumSongInfos) {
                info.AppendLine(song);
            }

            ShowHeader(maxCharacterLenght, info.ToString().Trim(), album.Name);
        }

        private void Delete() {
            _albumController.ListAll();
            Console.WriteLine("Enter ID to delete: ");

            if(!int.TryParse(Console.ReadLine(), out int id))
                throw new ArgumentException("Invalid input. Please enter a valid integer ID.");
            Console.Clear();

            Album Album = _albumController.Get(id) ?? throw new ArgumentException("Album was not found!");

            _albumController.Delete(id);
            Console.WriteLine("This album has been deleted!");
        }
    }
}
