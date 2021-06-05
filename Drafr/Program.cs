using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

//'Hello world' = true
//' Hello world' = false
//'Hello world  ' = false
//'Hello  world' = false
//'Hello' = true
//// Even though there are no spaces, it is still valid because none are needed
//'Helloworld' = true
//// true because we are not checking for the validity of words.
//'Helloworld ' = false
//' ' = false
//'' = true

namespace Drafr {

    class Program {
        static async Task Main(string[] args) {
            Console.WriteLine("BlcOdVj  s".Trim().Replace("  ",""));
        }
    }
}
