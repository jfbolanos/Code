using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroCallOption
{
    class EuroCallPrice
    {
        static void Main(string[] args)
        {
            double[] UnderlyingPrice;
            double[] CallPrice;
            Random r = new Random(); ///this is the class used to generate random variables
            
            Console.WriteLine("Please Enter The Initial Asset Price:");
            double X0 = Console.ReadLine();
            Console.WriteLine("Please Enter The Time To Expiration:");
            double T = Console.ReadLine();
            Console.WriteLine("Please Enter mu:");
            double mu = Console.ReadLine();
            Console.WriteLine("Please Enter sigma:");
            double sigma = Console.ReadLine();
            
            Console.ReadLine();
        }
    }
}
