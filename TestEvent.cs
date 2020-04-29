using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole2012
{
    public class TestEvent
    {
        public delegate int del1(int i,int j);
        public event del1 myEvent;
        private del1 objDel;
        public TestEvent()
        {
            setDelegate();
        }

        public void setDelegate()
        {
            del1 objDel = fn1;
        }

        public void RaiseEvent()
        {
            objDel.Invoke(2,4);
            if (myEvent != null)
                myEvent(3, 6);
        }

        private int fn1(int x, int y)
        {
            return x + y;
        }
    }
}
