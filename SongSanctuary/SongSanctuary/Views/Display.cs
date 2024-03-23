using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSanctuary.View {
    public abstract class Display {
        public static int closeOperationId = 6;
        public static void ShowCommands() {
            Console.WriteLine(new string('-', 31));
            Console.WriteLine(new string(' ', 11) + "Commands");
            Console.WriteLine(new string('-', 31));
            Console.WriteLine(new string(' ', 5) + "1. List all entries");
            Console.WriteLine(new string(' ', 5) + "2. Add new entry");
            Console.WriteLine(new string(' ', 5) + "3. Update entry");
            Console.WriteLine(new string(' ', 5) + "4. Fetch entry by ID");
            Console.WriteLine(new string(' ', 5) + "5. Delete entry by ID");
            Console.WriteLine(new string(' ', 5) + "6. Return");
            Console.WriteLine(new string('-', 31));
        }

        protected static void ShowHeader(int maxCharacterLength, string info, string title) {
            Console.WriteLine(new string('-', maxCharacterLength));
            Console.WriteLine(new string(' ', (maxCharacterLength - title.Length) / 2) + title);
            Console.WriteLine(new string('-', maxCharacterLength));
            Console.WriteLine(info);
            Console.WriteLine(new string('-', maxCharacterLength));
        }
    }
}
