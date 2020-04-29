using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole2012
{
    public interface IPrintable
    {
        bool CanPrint();
        bool CanFax();
        bool CanMail();
    }

    #region Composition Solution
    public class MailPrinter : IPrintable
    {
        public bool CanPrint()
        {
            return true;
        }

        public bool CanFax()
        {
            return true;
        }

        public bool CanMail()
        {
            return true;
        }
    }

    public class AveragePrinter : IPrintable
    {
        public bool CanPrint()
        {
            return true;
        }

        public bool CanFax()
        {
            return false ;
        }

        public bool CanMail()
        {
            return false;
        }
    }


    public class FaxPrinter : IPrintable
    {
        public bool CanPrint()
        {
            return true;
        }

        public bool CanFax()
        {
            return true;
        }

        public bool CanMail()
        {
            return false;
        }
    }

    public class ManagerCom
    {
        IPrintable print;
        public ManagerCom(IPrintable printer)
        {
            print = printer;
        }

        public void PrintCommand()
        {
            Console.WriteLine("Print Command " + print.CanPrint());
        }

        public void MailCommand()
        {
            Console.WriteLine("Mail Command " + print.CanMail());
        }

        public void FaxCommand()
        {
            Console.WriteLine("Fax Command " + print.CanFax());
        }
    }

    public class LeaderCom
    {
        IPrintable print;
        public LeaderCom(IPrintable printer)
        {
            print = printer;
        }

        public void PrintCommand()
        {
            Console.WriteLine("Print Command " + print.CanPrint());
        }

        public void MailCommand()
        {
            Console.WriteLine("Mail Command " + print.CanMail());
        }

        public void FaxCommand()
        {
            Console.WriteLine("Fax Command " + print.CanFax());
        }
    }
    #endregion

    // Inheritance Solution
    public abstract class EmployeeBase : IPrintable
    {
        public virtual bool CanPrint()
        {
            return false;
        }

        public virtual bool CanFax()
        {
            return false;
        }

        public virtual bool CanMail()
        {
            return false;
        }

        public void PrintCommand()
        {
            Console.WriteLine("Print Command " + this.CanPrint());
        }

        public void FaxCommand()
        {
            Console.WriteLine("Fax Command " + this.CanFax());
        }

        public void MailCommand()
        {
            Console.WriteLine("Mail Command " + this.CanMail());
        }
    }

    public class Manager : EmployeeBase
    {
        public override bool CanPrint()
        {
            return true;
        }

        public override bool CanFax()
        {
            return true;
        }

        public override bool CanMail()
        {
            return true;
        }
    }

    public class Leader : EmployeeBase
    {
        public override bool CanPrint()
        {
            return true;
        }

        public override bool CanFax()
        {
            return true;
        }
    }

    public class Coder : EmployeeBase
    {
        public override bool CanPrint()
        {
            return true;
        }
    }
}
