using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
//"This is a test sentence."  ==>  "1a1c4e1h2i2n4s4t"
namespace Drafr {

    class Program {

        static void Main(string[] args) {
            Loneliest("abc");
        }
        public static char[] Loneliest(string result) {
            var dic = new Dictionary<char, int>();
            var sp = 0; char cur = '\0';
            foreach (var c in result) {
                if (c == ' ') sp++;
                if (Regex.IsMatch(c + "", "[a-z]")) {
                    dic[c] = sp;
                    if (cur != '\0') dic[cur] += sp;
                    cur = c;
                    sp = 0;
                }
            }
            var max = dic.Max(v => v.Value);
            var res = dic.Where(v => v.Value == max).Select(v => v.Key);
            return res.ToArray();
        }
    }
}
