/* JSH (JSHell)
*  Linux Version
*  Stdcmds (Standard Commands), for example, cd is not in /bin, so we use Stdcmds to use our own implementation.
*/

using System;
using System.IO;
using System.Diagnostics;

namespace JSH {
    public class Stdcmds {
        public static void ChangeDir(string input) {
            string olddir = Program.path;
            try {
                if (input.StartsWith("/")) {
                    Program.path = input;
                    Environment.CurrentDirectory = input;
                }
                else {
                    if (Program.path == "/") {
                        Program.path = Program.path + input; // if path is /, and you're doing `cd home`, it would go into /home.
                        Environment.CurrentDirectory = Environment.CurrentDirectory + input;
                    }
                    else {
                        Program.path = Program.path + "/" + input; // if path is /, and you're doing `cd home`, it would go into //home.
                        Environment.CurrentDirectory = Environment.CurrentDirectory + "/" + input;
                    }
                }
            } catch {
                Console.WriteLine($"Failed To 'cd' into {input}");
                Program.path = olddir;
            }
        }
        public static void cdDotDot() {
            Program.path = Program.path.Remove(Program.path.LastIndexOf("/"));
            if (!Program.path.Contains("/")) {
                Program.path = "/";
            }
            Environment.CurrentDirectory = Environment.CurrentDirectory.Remove(Environment.CurrentDirectory.LastIndexOf("/"));
            if (!Environment.CurrentDirectory.Contains("/")) {
                Environment.CurrentDirectory = "/";
            }
        }
        public static void ListDir() {
            Process p = new Process();
            p.StartInfo.FileName = "/bin/ls";
            p.StartInfo.Arguments = $"{Program.path} --color=auto";
            p.Start();
            p.WaitForExit();
        }
        public static void ListDir(string input) {
            Process p = new Process();
            p.StartInfo.FileName = "/bin/ls";
            if (input.StartsWith("/")) {
                p.StartInfo.Arguments = $"{input} --color=auto";
            }
            else {
                if (Program.path == "/") {
                    p.StartInfo.Arguments = $"/{input} --color=auto";
                }
                else {
                    p.StartInfo.Arguments = $"{Program.path}/{input} --color=auto";
                }
            }
            p.Start();
            p.WaitForExit();
        }
    }
}