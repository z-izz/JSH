/* JSH (JSHell)
*  Linux Version
*/ 


using System;
using System.IO;
using System.Diagnostics;

namespace JSH {
    public class Program {
        public static string user = Environment.UserName; // USER
        public static string mname = Environment.MachineName; // MACHINE NAME
        public static string path = Directory.GetCurrentDirectory();
        public static string command; // COMMAND INPUT
        public static void Main(string[] args) {
            while (true) {
                Prompt(); // PROMPT
                command = Console.ReadLine();
                bool found = false;
                foreach (string bin in Directory.GetFiles("/bin/")) {
                    if (bin.Remove(0,5) == command.Split(" ")[0] && bin != "/bin/ls") {
                        found = true;
                        Process p = new Process();
                        p.StartInfo.FileName = bin;
                        p.StartInfo.Arguments = command.Remove(0,command.Split(" ")[0].Length);
                        p.Start();
                        p.WaitForExit();
                    }
                    else {
                        continue;
                    }
                }
                if (found == false) {
                    if (command.Split(" ")[0] == "cls") {
                        Console.Clear();
                    }
                    else if (command.Split(" ")[0] == "ls") {
                        Process p = new Process();
                        p.StartInfo.FileName = "/bin/ls";
                        p.StartInfo.Arguments = $"{path} --color=auto";
                        p.Start();
                        p.WaitForExit();
                    }
                    else if (command.Split(" ")[0] == "cd") {
                        if (command.Split(" ")[1].StartsWith("/")) {
                            path = command.Split(" ")[1];
                        }
                        else {
                            if (path == "/") {
                                path = path + command.Split(" ")[1];
                            }
                            else {
                                path = path + "/" + command.Split(" ")[1];
                            }
                        }
                    }
                    else if (command.Split(" ")[0] == "cd..") {
                        path = path.Remove(path.LastIndexOf("/"));
                        if (!path.Contains("/")) {
                            path = "/";
                        }
                    }
                    else {
                        Console.WriteLine($"Command not found: {command.Split(" ")[0]}");
                    }
                }
            }
        }

        public static void Prompt() {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("╭ ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(user);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(mname);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" [ {path.Replace($"/home/{user}", "~")} ]"); // PATH
            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (user == "root") {
                Console.Write("╰ # "); // IF USER IS ROOT
            }
            else {
                Console.Write("╰ $ "); // IF NORMAL USER
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}