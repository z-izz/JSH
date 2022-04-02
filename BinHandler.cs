/* JSH (JSHell)
*  Linux Version
*  Binary Handler (responsible for handling executing programs from /bin)
*/

using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace JSH {
    public class BinHandler {
        public static string[] FindBin(string[] input) {
            bool found = false;
            List<string> constructed = new List<string>();
            foreach (string bin in Directory.GetFiles("/bin/")) {
                if (bin.Remove(0,5) == input[0] && bin != "/bin/ls") {
                    found = true;
                    constructed.Add(bin);
                }
                else {
                    continue;
                }
            }
            if (!found) {
                if (input[0] == "cls") {
                    Console.Clear();
                }
                else if (input[0] == "ls") {
                    if (input.Length == 1) {
                        Stdcmds.ListDir();
                    }
                    else {
                        Stdcmds.ListDir(input[1]);
                    }
                }
                else if (input[0] == "cd") {
                    Stdcmds.ChangeDir(input[1]);
                }
                else if (input[0] == "cd..") {
                    Stdcmds.cdDotDot();
                }
                else {
                    Console.WriteLine($"Command not found: {input[0]}");
                }
                return null;
            }
            else {
                foreach(string i in input.Skip(1).ToArray()) {
                    constructed.Add(i);
                }
                return constructed.ToArray();
            }
        }
        public static void LaunchBin(string[] input) {
            Process p = new Process();
            p.StartInfo.FileName = input[0];
            p.StartInfo.Arguments = string.Join(" ", input.Skip(1).ToArray());
            p.Start();
            p.WaitForExit();
        }
    }
}