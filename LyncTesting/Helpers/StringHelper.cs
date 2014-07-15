using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyncTest.Helpers
{
    public static class StringHelper
    {
        public static bool IsEmpty(this string s)
        {
            return (String.IsNullOrEmpty(s) || String.IsNullOrWhiteSpace(s));
        }

        public static bool ICEquals(this string s1, string s2)
        {
            return (s1.Equals(s2, StringComparison.OrdinalIgnoreCase));
        }
    }
}
