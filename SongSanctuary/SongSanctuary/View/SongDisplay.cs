using Controller.Controller;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSanctuary.View {
    public class SongDisplay {
        private int _closeOperationId = 6;
        private SongController _songController = new SongController();

        public SongDisplay() {
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
                        _songController.ListAll();
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
            } while (operation != _closeOperationId);
        }


        /*private void ListAll() {
            AlbumController albumController = new AlbumController();
            var songs = _songController.GetAll();

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Songs");
            Console.WriteLine(new string('-', 40));

            foreach (var song in songs) {
                Album? album = albumController.Get(song.AlbumId);
                Console.WriteLine(album == null ? song.ToString() : song.ToString() + $", AlbumId: {album.Id}, AlbumName: {album.Name}");
            }
            Console.WriteLine(new string('-', 40));
        }*/


        private void Add() {
            Song song = new Song();
            Console.WriteLine("Enter name: ");
            song.Name = Console.ReadLine();
            Console.WriteLine("Enter duration (format: mm:ss): ");
            string lengthInput = Console.ReadLine();

            if (!TimeSpan.TryParse(lengthInput, out TimeSpan length)) {
                Console.WriteLine("Invalid length format. Song length will be set to default (0).");
            }
            song.Length = length; // if parsed successfully, sets song.Length to the parsed TimeSpan

            Console.WriteLine("Enter genre: ");
            song.Genre = Console.ReadLine();
            Console.WriteLine("Do you want to associate the song with an existing album? (Y/N): ");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "Y") {
                AlbumController albumController = new AlbumController();
                albumController.ListAll(); // lists all albums so you can choose
                Console.WriteLine("Enter album ID: ");
                if (!int.TryParse(Console.ReadLine(), out int albumId))
                    Console.WriteLine("Invalid input. Song will not be associated with any album.");

                Album album = albumController.Get(albumId);
                if (album == null)
                    Console.WriteLine("Album not found. Song will not be associated with any album.");

                song.AlbumId = albumId;
            }
            _songController.Add(song);
        }


        private void Update() {
            Console.WriteLine("Enter ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                Console.WriteLine("Invalid input. Input should be integer."); // TODO: ArgumentException
            }

            Song song = _songController.Get(id);
            if (song != null)
                Console.WriteLine("Song not found!"); // TODO: ArgumentException

            Console.WriteLine("Current value for this product are:");
            Console.WriteLine(song.ToString());
            Console.WriteLine("Enter name: ");
            song.Name = Console.ReadLine();
            Console.WriteLine("Enter duration (format: mm:ss): ");
            song.Length = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine("Enter genre: ");
            song.Genre = Console.ReadLine();
            Console.WriteLine("Enter albumId: ");
            song.AlbumId = int.Parse(Console.ReadLine());
            _songController.Update(song);
        }


        private void Fetch() {
            Console.WriteLine("Enter ID to fetch:");
            AlbumController albumController = new AlbumController();

            if (int.TryParse(Console.ReadLine(), out int id)) {
                Song? song = _songController.Get(id);

                if (song == null)
                    Console.WriteLine("Song not found!"); // TODO: ArgumentException


                Console.WriteLine(new string('-', 40));
                Console.WriteLine(new string(' ', 16) + "Song");
                Console.WriteLine(new string('-', 40));

                Album? album = albumController.Get(song?.AlbumId);
                Console.WriteLine(album == null ? song?.ToString() : song?.ToString() + $", AlbumId: {album.Id}, AlbumName: {album.Name}");
                Console.WriteLine(new string('-', 40));
            } else {
                Console.WriteLine("Invalid input. Input should be integer."); // TODO: ArgumentException
            }
        }

        private void Delete() {
            Console.WriteLine("Enter ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id)) {
                Song song = _songController.Get(id);
                if (song == null) {
                    Console.WriteLine("Song was not found!");
                    return;
                }
                _songController.Delete(id);
                Console.WriteLine("This song has been deleted!");
            } else {
                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
            }
        }

        private void ShowCommands() {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Commands");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
            Console.WriteLine(new string('-', 40));
        }
    }
}
