using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole2012
{
    public class TestValueRefType
    {
        internal static void TestValueType(int x)
        {
            x = 7;
        }

        internal static int TestRefType(object x)
        {
            int y;
            y = (int)x;
            x = 7;
            return (int)y;
        }

        internal static object TestRefType2(ref object x)
        {
            object y;
            y = x;
            x = 7;
            return y;
        }

        internal static void TestStringType(string s)
        {
            //string s2;
            //s2 = s;
            s = "Hello Delhi";
            //return s2;
        }

        internal static void SquareIt(ref int x)
        // The parameter x is passed by reference. 
        // Changes to x will affect the original value of x.
        {
            x *= x;
            System.Console.WriteLine("The value inside the method: {0}", x);
        }

        internal static void TestRefByValueType(TestRef obj)
        {
            obj.i = 10;
        }

    }

    public class TestRef
    {
        public int i;
    }
}
