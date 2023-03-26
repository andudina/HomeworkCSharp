using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public abstract class Patient
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public string Disease { get; set; }
        public virtual void Information()
        {
            Console.WriteLine($"\n{Name}\nВозраст - {Age}\nМесто жительства - {Adress}\nСтатус - {State}\nБолезнь - {Disease}");
        }
        public virtual void Registration(Doctor doctor)
        {
            Console.WriteLine($"\nЛечащий врач пациента {Name}  - {doctor.Specialization} {doctor.Name}");
        }

    }
}
        
    