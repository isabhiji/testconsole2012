using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace TestConsole2012
{

    class Program
    {

        TestEvent objEvent;
        public static ManualResetEvent me = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            #region ManualReset Event
            Console.WriteLine("Starting Main thread");
            new Thread(DoSomeWork).Start();
            
            Console.ReadLine();
            me.Set();
            me.Reset();
            new Thread(DoSomeOtherWork).Start();
            Console.ReadLine();
            me.Set();
        #endregion

            #region Composition Example
            ////IPrintable Printer = new MailPrinter();
            ////ManagerCom managerCom = new ManagerCom(Printer);

            ////Console.WriteLine("Printing Manager Acccess");
            ////managerCom.MailCommand();
            ////managerCom.PrintCommand();
            ////managerCom.FaxCommand();

            ////Console.WriteLine("\nPrinting Leader Acccess");
            ////Printer = new FaxPrinter();
            ////LeaderCom leaderCom = new LeaderCom(Printer);
            ////leaderCom.MailCommand();
            ////leaderCom.PrintCommand();
            ////leaderCom.FaxCommand();
            #endregion

            #region Inheritance Example
            ////Console.WriteLine("\nPrinting Manager Acccess");
            ////EmployeeBase employee = new Manager();
            ////employee.PrintCommand();
            ////employee.MailCommand();
            ////employee.FaxCommand();

            ////Console.WriteLine("\nPrinting Leader Acccess");
            ////employee = new Leader();
            ////employee.MailCommand();
            ////employee.PrintCommand();
            ////employee.FaxCommand();

            #endregion

            #region Test Covariance
            //List<B> bList = new List<B>();
            //bList.Add(new B());
            //// List<A> newList = bList.Cast<A>().ToList();
            //testConversion(bList);
            #endregion

            // Method1(); // To test auto window  
            Program p = new Program();
            Employee e = new Dept();
            Dept d = (Dept)e;

            //Employee e = new Dept();
            //Dept a = e as Dept;
            //string str = a.d;
            
            // p.CallDelegate();
            // Method();
            // Console.WriteLine("Main Thread");
            // Method2();
            // TestExpression.SampleExpression(2);
            // TestExpression.SampleExpression(20);

            #region ValueTypeRefType Examples
            //int num = 5;
            //TestValueRefType.TestValueType(num);
            //System.Console.WriteLine(num);

            //int b = TestValueRefType.TestRefType(5);
            //object x = 5;
            //int c = (int)TestValueRefType.TestRefType2(ref x);

            //// Passing reference by Value Example, in string not work as string is mutable
            //string s = "Hello";
            //TestValueRefType.TestStringType(s);
            //Console.WriteLine("New Value of string" + s);

            //TestRef obj = new TestRef();
            //obj.i = 5;
            //TestValueRefType.TestRefByValueType(obj);
            //Console.WriteLine("New Value i" + obj.i.ToString());
            ////****************

            //int n = 5;
            //System.Console.WriteLine("The value before calling the method: {0}", n);

            //TestValueRefType.SquareIt(ref n);  // Passing the variable by reference.
            //System.Console.WriteLine("The value after calling the method: {0}", n);

            //// Keep the console window open in debug mode.
            //System.Console.WriteLine("Press any key to exit.");
            //System.Console.ReadKey();


            #endregion

            #region AccessModifier Examples
            /* TestAccessModifier mC = new TestAccessModifier();
            // Direct access to public members:
            mC.x = 10;
            mC.y = 15;
            Console.WriteLine("x = {0}, y = {1}", mC.x, mC.y);

            Employee e = new Employee();
            e.addCounter();
            Employee e2 = new Employee();
            e2.addCounter();
            Console.WriteLine(e.Counter);
            Console.WriteLine(e2.Counter);

            // Accessing the public field:
            string name = e.name;

            // Accessing the private field:
            // double s = e.salary;
            double s2 = e.AccessSalary();
            Console.WriteLine(string.Format("Name: {0}, Salary: {1}", name, s2));
            */


            #endregion

            #region Yield Example
            //// Display powers of 2 up to the exponent of 8: 
            //foreach (int i in TestYield.Power(2, 8))
            //{
            //    Console.Write("{0} ", i);
            //}
            //#endregion

            //Console.ReadLine();
            #endregion
        }

        private static void DoSomeWork()
        {
            Console.WriteLine("Before wait");
            // me.Reset();// here this thread is controling thread causing other thread to wait because of Reset
            me.WaitOne();
            Console.WriteLine("After wait");
        }

        private static void DoSomeOtherWork()
        {
            Console.WriteLine("Before Other wait");
            me.WaitOne();
            Console.WriteLine("After Other wait");
        }

        private static void testConversion(IEnumerable<A> aList)
        {
            Console.WriteLine("Allowing child collection to be passed in place of Base collection " + aList.First().commonA + " " + aList.First().commonName);
        }
    
        void fn1(Employee e)
        {
            
        }

        private void CallDelegate()
        {
            objEvent = new TestEvent();
            TestConsole2012.TestEvent.del1 d;
            // Possible for Delegate
            d = fn1;
            d(3, 6);

            // Not Posible for event
            // TestConsole2012.TestEvent.myEvent=fn1;
            objEvent.myEvent += objEvent_myEvent;
            objEvent.RaiseEvent();
        }

        int objEvent_myEvent(int i, int j)
        {
            return i + j;
        }

        private int fn1(int x, int y)
        {
            return x + y;
        }

        #region To Test Auto Window
        static void Method1()
        {
            // 1. Step over the following line
            int result = Multiply(FourTimes(Five()), Six());
            // 2. Then view the return values in the Autos window
        }

        static int Multiply(int x, int y)
        {
            return x * y;
        }

        static int FourTimes(int x)
        {
            return 4 * x;
        }

        static int Five()
        {
            return 5;
        }

        static int Six()
        {
            return 6;
        }
        #endregion

        public static async void Method()
        {
            await Task.Run(new Action(LongTask));
            Console.WriteLine("New Thread from Await Keyword");
        }

        public static void Method2()
        {
            ActionTask(() => Console.WriteLine("New Thread from Action Call back"));
        }

        private static void LongTask()
        {
            Thread.Sleep(6000);
        }

        private static void ActionTask(Action action)
        {
            Thread.Sleep(3000);
            action();
        }

    }

    
}
    
