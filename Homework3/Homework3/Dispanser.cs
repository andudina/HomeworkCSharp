using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    internal class Dispanser : Patient
    {
        
            public bool Dispanserisation { get; set; }

            public override void Information()
            {
                base.Information();
                if (Dispanserisation == true)
                {
                    Console.WriteLine("В текущем году пациент прошел диспансеризацию");
                }
            }
        
    }
}
