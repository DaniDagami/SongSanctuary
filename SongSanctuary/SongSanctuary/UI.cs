using SongSanctuary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSanctuary {
    public class UI {
        private int _closeOperationId = 5;
        public UI() {
            Input();
        }
        public void Menu() {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Songs");
            Console.WriteLine("2. Albums");
            Console.WriteLine("3. Artists");
            Console.WriteLine("4. Bands");
            Console.WriteLine("5. Exit");
        }
    
        private void Input() {
            var operation = -1;
            do {
                Menu();
                operation = int.Parse(Console.ReadLine());
                switch(operation) {
                    case 1:
                        SongDisplay songDisplay = new SongDisplay();
                        break;
                    case 2:
                        AlbumDisplay albumDisplay = new AlbumDisplay();
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                }
            } while(operation != _closeOperationId);
        }
    }
}
