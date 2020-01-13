using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    public class TowerOfHanoi
    {
        private List<movement> movements;
        public string errorTrace = "";
        Logger logger;
        public TowerOfHanoi()
        {
            logger = new Logger();
            movements = new List<movement>();
        }

        /// <summary>
        ///  Public method to simulate Tower of Hanoi GamePlay
        /// </summary>
        public Dictionary<movement, int> simulate(int n)
        {
            try
            {
                int a = 0, b = 1, c = 2;
                _moveTower(n, a, c, b);
                return _statistics(a, b, c);
            }
            catch (Exception ex)
            {
                errorTrace = "TowerOfHanoi@simulate";
                logger.CreateLog(ex.Message, "Error", errorTrace);
                throw;
            }
        }

        /// <summary>
        ///  private method to move Tower
        /// </summary>
        private void _moveTower(int height, int fromPeg, int toPeg, int withPeg)
        {
            try
            {
                if (height >= 1)
                {
                    _moveTower(height - 1, fromPeg, withPeg, toPeg);
                    _moveDisk(fromPeg, toPeg);
                    _moveTower(height - 1, withPeg, toPeg, fromPeg);
                }
            }
            catch (Exception)
            {
                errorTrace = "TowerOfHanoi@moveTower";
                throw;
            }
        }

        /// <summary>
        ///  private method to add movements into List
        /// </summary>
        private void _moveDisk(int fromPeg, int toPeg)
        {
            try
            {
                movements.Add(new movement { fromPeg = fromPeg, toPeg = toPeg });
            }
            catch (Exception)
            {
                errorTrace = "TowerOfHanoi@moveDisk";
                throw;
            }
        }

        /// <summary>
        ///  private method to calculate statistics of movement of BOB during gameplay
        /// </summary>
        private Dictionary<movement, int> _statistics(int a, int b, int c)
        {
            try
            {
                Dictionary<movement, int> stat = new Dictionary<movement, int>();
                int movementCount = movements.Count();
                for (int i = 0; i < movementCount - 1; i++)
                {
                    int currFromPeg = this.movements[i].fromPeg;
                    int currToPeg = this.movements[i].toPeg;
                    int nextFromPeg = this.movements[i + 1].fromPeg;
                    int nextToPeg = this.movements[i + 1].toPeg;
                    foreach (movement currMovement in new List<movement>() { new movement { fromPeg = currFromPeg, toPeg = currToPeg }, new movement { fromPeg = currToPeg, toPeg = nextFromPeg } })
                    {
                        if (stat.Any(tr => tr.Key.Equals(currMovement)))
                        {
                            stat.Add(currMovement, 0);
                        }
                        if (stat.ContainsKey(currMovement))
                        {
                            stat[currMovement] += 1;
                        }
                        else
                        {
                            stat.Add(currMovement, 1);
                        }

                    }

                    movement currMovementTemp = this.movements[movementCount - 1];
                    if (stat.Any(tr => tr.Key.Equals(currMovementTemp)))
                    {
                        stat[currMovementTemp] = 0;

                    }
                    if (stat.ContainsKey(currMovementTemp))
                    {
                        stat[currMovementTemp] += 1;
                    }
                    else
                    {
                        stat.Add(currMovementTemp, 1);
                    }
                }
                return _mergeStatistics(stat, a, b, c);
            }
            catch (Exception)
            {
                errorTrace = "TowerOfHanoi@statistics";
                throw;
            }
        }

        /// <summary>
        ///  private method to merge statistics of movement of BOB during gameplay into the dictionary.
        /// </summary>
        private Dictionary<movement, int> _mergeStatistics(Dictionary<movement, int> stat, int a, int b, int c)
        {

            try
            {
                if (stat.Any(tr => tr.Key.Equals(new movement { fromPeg = a, toPeg = b })) && stat.Any(tr => tr.Key.Equals(new movement { fromPeg = b, toPeg = c })) && (stat[new movement { fromPeg = a, toPeg = b }] == stat[new movement { fromPeg = b, toPeg = c }]))
                {
                    if (!stat.Any(tr => tr.Key.Equals(new movement { fromPeg = a, toPeg = c })))
                    {
                        stat[new movement { fromPeg = a, toPeg = c }] = 0;
                    }

                    stat[new movement { fromPeg = a, toPeg = c }] += stat[new movement { fromPeg = a, toPeg = b }];
                    stat.Remove(new movement { fromPeg = a, toPeg = b });
                    stat.Remove(new movement { fromPeg = b, toPeg = c });
                }

                if (stat.Any(tr => tr.Key.Equals(new movement { fromPeg = c, toPeg = b })) && stat.Any(tr => tr.Key.Equals(new movement { fromPeg = b, toPeg = a })) && (stat[new movement { fromPeg = c, toPeg = b }] == stat[new movement { fromPeg = b, toPeg = a }]))
                {
                    if (!stat.Any(tr => tr.Key.Equals(new movement { fromPeg = c, toPeg = a })))
                    {
                        stat[new movement { fromPeg = c, toPeg = a }] = 0;
                    }

                    stat[new movement { fromPeg = c, toPeg = a }] += stat[new movement { fromPeg = c, toPeg = b }];
                    stat.Remove(new movement { fromPeg = c, toPeg = b });
                    stat.Remove(new movement { fromPeg = b, toPeg = a });
                }
                return stat;
            }
            catch (Exception)
            {
                errorTrace = "TowerOfHanoi@mergeStatistics";
                throw;
            }
        }
    }

}
