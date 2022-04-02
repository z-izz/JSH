/* JSH (JSHell)
*  Linux Version
*  Main File
*/ 


using System;
using System.IO;
using System.Diagnostics;

namespace JSH {
    public class Program {
        public static string user = Environment.UserName; // USER
        public static string mname = Environment.MachineName; // MACHINE NAME
        public static string path = Directory.GetCurrentDirectory(); // PATH
        public static string command; // COMMAND INPUT
        public static void Main(string[] args) {
            while (true) {
                ShellPrompt.Prompt(); // PROMPT
                command = Console.ReadLine();
                string[] bin = BinHandler.FindBin(command.Split(" "));
                if (bin != null) {
                    BinHandler.LaunchBin(bin);
                }
            }
        }
    }
}