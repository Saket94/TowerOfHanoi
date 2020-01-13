using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerOfHanoi;

namespace TowerOfHanoiTestCases
{
    [TestClass]
   public class TowerOfHanoiTest
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        [DeploymentItem("TowerOfHanoiTestCases\\TestDataFiles\\TowerOfHanoiTestData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "|DataDirectory|\\TestDataFiles\\TowerOfHanoiTestData.xml",
                   "Row",
                    DataAccessMethod.Sequential)]
        public void TestSolve()
        {
            int n;
            if (!string.IsNullOrEmpty((string)TestContext.DataRow["n"]))
            {

                bool isNumeric = int.TryParse((string)TestContext.DataRow["n"], out n);
                if (isNumeric)
                {

                    TowerOfHanoi.TowerOfHanoi towerOfHanoi = new TowerOfHanoi.TowerOfHanoi();
                    Dictionary<movement, int> stat = towerOfHanoi.simulate(n);

                    Assert.IsTrue(stat.Count > 0);

                }
            }
        }
    }
}
