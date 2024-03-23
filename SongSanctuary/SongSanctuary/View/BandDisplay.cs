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
                        BandController.ListAll();
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

        // Name: {Name}, Active: {(Active ? "Yes" : "No")}, Member Count: {MemberCount}

        private void Add() {
            Band band = new Band();

            Console.WriteLine("Enter name: ");
            band.Name = Console.ReadLine();

            Console.WriteLine("Alive? Y for yes/ N for no: ");
            string answerActive = Console.ReadLine().ToUpper();
            band.Active = answerActive == "Y" ? true : false;


            string memberCount = Console.ReadLine();
            if(!int.TryParse(memberCount, out int members)) {
                throw new ArgumentException("Invalid length format. The count of members will be set to default (0).");
            }
            band.MemberCount = members; // if parsed successfully, sets song.Length to the parsed TimeSpan

            _bandController.Add(band);
        }


        private void Update() {
            
            Console.WriteLine("Enter ID to update:");
            string idTest = Console.ReadLine();

            if(!int.TryParse(idTest, out int id)) {
                throw new ArgumentException("Invalid number format.");
            }

            Band band = _bandController.Get(id);
            Console.WriteLine("Enter name: ");
            band.Name = Console.ReadLine();

            Console.WriteLine("Active? Y for yes/ N for no: ");
            string answerActive = Console.ReadLine().ToUpper();
            band.Active = answerActive == "Y";

            Console.WriteLine("Enter member count: ");
            string memberCount = Console.ReadLine();
            if(!int.TryParse(memberCount, out int members)) {
                throw new ArgumentException("Invalid number format. The count of members will be set to default (0).");
            }
            band.MemberCount = members; // if parsed successfully, sets song.Length to the parsed TimeSpan

            _bandController.Update(band);
        }


        private void Fetch() {
            Console.WriteLine("Enter ID to fetch:");
            AlbumController albumController = new AlbumController();

            if(int.TryParse(Console.ReadLine(), out int id)) {
                Band? band = _bandController.Get(id);

                if(band == null)
                    Console.WriteLine("Band not found!"); // TODO: ArgumentException


                Console.WriteLine(new string('-', 40));
                Console.WriteLine(new string(' ', 16) + "Band");
                Console.WriteLine(new string('-', 40));

                Console.WriteLine(band.ToString());

                Console.WriteLine(new string('-', 40));
            } else {
                Console.WriteLine("Invalid input. Input should be integer."); // TODO: ArgumentExcep    tion
            }
        }

        private void Delete() {
            Console.WriteLine("Enter ID to delete: ");
            if(int.TryParse(Console.ReadLine(), out int id)) {
                Band band = _bandController.Get(id);
                if(band == null) {
                    Console.WriteLine("Band was not found!");
                    return;
                }
                _bandController.Delete(id);
                Console.WriteLine("This band has been deleted!");
            } else {
                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
            }

        }

    }
}
