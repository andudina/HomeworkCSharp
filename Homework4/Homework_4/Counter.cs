using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4
{
    internal class Counter
    {
        public delegate void CountMethod();
        public event CountMethod Stoptocount;
        public void Count()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 77)
                {
                    Stoptocount();
                }
            }
        }
    }
}
