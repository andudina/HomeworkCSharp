using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public abstract class Doctor
    { 
        public string Name { get; set; }
        
        public  int Age { get; set; }
        
        public  string Specialization { get; set; }  // специальность
        public  int Experience { get; set; } // стаж

        public virtual void Information()
        {
            Console.WriteLine($"\n{Name}\nВозраст - {Age}\nСпециализация - {Specialization}\nСтаж - {Experience}");
        }
        



    }
}


