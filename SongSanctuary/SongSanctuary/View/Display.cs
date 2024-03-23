using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSanctuary.View {
    public abstract class Display {
        public static int closeOperationId = 6;
        public static void ShowCommands() {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Commands");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Return");
            Console.WriteLine(new string('-', 40));
        }
    }
}
