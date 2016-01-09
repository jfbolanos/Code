using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization;
using System.Drawing;
using System.Windows.Forms;


namespace EuroCallOption
{
    class Discretization
    {
        
        public Discretization()
        {

        }

        public double Euler(double X0, double mu, double sigma, double delta, double Z)
        {
            return X0 + mu * X0 * delta + sigma * X0 * Math.Sqrt(delta) * Z;
        }


    }
    class EuroCallPrice
    {
        static void Main(string[] args)
        {
            double[] UnderlyingPrice;
            double[] CallPrice;
            Random r = new Random(); ///this is the class used to generate random variables
            Discretization disc = new Discretization();
            System.Windows.Forms.DataVisualization.Charting.Chart chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart.ChartAreas.Add("ChartArea1");
            
            Console.WriteLine("Please Enter The Initial Asset Price:");
            double X0 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please Enter The Strike Price of the Option:");
            double K = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please Enter The Time To Expiration:");
            double T = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please Enter mu:");
            double mu = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please Enter sigma:");
            double sigma = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter The Number of Simulations to Run:");
            int N = Convert.ToInt32(Console.ReadLine());
            
            int m = 400; ///Number of increments between t = 0 and t = T
            double delta = T / m; ///size of the increment
            CallPrice = new double[N]; ///now allocating the size of array based on the number of simulations
            double U1;
            double U2;
            double Z;
            double sum1 = 0;
            double sum2 = 0;
            double OptionPrice;
            double StandardError;
            UnderlyingPrice = new double[m+1];

            for (int i = 0; i < N; i++)
            {
                chart.Series.Add(Convert.ToString(i));
                chart.Series[Convert.ToString(i)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                UnderlyingPrice[0] = X0;
                chart.Series[Convert.ToString(i)].Points.AddXY(0, UnderlyingPrice[0]);

                for (int j = 0; j < m; j++)
                {

                    U1 = r.NextDouble();
                    U2 = r.NextDouble();
                    Z = Math.Sqrt(-2 * Math.Log(U1)) * Math.Cos(2 * Math.PI * U2);
                    UnderlyingPrice[j + 1] = disc.Euler(UnderlyingPrice[j], mu, sigma, delta, Z);
                    chart.Series[Convert.ToString(i)].Points.AddXY(delta*(j + 1), UnderlyingPrice[j + 1]);
                    

                }

                CallPrice[i] = Math.Max(0, UnderlyingPrice[m] - K);

            }

            for (int a = 0; a < N; a++ )
            {
                sum1 = sum1 + CallPrice[a];

            }

            //Calculate the average which represents the option price
            OptionPrice = sum1 / N;

            for (int b = 0; b < N; b++)
            {
                sum2 = sum2 + Math.Pow((CallPrice[b] - OptionPrice), 2);
            }

            StandardError = Math.Sqrt(sum2 / (N - 1)) / Math.Sqrt(N);

            Console.WriteLine("The Price of the Option is: " + OptionPrice);
            Console.WriteLine("The Standard Error of the Simulation is: " + StandardError);

            chart.SaveImage("StockPath.png", System.Drawing.Imaging.ImageFormat.Png);


            Console.ReadKey();
        }
    }
}
