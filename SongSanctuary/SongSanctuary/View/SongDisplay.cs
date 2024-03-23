using Controller.Controller;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSanctuary.View {
    public class SongDisplay : Display {
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
                        SongController.ListAll();
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
            Song song = new Song();
            Console.WriteLine("Enter name: ");
            song.Name = Console.ReadLine();
            Console.WriteLine("Enter duration (format: mm:ss): ");
            string lengthInput = Console.ReadLine();

            if (!TimeSpan.TryParse(lengthInput, out TimeSpan length)) {
                throw new ArgumentException("Invalid length format. Song length will be set to default (0).");
            }
            song.Length = length; // if parsed successfully, sets song.Length to the parsed TimeSpan

            Console.WriteLine("Enter genre: ");
            song.Genre = Console.ReadLine();
            Console.WriteLine("Do you want to associate the song with an existing album? (Y/N): ");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "Y") {
                AlbumController albumController = new AlbumController();
                AlbumController.ListAll(); // lists all albums so you can choose
                Console.WriteLine("Enter album ID: ");
                if (!int.TryParse(Console.ReadLine(), out int albumId))
                    throw new ArgumentException("Invalid input. Song will not be associated with any album.");

                Album album = albumController.Get(albumId);
                if (album == null)
                    throw new ArgumentException("Album not found. Song will not be associated with any album.");

                song.AlbumId = albumId;
            }
            _songController.Add(song);
        }


        private void Update() {
            SongController.ListAll(); // show all available songs
            Console.WriteLine("Enter ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                throw new ArgumentException("Invalid input. Input should be integer."); // TODO: ArgumentException
            }

            Song song = _songController.Get(id);
            if (song == null)
                throw new ArgumentException("Song not found!"); // TODO: ArgumentException

            string info = song.ToString();
            string title = "Current values for this song are:";
            ShowHeader(info.Length, info, title);

            Console.WriteLine("Enter name: ");
            song.Name = Console.ReadLine();
            Console.WriteLine("Enter duration (format: mm:ss): ");
            song.Length = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine("Enter genre: ");
            song.Genre = Console.ReadLine();
            Console.WriteLine("Do you want to associate the song with an existing album? (Y/N): ");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "Y") {
                AlbumController albumController = new AlbumController();
                AlbumController.ListAll(); // lists all albums so you can choose
                Console.WriteLine("Enter album ID: ");
                if (!int.TryParse(Console.ReadLine(), out int albumId))
                    throw new ArgumentException("Invalid input. Song will not be associated with any album.");

                Album album = albumController.Get(albumId);
                if (album == null)
                    throw new ArgumentException("Album not found. Song will not be associated with any album.");

                song.AlbumId = albumId;
            }
            _songController.Update(song);
        }


        private void Fetch() {
            AlbumController albumController = new AlbumController();
            string title = "Song";

            Console.WriteLine("Enter ID to fetch:");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                throw new ArgumentException("Invalid input. Input should be integer."); // TODO: ArgumentException
            }
            Song? song = _songController.Get(id);

            if (song == null)
                Console.WriteLine("Song not found!"); // TODO: ArgumentException

            Album? album = albumController.Get(song.AlbumId);
            string info = album.ToString();
            info += album is null ? $", Album Name: N/A" : $", Album Name: {album?.Name}";
            int maxCharacterLength = info.Length;

            ShowHeader(maxCharacterLength, info, title);
        }

        private void Delete() {
            Console.WriteLine("Enter ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id)) {
                Song song = _songController.Get(id);
                if (song == null) {
                    throw new ArgumentException("Song was not found!");                 
                }
                _songController.Delete(id);
                Console.WriteLine("This song has been deleted!");
            } else {
                throw new ArgumentException("Invalid input. Please enter a valid integer ID.");
            }

        }
    }
}
