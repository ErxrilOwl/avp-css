using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHS_CSS_APP
{
    static class Display
    {
        public static void DisplayMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string str = "   ▄  ▄  ▄ ▄    ▄  ▄  ▄▄▄▄  ▄▄▄▄    ▄  ▄  ▄  ▄▄▄▄  ▄  ▄";

            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 6);
            Console.WriteLine("   ▄  ▄  ▄ ▄    ▄  ▄  ▄▄▄▄  ▄▄▄▄    ▄  ▄  ▄  ▄▄▄▄  ▄  ▄");
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 7);
            Console.WriteLine("   █  █  █ █▀▄  █  █  █  █  █  █    █  █  █  █  █  █  █");
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 8);
            Console.WriteLine("   █  █  █ █  ▀▄█  █  █  █  █▄▄█    █▄▄█  █  █     █▄▄█ ");
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 9);
            Console.WriteLine("█  █  █  █ █    █  █  █  █  █ ▀▄    █  █  █  █ ▀█  █  █");
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 10);
            Console.WriteLine("█▄▄█  █▄▄█ █    █  █  █▄▄█  █  █    █  █  █  █▄▄█  █  █");

            str = "CLASS SECTIONING SYSTEM";
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 12);
            Console.WriteLine(str);

            Console.ForegroundColor = ConsoleColor.Black;
            str = "[a]. Student";
            Console.SetCursorPosition((Console.WindowWidth / 2) - 14, 20);
            Console.WriteLine(str);

            str = "[b]. Class Section";
            Console.SetCursorPosition((Console.WindowWidth / 2) - 14, 22);
            Console.WriteLine(str);

            str = "[c]. Exit";
            Console.SetCursorPosition((Console.WindowWidth / 2) - 14, 24);
            Console.WriteLine(str);
        }

        public static void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string str = "   ▄  ▄  ▄ ▄  ▄  ▄  ▄▄▄▄  ▄▄▄▄   ▄  ▄  ▄  ▄▄▄▄  ▄  ▄";

            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 0);
            Console.WriteLine("   ▄  ▄  ▄ ▄  ▄  ▄  ▄▄▄▄  ▄▄▄▄   ▄  ▄  ▄  ▄▄▄▄  ▄  ▄");
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 1);
            Console.WriteLine("   █  █  █ █▀▄█  █  █  █  █▄▄█   █▄▄█  █  █     █▄▄█ ");
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 2);
            Console.WriteLine("█▄▄█  █▄▄█ █  █  █  █▄▄█  █ ▀▄   █  █  █  █▄▄█  █  █");

            str = "CLASS SECTIONING SYSTEM";
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, 3);
            Console.WriteLine(str);
        }

    }
}
