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
                        ArtistController.ListAll();
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
                        //Delete();
                        break;
                    default:
                        break;

                }
            } while (operation != closeOperationId);
        }


        private void Add() {
            Artist artist = new Artist();

            Console.WriteLine("Enter first name: ");
            artist.FullName = Console.ReadLine(); 

            Console.WriteLine("Enter last name: ");
            artist.LastName = Console.ReadLine();

            Console.WriteLine("Alive? Y for yes/ N for no: ");
            string answerAlive = Console.ReadLine().ToUpper();
            artist.Alive = answerAlive == "Y" ? true : false;

            Console.WriteLine("Do you want to add a BandId? Y for yes/ N for no: ");
            string answerBandId = Console.ReadLine().ToUpper();
            if (answerBandId == "Y") {
                artist.BandId = int.Parse(Console.ReadLine());
            }
            _artistController.Add(artist);
        }


    }
}

