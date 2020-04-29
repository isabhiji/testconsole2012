using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole2012
{
    class TestAccessModifier
    {
            public int x;
            public int y;
    }

    interface I1
    {
        void add();
        void sub();
    }
    class Employee:I1
    {
        public string name = "xx";
        double salary = 100.00;   // private access by default
        static int count;

        public double AccessSalary()
        {
            return salary;
        }

        public void addCounter()
        {
            count++;
        }

        public int Counter
        {
            get
            {
                return count;
            }
        }

        public void add()
        {
 
        }

        public void sub()
        {

        }
    }

    class Dept : Employee, I1
    {
        public string d = string.Empty;
    }

}
