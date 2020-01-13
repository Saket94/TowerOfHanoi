using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
   public class Problem
    {

        int mod;
        int n, k , a , b , c;
       public string errorTrace = "";
        public Problem()
        {
            mod =Convert.ToInt32 ( Math.Pow(10, 9));
        }

        /// <summary>
        ///  Public method to initiate the gameplay and get expected number
        /// </summary>
        public bool solve(int n, int k,int a,int b,int c)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                this.n = n;
                this.k = k;
                this.a = a;
                this.b = b;
                this.c = c;

                benchmark();

                //Get and print expected number
                Console.WriteLine(("The last nine digit of \u03A3 1<=n<=10000 E(n,10n,3n,6n,9n) is ") + get());
                return true;
            }
            catch (Exception ex)
            {
                errorTrace = "Problem@Solve";
                throw;
            }
        }
        /// <summary>
        ///  Private method to get last 9 digits number of  n between 1 to 100000  E(n,10n,3n,6n,9n)
        /// </summary>
        private int get()
        {
            try
            {
                int total_expected_number = 0;
                int prev_g = 0;
                int curr_g = 1;

                for (int n = 1; n < 10000 + 1; n++)
                {
                    int expected_number = (2 * curr_g * (c - a) * (k - 1) - (2 * k - b - c) * (c - b)) % mod;
                    total_expected_number = (total_expected_number + expected_number) % mod;
                    prev_g = curr_g;
                    curr_g = (curr_g + 2 * prev_g + 1) % mod;
                    k = (k * 10) % mod;
                    a = (a * 3) % mod;
                    b = (b * 6) % mod;
                    c = (c * 9) % mod;
                }
                return total_expected_number;
            }
            catch (Exception ex)
            {
                errorTrace = "Problem@get";
                throw;
            }
        }

        /// <summary>
        ///  Private method to test gameplay
        /// </summary>
        private void benchmark() {
            try
            {
                if (this.n == 0)
                {
                    for (int n = 1; n < 10 + 1; n++)
                    {
                        TowerOfHanoi hanoi = new TowerOfHanoi();
                        Dictionary<movement, int> stat = hanoi.simulate(n);
                        var lines = stat.Select(kvp => "Movement " + kvp.Key.fromPeg + " to " + kvp.Key.toPeg + ": " + kvp.Value.ToString());
                        Console.WriteLine("Movements for "+ n+" disks" + " => \n" + string.Join("\n", lines));
                    }
                }
                else
                {
                    TowerOfHanoi hanoi = new TowerOfHanoi();
                    Dictionary<movement, int> stat = hanoi.simulate(this.n);
                    var lines = stat.Select(kvp => "Movement " + kvp.Key.fromPeg + " to " + kvp.Key.toPeg + ": " + kvp.Value.ToString());
                    Console.WriteLine(n + " => " + string.Join("\n", lines));
                }
                Debug.Assert(getExpectedNumber(2, 5, 1, 3, 5) == 60);
                Debug.Assert(getExpectedNumber(3, 20, 4, 9, 17) == 2358);
            }
            catch (Exception ex)
            {
                errorTrace = "Problem@benchmark";
                throw;
            }

        }
        /// <summary>
        ///  Private method to get expected number of E(n,kn,an,bn,cn,)
        /// </summary>
        public int getExpectedNumber(int n, int k, int a, int b, int c)
        {
            try
            {
                int g = Convert.ToInt32(Math.Pow(2, n + 2) - 3 - (Math.Pow(-1, n))) / 6;

                int val = 2 * g * (c - a) * (k - 1) - (2 * k - b - c) * (c - b);
                return val;
            }
            catch (Exception ex)
            {
                errorTrace = "Problem@getExpectedNumber";
                throw;
            }
        }
    }
}
