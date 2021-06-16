using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
//Heron 's formula:
//sqrt (s * (s - a) * (s - b) * (s - c)),
//where s = (a + b + c) / 2.
//Output should have 2 digits precision.

namespace Drafr {

    class Program {

        static void Main(string[] args) {
           var r = Solve("a(b(c))");
            Console.WriteLine(r);
        }

        private static string Solve(string s, string k="") => s == ( k = new Regex(@"\([^()]+\)").Replace(s, "")) ? s : Solve(k,k);
           
        
    }
}
