using System.Security.Cryptography.X509Certificates;
namespace Homework_4;

class Program
{
    static void Main(string[] args)
    {
        Counter Tocount = new Counter();
        Handler1 Handler_1 = new Handler1();
        Handler2 Handler_2 = new Handler2();
        Tocount.Stoptocount += Handler_1.Message1;
        Tocount.Stoptocount += Handler_2.Message2;
        Tocount.Count();
    }
}