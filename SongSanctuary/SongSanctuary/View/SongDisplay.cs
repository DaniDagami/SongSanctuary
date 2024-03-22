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
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch(operation) {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        //Update();
                        break;
                    case 4:
                        //Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;

                }
            } while(operation != _closeOperationId);
        }

        private void Delete() {
            Console.WriteLine("Enter ID to delete: ");
            if(int.TryParse(Console.ReadLine(), out int id)) {
                Song song = _songController.Get(id);
                if(song == null) {
                    throw new ArgumentException("Song was not found!");
                }
                _songController.Delete(id);
                Console.WriteLine("This song has been deleted!");
            } else {
                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
            }
        }

        private void Add() {
            Song song = new Song();
            Console.WriteLine("Enter name: ");
            song.Name = Console.ReadLine();
            Console.WriteLine("Enter length (format: hh:mm:ss): ");
            string lengthInput = Console.ReadLine();

            if(TimeSpan.TryParse(lengthInput, out TimeSpan length)) {
                song.Length = TimeSpan.Parse(lengthInput);
            } else {
                Console.WriteLine("Invalid length format. Song length will be set to default (0).");
            }

            Console.WriteLine("Enter genre: ");
            song.Genre = Console.ReadLine();
            Console.WriteLine("Do you want to associate the song with an existing album? (Y/N): ");
            string answer = Console.ReadLine();

            if(answer.ToUpper() == "Y") {
                AlbumController albumController = new AlbumController();
                Console.WriteLine("Enter album ID: ");
                if(int.TryParse(Console.ReadLine(), out int albumId)) {
                    Album album = albumController.Get(albumId);
                    if(album != null) {
                        song.AlbumId = albumId;
                    } else {
                        Console.WriteLine("Album not found. Song will not be associated with any album.");
                    }
                } else {
                    Console.WriteLine("Invalid input. Song will not be associated with any album.");
                }
            }
            _songController.Add(song);
        }

        private void ListAll() {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Songs");
            Console.WriteLine(new string('-', 40));
            var songs = _songController.GetAll();
            foreach(var song in songs) {
                Console.WriteLine($"{song.Id} {song.Name} {song.Length} {song.Genre} {song.Album.Id} {song.Album.Name}");
            }
        }

        private void ShowMenu() {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }
    }
}
