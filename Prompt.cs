/* JSH (JSHell)
*  Linux Version
*  Prompt ($)
*/ 


using System;
using System.IO;
using System.Diagnostics;

namespace JSH {
    public class ShellPrompt {
        public static void Prompt() {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("╭ ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(Program.user);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(Program.mname);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" [ {Program.path.Replace($"/home/{Program.user}", "~")} ]"); // PATH
            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (Program.user == "root") {
                Console.Write("╰ # "); // IF USER IS ROOT
            }
            else {
                Console.Write("╰ $ "); // IF NORMAL USER
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}