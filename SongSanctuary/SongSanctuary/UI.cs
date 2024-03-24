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
        public void ShowCommands() {
            Console.WriteLine(new string('-', 91));
            Console.WriteLine(new string(' ', 41) + "Commands");
            Console.WriteLine(new string('-', 91));
            Console.WriteLine(new string(' ', 40) + "1. Songs");
            Console.WriteLine(new string(' ', 40) + "2. Albums");
            Console.WriteLine(new string(' ', 40) + "3. Artists");
            Console.WriteLine(new string(' ', 40) + "4. Bands");
            Console.WriteLine(new string(' ', 40) + "5. Exit");
            Console.WriteLine(new string('-', 91));
        }

        private void Input() {
            var operation = -1;
            do {
                try {
                    ShowCommands();
                    operation = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (operation) {
                        case 1:
                            SongDisplay songDisplay = new SongDisplay();
                            break;
                        case 2:
                            AlbumDisplay albumDisplay = new AlbumDisplay();
                            break;
                        case 3:
                            ArtistDisplay artistDispay = new ArtistDisplay();
                            break;
                        case 4:
                            BandDisplay bandDispay = new BandDisplay();
                            break;
                        case 5:

                            break;
                    }
                }
                catch (ArgumentException ae) {
                    Console.WriteLine(ae);
                }
                catch (Exception e) {
                    Console.WriteLine("Error!");
                }
            } while (operation != _closeOperationId);

        }
    }
}
