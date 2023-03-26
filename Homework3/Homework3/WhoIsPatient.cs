using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public class WhoIsPatient : Patient
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