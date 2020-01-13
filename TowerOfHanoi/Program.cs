using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create logger object to create logs
            Logger logger = new Logger();

            // Create object of Class Problem to initiate the gameplay and get expected number
            Problem problem = new Problem();
            try
            {
                problem.solve(0, 10, 3, 6, 9);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                logger.CreateLog(ex.Message, "Error", problem.errorTrace);
            }
        }
    }
}
