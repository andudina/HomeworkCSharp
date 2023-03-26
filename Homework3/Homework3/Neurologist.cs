using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    internal class Neurologist : Doctor
    {
        public virtual void Heal(Patient patient)
        {
            if (new Random().Next(0, 10) > 5)
            {
                patient.State = "здоров";
                Console.WriteLine($"\nЛечение пациента {patient.Name} успешно");
            }
            else
            {
                patient.State = "нездоров";
                Console.WriteLine($"\nЛечение пациента {patient.Name} неуспешно");
            }
        }

    }
}
  
