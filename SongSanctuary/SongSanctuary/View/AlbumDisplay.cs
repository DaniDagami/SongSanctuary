using Controller.Controller;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSanctuary.View {
    public class AlbumDisplay {
        private int _closeOperationId = 6;
        private AlbumController _AlbumController = new AlbumController();

        public AlbumDisplay() {
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
            int id = int.Parse(Console.ReadLine());
            Album Album = _AlbumController.Get(id);
            if(Album == null)
                Console.WriteLine("Album was not found!");

            _AlbumController.Delete(id);
            Console.WriteLine("This Album has been deleted!");
        }

        private void Add() {
            Album Album = new Album();
            Console.WriteLine("Enter name: ");
            Album.Name = Console.ReadLine();
            Console.WriteLine("Enter release year: ");
            Album.ReleaseYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter song count: ");
            Album.SongCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Do you want to add a BandId? Y for yes/ N for no: ");
            string answer = Console.ReadLine();
            if(answer.ToUpper() == "Y") {
                Album.BandId = int.Parse(Console.ReadLine());
            }
            _AlbumController.Add(Album);
        }

        private void ListAll() {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Albums");
            Console.WriteLine(new string('-', 40));
            var Albums = _AlbumController.GetAll();
            foreach(var Album in Albums) {
                Console.WriteLine($"{Album.Id} {Album.Name} {Album.ReleaseYear} {Album.SongCount} {Album.Band?.Id} {Album.Band?.Name}");
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
