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
            double X0 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please Enter The Time To Expiration:");
            double T = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please Enter mu:");
            double mu = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please Enter sigma:");
            double sigma = Convert.ToDouble(Console.ReadLine());
            
            Console.WriteLine(X0);
            Console.WriteLine(T);
            Console.WriteLine(mu);
            Console.WriteLine(sigma);
            Console.ReadKey();
        }
    }
}
